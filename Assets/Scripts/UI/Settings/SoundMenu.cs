using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using Unity.Mathematics;
using System;

public class SoundMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider soundEffectsSlider;
    public TMP_InputField volumeInputField;
    public TMP_InputField soundEffectsInputField;
    public AudioMixer audioMixer;
    public string audioMixerGroupSounds = "Sounds";
    public string audioMixerGroupMusic = "Music";
    private float musicVolume = 100f;
    private float soundEffectsVolume = 100f;

    private void Start()
    {
        if (audioMixer == null)
        {
            Debug.LogError("AudioMixer is not assigned.");
            return;
        }
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        }
        else
        {
            PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        }
        volumeSlider.value = musicVolume;
        audioMixer.SetFloat(audioMixerGroupMusic, Mathf.Log10(musicVolume / 100f) * 20f);
        volumeInputField.text = musicVolume.ToString();

        if (PlayerPrefs.HasKey("SoundEffectsVolume"))
        {
            soundEffectsVolume = PlayerPrefs.GetFloat("SoundEffectsVolume");
        }
        else
        {
            PlayerPrefs.SetFloat("SoundEffectsVolume", soundEffectsVolume);
        }
        soundEffectsSlider.value = soundEffectsVolume;
        soundEffectsInputField.text = soundEffectsVolume.ToString();
        audioMixer.SetFloat(audioMixerGroupSounds, Mathf.Log10(soundEffectsVolume / 100f) * 20f);
    }

    public void SetMusicVolume()
    {
        musicVolume = volumeSlider.value;
        audioMixer.SetFloat(audioMixerGroupMusic, Mathf.Log10(musicVolume / 100f) * 20f);
        volumeInputField.text = musicVolume.ToString();
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }

    public void SetMusicVolumeInputField()
    {
        float volume = float.Parse(volumeInputField.text);

        if (volume < 0.0001f) volume = 0.0001f;
        if (volume > 100f) volume = 100f;

        musicVolume = volume;
        audioMixer.SetFloat(audioMixerGroupMusic, Mathf.Log10(musicVolume / 100f) * 20f);
        volumeSlider.value = musicVolume;
        volumeInputField.text = musicVolume.ToString();
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }

    public void SetSoundEffectsVolume()
    {
        soundEffectsVolume = soundEffectsSlider.value;
        soundEffectsInputField.text = soundEffectsVolume.ToString();
        audioMixer.SetFloat(audioMixerGroupSounds, Mathf.Log10(soundEffectsVolume / 100f) * 20f);
        PlayerPrefs.SetFloat("SoundEffectsVolume", soundEffectsVolume);
    }

    public void SetSoundEffectsVolumeInputField()
    {
        float volume = float.Parse(soundEffectsInputField.text);

        if (volume < 0.0001f) volume = 0.0001f;
        if (volume > 100f) volume = 100f;

        soundEffectsVolume = volume;
        soundEffectsInputField.text = volume.ToString();
        soundEffectsSlider.value = soundEffectsVolume;
        audioMixer.SetFloat(audioMixerGroupSounds, Mathf.Log10(soundEffectsVolume / 100f) * 20f);
        PlayerPrefs.SetFloat("SoundEffectsVolume", soundEffectsVolume);
    }
}
