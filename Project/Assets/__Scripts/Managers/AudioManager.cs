using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    //Variables
    public AudioSource AudioSource;
    private float musicVolume = 1f;

    //Play music once the scene begins
    void Start()
    {
        AudioSource.Play();
        musicVolume = PlayerPrefs.GetFloat("Volume");
    }
    // Keep track of the volume slider
    void Update()
    {
        PlayerPrefs.SetFloat("Volume", musicVolume);
        AudioSource.volume = musicVolume;
    }
    //Change the volume levels
    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }


}
