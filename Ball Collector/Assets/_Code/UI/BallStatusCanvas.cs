using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallStatusCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _findBallText;
    [SerializeField] private GameObject _returnBallText;
    [SerializeField] private Image _ballStatusImage;

    private Color _defaultColor = Color.white;
    private Color _foundColor = new Color(255, 180, 30, 255);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowReturnBall()
    {
        _findBallText.SetActive(false);
        _returnBallText.SetActive(true);
        _ballStatusImage.color = _foundColor;
    }

    public void ShowFindBall()
    {
        _returnBallText.SetActive(false);
        _findBallText.SetActive(true);
        _ballStatusImage.color = _defaultColor;
    }
}
