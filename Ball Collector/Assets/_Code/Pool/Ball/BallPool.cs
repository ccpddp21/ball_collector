using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
    public static BallPool Singleton;

    [SerializeField] private List<GameObject> _ballPoolList = new List<GameObject>();

    private int _poolIndex;

    void Awake()
    {
        Singleton = this;

        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(false);
            _ballPoolList.Add(this.transform.GetChild(i).gameObject);
        }
    }

    public void ResetPool()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
