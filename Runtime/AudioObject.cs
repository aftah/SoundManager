using UnityEngine;
using UnityEngine.Audio;

namespace BulletHell.Audio
{
    public enum TypeOfAudio

    {

        NONE,
        SOUND_TRACK,
        SFX,
        SFX_SHOOT,
        SFX_RELOAD,
        SFX_EXPLOSION,
        SFX_IMPACT

    }

   

    [System.Serializable]
    public class AudioObject
    {
        [Header("Audio Object")]
        public TypeOfAudio TypeOfAudio;
        public AudioSource audioSource;
        public AudioMixerGroup outpup;

        [Header("Audio Clip")]
        public string name;
        public AudioClip clip;

        [Header("Clip Sound Effect")]
        [Range(0,1)]
        public float volume = 1f;

        [Range(0,3)]
        public float pitch = 1f;

        [Range(-1,1)]
        public float stereoPan = 0f;

        public bool loop = false;
        public bool mute = false;
        public bool playOnAwake = false;



        public void Play()
        {

            audioSource.volume = volume;
            audioSource.pitch = pitch;
            audioSource.panStereo = stereoPan;
            audioSource.loop = loop;
            audioSource.mute = mute;
            audioSource.outputAudioMixerGroup = outpup;

            audioSource.Play();

        }

        public void Stop()
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }

        }
    }


}

