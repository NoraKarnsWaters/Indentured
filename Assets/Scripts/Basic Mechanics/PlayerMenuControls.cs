using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuControls : MonoBehaviour
{
    [SerializeField]
    GameObject goGameMenu;

    //Continually look for whether the menu button is pressed
    //Change active state for menu if the menu button is pressed and the menu object is not null
    void Update()
    {
        if(goGameMenu != null)
        {
            if(Input.GetKeyDown(KeyCode.Tab))
            {
                goGameMenu.SetActive(!goGameMenu.activeSelf);
            }
        }
    }
}
