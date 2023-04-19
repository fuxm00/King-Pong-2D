using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioMng : MonoBehaviour
{
    // kdekoli v kódu zadej: "FindObjectOfType<AudioManager>().play("name");"
    // aby se přehrál zvuk s daným jménem

    public Sound[] sounds;
    public Sound[] playlist; //sice je to pole soundů , které mají různé atributy, ale ty jsou tady k ničemu (volume, pitch,...)
    public AudioSource playlistSource;
    private int currentTrackNumber;
    private int nextTrackNumber;

    public static AudioMng Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        playlistSource = gameObject.AddComponent<AudioSource>();
    }

    private void Start()
    {
        startPlaylist();
    }

    public void Update()
    {
        continuePlaylist();

        if (Input.GetKeyDown(KeyCode.P))
        {
            playNextSong();
            //Debug.Log("next song");
        }
    }
    public void play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.source.Play();
    }

    public void startPlaylist()
    {
        currentTrackNumber = UnityEngine.Random.Range(0, playlist.Length);

        playlistSource.clip = playlist[currentTrackNumber].clip;
        playlistSource.Play();
    }

    public void continuePlaylist()
    {
        if (!playlistSource.isPlaying)
        {
            skipSong();
        }
    }

    public void playNextSong()
    {
        if (!playlistSource.isPlaying)
        {
            return;
        }

        playlistSource.Stop();

        skipSong();
    }
    public void skipSong()
    {
        nextTrackNumber = UnityEngine.Random.Range(0, playlist.Length);

        while (currentTrackNumber == nextTrackNumber)
        {
            nextTrackNumber = UnityEngine.Random.Range(0, playlist.Length);
        }

        playlistSource.clip = playlist[nextTrackNumber].clip;
        currentTrackNumber = nextTrackNumber;
        playlistSource.Play();
    }
}
