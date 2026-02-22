using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer mainMixer;
    
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip[] musicList;
    [SerializeField] private AudioClip hoverSound;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip closeSound;

    private void Awake()
    {
        // Instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }

        else
        {
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        // Ielādē Saglabātos iestatījumus
        LoadSettings();

        if (musicList.Length > 0)
        StartCoroutine(PlayMusicList());
    }

    // MŪZIKAS LOĢIKA
    IEnumerator PlayMusicList()
    {
        // Index 0, vienmēr spēlēs pirmais
        AudioClip firstClip = musicList[0];
        musicSource.clip = firstClip;
        musicSource.Play();

        // Pagaida kamēr pirmā mūzika pabeigies
        yield return new WaitForSeconds(firstClip.length);

        // Random loop
        while (true)
        {
            int randomIndex = Random.Range(0, musicList.Length);
            AudioClip clip = musicList[randomIndex];

            musicSource.clip = clip;
            musicSource.Play();

            // Gaida kamēr beigsies mūzika pirms izvēlas nākošo
            yield return new WaitForSeconds(clip.length);
        }
    }

    // SFX
    public void PlayHover() 
    {
        sfxSource.PlayOneShot(hoverSound);
    }

    public void PlayClick() 
    {
        sfxSource.PlayOneShot(clickSound);
    }

    public void PlayClose() 
    {
        sfxSource.PlayOneShot(closeSound);
    }


    // Metode ko izsauc Music slider
    public void SetMusicVolume(float value) 
    {
        musicSource.volume = value;
    }

    // Metode ko izsauc SFX Slider
    public void SetSFXVolume(float value)
    {
        sfxSource.volume = value;
    }


    // --- SETTINGS METODES ---

    // Metode kas saglabā iestatijumus PlayerPrefs
    public void SaveSettings(float musicValue, float sfxValue)
    {
        PlayerPrefs.SetFloat("MusicValue", musicValue);
        PlayerPrefs.SetFloat("SFXValue", sfxValue);
        PlayerPrefs.Save();
    }

    // Metode kas ielāde iestatijumus
    private void LoadSettings()
    {
        float m = PlayerPrefs.GetFloat("MusicValue", 0.75f);
        float s = PlayerPrefs.GetFloat("SFXValue", 0.75f);
        SetMusicVolume(m);
        SetSFXVolume(s);
    }
}