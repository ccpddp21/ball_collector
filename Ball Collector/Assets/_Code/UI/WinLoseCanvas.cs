using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinLoseCanvas : MonoBehaviour
{
    [SerializeField] private BooleanVariable _gameWonVariable;
    [SerializeField] private IntegerVariable _ballsCollectedVariable;
    [SerializeField] private TextMeshProUGUI _winLoseText;
    [SerializeField] private TextMeshProUGUI _gameScoreText;

    public void ShowYouWin(bool didWin)
    {
        if (didWin)
        {
            _winLoseText.text = "You Win!";
        }
        else
        {
            _winLoseText.text = "Try Again?";
        }

        _gameScoreText.text = _ballsCollectedVariable.RuntimeValue.ToString();
    }
}
