using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReturnBall : MonoBehaviour
{
    [SerializeField] private GameEvent _ballReturnedEvent;
    [SerializeField] private BooleanVariable _hasBallVariable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collection Point")
        {
            _hasBallVariable.RuntimeValue = false;
            _ballReturnedEvent.Raise();
        }
    }
}
