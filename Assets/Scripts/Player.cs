using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    
    public static bool isCreated = false;
    [Header("Ball speed")]
    [SerializeField] float multiply;
    [SerializeField] float _plusSpeedForBall;
    [Header("Game Object-s")]
    [Space(5f)]
    [SerializeField] GameObject _ball;
    [SerializeField] float _timeDestroyBall =7f;
    public Transform _ballPosition;
    public Transform _player;

    Camera mainCamera;
    Vector3 _originalPlayerPos;

   public float _power;
    float _minPower = 0.6f;
    float _maxPower = 4f;


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

        if (Input.GetMouseButton(0))
        {
            if (!isCreated)
            {
                Aiming();
                GUI.gUI.arrow.gameObject.SetActive(true);
                GUI.gUI.arrow.fillAmount = Mathf.InverseLerp(_minPower, _maxPower, _power);
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

        const byte _zero = 0;
        if (Input.touchCount > _zero)
        {
            Touch touch = Input.GetTouch(0);

            
            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    if (!isCreated)
                    {
                        Aiming();
                        GUI.gUI.arrow.gameObject.SetActive(true);
                        GUI.gUI.arrow.fillAmount = Mathf.InverseLerp(_minPower, _maxPower, _power);
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
        pref.GetComponent<Rigidbody>().AddForce(_ballPosition.transform.forward * ((_plusSpeedForBall * speed) * multiply));
        Destroy(pref, _timeDestroyBall);
    }
    void Aiming()
    {
        float enter;
        float minPoz_Z = 0;
        float maxPoz_Z = 5f;
        float minPoz_x = 6f;
        float maxPoz_x = -6f;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        new Plane(-Vector3.up, _ballPosition.transform.position).Raycast(ray, out enter);
        Vector3 mouseInWorld = ray.GetPoint(enter);
        Vector3 position = mouseInWorld - _ballPosition.transform.position;
        _ballPosition.transform.rotation = Quaternion.LookRotation(position);
        if (position.z >= minPoz_Z && position.z <= maxPoz_Z && position.x <= minPoz_x && position.x >= maxPoz_x)
        {
            _player.transform.position = _ballPosition.position + position;
        }
        
        if (position.z <= _maxPower && position.z > _minPower)
        {
            _power = position.z;
        }

    }
}
