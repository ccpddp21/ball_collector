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
            _titleCanvas.gameObject.SetActive(false);
        }

        if (_hudCanvas.enabled)
        {
            _hudCanvas.enabled = false;
            foreach (Canvas canvas in _hudCanvas.GetComponentsInChildren<Canvas>())
            {
                canvas.enabled = false;
            }
            _hudCanvas.gameObject.SetActive(false);
        }

        if (_pauseCanvas.enabled)
        {
            _pauseCanvas.enabled = false;
            foreach (Canvas canvas in _pauseCanvas.GetComponentsInChildren<Canvas>())
            {
                canvas.enabled = false;
            }
            _pauseCanvas.gameObject.SetActive(false);
        }

        if (_winLoseCanvas.enabled)
        {
            _winLoseCanvas.enabled = false;
            foreach (Canvas canvas in _winLoseCanvas.GetComponentsInChildren<Canvas>())
            {
                canvas.enabled = false;
            }
            _winLoseCanvas.gameObject.SetActive(false);
        }
    }

    public void ShowTitleCanvas()
    {
        HideCanvases();
        _titleCanvas.gameObject.SetActive(true);
        _titleCanvas.enabled = true;
        foreach (Canvas canvas in _titleCanvas.GetComponentsInChildren<Canvas>())
        {
            canvas.enabled = true;
        }
    }

    public void ShowHudCanvas()
    {
        HideCanvases();
        _hudCanvas.gameObject.SetActive(true);
        _hudCanvas.enabled = true;
        foreach (Canvas canvas in _hudCanvas.GetComponentsInChildren<Canvas>())
        {
            canvas.enabled = true;
        }
    }
    public void ShowPauseCanvas()
    {
        HideCanvases();
        _pauseCanvas.gameObject.SetActive(true);
        _pauseCanvas.enabled = true;
        foreach (Canvas canvas in _pauseCanvas.GetComponentsInChildren<Canvas>())
        {
            canvas.enabled = true;
        }
    }

    public void ShowWinLoseCanvas()
    {
        HideCanvases();
        _winLoseCanvas.gameObject.SetActive(true);
        _winLoseCanvas.enabled = true;
        foreach (Canvas canvas in _winLoseCanvas.GetComponentsInChildren<Canvas>())
        {
            canvas.enabled = true;
        }
    }
}
