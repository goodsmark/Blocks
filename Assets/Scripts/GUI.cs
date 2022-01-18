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
    [SerializeField] Text _score;

    [SerializeField] Player _player;
    [HideInInspector] public int _lvl = 1;
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

        arrow.transform.position = Camera.main.WorldToScreenPoint(_player._player.transform.position);
        arrow.transform.rotation = Quaternion.LookRotation(_player._player.transform.position, -Vector3.forward);
    }
}
