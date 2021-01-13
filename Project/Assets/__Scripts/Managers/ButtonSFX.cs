using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    //Variables
    public AudioSource SFX;
    public AudioClip click;

    //Play click when selecting menu items
    public void ClickSound()
    {
        SFX.PlayOneShot(click);
    }

}
