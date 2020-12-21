using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Canvas _titleCanvas;
    [SerializeField] private Canvas _hudCanvas;
    [SerializeField] private Canvas _pauseCanvas;
    [SerializeField] private Canvas _winLoseCanvas;

    void Awake()
    {
        ShowTitleCanvas();
    }

    private void HideCanvases()
    {
        if (_titleCanvas.enabled)
        {
            _titleCanvas.enabled = false;
            foreach (Canvas canvas in _titleCanvas.GetComponentsInChildren<Canvas>())
            {
                canvas.enabled = false;
            }
        }

        if (_hudCanvas.enabled)
        {
            _hudCanvas.enabled = false;
            foreach (Canvas canvas in _hudCanvas.GetComponentsInChildren<Canvas>())
            {
                canvas.enabled = false;
            }
        }

        if (_pauseCanvas.enabled)
        {
            _pauseCanvas.enabled = false;
            foreach (Canvas canvas in _pauseCanvas.GetComponentsInChildren<Canvas>())
            {
                canvas.enabled = false;
            }
        }

        if (_winLoseCanvas.enabled)
        {
            _winLoseCanvas.enabled = false;
            foreach (Canvas canvas in _winLoseCanvas.GetComponentsInChildren<Canvas>())
            {
                canvas.enabled = false;
            }
        }
    }

    public void ShowTitleCanvas()
    {
        HideCanvases();
        _titleCanvas.enabled = true;
        foreach (Canvas canvas in _titleCanvas.GetComponentsInChildren<Canvas>())
        {
            canvas.enabled = true;
        }
    }

    public void ShowHudCanvas()
    {
        HideCanvases();
        _hudCanvas.enabled = true;
        foreach (Canvas canvas in _hudCanvas.GetComponentsInChildren<Canvas>())
        {
            canvas.enabled = true;
        }
    }
    public void ShowPauseCanvas()
    {
        HideCanvases();
        _pauseCanvas.enabled = true;
        foreach (Canvas canvas in _pauseCanvas.GetComponentsInChildren<Canvas>())
        {
            canvas.enabled = true;
        }
    }

    public void ShowWinLoseCanvas()
    {
        HideCanvases();
        _winLoseCanvas.enabled = true;
        foreach (Canvas canvas in _winLoseCanvas.GetComponentsInChildren<Canvas>())
        {
            canvas.enabled = true;
        }
    }
}
