using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoppraGames
{
    public class SoundController : MonoBehaviour
    {
        public static SoundController instance;

        /* object refs */
        public GameObject AudioListenerObject;
        public AudioClip[] sounds;

        public AudioSource[] audioSourceSlots;

        /* private vars */

        private Dictionary<string, AudioClip> _soundsMap;
        private int audioSlotIndex;


        public void Awake()
        {
            instance = this;

            this._soundsMap = new Dictionary<string, AudioClip>();
            for (int index = 0; index < this.sounds.Length; index++)
            {
                this._soundsMap.Add(this.sounds[index].name, this.sounds[index]);
            }

            this.audioSourceSlots = new AudioSource[3];
            for (int index = 0; index < audioSourceSlots.Length; index++)
            {
                AudioSource source = this.AudioListenerObject.AddComponent<AudioSource>();
                audioSourceSlots[index] = source;
            }

            audioSlotIndex = -1;

        }

        private AudioSource _GetAudioSource()
        {
            audioSlotIndex++;
            if (audioSlotIndex >= audioSourceSlots.Length)
                audioSlotIndex = 0;

            return audioSourceSlots[audioSlotIndex];
        }


        public AudioSource PlaySoundEffect(string name, bool loop, float volume)
        {
            if (string.IsNullOrEmpty(name))
                return null;

            return this.PlaySound(this.GetSoundByName(name), loop, volume);
        }


        public AudioSource PlaySound(AudioClip clip, bool loop, float volume)
        {
            if (clip == null)
                return null;

            AudioSource source = _GetAudioSource();
            source.Stop();
            source.clip = clip;
            source.loop = loop;
            source.volume = volume;
            source.Play();

            return source;
        }

        public void StopSound(AudioSource source)
        {
            source.Stop();
        }

        public void StopAllSounds()
        {
            foreach (AudioSource source in this.AudioListenerObject.GetComponents<AudioSource>())
            {
                if (source.clip != null && source.isPlaying)
                    source.Stop();
            }

        }

        public AudioSource GetAudioSource(string name)
        {
            AudioClip clip = this.GetSoundByName(name);
            foreach (AudioSource source in this.AudioListenerObject.GetComponents<AudioSource>())
            {
                if (source.clip == clip)
                    return source;
            }
            return null;
        }


        public AudioClip GetSoundByName(string name)
        {
            if (!string.IsNullOrEmpty(name) && _soundsMap.ContainsKey(name))
                return this._soundsMap[name];

            return null;
        }
    }
}