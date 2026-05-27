using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;

using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace WpfApp1.Services;

public class AudioPlayer
{
    public void welcomeAudio()
    {
        try
        {
            SoundPlayer sound = new SoundPlayer("Assets/Greeting.wav");
            sound.Play();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    
    }
}