using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    AudioSource music;
    public AudioClip titleMusic;
    public AudioClip bgm;
    void Awake()
    {
        music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayTitle()
    {
        music.clip = titleMusic;
        music.loop = true;
        music.Play();
    }

    public void Playbgm()
    {
        music.clip = bgm;
        music.loop = true;
        music.Play();
    }

    public void StopAudio(){
        music.Stop();
    }
}
