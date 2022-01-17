using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float multiply;
    [SerializeField] GameObject _ball;
    [SerializeField] Transform _ballPosition;
    [SerializeField] Transform _player;

    Camera mainCamera;

    Vector3 _originalPlayerPos;
    float _power;
    public static bool isCreated = false;


    private void Start()
    {
        mainCamera = Camera.main;
        _originalPlayerPos = _player.transform.position;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isCreated)
            {
                Aiming();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            _player.transform.position = Vector3.Lerp(_player.transform.position, _originalPlayerPos, Time.time);
            if (!isCreated)
            {
                Shoot(_power);
                isCreated = true;
            }
        }
    }

    void Shoot(float speed)
    {
        GameObject pref = Instantiate(_ball, _ballPosition.position, _ball.transform.rotation);
        pref.GetComponent<Rigidbody>().AddForce(-_ballPosition.transform.forward * ((10 + speed) * multiply));
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
        if (position.z >= 0f && position.z <= 4f && position.x <= 6.5f && position.x >= -6.5f)
        {
            _player.transform.position = _ballPosition.position + position;
        }
        _power = position.z;
    }
}
