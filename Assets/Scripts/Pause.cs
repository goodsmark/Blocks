using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public float timer;
    public bool isPause;
    public bool guiPause;

    const byte _zero = 0;
    const byte _one = 1;

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
            timer = _zero;
            guiPause = true;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Continue()
    {
        GUI.gUI.menuPanel.gameObject.SetActive(false);
        timer = _one;
        isPause = false;
        guiPause = false;
    }

}