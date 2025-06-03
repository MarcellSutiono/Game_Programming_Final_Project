using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSound : MonoBehaviour
{
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource sfx;

    //MUSIC
    [SerializeField] private AudioClip background;

    //SFX
    public AudioClip jump;
    public AudioClip jumpMelon;
    public AudioClip throwCap;
    public AudioClip gemCollect;
    public AudioClip theSun;
    public AudioClip beam;

    private void Start()
    {
        music.clip = background;
        music.volume = 1.5f;
        music.loop = true;
        music.Play();
    }

    public void PlaySFX(AudioClip sound)
    {
        sfx.PlayOneShot(sound);
    }
}
