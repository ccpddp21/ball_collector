using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectBall : MonoBehaviour
{
    [SerializeField] private GameEvent _ballCollectedEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            _ballCollectedEvent.Raise();
            other.gameObject.SetActive(false);
        }
    }
}
