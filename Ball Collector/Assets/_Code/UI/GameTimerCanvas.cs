using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimerCanvas : MonoBehaviour
{
    [SerializeField] private GameEvent _gameLoseEvent;
    [SerializeField] private BooleanVariable _gameStartedVariable;
    [SerializeField] private BooleanVariable _gamePausedVariable;
    [SerializeField] private IntegerVariable _gameTimerVariable;
    [SerializeField] private TextMeshProUGUI _gameTimerText;

    private int _defaultTime = 10;
    private float _timer;

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameStartedVariable.RuntimeValue && !_gamePausedVariable.RuntimeValue)
        {
            _timer = _timer - 1 * Time.deltaTime;
            _gameTimerVariable.RuntimeValue = Mathf.CeilToInt(_timer);
            _gameTimerText.text = _gameTimerVariable.RuntimeValue.ToString();

            if (_gameTimerVariable.RuntimeValue <= 0)
            {
                _gameLoseEvent.Raise();
            }
        }
    }

    public void ResetTimer()
    {
        _timer = _defaultTime;
        _gameTimerVariable.RuntimeValue = _defaultTime;
        _gameTimerText.text = _gameTimerVariable.RuntimeValue.ToString();
    }

    public void AddTime()
    {
        _timer += 5;
    }
}
