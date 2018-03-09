using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Un4seen.Bass;
using System.IO;
using myPlayer.Properties;


namespace myPlayer
{
    public partial class Form1 : Form
    {
        public  Form1()
        {
            InitializeComponent(); 
            BassNet.Registration("rus100@yandex.ru","2X37836163438"); 
        }
        List<string> fplaylist=new List<string>();
        List<int> porjadokplay = new List<int>();
        double time;
        int i=0;
        double timetrek;
        int nomertreka = -1;
        int k = 0;
        string prodoljit="";
        string filename = " ";
        string trek = " ";
        bool automode = true;
        double pauseposition = 0;
        int position = 0;
        bool pause = false;
        bool porjadok = false;
        private ContextMenu m = new ContextMenu();
                //играть
        private  void button1_Click(object sender, EventArgs e)
        {

            autoplay();
                 }
        
        //стоп
        private void button2_Click(object sender, EventArgs e)
        { Bass.BASS_ChannelStop(Player.stream);
          timer1.Stop(); 
          time = 0;
        }
        //пауза
        private void button3_Click(object sender, EventArgs e)
        {
            Bass.BASS_ChannelPause(Player.stream);
            pauseposition = time;
            timer1.Stop();
            pause = true;
        }
        //предыдущая композиция
        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10000000; i++) { }
            Bass.BASS_ChannelStop(Player.stream);
            Bass.BASS_Free();
            if (fplaylist.Count > 0) {  
            if (nomertreka > 0) {
            nomertreka--;    
            Single level = 1;
            level = trackBar2.Value;
            Bass.BASS_SetVolume(level / 100);
            Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_SPEAKERS, IntPtr.Zero);
            time = 0;
            k= porjadokplay[nomertreka];
            i = k;
            listBox1.SetSelected(k, true);
            Player.stream = Bass.BASS_StreamCreateFile(fplaylist[k], 0, 0, BASSFlag.BASS_MUSIC_AUTOFREE);
            timetrek = Bass.BASS_ChannelBytes2Seconds(Player.stream, Bass.BASS_ChannelGetLength(Player.stream));
            trackBar1.Maximum = (int)timetrek;
            trackBar1.Minimum = 0;
            trackBar1.TickFrequency = 1;
            vremya(timetrek);
            label3.Text = "Продолжительность трека" + " " + prodoljit;
            Bass.BASS_ChannelPlay(Player.stream, false);
            label2.Text = listBox1.Items[k].ToString(); 
            }
            }
        }
        //следующая композиция
        private void button5_Click(object sender, EventArgs e)
        {
             for (int i = 0; i < 10000000; i++) { }
             if ((fplaylist.Count > 0)&&(porjadokplay.Count>0)) { 
            Bass.BASS_ChannelStop(Player.stream);
            Bass.BASS_Free();
            Single level = 1;
            level = trackBar2.Value;
            Bass.BASS_SetVolume(level / 100);
            Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_SPEAKERS, IntPtr.Zero);
            time = 0;
            if ((nomertreka == porjadokplay.Count - 1))
            {

                if (porjadok)
                {
                    if (i == fplaylist.Count - 1)
                    {
                        i = 0;
                    }
                    else { i++; }

                }
                else {
                Random r = new Random();
                i = r.Next(fplaylist.Count);
                }  
                
                porjadokplay.Add(i);
                nomertreka = nomertreka + 1;
                listBox1.SetSelected(i, true);
                Player.stream = Bass.BASS_StreamCreateFile(fplaylist[i], 0, 0, BASSFlag.BASS_MUSIC_AUTOFREE);
                timetrek = Bass.BASS_ChannelBytes2Seconds(Player.stream, Bass.BASS_ChannelGetLength(Player.stream));
                trackBar1.Maximum = (int)timetrek;
                trackBar1.Minimum = 0;
                trackBar1.TickFrequency = 1;
                vremya(timetrek);
                label3.Text = "Продолжительность трека" + " " + prodoljit;
                Bass.BASS_ChannelPlay(Player.stream, false);
                label2.Text = listBox1.Items[i].ToString();
            }
            else {
                if ((nomertreka < porjadokplay.Count - 1))
            {
           k = porjadokplay[nomertreka];
                nomertreka = nomertreka + 1; 
                k = porjadokplay[nomertreka]; 
                i = k;
              listBox1.SetSelected(k, true);
             Player.stream = Bass.BASS_StreamCreateFile(fplaylist[k], 0, 0, BASSFlag.BASS_MUSIC_AUTOFREE);
             timetrek = Bass.BASS_ChannelBytes2Seconds(Player.stream, Bass.BASS_ChannelGetLength(Player.stream));
             trackBar1.Maximum = (int)timetrek;
             trackBar1.Minimum = 0;
             trackBar1.TickFrequency = 1;
             vremya(timetrek);
             label3.Text = "Продолжительность трека" + " " + prodoljit;
            Bass.BASS_ChannelPlay(Player.stream, false);
            label2.Text = listBox1.Items[k].ToString();
              }
            } 
            }
        }
        //регулятор громкости
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Single level = 0;
            level = trackBar2.Value;
            Bass.BASS_SetVolume(level / 100);
        }
        //вызов диалога загрузки файла
        private void addFileToolStripMenuItem_Click(object sender, EventArgs e)
        {         openFileDialog1.Filter = "Файл музыки|*.mp3;*.mp2;*.mp1;*.aiff;*.ogg;*.wav";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
             filename = openFileDialog1.FileName;
            trek = openFileDialog1.SafeFileName;
           fplaylist.Add(filename);
           listBox1.Items.Add(trek); }
        }
        //вызов диалога загрузки папки
        private void addFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {  if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) { 
                string imyapapki=folderBrowserDialog1.SelectedPath;
            string[] fpath = Directory.GetFiles(imyapapki);
            for (int i = 0; i <fpath.Length ; i++) {
                filename = fpath[i];
                 string s4 = Path.GetExtension(filename);
                   if ((s4 == ".mp3")|| (s4 == ".mp2") || (s4 == ".mp1") || (s4 == ".aiff") || (s4 == ".ogg") || (s4 == ".wav")) {
                    trek = Path.GetFileName(filename);
            fplaylist.Add(filename);
            listBox1.Items.Add(trek);
                   }
            }}
        }
            
        //очистка плейлиста
        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fplaylist.Clear();
            listBox1.Items.Clear();
            porjadokplay.Clear();
        }
        //удаление выделенного трека из плейлиста
        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;
                fplaylist.Remove(fplaylist[i]);
                listBox1.Items.RemoveAt(i);
        }
        //перевод в автоматический режим
        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            automode = true;
            porjadok = false;
            label4.Text = "Автоматический режим";
        }
        //перевод в ручной режим
        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            automode = false;
            porjadok = false;
            label4.Text = "Ручной режим";
        }
        //системный таймер
        private void timer1_Tick(object sender, EventArgs e)
        {    
            time++;
            vremya(time);
            if (time < timetrek) { 
             trackBar1.Value =Convert.ToInt32(time); 
                label5.Text =vremya(time);
            }
           if ((time>=timetrek)&&((automode)||(porjadok))){
               autoplay(); //вызов принудительного нажатия кнопки по завершению композиции.
               if ((!automode)&&(!porjadok)) {timer1.Stop();}
           }
        }
        //о программе
        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор программы Ахметов Р.Р.Программа создана с помощью библиотеки BASS.NET");
        }
       // перевод времени в другую форму
        string vremya(double timetrek) {
            string minut = ((int)timetrek / 60).ToString();
            string sekund = ((int)timetrek - ((int)timetrek / 60) * 60).ToString();
            if ((Convert.ToInt32(minut) < 10)) {
                minut = "0" + minut;
            }
            if ((Convert.ToInt32(sekund) < 10)) {
                sekund = "0" + sekund;
            }
            prodoljit = minut + ":" + sekund;
            return prodoljit;
        }
        //постановка на проигрывание мелодии двойным кликом.
               private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

                       if ((fplaylist.Count > 0) )
                       {     time = 0; 
                   timer1.Start();
                   timer1.Interval = 1000;
                   Bass.BASS_Free();
                 Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_SPEAKERS, IntPtr.Zero);
                       Single level = 1;
                       level = trackBar2.Value;
                       i = listBox1.SelectedIndex;
                       nomertreka++;
                       porjadokplay.Add(i);
                           Player.stream = Bass.BASS_StreamCreateFile(fplaylist[i], 0, 0, BASSFlag.BASS_DEFAULT);
                           timetrek = Bass.BASS_ChannelBytes2Seconds(Player.stream, Bass.BASS_ChannelGetLength(Player.stream));
                           trackBar1.Maximum = (int)timetrek;
                           trackBar1.Minimum = 0;
                           trackBar1.TickFrequency = 1;
                           vremya(timetrek);
                           label3.Text = "Продолжительность трека" + " " + prodoljit;
                           Bass.BASS_ChannelPlay(Player.stream, false);
                           label2.Text = listBox1.Items[i].ToString();
                       } }
                   
               
        //прокрутка композиции.
               private void trackBar1_Scroll(object sender, EventArgs e)
               {     trackBar1.Maximum = Convert.ToInt32(timetrek);
                   trackBar1.Minimum = 0;
                   trackBar1.TickFrequency = 1;
                   position = trackBar1.Value;
                   Bass.BASS_ChannelSetPosition(Player.stream, (double)position);
                   time = position;
               }
        //кнопки с картинками.
               private void Form1_Load(object sender, EventArgs e)
               {
                   button1.BackgroundImage = myPlayer.Properties.Resources.player_play;
                   button2.BackgroundImage = myPlayer.Properties.Resources.player_stop;
                   button3.BackgroundImage = myPlayer.Properties.Resources.player_pause;
                   button4.BackgroundImage = myPlayer.Properties.Resources.player_rew;
                   button5.BackgroundImage = myPlayer.Properties.Resources.player_fwd;
                   notifyIcon1.Icon = myPlayer.Properties.Resources.kbemusedsrv_8121;
                   m.MenuItems.Add(0, new MenuItem("Show", new System.EventHandler(Show_Click)));
                   m.MenuItems.Add(0, new MenuItem("Stop music", new System.EventHandler(Stop_Click)));
                   
               }
        //вызов эквалайзер.
               private void ekvalyzerToolStripMenuItem_Click(object sender, EventArgs e)
               {
                   Form2 f = new Form2();
                   f.Show();
               }
        //перенос папки и файлов в плейлист.
                private void listBox1_DragDrop(object sender, DragEventArgs e)
               {
                   string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                   for (int i = 0; i < s.Length; i++)
                   {
                       filename = s[i];
                       string s4 = Path.GetExtension(filename);
                       if ((s4.Length > 0))
                       {
                           if ((s4 == ".mp3")|| (s4 == ".mp2") || (s4 == ".mp1") || (s4 == ".aiff") || (s4 == ".ogg") || (s4 == ".wav")) {
                               string s3 = Path.GetFileName(filename);
                            trek = s3;
                           fplaylist.Add(filename);
                          listBox1.Items.Add(trek); }
                       }
                       else { 
                           download();
                       }  } }
               private void listBox1_DragEnter(object sender, DragEventArgs e)
               {
                   if (e.Data.GetDataPresent(DataFormats.FileDrop))
                   { e.Effect = DragDropEffects.All; }
                   else
                   { e.Effect = DragDropEffects.None; }
               }
        // рекурсивная загрузка файлов в плейлист.
               private void download() {
                     string[] s2 = Directory.GetDirectories(filename);//массив путей для папок
                     string[] s1 = Directory.GetFiles(filename);//массив путей для файлов на том же уровне
                     
                   //открытие папок
                   for (int i = 0; i < s2.Length; i++)
                   {
                       filename = s2[i];
                             download();//рекурсивный вызов
                   }
                   //открытие файлов на том же уровне, что и папка. 
                   for (int j1 = 0; j1 < s1.Length; j1++)
                   {
                       filename = s1[j1];
                       string s4 = Path.GetExtension(filename);
                       if ((s4 == ".mp3") || (s4 == ".mp2") || (s4 == ".mp1") || (s4 == ".aiff") || (s4 == ".ogg") || (s4 == ".wav")) {
                           trek = Path.GetFileName(s1[j1]);
                       fplaylist.Add(filename);
                       listBox1.Items.Add(trek); }
                                                     } 
               }
                //сохранение плейлиста
               private void savePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
               {
                   string[] saveplaylist=new string[fplaylist.Count];
                   for (int i = 0; i < fplaylist.Count; i++) {
                       saveplaylist[i] = fplaylist[i];
                   }   
                   saveFileDialog1.Filter = "Файл плейлиста(*.mypl)|*.mypl";
                   if(saveFileDialog1.ShowDialog()==System.Windows.Forms.DialogResult.OK){
                       
                       string savepl = saveFileDialog1.FileName;
                   File.WriteAllLines(savepl, saveplaylist);
                   }
               }
               //открытие плейлиста
               private void openPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
               {
                   fplaylist.Clear();
                   listBox1.Items.Clear();
                    openFileDialog2.Filter = "Файл плейлиста(*.mypl)|*.mypl";
                   if (openFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                       string[] openplaylist= File.ReadAllLines(openFileDialog2.FileName);
                    for (int i = 0; i < openplaylist.Length; i++) { 
                    if (File.Exists(openplaylist[i])){
                        fplaylist.Add(openplaylist[i]);
                        trek = Path.GetFileName(openplaylist[i]);
                        listBox1.Items.Add(trek);
                    } }  }  }

               private void normalToolStripMenuItem_Click(object sender, EventArgs e)
               {
                   porjadok = true;
                   automode = false;
                   label4.Text = "Нормальный режим";
               }
             
               private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
               {
                   Show();
                  WindowState = FormWindowState.Normal;
               
               
               }

           private void Form1_Resize(object sender, EventArgs e)
               {
                   if (WindowState == FormWindowState.Minimized)
                   {Hide(); }
                  
               }
        

           private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
           {
               if (e.Button == MouseButtons.Right) {

                   notifyIcon1.ContextMenu = m;  
               }
           }
             protected void Show_Click(Object sender, System.EventArgs e)
           {
               Show();
               WindowState = FormWindowState.Normal;
           }
           private void Stop_Click(Object sender, System.EventArgs e) {
               if(time>0){ 
                   Bass.BASS_ChannelStop(Player.stream);
               timer1.Stop();
               time = 0;
               }
           }
           void autoplay()
           {
               if (pause) //если пауза
               {
                   pause = false;
                   Bass.BASS_Free();
                   listBox1.SelectedItem = listBox1.Items[i];
                   Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_SPEAKERS, IntPtr.Zero);
                   Bass.BASS_Start();
                   Single level = 1;
                   level = trackBar2.Value;
                   Bass.BASS_SetVolume(level / 100);
                   Player.stream = Bass.BASS_StreamCreateFile(fplaylist[i], 0, 0, BASSFlag.BASS_DEFAULT);
                   Bass.BASS_ChannelPlay(Player.stream, false);
                   Bass.BASS_ChannelSetPosition(Player.stream, pauseposition);
                   time = pauseposition;
                   timer1.Start();
               }   //если нет
               else
               {
                   if (fplaylist.Count > 0)// мелодии есть нет
                   {
                       if (automode) //автоматический режим
                       {
                           Bass.BASS_Free();
                           Random r = new Random();
                           i = r.Next(fplaylist.Count);
                           listBox1.SelectedItem = listBox1.Items[i];
                           nomertreka++;
                           porjadokplay.Add(i);
                           time = 0;
                           timer1.Enabled = true;
                           timer1.Start();
                           timer1.Interval = 1000;
                           Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_SPEAKERS, IntPtr.Zero);
                           Single level = 1;
                           level = trackBar2.Value;
                           Bass.BASS_SetVolume(level / 100);
                           Player.stream = Bass.BASS_StreamCreateFile(fplaylist[i], 0, 0, BASSFlag.BASS_DEFAULT);
                           timetrek = Bass.BASS_ChannelBytes2Seconds(Player.stream, Bass.BASS_ChannelGetLength(Player.stream));
                           trackBar1.Maximum = (int)timetrek;
                           trackBar1.Minimum = 0;
                           trackBar1.TickFrequency = 1;
                           vremya(timetrek);
                           label3.Text = "Продолжительность трека" + " " + prodoljit;
                           Bass.BASS_ChannelPlay(Player.stream, false);
                           label2.Text = listBox1.Items[i].ToString();
                       }
                       else //ручной
                       {
                           if (porjadok)
                           {
                               if (i == fplaylist.Count - 1)
                               {
                                   i = 0;
                               }
                               else { i++; }
                               Bass.BASS_Free();
                               listBox1.SelectedItem = listBox1.Items[i];
                               nomertreka++;
                               porjadokplay.Add(i);
                               time = 0;
                               timer1.Enabled = true;
                               timer1.Start();
                               timer1.Interval = 1000;
                               Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_SPEAKERS, IntPtr.Zero);
                               Single level = 1;
                               level = trackBar2.Value;
                               Bass.BASS_SetVolume(level / 100);
                               Player.stream = Bass.BASS_StreamCreateFile(fplaylist[i], 0, 0, BASSFlag.BASS_DEFAULT);
                               timetrek = Bass.BASS_ChannelBytes2Seconds(Player.stream, Bass.BASS_ChannelGetLength(Player.stream));
                               trackBar1.Maximum = (int)timetrek;
                               trackBar1.Minimum = 0;
                               trackBar1.TickFrequency = 1;
                               vremya(timetrek);
                               label3.Text = "Продолжительность трека" + " " + prodoljit;
                               Bass.BASS_ChannelPlay(Player.stream, false);
                               label2.Text = listBox1.Items[i].ToString();
                           }
                           if ((!automode) && (!porjadok))
                           {
                               time = 0;
                               timer1.Start();
                               Bass.BASS_Free();
                               Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_SPEAKERS, IntPtr.Zero);
                               Single level = 1;
                               level = trackBar2.Value;
                               Bass.BASS_SetVolume(level / 100);
                               i = listBox1.SelectedIndex;
                               nomertreka++;
                               porjadokplay.Add(i);
                               if ((fplaylist.Count > 0) && (i >= 0))
                               {
                                   Player.stream = Bass.BASS_StreamCreateFile(fplaylist[i], 0, 0, BASSFlag.BASS_DEFAULT);
                                   timetrek = Bass.BASS_ChannelBytes2Seconds(Player.stream, Bass.BASS_ChannelGetLength(Player.stream));
                                   trackBar1.Maximum = (int)timetrek;
                                   trackBar1.Minimum = 0;
                                   trackBar1.TickFrequency = 1;
                                   vremya(timetrek);
                                   label3.Text = "Продолжительность трека" + " " + prodoljit;
                                   Bass.BASS_ChannelPlay(Player.stream, false);
                                   label2.Text = listBox1.Items[i].ToString();
                               }
                           }
                       }
                   }
               }
           }
    }
     abstract class Player {
        static public int stream;
       static public int[] p = new int[10];
       static public BASS_DX8_PARAMEQ ek = new BASS_DX8_PARAMEQ();
    } }
