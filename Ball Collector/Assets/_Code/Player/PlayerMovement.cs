using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _horizontalVal, _verticalVal, _mouseXVal;

    // Update is called once per frame
    void Update()
    {
        _horizontalVal = Input.GetAxis("Horizontal");
        _verticalVal = Input.GetAxis("Vertical");
        _mouseXVal = Input.GetAxis("Mouse X");

        if (_horizontalVal != 0)
            Strafe(_horizontalVal);
        
        if (_verticalVal != 0)
            MoveForward(_verticalVal);

        if (_mouseXVal != 0)
            Turn(_mouseXVal);
    }

    private void MoveForward(float axisVal)
    {
        this.transform.Translate(new Vector3(0, 0, 1) * axisVal * Time.deltaTime);
    }

    private void Strafe(float axisVal)
    {
        this.transform.Translate(new Vector3(1, 0, 0) * axisVal * Time.deltaTime);
    }

    private void Turn(float axisVal)
    {
        this.transform.Rotate(new Vector3(0, 30, 0) * axisVal * Time.deltaTime);
    }
}
