
using UnityEngine;
using UnityEngine.Audio;


public class AudioController : MonoBehaviour
{
    // in-game sounds
    // get a reference to the audio mixer
    public AudioMixer audioMixer;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetVolumeLevels();
    }


    private void SetVolumeLevels()
    {
        // if music volume data has been saved
        // master volume
        if (PlayerPrefs.HasKey("Master Volume"))
        {
            // read master volume data
            audioMixer.SetFloat("Master Volume", PlayerPrefs.GetFloat("Master Volume"));
        }

        // music volume
        if (PlayerPrefs.HasKey("Music Volume"))
        {
            // read music volume data
            audioMixer.SetFloat("Music Volume", PlayerPrefs.GetFloat("Music Volume"));
        }

        // sfx volume
        if (PlayerPrefs.HasKey("SFX Volume"))
        {
            // read sfx volume data
            audioMixer.SetFloat("SFX Volume", PlayerPrefs.GetFloat("SFX Volume"));
        }
    }


} // end of class
