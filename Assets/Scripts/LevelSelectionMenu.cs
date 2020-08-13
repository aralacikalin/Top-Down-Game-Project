using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MainMenu;
    public GameObject LevelSelection;
    public GameObject Scores;
    public void SwitchToLevel()
    {
        MainMenu.SetActive(false);
        
        LevelSelection.SetActive(true);
    }
    public void ReturnToMain()
    {
        Scores.SetActive(false);
        LevelSelection.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void SwitchToScores()
    {
        
        MainMenu.SetActive(false);
        Scores.SetActive(true);
    }

}
