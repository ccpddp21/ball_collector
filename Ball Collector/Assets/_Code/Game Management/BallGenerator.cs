using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    public static BallGenerator Singleton;

    [SerializeField] private IntegerVariable _ballsRemaining;
    [SerializeField] private List<string> _ballLocationList = new List<string>();
    [SerializeField] private GameObject _ballPoolContainer;

    private string _levelCenter;
    private string _ballLocation;
    private int _randX, _randZ;

    void Awake()
    {
        Singleton = this;
    }

    public void GenerateBalls()
    {
        Vector3 center = (LevelManager.Singleton.BoundaryMin + LevelManager.Singleton.BoundaryMax) / 2;
        _levelCenter = string.Format("{0},{1},{2}", center.x, center.y, center.z);
        _ballLocationList.Add(_levelCenter);

        for (int i = 0; i < _ballPoolContainer.transform.childCount; i++)
        {
            do
            {
                _randX = Random.Range(Mathf.RoundToInt(LevelManager.Singleton.BoundaryMin.x + 1), Mathf.RoundToInt(LevelManager.Singleton.BoundaryMax.x));
                _randZ = Random.Range(Mathf.RoundToInt(LevelManager.Singleton.BoundaryMin.z + 1), Mathf.RoundToInt(LevelManager.Singleton.BoundaryMax.z));

                _ballLocation = string.Format("{0},{1},{2}", _randX, LevelManager.Singleton.BoundaryMin.y, _randZ);
            } while (_ballLocationList.Contains(_ballLocation));

            _ballLocationList.Add(_ballLocation);

            _ballPoolContainer.transform.GetChild(i).position = new Vector3(_randX, LevelManager.Singleton.BoundaryMin.y, _randZ);
            _ballPoolContainer.transform.GetChild(i).gameObject.SetActive(true);

            _ballsRemaining.RuntimeValue += 1;
        }
    }
}
