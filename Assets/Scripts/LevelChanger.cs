using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    public string scenename;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FadeToLevel(string sceneName)
    {
        scenename = sceneName;
        Time.timeScale = 1;
        animator.SetTrigger("FadeOut");
    }
    public void FadeToQuit()
    {
        Time.timeScale = 1;
        animator.SetTrigger("FadeOut");
        scenename = "Quit";
    }
    public void SwitchToScene()
    {
        if (scenename != "Quit")
            SceneManager.LoadScene(scenename);
        else
            Quit();
    }
    public void Quit()
    {
        Application.Quit();
    }

}
