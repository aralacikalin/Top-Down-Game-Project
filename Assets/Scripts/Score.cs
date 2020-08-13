using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text hiScoreText;
    public Text scoreText;
    private int hiScore;

    
    // Start is called before the first frame update
    void Start()
    {
        hiScore = PlayerPrefs.GetInt("Score");
        hiScoreText.text = "HIGH SCORE:" + hiScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (hiScoreText.gameObject.activeInHierarchy&&GM.instance.BatteryCount()>hiScore)
        {
            hiScore = GM.instance.BatteryCount();
            PlayerPrefs.SetInt("Score", hiScore);
            hiScoreText.text = "HIGHEST SCORE:" + hiScore;
        }
        if(hiScoreText.gameObject.activeInHierarchy && GM.instance.BatteryCount() < hiScore)
        {
            scoreText.text = "SCORE:" + GM.instance.BatteryCount();
        }
        
    }
}
