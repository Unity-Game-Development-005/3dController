
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;


public class MenuOptionsController : MonoBehaviour
{
    // get a reference to the audio controller script
    private AudioController audioController;


    // get a reference to the volume slider controls
    public Slider masterVolumeSlider;

    public Slider musicVolumeSlider;

    public Slider sfxVolumeSlider;

    // get a reference to the volume value labels
    public TMP_Text masterVolumeValue;

    public TMP_Text musicVolumeValue;

    public TMP_Text sfxVolumeValue;

    // volume offset value
    private float volumeOffset = 80f;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // set the reference to the player controller script
        audioController = GameObject.Find("Audio Controller").GetComponent<AudioController>();


        Initialise();

        UpdateDisplay();
    }


    private void Initialise()
    {
        // if music volume data has been saved
        // master volume
        if (PlayerPrefs.HasKey("Master Volume"))
        {
            // get master volume data
            masterVolumeSlider.value = PlayerPrefs.GetFloat("Master Volume");
        }

        // music volume
        if (PlayerPrefs.HasKey("Music Volume"))
        {
            // get music volume data
            musicVolumeSlider.value = PlayerPrefs.GetFloat("Music Volume");
        }

        // sfx volume
        if (PlayerPrefs.HasKey("SFX Volume"))
        {
            // get sfx volume data
            sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFX Volume");
        }
    }


    // update the volume value for each control, and save to playerprefs
    // master volume
    public void SetMasterVolume()
    {
        audioController.audioMixer.SetFloat("Master Volume", masterVolumeSlider.value);

        PlayerPrefs.SetFloat("Master Volume", masterVolumeSlider.value);

        UpdateDisplay();
    }


    // music volume
    public void SetMusicVolume()
    {
        audioController.audioMixer.SetFloat("Music Volume", musicVolumeSlider.value);

        PlayerPrefs.SetFloat("Music Volume", musicVolumeSlider.value);

        UpdateDisplay();
    }


    // sfx volume
    public void SetSfxVolume()
    {
        audioController.audioMixer.SetFloat("SFX Volume", sfxVolumeSlider.value);

        PlayerPrefs.SetFloat("SFX Volume", sfxVolumeSlider.value);

        UpdateDisplay();
    }


    // update the display for each slider control
    private void UpdateDisplay()
    {
        masterVolumeValue.text = (masterVolumeSlider.value + volumeOffset).ToString() + "%";

        musicVolumeValue.text = (musicVolumeSlider.value + volumeOffset).ToString() + "%";

        sfxVolumeValue.text = (sfxVolumeSlider.value + volumeOffset).ToString() + "%";
    }


} // end of class
