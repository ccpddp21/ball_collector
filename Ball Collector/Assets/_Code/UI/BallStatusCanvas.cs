using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallStatusCanvas : MonoBehaviour
{
    [SerializeField] private IntegerVariable _ballsRemainingVariable;
    [SerializeField] private GameObject _findBallText;
    [SerializeField] private GameObject _returnBallText;
    [SerializeField] private TextMeshProUGUI _ballsLeftText;
    [SerializeField] private Image _ballStatusImage;

    private Color _defaultColor = Color.white;
    private Color32 _foundColor = new Color32(255, 180, 30, 255);

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

    public void UpdateBallsRemaining()
    {
        _ballsLeftText.text = _ballsRemainingVariable.RuntimeValue.ToString();
    }
}
