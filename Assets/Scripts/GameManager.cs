using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    void Update()
    {
        GameObject[] remainingObj = GameObject.FindGameObjectsWithTag("EnemyBlock");
        if (remainingObj.Length == 1)
        {
            SceneManager.LoadScene(0);
            Enemy.multyplySpeedEnemy += 1;
            print(Enemy.multyplySpeedEnemy);
        }
    }
}
