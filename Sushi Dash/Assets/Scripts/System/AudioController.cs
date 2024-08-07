using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Notifications.iOS;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [Header("Music Components")]
    [SerializeField] private List<AudioClip> backgroundMusic;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private float musicVolume;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip musicClip;

    [Header("Sound FX Components")]
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private float sfxVolume;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip sfxClip;


    // Start is called before the first frame update
    void Start()
    {
        musicVolume = 1;
        sfxVolume = 1;

        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void setMusicVolume(){
        musicVolume = musicSlider.value;
        musicSource.volume = musicVolume;
    }

    public void setSfxVolume(){
        sfxVolume = sfxSlider.value;
        sfxSource.volume = sfxVolume;
    }
}
