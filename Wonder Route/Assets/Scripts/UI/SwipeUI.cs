using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _camera;

    [SerializeField]
    private List<Vector3> _canvasLocations;

    [SerializeField]
    private List<bool> _canMoveX;

    [SerializeField]
    private List<bool> _canMoveY;

    [SerializeField]
    private float _lerpSpeed;

    [SerializeField]
    private float _maxCameraRangeX;

    [SerializeField]
    private float _maxCameraRangeY;

    [SerializeField]
    private float _camSpeedX;

    [SerializeField]
    private float _camSpeedY;

    [SerializeField]
    private float _swipeDirectionAccuracy;

    private Vector3 _currentLocation;
    private Vector3 _target;
    private int _current;
    private bool _LerpToTarget;
    private bool _firstInputX = false;
    private bool _firstInputY = false;
    private bool _onCooldown;


    void Start()
    {
        _target = _camera.transform.position;
        LerpClosest(FindClosest());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _onCooldown = true;
            Invoke("Cooldown", 0.01f);
        }

        if (_onCooldown)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Mouse0) && _canMoveX[_current] && _canMoveY[_current])
        {
            if ((Input.GetAxisRaw("Mouse X") < -_swipeDirectionAccuracy || Input.GetAxisRaw("Mouse X") > _swipeDirectionAccuracy) && !_firstInputY)
            {
                _firstInputX = true;
                MouseX();
            }
            if ((Input.GetAxisRaw("Mouse Y") < -_swipeDirectionAccuracy || Input.GetAxisRaw("Mouse Y") > _swipeDirectionAccuracy) && !_firstInputX)
            {
                _firstInputY = true;
                MouseY();
            }
            return;
        }

        if (Input.GetKey(KeyCode.Mouse0) && _canMoveX[_current])
        {
            MouseX();
        }

        if (Input.GetKey(KeyCode.Mouse0) && _canMoveY[_current])
        {
            MouseY();
        }

        if (!Input.GetKey(KeyCode.Mouse0))
        {
            _target = FindClosest();
            LerpClosest(_target);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _target = FindClosest();
            _firstInputX = false;
            _firstInputY = false;
        }
    }

    void MouseX()
    {
        float dragX = Input.GetAxisRaw("Mouse X") * _camSpeedX;
        _camera.transform.position = new Vector3(_camera.transform.position.x + -dragX, _camera.transform.position.y, _camera.transform.position.z);
        if (_maxCameraRangeX < _camera.transform.position.x)
        {
            _camera.transform.position = new Vector3(_maxCameraRangeX, _camera.transform.position.y, _camera.transform.position.z);
        }
        if (-_maxCameraRangeX > _camera.transform.position.x)
        {
            _camera.transform.position = new Vector3(-_maxCameraRangeX, _camera.transform.position.y, _camera.transform.position.z);
        }
    }

    void MouseY()
    {
        float dragY = Input.GetAxisRaw("Mouse Y") * _camSpeedY;
        _camera.transform.position = new Vector3(_camera.transform.position.x, _camera.transform.position.y, _camera.transform.position.z + -dragY);
        if (_maxCameraRangeY < _camera.transform.position.z)
        {
            _camera.transform.position = new Vector3(_camera.transform.position.x, _camera.transform.position.y, _maxCameraRangeY);
        }
        if (-_maxCameraRangeY > _camera.transform.position.z)
        {
            _camera.transform.position = new Vector3(_camera.transform.position.x, _camera.transform.position.y, -_maxCameraRangeY);
        }
    }

    void Cooldown()
    {
        _onCooldown = false;
    }

    private Vector3 FindClosest()
    {
        bool first = true;
        var closestLocation = _camera.transform.position;
        float smallestDistance = 0;
        for (int i = 0; i < _canvasLocations.Count; i++)
        {
            var currentDistance = Vector3.Distance(_canvasLocations[i], _camera.transform.position);
            if (first || smallestDistance > currentDistance)
            {
                first = false;
                closestLocation = _canvasLocations[i];
                _current = i;
                smallestDistance = currentDistance;
            }
        }
        return closestLocation;
    }

    void LerpClosest(Vector3 closest)
    {
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, closest, _lerpSpeed);
    }
}
