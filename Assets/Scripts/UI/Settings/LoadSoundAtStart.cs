using UnityEngine;
using UnityEngine.Audio;

public class LoadSoundAtStart : MonoBehaviour
{
    public string audioMixerGroupSounds = "Sounds";
    public string audioMixerGroupMusic = "Music";
    public AudioMixer audioMixer;

    private void Start()
    {
        if (audioMixer == null)
        {
            Debug.LogError("AudioMixer is not assigned.");
            return;
        }

        float musicVolume = 100f;
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        }
        audioMixer.SetFloat(audioMixerGroupMusic, Mathf.Log10(musicVolume / 100f) * 20f);

        float soundEffectsVolume = 100f;
        if (PlayerPrefs.HasKey("SoundEffectsVolume"))
        {
            soundEffectsVolume = PlayerPrefs.GetFloat("SoundEffectsVolume");
        }
        audioMixer.SetFloat(audioMixerGroupSounds, Mathf.Log10(soundEffectsVolume / 100f) * 20f);
    }
}
