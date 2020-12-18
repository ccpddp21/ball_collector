using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private float _jumpForce;

    void Awake()
    {
        if (_rigidbody == null)
        {
            _rigidbody = this.GetComponent<Rigidbody>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _jumpForce = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && DetectGround())
        {
            Jump();
        }
    }

    private void Jump()
    {
        _rigidbody.AddForce(new Vector3(0, _jumpForce, 0), ForceMode.Impulse);
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
