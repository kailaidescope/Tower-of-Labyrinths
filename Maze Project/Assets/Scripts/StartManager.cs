using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("Start");
    }
    public void GameStart(){
        SceneManager.LoadScene("Boss-Level-1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
