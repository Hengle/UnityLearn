using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WFramework
{
    public class AudioManager : MonoSingleTon<AudioManager>
    {
        private AudioListener _mAudioListener;

        void CheckAudioListener()
        {
            if (!_mAudioListener)
            {
                _mAudioListener = FindObjectOfType<AudioListener>();
            }

            if (!_mAudioListener)
            {
                _mAudioListener = gameObject.AddComponent<AudioListener>();
            }
        }

        public void PlaySound(string soundName)
        {
            CheckAudioListener();
            var coinClip = Resources.Load<AudioClip>(soundName);
            var audioSource = gameObject.AddComponent<AudioSource>();

            audioSource.clip = coinClip;
            audioSource.Play();
        }
        
        private AudioSource _mMusicSource;

        public void PlayMusic(string musicName, bool loop)
        {
            CheckAudioListener();
            if (!_mMusicSource)
            {
                _mMusicSource = gameObject.AddComponent<AudioSource>();
            }

            var coinClip = Resources.Load<AudioClip>(musicName);
            
            _mMusicSource.clip = coinClip;
            _mMusicSource.loop = loop;
            _mMusicSource.Play();
        }

        public void StopMusic()
        {
            _mMusicSource.Stop();
        }

        public void PauseMusic()
        {
            _mMusicSource.Pause();
        }

        public void ResumeMusic()
        {
            _mMusicSource.UnPause();
        }

        public void MusicOff()
        {
            _mMusicSource.Pause();
            _mMusicSource.mute = true;
        }

        public void MusicOn()
        {
            _mMusicSource.UnPause();
            _mMusicSource.mute = false;
        }

        public void SoundOff()
        {
            var soundSources = GetComponents<AudioSource>();
            foreach (var soundSource in soundSources)
            {
                if (soundSource != null)
                {
                    soundSource.Pause();
                    soundSource.mute = true;
                }
            }
        }

        public void SoundOn()
        {
            var soundSources = GetComponents<AudioSource>();

            foreach (var soundSource in soundSources)
            {
                if (soundSource != _mMusicSource)
                {
                    soundSource.UnPause();
                    soundSource.mute = false;
                }
            }
        }


    }
}