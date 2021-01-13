using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    //Open the menu
    public void ToggleMenu()
    {
        gameObject.SetActive(true);
    }

    //Close the menu
    public void Return()
    {
        gameObject.SetActive(false);
    }
}
