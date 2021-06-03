using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCollectionPoint : MonoBehaviour
{
    [SerializeField] private GameObject _beam;

    void Awake()
    {
        Deactivate();
    }

    public void Activate()
    {
        _beam.SetActive(true);
    }

    public void Deactivate()
    {
        _beam.SetActive(false);
    }
}
