using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public static GM instance = null;
    //check variables
    private int HP = 3;
    private int batteryCount = 0;
    public int batteryGoal = 10;
    //things to spawn
    public GameObject enemy;
    public GameObject battery;
    //canvas
    public Text batteryText;
    public GameObject Lives;
    public GameObject PauseMenu;
    public GameObject GameOver;
    public GameObject NextLevel;
    public int RegainLifePerLife = 5;
    
    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(5);
        SpawnBatteries(2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            PauseUnpause();
        }
    }

    public void SpawnEnemies(int howMany)
    {
        int i = 0;
        while (i < howMany)
        {
            float randomx = Random.Range(-120, 180);
            float randomy = Random.Range(-120, 90);
            Vector3 spawnloc = new Vector3(randomx, randomy, -3);
            Instantiate(enemy, spawnloc, new Quaternion(0, 0, 0, 0));
            i++;
        }
    }
    public void TakeDamage()
    {
        Lives.transform.GetChild(HP).gameObject.SetActive(false);
        HP--;
        if (HP <= 0)
        {
            //game over menu
            GameOver.SetActive(true);
            Time.timeScale = 0;
        }
       
        
    }
    public void GainHealth()
    {
        if(HP<3)
            HP++;
        if(Lives.transform.GetChild(HP).gameObject!=null)
            Lives.transform.GetChild(HP).gameObject.SetActive(true);
    }
    public void CollectBattery()
    {
        batteryCount++;
        batteryText.text = "Battery: " + batteryCount;
        SpawnEnemies(3);
        SpawnBatteries(1);
        if (batteryCount >= batteryGoal)
        {
            //next level menu
            NextLevel.SetActive(true);
            Time.timeScale = 0;
        }
        if (batteryCount%RegainLifePerLife==0)
        {
            GainHealth();
        }
    }
    public void SpawnBatteries(int howMany)
    {
        int i = 0;
        while (i<howMany)
        {
            float randomx = Random.Range(-120, 160);
            float randomy = Random.Range(-110, 90);
            Vector3 spawnloc = new Vector3(randomx, randomy, -2);
            Instantiate(battery, spawnloc, new Quaternion(-90,0,0,0));
            i++;
        }
    }
    public void PauseUnpause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
        }
    }
    public int BatteryCount()
    {
        return batteryCount;
    }
}
