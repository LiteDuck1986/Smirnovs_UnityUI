using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    void Start()
    {
        // Load sliders to saved positions
        musicSlider.value = PlayerPrefs.GetFloat("MusicValue", 0.75f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXValue", 0.75f);
        
        // Add listeners so it changes in real-time
        musicSlider.onValueChanged.AddListener(AudioManager.Instance.SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(AudioManager.Instance.SetSFXVolume);
    }

    public void ApplySettings()
    {
        AudioManager.Instance.SaveSettings(musicSlider.value, sfxSlider.value);
        Debug.Log("Iestatījumi saglabāti!");
    }
}