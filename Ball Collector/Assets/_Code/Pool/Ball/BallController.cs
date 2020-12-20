using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject _groundDetectorPoint;

    private Ray _ray;
    private RaycastHit _hit;

    void Awake()
    {
        _ray = new Ray(_groundDetectorPoint.transform.position, new Vector3(0, -1, 0));
    }

    void OnEnable()
    {
        DetectGround();
    }

    void OnDisable()
    {
        this.transform.localPosition = new Vector3(0, 0, 0);
    }

    private void DetectGround()
    {
        if (Physics.Raycast(_ray, out _hit))
        {
            this.transform.position = new Vector3(_hit.point.x, _hit.point.y + 1, _hit.point.z);
        }
    }
}
