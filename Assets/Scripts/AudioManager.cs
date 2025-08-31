using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)] public float volume = 1f;
    }

    public List<Sound> sounds = new List<Sound>();

    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Play(string soundName)
    {
        Sound s = sounds.Find(x => x.name == soundName);
        if (s != null && audioSource != null)
        {
            audioSource.PlayOneShot(s.clip, s.volume);
        }
        else
        {
            Debug.LogWarning("Sound not found: " + soundName);
        }
    }
}
