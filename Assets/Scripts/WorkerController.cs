using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WorkerController : MonoBehaviour
{
    private List<Vector3> _nextPositions = new List<Vector3>();
    private Vector2 _moveDirection = new Vector2();             
    private float _distanceOffset = 0.3f;                       // if distance between worker and next position smaller than this value worker go to next position

    private void AddNextMovePosition()
    {
        _nextPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        GameManager.instance.DrawTrajectoryLine(transform.position, _nextPositions);
    }
    private void MoveToNextPostion()
    {
        _moveDirection = _nextPositions[0] - transform.position;
        transform.Translate(_moveDirection * GameManager.instance.MoveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _nextPositions[0]) < _distanceOffset)
        {
                GameManager.instance.DrawTrajectoryLine(transform.position, _nextPositions);
                _nextPositions.RemoveAt(0);
        }
    }
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
            AddNextMovePosition();

        if (_nextPositions.Count > 0)
            MoveToNextPostion();
    }

}
