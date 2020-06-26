using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletHell.Helper;


namespace BulletHell.Audio
{


    /// <summary>
    /// 
    /// </summary>
    public class SoundController : Singleton<SoundController>
    {
        [SerializeField]
        private AudioObject[] audioObject;

        private void Start()
        {

            for (int i = 0; i < audioObject.Length; i++)
            {
                if (audioObject[i].audioSource == null && audioObject[i].clip != null)
                {
                    GameObject gameObject = new GameObject("Clip_" + i + "_" + audioObject[i].name);
                    gameObject.transform.SetParent(this.transform);
                    audioObject[i].audioSource = gameObject.AddComponent<AudioSource>();
                    audioObject[i].audioSource.clip = audioObject[i].clip;


                }

                if (audioObject[i].playOnAwake)
                {
                    audioObject[i].Play();
                    return;
                }

            }
        }


        public void PlaySound(string name)
        {

            for (int i = 0; i < audioObject.Length; i++)
            {
                if (audioObject[i].name == name)
                {
                    audioObject[i].Play();
                    return;
                }

            }
            Debug.LogWarning("Sound Manager(Play) : Cannot find the clip name in the list !!!");

        }

        public void StopSound(string name)
        {


            for (int i = 0; i < audioObject.Length; i++)
            {
                if (audioObject[i].name == name)
                {
                    audioObject[i].Stop();
                    return;
                }

            }
            Debug.LogWarning("Sound Manager(Stop) : Cannot find the clip name in the list !!!");



        }




    }
}
