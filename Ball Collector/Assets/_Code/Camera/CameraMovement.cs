﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private BooleanVariable _gamePausedVariable;
    private float _mouseXVal;
    private float _mouseYVal;
    private Vector3 xRot;
    private float _xSensitivity;
    private float _ySensitivity;

    void Start()
    {
        _xSensitivity = _ySensitivity = 15;
    }

    // Update is called once per frame
    void Update()
    {
        _mouseXVal = Input.GetAxis("Mouse X");
        _mouseYVal = Input.GetAxis("Mouse Y");

        if (_mouseXVal != 0 && !_gamePausedVariable.RuntimeValue)
            Turn(_mouseXVal);

        if (_mouseYVal != 0 && !_gamePausedVariable.RuntimeValue)
            Pitch(_mouseYVal);
    }

    private void Pitch(float axisVal)
    {
        xRot = this.transform.localRotation.eulerAngles;
        xRot.x = xRot.x < 360 && xRot.x >= 300 ? xRot.x - 360 : xRot.x;
        xRot.x = Mathf.Clamp(xRot.x + axisVal, 0, 10);
        this.transform.localRotation = Quaternion.Euler(xRot);
    }

    private void Turn(float axisVal)
    {
        this.transform.parent.Rotate(new Vector3(0, 30, 0) * axisVal * Time.deltaTime * _xSensitivity);
    }
}
