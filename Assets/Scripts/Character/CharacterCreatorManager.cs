using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharacterCreatorManager : MonoBehaviour
{
    [Header("Character Models")]
    public GameObject maleModel;
    public GameObject femaleModel;

    [Header("Input Fields")]
    public TMP_InputField forenameInput;
    public TMP_InputField surnameInput;
    public TMP_InputField YearInput;

    [Header("Output Text")]
    public TextMeshProUGUI aboutText;

    [Header("Clothing Categories")]
    public GameObject[] maleHats;
    public GameObject[] femaleHats;
    // Vēlāk pieliksu citas drēbes priekš sievietes un vīrieša..

    [Header("UI Elements to Reset")]
    public TMP_Dropdown genderDropdown;
    public TMP_Dropdown hatDropdown;
    public TMP_Dropdown voiceDropdown;

    [Header("Voice Settings")]
    public AudioSource voiceSource;
    public AudioClip[] maleVoices;
    public AudioClip[] femaleVoices;
    public Slider pitchSlider;

    private bool isMale = true;
    private bool isFemale = false;

    void Start()
    {
        UpdateAboutText();

        UpdateVoiceDropdownOptions();

        if (maleVoices.Length > 0)
        {
            voiceSource.clip = maleVoices[0];
        }
    }

    // Metode kas reseto visu, ja nomaina dzimumu
    public void OnGenderChanged(int index)
    {
        if (index == 0)
        {
            isMale = true;
            isFemale = false;
        }

        else if(index == 1)
        {
            isMale = false;
            isFemale = true;
        }

        OnVoiceDropdownChanged(0);

        // Dzimumi
        maleModel.SetActive(isMale);
        femaleModel.SetActive(isFemale);

        // Input fields un Dropdown
        forenameInput.text = "";
        surnameInput.text = "";
        YearInput.text = "";
        hatDropdown.value = 0; // dropdown index 0

        // Islēdz visas drēbes
        DisableAllClothing(maleHats);
        DisableAllClothing(femaleHats);

        UpdateAboutText();

        // Atjauno Dropdown opcijas
        UpdateVoiceDropdownOptions();
    }

    // DRĒBES
    public void OnHatChanged(int index)
    {
        GameObject[] currentHatList = maleHats;

        if (isMale)
        {
            currentHatList = maleHats;
        }

        if (!isMale)
        {
            currentHatList = femaleHats;
        }

        // Islēdz visas cepures
        DisableAllClothing(currentHatList);

        // Ja index > 0, tad ieslēdz izvēlēto cepuri (index - 1, jo 0 ir "None")
        if (index > 0 && index <= currentHatList.Length)
        {
            currentHatList[index - 1].SetActive(true);
        }
    }

    // Metode kas izslēdz visas drēbes objektus
    private void DisableAllClothing(GameObject[] list)
    {
        foreach (GameObject item in list)
        {
            if (item != null) item.SetActive(false);
        }
    }

    // Tēla balss metodes
    public void PlayVoicePreview()
    {
        // Pitch
        voiceSource.pitch = pitchSlider.value;
        voiceSource.Play();
    }

    // Metode ko izsauc dropdown, kad index tiek mainīts
    public void OnVoiceDropdownChanged(int index)
    {
        AudioClip[] currentVoiceList = maleVoices;

        // Pārbaude
        if (isMale)
        {
            currentVoiceList = maleVoices;
        }

        if (!isMale)
        {
            currentVoiceList = femaleVoices;
        }

        if (index >= 0 && index < currentVoiceList.Length)
        {
            voiceSource.clip = currentVoiceList[index];
        }
    }


    // About Text (OUTPUT)
    public void UpdateAboutText()
    {
        // Lokālie mainīgie
        string finalForename;
        string finalSurname;
        string finalYear;

    // Pārbaudes
        if (forenameInput.text == "") 
        {
            finalForename = "Jacob";
        }
        else 
        {
            finalForename = forenameInput.text;
        }

        if (surnameInput.text == "") 
        {
            finalSurname = "Jones";
        }
        else 
        {
            finalSurname = surnameInput.text;
        }

        if (YearInput.text == "") 
        {
            finalYear = "1986";
        }
        else 
        {
            finalYear = YearInput.text;
        }

        // Atjaunina text
        aboutText.text = "Name: " + finalForename + " " + finalSurname + "\nBorn: " + finalYear;
    }

    private void UpdateVoiceDropdownOptions()
    {
        // Izstīra dropdown opcijas.
        voiceDropdown.ClearOptions();

        // String list priekš jaunajiem dropdown items, mainot dzimumu
        List<string> newVoiceNames = new List<string>();

        // Pārbaude
        if (isMale)
        {
            foreach (AudioClip clip in maleVoices)
            {
                newVoiceNames.Add(clip.name);
            }
        }
        else
        {
            foreach (AudioClip clip in femaleVoices)
            {
                newVoiceNames.Add(clip.name);
            }
        }

        // Atjauno dropdown UI
        voiceDropdown.AddOptions(newVoiceNames);

        voiceDropdown.value = 0;
        voiceDropdown.RefreshShownValue();
        OnVoiceDropdownChanged(0); 
    }
}