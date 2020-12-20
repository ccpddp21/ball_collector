using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectBall : MonoBehaviour
{
    [SerializeField] private GameEvent _ballCollectedEvent;
    [SerializeField] private BooleanVariable _hasBallVariable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball" && !_hasBallVariable.RuntimeValue)
        {
            _hasBallVariable.RuntimeValue = true;
            _ballCollectedEvent.Raise();
            other.gameObject.SetActive(false);
        }
    }
}
