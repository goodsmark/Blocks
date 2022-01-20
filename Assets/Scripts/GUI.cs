using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    public static GUI gUI;
    public Image menuPanel;
    public Image arrow;
    public Vector3 arrowOffset;
    [SerializeField] Text _score;

    [SerializeField] Player _player;
    [HideInInspector] public int _lvl = 1;
    const float arrowPosX = 0.01f;
    float divideArrowOffsetX = 5f;
    void Start()
    {
        arrow.gameObject.SetActive(false);
        menuPanel.gameObject.SetActive(false);
        if (gUI == null)
        {
            gUI = this;
        }
        else
        {
            Destroy(this);
        }
        _player = FindObjectOfType<Player>();
    }
    void Update()
    {
        _score.text = "Уровень :" + _lvl;

        arrow.transform.position = Camera.main.WorldToScreenPoint(_player._player.position + arrowOffset);
        var newRotation = Quaternion.LookRotation(_player._ballPosition.position - _player._player.position - Vector3.up*90, -Vector3.up);
        newRotation.x = arrowPosX;
        if (_player._player.position.x > arrowPosX)
        {
            arrowOffset.x = -_player._player.position.x / divideArrowOffsetX;
        }
        else if (_player._player.position.x < -arrowPosX)
        {
            arrowOffset.x = _player._player.position.x / -divideArrowOffsetX;
        }
        arrow.transform.rotation = newRotation;
    }
}