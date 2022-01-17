using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlockSpawner : MonoBehaviour
{
    public static EnemyBlockSpawner enemyBlockSpawner;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject[] _enemyBlocksPosition;

    GameObject _enemy;
    private void Start()
    {
        SpawnEnemy();
    }
    public void SpawnEnemy()
    {

        for (int i = 0; i < _enemyBlocksPosition.Length; i++)
        {
            _enemy = Instantiate(enemyPrefab, _enemyBlocksPosition[i].transform.position, _enemyBlocksPosition[i].transform.rotation);
        }
    }

}
