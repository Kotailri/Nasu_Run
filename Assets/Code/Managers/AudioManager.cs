using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 0.7f;

    [Range(0f, 1f)]
    public float pitch = 1f;

    [Header("Variance")]
    [Range(0f, 0.5f)]
    public float randomVolume = 0.1f;

    [Range(0f, 0.5f)]
    public float randomPitch = 0.1f;

    public bool loops = false;

    private List<AudioSource> sources = new List<AudioSource>();

    public void SetSource(AudioSource _source)
    {
        AudioSource source = _source;
        source.clip = clip;
        source.loop = loops;
        sources.Add(source);
    }

    public void ChangeVolume(float vol)
    {
        foreach (AudioSource source in sources)
        {
            if (source != null)
                source.volume = vol * volume;
        }
        
    }

    public int GetIndex()
    {
        return sources.Count;
    }

    public bool IsSourceAvailable()
    {
        foreach (AudioSource source in sources)
        {
            if (!source.isPlaying)
            {
                return true;
            }
        }
        return false;
    }

    public void Play()
    {
        foreach (AudioSource source in sources)
        {
            if (!source.isPlaying)
            {
                source.volume = Config.soundVolume * volume * (1 + Random.Range(-randomVolume / 2f, randomVolume / 2f));
                source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
                source.Play();
                return;
            }
        }
        
    }

    public void Stop()
    {
        foreach (AudioSource source in sources)
        {
            source.Stop();
        }
    }
}

public class AudioManager : MonoBehaviour
{
    private void Awake()
    {
        if (Managers.audioManager == null)
        {
            Managers.audioManager = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [SerializeField]
    List<Sound> sounds = new List<Sound>();

    private void Start()
    {
        for (int i = 0; i < sounds.Count; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
            _go.transform.SetParent(this.gameObject.transform);
        }
        PlaySound("bgm");
    }

    public void StopAllSounds()
    {
        for (int i = 0; i < sounds.Count; i++)
        {
            sounds[i].Stop();
        }
    }

    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Count; i++)
        {
            if (sounds[i].name == _name)
            {

                if (sounds[i].IsSourceAvailable())
                {
                    sounds[i].Play();
                }
                else
                {
                    GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].GetIndex() + "_" + sounds[i].name);
                    sounds[i].SetSource(_go.AddComponent<AudioSource>());
                    _go.transform.SetParent(this.gameObject.transform);
                    sounds[i].Play();
                }
                
                return;
            }
        }
        Debug.LogWarning(_name + " not found in Audio Manager");
    }
}
