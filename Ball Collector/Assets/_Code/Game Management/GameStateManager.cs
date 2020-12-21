using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Singleton;

    [SerializeField] private GameEvent _gameStartedEvent;
    [SerializeField] private GameEvent _gamePausedEvent;
    [SerializeField] private GameEvent _gameUnpausedEvent;
    [SerializeField] private GameEvent _gameResetEvent;
    [SerializeField] private GameEvent _gameEndedEvent;
    [SerializeField] private BooleanVariable _gameStartedVariable;
    [SerializeField] private BooleanVariable _gamePausedVariable;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!_gameStartedVariable.RuntimeValue)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                StartNewGame();
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
        }
        else if (_gameStartedVariable.RuntimeValue)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (_gamePausedVariable.RuntimeValue)
                {
                    UnpauseGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }
    }

    public void StartNewGame()
    {
        _gameStartedEvent.Raise();
        _gamePausedVariable.RuntimeValue = false;
        _gameStartedVariable.RuntimeValue = true;
    }

    private void PauseGame()
    {
        _gamePausedEvent.Raise();
        _gamePausedVariable.RuntimeValue = true;
    }

    private void UnpauseGame()
    {
        _gameUnpausedEvent.Raise();
        _gamePausedVariable.RuntimeValue = false;
    }

    public void ResetGame()
    {
        _gameResetEvent.Raise();
        _gamePausedVariable.RuntimeValue = false;
        _gameStartedVariable.RuntimeValue = true;
    }

    public void EndGame()
    {
        _gameEndedEvent.Raise();
        _gamePausedVariable.RuntimeValue = false;
        _gameStartedVariable.RuntimeValue = false;
    }
}
