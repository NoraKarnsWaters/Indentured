using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuControls : MonoBehaviour
{
    [SerializeField]
    GameObject goGameMenu;

    // Update is called once per frame
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
