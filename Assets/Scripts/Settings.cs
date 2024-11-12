using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using UnityEngine.Serialization;

    public class Settings : MonoBehaviour
{
        
    public Button twoHandedButton;
    public Button leftHandedButton;
    public Button rightHandedButton;
        
    public Slider masterAudioSlider;
        
    public Button colorBlindEnableButton;
    public Button[] colorBlindButtons; //first index is the disable button
        
    public Button spanishButton;
    public Button englishButton;

    private float _tempVolume;
    private int _tempLocale;
    private int _tempScheme;
    private int _colorBlindMode;


    void Start()
    { 
        //load locale based on player prefs and changes UI
        OnClickChangeLocale(GameManager.Instance.locale);
            
        // Load current settings from GameManager into temp variables and UI
        _tempVolume = GameManager.Instance.volume;
        _tempLocale = GameManager.Instance.locale;
        _tempScheme = GameManager.Instance.controlScheme;
        _colorBlindMode = GameManager.Instance.colorBlind;

        // Set UI based on loaded settings
        masterAudioSlider.value = _tempVolume;
        UpdateLocaleButtons(_tempLocale);
        UpdateControlSchemeButtons(_tempScheme);
        UpdateColorBlindButtons(_colorBlindMode);
            
        //EventSystem.current.SetSelectedGameObject(twoHandedButton.gameObject);
    }
        
    public void ChangeControlScheme(int schemeNum)
    {
        _tempScheme = schemeNum; // Update temp value
        UpdateControlSchemeButtons(schemeNum); // Update UI appearance
    }

    private void UpdateControlSchemeButtons(int schemeNum)
    {
        // Enable/disable buttons visually based on the selected scheme
        twoHandedButton.interactable = schemeNum != 0;
        leftHandedButton.interactable = schemeNum != 1;
        rightHandedButton.interactable = schemeNum != 2;
            
        ApplyControlScheme(schemeNum);
    }
        
    private void ApplyControlScheme(int schemeNum)
    {
        string schemeName;
        switch (schemeNum)
        {
            case 0:
                schemeName = "TwoHanded";
                break;
            case 1:
                schemeName = "LeftHanded";
                break;
            case 2:
                schemeName = "RightHanded";
                break;
            default:
                Debug.Log("Error applying control scheme. Case out of bounds");
                return;
        }
                
        //InputHandler.Instance.SwitchControlScheme(schemeName);
    }

    public void OnClickChangeLocale(int localeNumber)
    {
        _tempLocale = localeNumber; // Update temp value
        StartCoroutine(ChangeLocale(localeNumber)); // Apply locale change
        UpdateLocaleButtons(localeNumber); // Update UI
    }

    IEnumerator ChangeLocale(int localeNumber)
    {
        yield return LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeNumber];
        //Debug.Log("Locale changed to: " + LocalizationSettings.SelectedLocale.LocaleName);
    }

    private void UpdateLocaleButtons(int localeNumber)
    {
        // Update button states visually to reflect active/inactive status
        englishButton.interactable = localeNumber != 0;
        spanishButton.interactable = localeNumber != 1;
            
        englishButton.OnDeselect(null);
        spanishButton.OnDeselect(null);
    }
        
    public void UpdateColorBlindMode(int mode)
    {
        _colorBlindMode = mode;
        UpdateColorBlindButtons(mode);
        //should update immediately when pressed.
            
    }

    private void UpdateColorBlindButtons(int mode)
    {
        for (int i = 0; i < colorBlindButtons.Length; i++)
        { 
            // Disable the button for the selected mode, enable others
            colorBlindButtons[i].interactable = (i != mode);
        }
    }

    public void ChangeVolume(float volume)
    {
        _tempVolume = volume; // Update temp volume value from slider
            
        // GameManager.Instance.ApplyVolume(volume);
    }



    public void QuitAndSave()
    {
        // Save temp settings into GameManager and PlayerPrefs
        GameManager.Instance.volume = _tempVolume;
        GameManager.Instance.locale = _tempLocale;
        GameManager.Instance.controlScheme = _tempScheme;
        GameManager.Instance.colorBlind = _colorBlindMode;

        GameManager.Instance.SaveSettings(); // Save preferences
    }

    public void JustQuit()
    {
        // Reset the UI to the original settings from GameManager
        _tempVolume = GameManager.Instance.volume;
        _tempLocale = GameManager.Instance.locale;
        _tempScheme = GameManager.Instance.controlScheme;
        _colorBlindMode = GameManager.Instance.colorBlind;

        // Update UI elements to reflect original settings
        masterAudioSlider.value = _tempVolume;
        UpdateLocaleButtons(_tempLocale);
        UpdateControlSchemeButtons(_tempScheme);
        UpdateColorBlindButtons(_colorBlindMode);
    }
}
