using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private BooleanVariable _gamePausedVariable;
    [SerializeField] private Rigidbody _rigidbody;

    private float _speed;
    private float _speedMultiplier;
    private float _horizontalVal;
    private float _verticalVal;

    void Awake()
    {
        if (_rigidbody == null)
            _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _speed = 10;
        _speedMultiplier = 2f;
    }

    void FixedUpdate()
    {
        _horizontalVal = Input.GetAxis("Horizontal");
        _verticalVal = Input.GetAxis("Vertical");

        if (_horizontalVal != 0 && !_gamePausedVariable.RuntimeValue)
            Strafe(_horizontalVal);
        
        if (_verticalVal != 0&& !_gamePausedVariable.RuntimeValue)
        {
            _verticalVal = Input.GetKey(KeyCode.LeftShift) && DetectGround() ? _verticalVal * _speedMultiplier : _verticalVal;
            
            MoveForward(_verticalVal);
        }        
    }

    private void MoveForward(float axisVal)
    {
        _rigidbody.MovePosition(_rigidbody.position + (transform.forward * axisVal * Time.deltaTime * _speed));
    }

    private void Strafe(float axisVal)
    {
        _rigidbody.MovePosition(_rigidbody.position + (transform.right * axisVal * Time.deltaTime * _speed));
    }
    private bool DetectGround()
    {
        Ray ray = new Ray(this.transform.position, new Vector3(0, -1, 0));

        if (Physics.Raycast(ray, 1.1f, LayerMask.GetMask("Ground")))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
