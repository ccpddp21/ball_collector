using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReturnBall : MonoBehaviour
{
    [SerializeField] private GameEvent _ballReturnedEvent;
    [SerializeField] private GameEvent _ballsClearedEvent;
    [SerializeField] private BooleanVariable _hasBallVariable;
    [SerializeField] private IntegerVariable _ballsCollectedVariable;
    [SerializeField] private IntegerVariable _ballsRemainingVariable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collection Point")
        {
            _hasBallVariable.RuntimeValue = false;
            _ballsCollectedVariable.RuntimeValue += 1;
            _ballsRemainingVariable.RuntimeValue -= 1;
            _ballReturnedEvent.Raise();

            if (_ballsRemainingVariable.RuntimeValue <= 0)
            {
                _ballsClearedEvent.Raise();
            }
        }
    }
}
