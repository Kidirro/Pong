using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public Rigidbody2D LeftRB2D;
    public Rigidbody2D RightRB2D;

    [SerializeField] private float _power;

    private AudioScript _audio;

    private void Awake()
    {
        RightRB2D.velocity = -Vector2.up * _power;
        LeftRB2D.velocity = -Vector2.up * _power;
        _audio = AudioScript.Instance;
    }

    private void Update()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began)
            {
                _audio.PlayAudio(AudioType.FliperActive);
                if (t.position.x > Camera.main.pixelWidth / 2)
                {
                    RightRB2D.velocity = Vector2.up * _power;
                }
                else
                {
                    LeftRB2D.velocity = Vector2.up * _power;
                }
            }
            else if (t.phase == TouchPhase.Ended)
            {
                if (t.position.x > Camera.main.pixelWidth / 2)
                {
                    RightRB2D.velocity = -Vector2.up * _power;
                }
                else
                {
                    LeftRB2D.velocity = -Vector2.up * _power;
                }
            }
            i++;
        }
    }
}

