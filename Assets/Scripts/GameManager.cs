using System;
using System.Collections;
using SOHNE.Accessibility.Colorblindness;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        // Player settings
        public float volume;
        public int locale;
        public int controlScheme;
        public int colorBlind;

        private void Awake()
        {
            // Ensure there's only one instance of GameManager
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject); // Keep this GameManager in all scenes
            }
            else
            {
                Destroy(gameObject); // Only ONE!
            }
        }

        private void Start()
        {
            Debug.Log("GameManager Starting");
            // Load settings from PlayerPrefs when game starts
            LoadSettings();
            //sets locale from player prefs at the start.
            StartCoroutine(InitializeAndChangeLocale(locale)); 
            
            StartCoroutine(WaitForColorblindnessInitialization());
            
           // ApplyVolume(volume);
        }

        public void LoadSettings()
        {
            // Load settings from PlayerPrefs or set defaults
            volume = PlayerPrefs.GetFloat("MasterVolume", 0.5f);
            locale = PlayerPrefs.GetInt("Locale", 0);  // 0 = English
            controlScheme = PlayerPrefs.GetInt("ControlScheme", 0);
            colorBlind = PlayerPrefs.GetInt("Accessibility.ColorblindType", 0);
            
            ApplyColorBlindSetting();
        }

        public void SaveSettings()
        {
            // Save all settings to PlayerPrefs
            PlayerPrefs.SetFloat("MasterVolume", volume);
            PlayerPrefs.SetInt("Locale", locale);
            PlayerPrefs.SetInt("ControlScheme", controlScheme);
            PlayerPrefs.SetInt("Accessibility.ColorblindType", colorBlind);
            PlayerPrefs.Save();
            
            ApplyColorBlindSetting();
        }
        
        private void ApplyColorBlindSetting()
        {
            if (Colorblindness.Instance != null)
            {
                Colorblindness.Instance.Change(colorBlind);
            }
            else
            {
                Debug.LogError("Colorblindness.Instance is null. Ensure that the Colorblindness script is initialized before GameManager.");
            }
        }
        
        private IEnumerator WaitForColorblindnessInitialization()
        {
            // Wait until the Colorblindness instance is initialized
            while (Colorblindness.Instance == null)
            {
                yield return null;  // Wait until the next frame
            }

            // Once initialized, apply the colorblind setting
            ApplyColorBlindSetting();
        }
        
        //public void ApplyVolume(float volume)
       // {
        //    // This is obnoxiously loud if it's not adjusted, it will drown out all other sounds
        //    var music = GameManager.Instance.gameObject.GetComponent<AudioSource>();
        //    music.volume = Mathf.Clamp(volume / 3f, 0f, 1f);

        //    var playerSounds = PlayerMovement.Instance.gameObject.GetComponent<AudioSource>();
        //    playerSounds.volume = Mathf.Clamp(volume, 0f, 1f); 
       // }
    
        IEnumerator InitializeAndChangeLocale(int localeNumber)
        {
            // Wait until the LocalizationSettings are fully initialized
            //If we don't, locale string tables aren't initialized and we get yelled at! I would know!
            yield return LocalizationSettings.InitializationOperation;
        
            // Now we can safely change the locale
            yield return LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeNumber];
        }
    }
