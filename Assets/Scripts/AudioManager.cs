using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource musicAs;
    public AudioSource sfxAs;
    public Slider musicSlider;
    public Slider sfxSlider;
    public float musicVolume;
    public float sfxVolume;

    private void Awake() {
        instance = this;
        LoadVolume();
    }

    public void PlayBGM(AudioClip audio) {
        musicAs.Stop();
        musicAs.clip = audio;
        musicAs.Play();
    }

    public void PlaySFX(AudioClip audio) {
        sfxAs.PlayOneShot(audio);
    }

    public void SaveVolume() {
        if (musicSlider != null)
            musicVolume = musicSlider.value;
        if (sfxSlider != null)
            sfxVolume = sfxSlider.value;
        musicAs.volume = musicVolume;
        sfxAs.volume = sfxVolume;
        PlayerPrefs.SetFloat("Music", musicVolume);
        PlayerPrefs.SetFloat("SFX", sfxVolume);
    }

    public void LoadVolume() {
        musicVolume = PlayerPrefs.GetFloat("Music", 0.2f);
        sfxVolume = PlayerPrefs.GetFloat("SFX", 0.2f);
        musicAs.volume = musicVolume;
        sfxAs.volume = sfxVolume;
        if (musicSlider != null)
            musicSlider.value = musicVolume;
        if (sfxSlider != null)
            sfxSlider.value = sfxVolume;
    }
}
