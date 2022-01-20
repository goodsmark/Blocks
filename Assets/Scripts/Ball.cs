using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            if (other.gameObject.tag == "Enemy")
            {
                Destroy(gameObject);
            }
            else
            { 
                Destroy(other.gameObject);
                Destroy(gameObject);
            }

            Player.isCreated = false;
        }
    }
}
