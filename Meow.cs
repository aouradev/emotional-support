using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace EmotionalSupport
{
    public class Meow : MonoBehaviour
    {
        public static AssetBundle bundle2;

        public AudioClip one;
        public AudioClip two;
        public AudioClip three;
        public AudioClip four;

        public int catSound;

        public AudioSource thisAS;

        void Start()
        {
            thisAS = GetComponent<AudioSource>();

            Stream stream2 = Assembly.GetExecutingAssembly().GetManifestResourceStream("EmotionalSupport.Resources.cataudio");
            bundle2 = AssetBundle.LoadFromStream(stream2);

            if (stream2 == null)
            {
                Debug.LogError("STREAM 2 IS NULL. NOT LOADING ASSETS");
            }
            stream2.Close();

            one = bundle2.LoadAsset<AudioClip>("1");
            two = bundle2.LoadAsset<AudioClip>("2");
            three = bundle2.LoadAsset<AudioClip>("3");
            four = bundle2.LoadAsset<AudioClip>("4");
        }

        void OnTriggerEnter(Collider other)
        {
            catSound = UnityEngine.Random.Range(1, 4);

            if (catSound == 1)
            {
                thisAS.clip = one;
                thisAS.Play();
            }
            else if (catSound == 2)
            {
                thisAS.clip = two;
                thisAS.Play();
            }
            else if (catSound == 3)
            {
                thisAS.clip = three;
                thisAS.Play();
            }
            else if (catSound == 4)
            {
                thisAS.clip = four;
                thisAS.Play();
            }
        }
    }
}
