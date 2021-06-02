using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerObjectScript : MonoBehaviour
{
    public float Power;
    public float DeltaPower;

    private AudioScript _audio;

    private SpriteRenderer _sprite;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _sprite.color = Color.green;
    }

    private void Start()
    {
        _audio = AudioScript.Instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            _sprite.color = Color.red;
            _audio.PlayAudio(AudioType.PowerHit);
            Vector2 delta = collision.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(delta * (Power + Random.Range(0f, 1f) * DeltaPower), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _sprite.color = Color.green;
        }
    }
}
