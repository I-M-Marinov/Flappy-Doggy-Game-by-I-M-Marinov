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

        private WaveOutEvent _backgroundMusicPlayer = new();
        private SoundPlayer _effectsSoundPlayer = new();


        public void InitializeBackgroundMusic()
        {
            string path = Application.StartupPath + @"\backgroundMusic.wav";
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
            var path = Application.StartupPath + @"\upAndDown.wav";
            if (File.Exists(path))
            {
                _effectsSoundPlayer = new SoundPlayer(path);
                _effectsSoundPlayer.Play();
            }
        }
        public void HitAnObstacleSound()
        {
            var path = Application.StartupPath + @"\hitObstacle.wav";
            if (File.Exists(path))
            {
                _effectsSoundPlayer = new SoundPlayer(path);
                _effectsSoundPlayer.Play();
            }
        }

        public void ButtonClickSound()
        {
            var path = Application.StartupPath + @"\buttonClick.wav";
            if (File.Exists(path))
            {
                _effectsSoundPlayer = new SoundPlayer(path);
                _effectsSoundPlayer.Play();
            }
        }

        public void UpOneLevelSound()
        {
            var path = Application.StartupPath + @"\levelChange.wav";
            if (File.Exists(path))
            {
                _effectsSoundPlayer = new SoundPlayer(path);
                _effectsSoundPlayer.Play();
            }
        }
    }
}
