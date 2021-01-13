using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{   
    //Open the options menu
    public void OpenOptionsMenu() { gameObject.SetActive(true); }
    //Close the options menu
    public void CloseOptionsMenu() { gameObject.SetActive(false); }
}
