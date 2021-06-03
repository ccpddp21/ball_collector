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
    private bool _canMove;

    private Ray _groundRay;
    private bool _onGround;

    private bool TouchingForward { get; set; }
    private bool TouchingBackward { get; set; }
    private bool TouchingRight { get; set; }
    private bool TouchingLeft { get; set; }

    void Awake()
    {
        if (_rigidbody == null)
            _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _canMove = true;
        _speed = 10;
        _speedMultiplier = 2f;

        _groundRay = new Ray(transform.position, new Vector3(0, -1, 0));
    }

    void FixedUpdate()
    {
        _onGround = DetectGround();
        DetectObstruction();

        _horizontalVal = Input.GetAxis("Horizontal");
        _verticalVal = Input.GetAxis("Vertical");

        if (_horizontalVal != 0 && !_gamePausedVariable.RuntimeValue && _canMove)
        {
            if ((_horizontalVal > 0 && !TouchingRight) || (_horizontalVal < 0 && !TouchingLeft))
                Strafe(_horizontalVal);
        }


        if (_verticalVal != 0 && !_gamePausedVariable.RuntimeValue && _canMove)
        {
            _verticalVal = Input.GetKey(KeyCode.LeftShift) ? _verticalVal * _speedMultiplier : _verticalVal;

            if ((_verticalVal > 0 && !TouchingForward) || (_verticalVal < 0 && !TouchingBackward))
                MoveForward(_verticalVal);
        }

        if (!_onGround && ((TouchingForward || TouchingBackward || TouchingRight || TouchingLeft)))
            _canMove = false;
        else if (_onGround)
            _canMove = true;
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
        Vector3 pos = transform.position;
        _groundRay.origin = pos;
        if (Physics.Raycast(_groundRay, 1.1f, LayerMask.GetMask("Ground")))
            return true;

        pos = transform.position;
        pos.z += 1f;
        _groundRay.origin = pos;
        if (Physics.Raycast(_groundRay, 1.1f, LayerMask.GetMask("Ground")))
            return true;

        pos = transform.position;
        pos.z -= 1f;
        _groundRay.origin = pos;
        if (Physics.Raycast(_groundRay, 1.1f, LayerMask.GetMask("Ground")))
            return true;

        pos = transform.position;
        pos.x += 1f;
        _groundRay.origin = pos;
        if (Physics.Raycast(_groundRay, 1.1f, LayerMask.GetMask("Ground")))
            return true;

        pos = transform.position;
        pos.x -= 1f;
        _groundRay.origin = pos;
        if (Physics.Raycast(_groundRay, 1.1f, LayerMask.GetMask("Ground")))
            return true;

        return false;
    }

    private void DetectObstruction()
    {
        TouchingForward = Physics.Raycast(transform.position, transform.forward, 1f, LayerMask.GetMask("Ground"));
        TouchingBackward = Physics.Raycast(transform.position, -transform.forward, 1f, LayerMask.GetMask("Ground"));
        TouchingRight = Physics.Raycast(transform.position, transform.right, 1f, LayerMask.GetMask("Ground"));
        TouchingLeft = Physics.Raycast(transform.position, -transform.right, 1f, LayerMask.GetMask("Ground"));

        TouchingRight = TouchingForward = Physics.Raycast(transform.position, (transform.right + transform.forward), 1f, LayerMask.GetMask("Ground"));
        TouchingRight = TouchingBackward = Physics.Raycast(transform.position, (transform.right + -transform.forward), 1f, LayerMask.GetMask("Ground"));
        TouchingLeft = TouchingForward = Physics.Raycast(transform.position, (-transform.right + transform.forward), 1f, LayerMask.GetMask("Ground"));
        TouchingLeft = TouchingBackward = Physics.Raycast(transform.position, (-transform.right + -transform.forward), 1f, LayerMask.GetMask("Ground"));
    }
}
