using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingScript : MonoBehaviour
{
    public Direction RotateDirection;
    public float Power;
    private Rigidbody2D _rb2D;

    public void ChangeRotate()
    {
        RotateDirection = (Direction)(-(int)RotateDirection);
        _rb2D.angularVelocity = Power * (int)RotateDirection;
    }

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        if (_rb2D == null) _rb2D = gameObject.AddComponent<Rigidbody2D>();
        _rb2D.isKinematic = true;
        _rb2D.angularVelocity = Power *(int) RotateDirection;
    }
}

public enum Direction
{
    Clockwise=-1,
    CounterClockwise=1
}