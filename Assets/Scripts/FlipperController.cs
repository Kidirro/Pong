using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public Rigidbody2D LeftRB2D;
    public Rigidbody2D RightRB2D;

    [SerializeField] private float _power;

    private void Update()
    {
        /*        int i = 0;
                while (i < Input.touchCount)
                {
                    Touch t = Input.GetTouch(i);
                    if (t.position.x > Camera.main.pixelWidth/2)
                    {
                        StopCoroutine(_rightFlipperProcess);
                        _rightFlipperProcess = StartCoroutine(RightFlipperProcess());
                    }
                    else
                    {
                        StopCoroutine(_leftFlipperProcess); ;
                        _leftFlipperProcess = StartCoroutine(RightFlipperProcess());
                    }
                }*/
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x > Camera.main.pixelWidth / 2)
            {
                RightRB2D.velocity = Vector2.up * _power;
            }
            else
            {
                LeftRB2D.velocity = Vector2.up * _power;
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            if (Input.mousePosition.x > Camera.main.pixelWidth / 2)
            {
                RightRB2D.velocity = -Vector2.up * _power;
            }
            else
            {
                LeftRB2D.velocity = -Vector2.up * _power;
            }

        }
    }
}

