using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public Rigidbody2D LeftRB2D;
    public Rigidbody2D RightRB2D;

    static public FlipperController Instance => _instance;
    private static FlipperController _instance;
    public bool AutoFlippers
    {
        set
        {
            _leftTrigger.SetActive(value);
            _rightTrigger.SetActive(value);
            _autoFlippers = value;
        }
        get
        {
            return _autoFlippers;
        }
    }

    private bool _autoFlippers = false;
    
    [SerializeField] private float _power;

    private GameObject _leftTrigger;
    private GameObject _rightTrigger;

    private AudioScript _audio;

    private void Awake()
    {
        _instance = this;
        RightRB2D.velocity = -Vector2.up * _power;
        LeftRB2D.velocity = -Vector2.up * _power;
        _audio = AudioScript.Instance;
        _leftTrigger = LeftRB2D.gameObject.transform.GetChild(0).gameObject;
        _rightTrigger = RightRB2D.gameObject.transform.GetChild(0).gameObject;
    }

    private void Update()
    { 
        if (!Application.isEditor)
        {
            int i = 0;
            while (i < Input.touchCount)
            {
                Touch t = Input.GetTouch(i);
                if (t.phase == TouchPhase.Began)
                {
                    if (t.position.x > Camera.main.pixelWidth / 2)
                    {
                        FlipperMoving(false);
                    }
                    else
                    {
                        FlipperMoving(true);
                    }
                }
                i++;
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                if (Input.mousePosition.x > Camera.main.pixelWidth / 2)
                {
                    FlipperMoving(false);
                }
                else
                {
                    FlipperMoving(true);
                }
            }
        }
    }

    public void FlipperMoving(bool left)
    {

        _audio.PlayAudio(AudioType.FliperActive);
        if (left)
        {
            LeftRB2D.velocity = Vector2.up * _power;
        }
        else
        {
            RightRB2D.velocity = Vector2.up * _power;
        }
    }

}

