using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _detector;

    private float _jumpForce;
    [SerializeField] private float _velocityX;
    [SerializeField] private float _velocityZ;

    [SerializeField] private bool _jumping;
    private bool _canJump;

    private WaitForSeconds secs;
    private bool _onGround;

    void Awake()
    {
        if (_rigidbody == null)
        {
            _rigidbody = this.GetComponent<Rigidbody>();
        }

        if (_animator == null)
            _animator = GetComponentInChildren<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _jumpForce = 8;
        _canJump = true;

        secs = new WaitForSeconds(1f);
    }

    void FixedUpdate()
    {
        _velocityX = _rigidbody.velocity.x;
        _velocityZ = _rigidbody.velocity.z;

        _onGround = DetectGround();

        if (Input.GetKeyDown(KeyCode.Space) && _onGround && _canJump)
        {
            _animator.SetBool("IsSprint", false);
            _animator.SetBool("IsWalk", false);
            _animator.SetTrigger("Jump");
            Jump();
        }
    }

    private void Jump()
    {
        _canJump = false;
        _rigidbody.AddForce(new Vector3(_velocityX, _jumpForce, _velocityZ), ForceMode.Impulse);
        StartCoroutine(JumpWait());
    }

    private IEnumerator JumpWait()
    {
        yield return secs;
        _jumping = true;
    }

    private bool DetectGround()
    {
        Ray ray = new Ray(_detector.position, -transform.up);

        if (Physics.Raycast(ray, 1.1f, LayerMask.GetMask("Ground")))
        {
            if (_jumping)
            {
                _animator.SetTrigger("HitGround");
                _jumping = false;
                _canJump = true;
            }

            return true;
        }
        else
        {
            return false;
        }
    }
}
