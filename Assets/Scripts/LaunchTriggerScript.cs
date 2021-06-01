using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchTriggerScript : MonoBehaviour
{

    public float Power;
    public float DeltaPower;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up*(Power+Random.Range(0f,1f)*DeltaPower),ForceMode2D.Impulse);
        }
    }
}
