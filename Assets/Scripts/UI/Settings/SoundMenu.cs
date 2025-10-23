using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundMenu : MonoBehaviour
{
    public AudioSource musicSource;
    public Slider volumeSlider;
    public TMP_InputField volumeInputField;
    private float musicVolume = 100f;

    private void Start()
    {
        if (musicSource == null)
        {
            musicSource = GameObject.Find("MusicSource").GetComponent<AudioSource>();
            if (musicSource == null)
            {
                Debug.LogError("MusicSource not found in the scene.");
                return;
            }
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
        musicSource.volume = musicVolume;
        volumeInputField.text = musicVolume.ToString();
    }

    public void SetMusicVolume()
    {
        musicVolume = volumeSlider.value;
        musicSource.volume = musicVolume / 100f;
        volumeInputField.text = musicVolume.ToString();
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }

    public void SetMusicVolumeInputField()
    {
        float volume = float.Parse(volumeInputField.text);

        if (volume < 0f) volume = 0f;
        if (volume > 100f) volume = 100f;

        musicVolume = volume;
        musicSource.volume = musicVolume / 100f;
        volumeSlider.value = musicVolume;
        volumeInputField.text = musicVolume.ToString();
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }
}
