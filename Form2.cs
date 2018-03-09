using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Un4seen.Bass;

namespace myPlayer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }
             
        private void button1_Click(object sender, EventArgs e)
        {
            ekvalayzer();
            Player.ek.fGain = trackBar1.Value;
            Player.ek.fBandwidth = 3;
            Player.ek.fCenter = 32;
            Bass.BASS_FXSetParameters(Player.p[0], Player.ek);
            Player.ek.fGain = trackBar2.Value;
            Player.ek.fBandwidth = 3;
            Player.ek.fCenter = 64;
            Bass.BASS_FXSetParameters(Player.p[1], Player.ek);
            Player.ek.fGain = trackBar3.Value;
            Player.ek.fBandwidth = 3;
            Player.ek.fCenter = 128;
            Bass.BASS_FXSetParameters(Player.p[2], Player.ek);
            Player.ek.fGain = trackBar4.Value;
            Player.ek.fBandwidth = 3;
            Player.ek.fCenter = 256;
            Bass.BASS_FXSetParameters(Player.p[3], Player.ek);
            Player.ek.fGain = trackBar5.Value;
            Player.ek.fBandwidth = 3;
            Player.ek.fCenter = 512;
            Bass.BASS_FXSetParameters(Player.p[4], Player.ek);
            Player.ek.fGain = trackBar6.Value;
            Player.ek.fBandwidth = 3;
            Player.ek.fCenter = 1024;
            Bass.BASS_FXSetParameters(Player.p[5], Player.ek);
            Player.ek.fGain = trackBar7.Value;
            Player.ek.fBandwidth = 3;
            Player.ek.fCenter = 2048;
            Bass.BASS_FXSetParameters(Player.p[6], Player.ek);
            Player.ek.fGain = trackBar8.Value;
            Player.ek.fBandwidth = 3;
            Player.ek.fCenter = 4096;
            Bass.BASS_FXSetParameters(Player.p[7], Player.ek);
            Player.ek.fGain = trackBar9.Value;
            Player.ek.fBandwidth = 3;
            Player.ek.fCenter = 8192;
            Bass.BASS_FXSetParameters(Player.p[8], Player.ek);
            Player.ek.fGain = trackBar10.Value;
            Player.ek.fBandwidth = 3;
            Player.ek.fCenter = 16384;
            Bass.BASS_FXSetParameters(Player.p[9], Player.ek);
            this.Hide();
            }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
          
            Bass.BASS_FXGetParameters(Player.p[0], Player.ek);
            Player.ek.fGain = trackBar1.Value;
            Player.ek.fBandwidth = 3;
            Player.ek.fCenter = 32;
            Bass.BASS_FXSetParameters(Player.p[0], Player.ek); 
            //ekvalayzer();
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
         
            Bass.BASS_FXGetParameters(Player.p[1], Player.ek);
            Player.ek.fGain = trackBar2.Value;
            Player.ek.fBandwidth = 3;
            Player.ek.fCenter = 64;
            Bass.BASS_FXSetParameters(Player.p[1], Player.ek); 
            //ekvalayzer();
        }
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
           
            Bass.BASS_FXGetParameters(Player.p[2], Player.ek);
            Player.ek.fGain = trackBar3.Value;
            Player.ek.fBandwidth = 3;
            Player.ek.fCenter = 128;
            Bass.BASS_FXSetParameters(Player.p[2], Player.ek); 
            //ekvalayzer();
        }
        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            
            Bass.BASS_FXGetParameters(Player.p[3], Player.ek);
            Player.ek.fGain = trackBar4.Value;
            Player.ek.fBandwidth = 3;
            Player.ek.fCenter = 256;
            Bass.BASS_FXSetParameters(Player.p[3], Player.ek);
           // ekvalayzer();
        }
        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            
            Bass.BASS_FXGetParameters(Player.p[4], Player.ek);
            Player.ek.fGain = trackBar5.Value;
            Player.ek.fBandwidth = 3;
            Player.ek.fCenter = 512;
            Bass.BASS_FXSetParameters(Player.p[4], Player.ek);  
            //ekvalayzer();
        }
        private void trackBar6_Scroll(object sender, EventArgs e)
        {
          
            Bass.BASS_FXGetParameters(Player.p[5], Player.ek);
            Player.ek.fGain = trackBar6.Value;
            Player.ek.fBandwidth = 3;
            Player.ek.fCenter = 1024;
            Bass.BASS_FXSetParameters(Player.p[5], Player.ek); 
            //ekvalayzer();
        }
         private void trackBar7_Scroll(object sender, EventArgs e)
        {
          
            Bass.BASS_FXGetParameters(Player.p[6], Player.ek);
            Player.ek.fGain = trackBar7.Value;
            Player.ek.fBandwidth = 3;
            Player.ek.fCenter = 2048;
            Bass.BASS_FXSetParameters(Player.p[6], Player.ek);
             //ekvalayzer();
        }
        private void trackBar8_Scroll(object sender, EventArgs e)
         {
              
            Bass.BASS_FXGetParameters(Player.p[7], Player.ek);
            Player.ek.fGain = trackBar8.Value;
            Player.ek.fBandwidth = 3;
            Player.ek.fCenter = 4096;
            Bass.BASS_FXSetParameters(Player.p[7], Player.ek); 
            //ekvalayzer();
        }
        private void trackBar9_Scroll(object sender, EventArgs e)
        {
           
            Bass.BASS_FXGetParameters(Player.p[8], Player.ek);
            Player.ek.fGain = trackBar9.Value;
            Player.ek.fBandwidth = 3;
            Player.ek.fCenter = 8192;
            Bass.BASS_FXSetParameters(Player.p[8], Player.ek);
           // ekvalayzer();
        }
        private void trackBar10_Scroll(object sender, EventArgs e)
        {
         
            Bass.BASS_FXGetParameters(Player.p[9], Player.ek);
            Player.ek.fGain = trackBar10.Value;
            Player.ek.fBandwidth = 3;
            Player.ek.fCenter = 16384;
            Bass.BASS_FXSetParameters(Player.p[9], Player.ek); 
            //ekvalayzer();
        }
        void ekvalayzer() {
            Player.p[0] = Bass.BASS_ChannelSetFX(Player.stream, BASSFXType.BASS_FX_DX8_PARAMEQ, 1);
            Player.p[1] = Bass.BASS_ChannelSetFX(Player.stream, BASSFXType.BASS_FX_DX8_PARAMEQ, 1);
            Player.p[2] = Bass.BASS_ChannelSetFX(Player.stream, BASSFXType.BASS_FX_DX8_PARAMEQ, 1);
            Player.p[3] = Bass.BASS_ChannelSetFX(Player.stream, BASSFXType.BASS_FX_DX8_PARAMEQ, 1);
            Player.p[4] = Bass.BASS_ChannelSetFX(Player.stream, BASSFXType.BASS_FX_DX8_PARAMEQ, 1);
            Player.p[5] = Bass.BASS_ChannelSetFX(Player.stream, BASSFXType.BASS_FX_DX8_PARAMEQ, 1);
            Player.p[6] = Bass.BASS_ChannelSetFX(Player.stream, BASSFXType.BASS_FX_DX8_PARAMEQ, 1);
            Player.p[7] = Bass.BASS_ChannelSetFX(Player.stream, BASSFXType.BASS_FX_DX8_PARAMEQ, 1);
            Player.p[8] = Bass.BASS_ChannelSetFX(Player.stream, BASSFXType.BASS_FX_DX8_PARAMEQ, 1);
            Player.p[9] = Bass.BASS_ChannelSetFX(Player.stream, BASSFXType.BASS_FX_DX8_PARAMEQ, 1);
            
        
        } 
    }
} 
       
