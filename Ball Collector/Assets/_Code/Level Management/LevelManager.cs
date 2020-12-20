using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Singleton;

    [SerializeField] private Transform _boundaryMin;
    [SerializeField] private Transform _boundaryMax;

    public Vector3 BoundaryMin
    {
        get { return _boundaryMin.transform.position; }
    }

    public Vector3 BoundaryMax
    {
        get { return _boundaryMax.transform.position; }
    }

    void Awake()
    {
        Singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
