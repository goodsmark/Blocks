using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    public static GUI gUI;
    [SerializeField] Text _score;


    public int _lvl = 1;
    void Start()
    {
        if (gUI == null)
        {
            gUI = this;
        }
        else
        {
            Destroy(this);
        }

    }
    void Update()
    {
        _score.text = "Уровень :" + _lvl;
    }
}
