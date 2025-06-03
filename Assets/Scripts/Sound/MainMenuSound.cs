using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSound : MonoBehaviour
{
    [SerializeField] private AudioSource music;
    [SerializeField] AudioClip background;

    private void Start()
    {
        music.clip = background;
        music.loop = true;
        music.Play();
    }
}
