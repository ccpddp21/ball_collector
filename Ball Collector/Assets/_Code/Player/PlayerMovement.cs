using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _speed;
    private float _speedMultiplier;
    private float _horizontalVal;
    private float _verticalVal;

    void Start()
    {
        _speed = 10;
        _speedMultiplier = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalVal = Input.GetAxis("Horizontal");
        _verticalVal = Input.GetAxis("Vertical");

        if (_horizontalVal != 0)
            Strafe(_horizontalVal);
        
        if (_verticalVal != 0)
        {
            _verticalVal = Input.GetKey(KeyCode.LeftShift) ? _verticalVal * _speedMultiplier : _verticalVal;
            MoveForward(_verticalVal);
        }

        
    }

    private void MoveForward(float axisVal)
    {
        this.transform.Translate(new Vector3(0, 0, 1) * axisVal * Time.deltaTime * _speed);
    }

    private void Strafe(float axisVal)
    {
        this.transform.Translate(new Vector3(1, 0, 0) * axisVal * Time.deltaTime * _speed);
    }
}
