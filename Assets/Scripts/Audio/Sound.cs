using UnityEngine;

namespace Audio
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;

        public float volume = 1;
        public float pitch = 1;
    
        [HideInInspector] public AudioSource source;
    }
}