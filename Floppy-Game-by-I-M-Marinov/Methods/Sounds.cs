using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Floppy_Game_by_I_M_Marinov.Methods
{
    public class Sounds
    {

        private  WaveOutEvent _backgroundMusicPlayer;
        private  SoundPlayer _effectsSoundPlayer;
        private const string basePath = @"C:\Users\Marinov\source\repos\Floppy-Game-by-I-M-Marinov\Floppy-Game-by-I-M-Marinov\Sounds";


        public Sounds()
        {
            _backgroundMusicPlayer = new WaveOutEvent();
            _effectsSoundPlayer = new SoundPlayer();
        }


        public void InitializeBackgroundMusic()
        {
            
            string path = System.IO.Path.Combine(basePath, "backgroundMusic.wav"); 
            if (File.Exists(path))
            {
                var audioFileReader = new AudioFileReader(path);
                _backgroundMusicPlayer.Init(audioFileReader);
                _backgroundMusicPlayer.Play();
                _backgroundMusicPlayer.PlaybackStopped += (s, e) =>
                {
                    audioFileReader.Position = 0; // Reset position to loop
                    _backgroundMusicPlayer.Play(); // Restart playback
                };
            }
        }
        public void PlayUpAndDownSounds()
        {
            string path = System.IO.Path.Combine(basePath, "upAndDown.wav");

            if (File.Exists(path))
            {
                _effectsSoundPlayer = new SoundPlayer(path);
                _effectsSoundPlayer.Play();
            }
        }
        public void HitAnObstacleSound()
        {
            string path = System.IO.Path.Combine(basePath, "hitObstacle.wav");
            if (File.Exists(path))
            {
                _effectsSoundPlayer = new SoundPlayer(path);
                _effectsSoundPlayer.Play();
            }
        }

        public void ButtonClickSound()
        {
            string path = System.IO.Path.Combine(basePath, "buttonClick.wav");

            if (File.Exists(path))
            {
                _effectsSoundPlayer = new SoundPlayer(path);
                _effectsSoundPlayer.Play();
            }
        }

        public void UpOneLevelSound()
        {
            string path = System.IO.Path.Combine(basePath, "levelChange.wav");

            if (File.Exists(path))
            {
                _effectsSoundPlayer = new SoundPlayer(path);
                _effectsSoundPlayer.Play();
            }
        }
    }
}
