using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] byte _lvlCount = 1;

    EnemyBlockSpawner _blockSpawner;
    private void Start()
    {
        _blockSpawner = FindObjectOfType<EnemyBlockSpawner>();
    }
    void FixedUpdate()
    {
        GameObject[] remainingObj = GameObject.FindGameObjectsWithTag("EnemyBlock");
        if (remainingObj.Length == 0)
        {
            _blockSpawner.SpawnEnemy();
            Enemy.multyplySpeedEnemy += _lvlCount;
            GUI.gUI._lvl += _lvlCount;

        }
        GameObject pref = GameObject.FindGameObjectWithTag("Ball");
        if (pref == null)
        {
            Player.isCreated = false;
        }

    }
}
