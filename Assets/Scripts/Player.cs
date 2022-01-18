using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static bool isCreated = false;

    [SerializeField] float multiply;
    [SerializeField] GameObject _ball;

    public Transform _ballPosition;
    public Transform _player;

    Camera mainCamera;

    Vector3 _originalPlayerPos;
    float _power;
   


    private void Start()
    {
        mainCamera = Camera.main;
        _originalPlayerPos = _player.transform.position;
    }

    void FixedUpdate()
    {
       // PlayOnPhone();
        PlayOnPC();

    }
    void PlayOnPC()
    {
        if (Input.GetMouseButton(0) && Input.mousePosition.y >= 210 && Input.mousePosition.y <= 270)
        {
            if (!isCreated)
            {
                Aiming();
                GUI.gUI.arrow.gameObject.SetActive(true);
                GUI.gUI.arrow.fillAmount = Mathf.InverseLerp(0, 4f, _power);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            _player.transform.position = Vector3.Lerp(_player.transform.position, _originalPlayerPos, Time.time);
            if (!isCreated)
            {
                GUI.gUI.arrow.gameObject.SetActive(false);
                Shoot(_power);
                isCreated = true;
            }
        }
    }
    void PlayOnPhone()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            
            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    if (!isCreated)
                    {
                        Aiming();
                        GUI.gUI.arrow.gameObject.SetActive(true);
                        GUI.gUI.arrow.fillAmount = Mathf.InverseLerp(0, 4f, _power);
                    }
                    break;
                case TouchPhase.Ended:
                    _player.transform.position = Vector3.Lerp(_player.transform.position, _originalPlayerPos, Time.time);
                    if (!isCreated)
                    {
                        GUI.gUI.arrow.gameObject.SetActive(false);
                        Shoot(_power);
                        isCreated = true;
                    }
                    break;
            }
        }
    }

    void Shoot(float speed)
    {
        GameObject pref = Instantiate(_ball, _ballPosition.position, _ball.transform.rotation);
        pref.GetComponent<Rigidbody>().AddForce(-_ballPosition.transform.forward * ((10 * speed) * multiply));
        Destroy(pref, 7f);
    }
    void Aiming()
    {
        float enter;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        new Plane(-Vector3.up, _ballPosition.transform.position).Raycast(ray, out enter);
        Vector3 mouseInWorld = ray.GetPoint(enter);
        Vector3 position = mouseInWorld - _ballPosition.transform.position;
        _ballPosition.transform.rotation = Quaternion.LookRotation(position);
        if (position.z >= 0f && position.z <= 5f && position.x <= 6f && position.x >= -6f)
        {
            _player.transform.position = _ballPosition.position + position;
        }
        
        if (position.z < 4 && position.z >1)
        {
            _power = position.z;
        }
    }
}
