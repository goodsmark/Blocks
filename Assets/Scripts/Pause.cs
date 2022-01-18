using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public float timer;
    public bool isPause;
    public bool guiPause;

    void Update()
    {
        Time.timeScale = timer;
        if (Input.GetKeyDown(KeyCode.Escape) && isPause == false)
        {
            isPause = true;

        }
        if (isPause == true)
        {
            GUI.gUI.menuPanel.gameObject.SetActive(true);
            timer = 0;
            guiPause = true;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Continue()
    {
        GUI.gUI.menuPanel.gameObject.SetActive(false);
        timer = 1f;
        isPause = false;
        guiPause = false;
    }

}