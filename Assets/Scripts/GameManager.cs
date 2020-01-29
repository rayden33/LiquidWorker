using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public LineRenderer _trajectoryLineRenderer;
    public static GameManager instance = null;

    [SerializeField] private float _maxMoveSpeed = 1f;
    private float _moveSpeed;                           
    public float MoveSpeed
    {
        get { return _moveSpeed; }
    }

    public void DrawTrajectoryLine(Vector2 _workerPosition, List<Vector3> _nextPositions)
    {
        if (_trajectoryLineRenderer == null)
            _trajectoryLineRenderer = gameObject.AddComponent<LineRenderer>();

        _trajectoryLineRenderer.positionCount = _nextPositions.Count + 1;
        _trajectoryLineRenderer.SetPosition(0, _workerPosition);

        for (int i = 0; i < _nextPositions.Count; i++)
        {
                _trajectoryLineRenderer.SetPosition(i + 1, (Vector2) _nextPositions[i]);
        }
    }

    public void ChangeSpeed(float _sliderValue)
    {
        _moveSpeed = _maxMoveSpeed * _sliderValue;
    }
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

}
