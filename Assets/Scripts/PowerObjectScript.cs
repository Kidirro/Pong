using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerObjectScript : MonoBehaviour
{
    public float Power;
    public float DeltaPower;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Vector2 delta = collision.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(delta * (Power + Random.Range(0f, 1f) * DeltaPower), ForceMode2D.Impulse);
        }
    }
}
