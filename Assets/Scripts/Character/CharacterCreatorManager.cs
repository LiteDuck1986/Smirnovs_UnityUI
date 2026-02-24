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
    // Vīriešu kategorijas
    public GameObject[] maleHats;
    public GameObject[] maleVests;
    public GameObject[] maleShirts;
    public GameObject[] maleTshirts;
    public GameObject[] malePants;
    public GameObject[] maleSocks;
    public GameObject[] maleShoes;
    public GameObject[] maleNecklace;

    // Sieviešu kategorijas
    public GameObject[] femaleHats;
    public GameObject[] femaleVests;
    public GameObject[] femaleShirts;
    public GameObject[] femaleTshirts;
    public GameObject[] femalePants;
    public GameObject[] femaleSocks;
    public GameObject[] femaleShoes;
    public GameObject[] femaleNecklace;


    [Header("UI Elements to Reset")]
    public TMP_Dropdown genderDropdown;
    public TMP_Dropdown hatDropdown;
    public TMP_Dropdown vestDropdown;
    public TMP_Dropdown shirtDropdown;
    public TMP_Dropdown tShirtDropdown;
    public TMP_Dropdown pantsDropdown;
    public TMP_Dropdown socksDropdown;
    public TMP_Dropdown shoesDropdown;
    public TMP_Dropdown necklaceDropdown;
    public TMP_Dropdown voiceDropdown;

    public Transform bloodPanel; // blood overlay
    public Transform bandagePanel; // bandage overlay

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

        // Dropdown values
        hatDropdown.value = 0; // dropdown index 0
        vestDropdown.value = 0; // dropdown index 0
        shirtDropdown.value = 0; // dropdown index 0
        tShirtDropdown.value = 0; // dropdown index 0
        pantsDropdown.value = 0; // dropdown index 0
        socksDropdown.value = 0; // dropdown index 0
        shoesDropdown.value = 0; // dropdown index 0
        necklaceDropdown.value = 0; // dropdown index 0

        // Islēdz visas drēbes
        DisableAllClothing(maleHats);
        DisableAllClothing(maleVests);
        DisableAllClothing(maleShirts);
        DisableAllClothing(maleTshirts);
        DisableAllClothing(malePants);
        DisableAllClothing(maleSocks);
        DisableAllClothing(maleShoes);
        DisableAllClothing(maleNecklace);

        DisableAllClothing(femaleHats);
        DisableAllClothing(femaleVests);
        DisableAllClothing(femaleShirts);
        DisableAllClothing(femaleTshirts);
        DisableAllClothing(femalePants);
        DisableAllClothing(femaleSocks);
        DisableAllClothing(femaleShoes);
        DisableAllClothing(femaleNecklace);

        UpdateAboutText();

        // Atjauno Dropdown opcijas
        UpdateVoiceDropdownOptions();
    }

    // DRĒBES Metodes
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

    public void OnVestChanged(int index)
    {
        GameObject[] currentVestList = maleVests;

        if (isMale)
        {
            currentVestList = maleVests;
        }

        if (!isMale)
        {
            currentVestList = femaleVests;
        }

        // Islēdz visas cepures
        DisableAllClothing(currentVestList);

        // Ja index > 0, tad ieslēdz izvēlēto cepuri (index - 1, jo 0 ir "None")
        if (index > 0 && index <= currentVestList.Length)
        {
            currentVestList[index - 1].SetActive(true);
        }
    }

    public void OnShirtChanged(int index)
    {
        GameObject[] currentShirtList = maleShirts;

        if (isMale)
        {
            currentShirtList = maleShirts;
        }

        if (!isMale)
        {
            currentShirtList = femaleShirts;
        }

        // Islēdz visas cepures
        DisableAllClothing(currentShirtList);

        // Ja index > 0, tad ieslēdz izvēlēto cepuri (index - 1, jo 0 ir "None")
        if (index > 0 && index <= currentShirtList.Length)
        {
            currentShirtList[index - 1].SetActive(true);
        }
    }

    public void OnTshirtChanged(int index)
    {
        GameObject[] currentTshirtList = maleTshirts;

        if (isMale)
        {
            currentTshirtList = maleTshirts;
        }

        if (!isMale)
        {
            currentTshirtList = femaleTshirts;
        }

        // Islēdz visas cepures
        DisableAllClothing(currentTshirtList);

        // Ja index > 0, tad ieslēdz izvēlēto cepuri (index - 1, jo 0 ir "None")
        if (index > 0 && index <= currentTshirtList.Length)
        {
            currentTshirtList[index - 1].SetActive(true);
        }
    }

    public void OnPantsChanged(int index)
    {
        GameObject[] currentPantsList = malePants;

        if (isMale)
        {
            currentPantsList = malePants;
        }

        if (!isMale)
        {
            currentPantsList = femalePants;
        }

        // Islēdz visas cepures
        DisableAllClothing(currentPantsList);

        // Ja index > 0, tad ieslēdz izvēlēto cepuri (index - 1, jo 0 ir "None")
        if (index > 0 && index <= currentPantsList.Length)
        {
            currentPantsList[index - 1].SetActive(true);
        }
    }

    public void OnSocksChanged(int index)
    {
        GameObject[] currentSocksList = maleSocks;

        if (isMale)
        {
            currentSocksList = maleSocks;
        }

        if (!isMale)
        {
            currentSocksList = femaleSocks;
        }

        // Islēdz visas cepures
        DisableAllClothing(currentSocksList);

        // Ja index > 0, tad ieslēdz izvēlēto cepuri (index - 1, jo 0 ir "None")
        if (index > 0 && index <= currentSocksList.Length)
        {
            currentSocksList[index - 1].SetActive(true);
        }
    }

    public void OnShoesChanged(int index)
    {
        GameObject[] currentShoesList = maleShoes;

        if (isMale)
        {
            currentShoesList = maleShoes;
        }

        if (!isMale)
        {
            currentShoesList = femaleShoes;
        }

        // Islēdz visas cepures
        DisableAllClothing(currentShoesList);

        // Ja index > 0, tad ieslēdz izvēlēto cepuri (index - 1, jo 0 ir "None")
        if (index > 0 && index <= currentShoesList.Length)
        {
            currentShoesList[index - 1].SetActive(true);
        }
    }

    public void OnNecklaceChanged(int index)
    {
        GameObject[] currentNecklaceList = maleNecklace;

        if (isMale)
        {
            currentNecklaceList = maleNecklace;
        }

        if (!isMale)
        {
            currentNecklaceList = femaleNecklace;
        }

        // Islēdz visas cepures
        DisableAllClothing(currentNecklaceList);

        // Ja index > 0, tad ieslēdz izvēlēto cepuri (index - 1, jo 0 ir "None")
        if (index > 0 && index <= currentNecklaceList.Length)
        {
            currentNecklaceList[index - 1].SetActive(true);
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

    public void ClearAllDecals()
    {
        foreach (Transform child in bloodPanel)
        {
            // Iznīcina child objects
            Destroy(child.gameObject);
        }

        foreach (Transform child in bandagePanel)
        {
            // Iznīcina child objects
            Destroy(child.gameObject);
        }
    }
}