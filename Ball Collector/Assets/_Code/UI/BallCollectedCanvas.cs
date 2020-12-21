using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallCollectedCanvas : MonoBehaviour
{
    [SerializeField] private IntegerVariable _ballsCollectedVariable;
    [SerializeField] private TextMeshProUGUI _ballsCollectedText;

    // Update is called once per frame
    public void UpdateScore()
    {
        _ballsCollectedText.text = _ballsCollectedVariable.RuntimeValue.ToString();
    }
}
