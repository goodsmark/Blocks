using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float multyplySpeedEnemy = 1f;
    public float moveSpeed = 5f;

    [SerializeField] GameObject _enemy;

    byte distance = 20;
    Vector3 _originalPos; 

    void Start()
    {
        _originalPos = _enemy.transform.position;
    }

    void FixedUpdate()
    {
        
        if (Player.isCreated)
        {
            GameObject _ball = GameObject.FindGameObjectWithTag("Ball");
            float direction = _ball.transform.position.x - _enemy.transform.position.x;
            if (Mathf.Abs(direction) < distance)
            {
                Vector3 pos = _enemy.transform.position;
                pos.x += Mathf.Sign(direction) * moveSpeed * multyplySpeedEnemy* Time.deltaTime;
                _enemy.transform.position = pos;
            }
        }
        else
        {
            _enemy.transform.position = _originalPos;
        }
    }

}
