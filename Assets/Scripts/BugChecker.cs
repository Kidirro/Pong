using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugChecker : MonoBehaviour
{
    private Vector2 _starterPosition;
    private Rigidbody2D _rb2d;

    private float _timer;

    private void Start()
    {
        _starterPosition = transform.position;
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Wall" && _rb2d.velocity.magnitude<0.1f)
        {
            Debug.Log("STUCK!!");
            _timer += Time.deltaTime;
            if (_timer > 2)
            {
                _rb2d.velocity = Vector2.zero;
                transform.position = _starterPosition;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _timer = 0;
    }
}
