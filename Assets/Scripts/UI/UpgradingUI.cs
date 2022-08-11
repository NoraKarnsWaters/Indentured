using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradingUI : MonoBehaviour
{
    
    //The menu panels that will be swapped between
    [SerializeField]
    private GameObject[] goPanels = new GameObject[3];

    //Sets the first panel added as the active panel
    private void Start()
    {
        goPanels[0].SetActive(true);
    }

    //Opens the panel based on the current button pressed
    //Currently dependant on the script being on the button
    public void OpenPanel()
    {
        //Checks if all provided panels are set, otherwise gives feedback
        if (goPanels[0] != null && goPanels[1] != null && goPanels[2] != null)
        {
            switch (name)
            {
                case "QuestsButton":
                    goPanels[0].SetActive(true);
                    goPanels[1].SetActive(false);
                    goPanels[2].SetActive(false);
                    break;

                case "CraftingButton":
                    goPanels[0].SetActive(false);
                    goPanels[1].SetActive(true);
                    goPanels[2].SetActive(false);
                    break;

                case "SkillsButton":
                    goPanels[0].SetActive(false);
                    goPanels[1].SetActive(false);
                    goPanels[2].SetActive(true);
                    break;
            }
        }
        else
        {
            Debug.Log("A menu panel is not available, please assign all menu panels...");
        }
    }
}
