using UnityEngine;
using System;

namespace Seance.SoundManagement
{
    /// <summary>
    /// Edouard
    /// Singleton & DontDestroyOnLoad
    /// </summary>
    public class AudioManager : Singleton<AudioManager>
    {
        public Mixer[] mixers; // Mixers list, fill in Unity Inspector
        public Sound[] sounds; // Sounds list, fill in Unity Inspector

        public bool debug;


        #region Unity events

        void Awake()
        {
            CreateSingleton(true);

            CreateAudioBank();
        }

        #endregion

        #region Public methods

        public void PlayAudio(string _name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == _name);
            
            if(s == null)
            {
                LogWarning("AudioManager : Sound '" + _name + "' is unknown. Check name spelling");
            }
            else
            {
                s.source.Play();
                Log("Playing audio: " + _name);
            }
        }

        public void StopAudio(string _name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == _name);

            if (s == null)
            {
                LogWarning("AudioManager : Sound '" + _name + "' is unknown. Check name spelling");
            }
            else
            {
                s.source.Stop();
                Log("Stopping audio: " + _name);
            }
        }

        public void StopAllAudio()
        {
            Log("Stopping all audios");
            foreach(Sound s in sounds)
            {
                s.source.Stop();
                Log("Stopped audio: " + s.name);
            }
        }

        public void PauseAudio(string _name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == _name);

            if (s == null)
            {
                LogWarning("AudioManager : Sound '" + _name + "' is unknown. Check name spelling");
            }
            else
            {
                s.source.Stop();
                Log("Pausing audio: " + _name);
            }
        }

        public void UnpauseAudio(string _name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == _name);

            if (s == null)
            {
                LogWarning("AudioManager : Sound '" + _name + "' is unknown. Check name spelling");
            }
            else
            {
                s.source.Stop();
                Log("Unpausing audio: " + _name);
            }
        }

        #endregion

        #region Private methods

        private void CreateAudioBank()
        {
            foreach(Sound s in sounds)
            {
                AudioSource _source = gameObject.AddComponent<AudioSource>();
                _source.clip = s.clip;
                _source.outputAudioMixerGroup = Array.Find(mixers, mixer => mixer.category == s.category).mixerGroup;
                _source.volume = s.volume;
                _source.pitch = s.pitch;
                _source.loop = s.loop;

                s.source = _source;
            }
        }

        #region Debug methods

        private void Log(string _msg)
        {
            if(!debug) return;
            Debug.Log("[AudioManager]: " + _msg);
        }
        
        private void LogWarning(string _msg)
        {
            if (!debug) return;
            Debug.LogWarning("[AudioManager]: " + _msg);
        }

        #endregion

        #endregion
    }
}
