using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [Header("Music Components")]
    [SerializeField] private Slider musicSlider;
    [SerializeField] private float musicVolume;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip mmMusicClip;
    [SerializeField] private AudioClip gameplayMusicClip;
    [SerializeField] private AudioClip currMusicClip;

    [SerializeField] private float transitionDuration;

    [Header("Sound FX Components")]
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private float sfxVolume;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip sfxClip;


    // Start is called before the first frame update
    void Start()
    {
        musicVolume = musicSource.volume;
        sfxVolume = 1;

        musicSource.clip = mmMusicClip;
        currMusicClip = mmMusicClip;

        transitionMusic(mmMusicClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void multiplyMusicVolume(float multiplier){
        float currMusicVolume = musicSource.volume;
        musicSource.volume = currMusicVolume*multiplier;
    }


    public void setMusicVolume(){
        musicVolume = musicSlider.value;
        musicSource.volume = musicVolume;
    }

    public void setSfxVolume(){
        sfxVolume = sfxSlider.value;
        sfxSource.volume = sfxVolume;
    }

    public void playGameplayMusic(){

        transitionMusic(gameplayMusicClip);
    }

    public void playMainMenuMusic(){
        transitionMusic(mmMusicClip);
    }

    private void transitionMusic(AudioClip newClip){
        musicSource.Stop();

        musicSource.clip = newClip;
        currMusicClip = newClip;

        musicSource.volume = musicVolume;
        musicSource.Play();
    }
}
