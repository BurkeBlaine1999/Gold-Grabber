using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTPMenu : MonoBehaviour
{
    //Open the HTP menu
    public void ToggleHTPMenu()
    {
        gameObject.SetActive(true);
    }
    //Close the HTP menu
    public void Return()
    {
        gameObject.SetActive(false);
    }
}
