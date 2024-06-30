using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Floppy_Game_by_I_M_Marinov.Methods
{
    public class Sounds
    {

        private static WaveOutEvent _backgroundMusicPlayer;
        private static SoundPlayer _effectsSoundPlayer;

        public Sounds()
        {
            _backgroundMusicPlayer = new WaveOutEvent();
            _effectsSoundPlayer = new SoundPlayer();
        }


        public static void InitializeBackgroundMusic()
        {
            string path = Application.StartupPath + @"\backgroundMusic.wav";
            if (File.Exists(path))
            {
                _backgroundMusicPlayer = new WaveOutEvent();
                var audioFileReader = new AudioFileReader(path);
                _backgroundMusicPlayer.Init(audioFileReader);
                _backgroundMusicPlayer.Play();
                _backgroundMusicPlayer.PlaybackStopped += (s, e) => audioFileReader.Position = 0; // Loop the music
            }
        }

        public static void PlayUpAndDownSounds()
        {
            var path = Application.StartupPath + @"\upAndDown.wav";
            if (File.Exists(path))
            {
                _effectsSoundPlayer = new SoundPlayer(path);
                _effectsSoundPlayer.Play();
            }
        }

        public static void HitAnObstacleSound()
        {
            var path = Application.StartupPath + @"\hitObstacle.wav";
            if (File.Exists(path))
            {
                _effectsSoundPlayer = new SoundPlayer(path);
                _effectsSoundPlayer.Play();
            }
        }
    }
}
