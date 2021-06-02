using UnityEngine.Events;
using UnityEngine;

public class TriggerInvoke : MonoBehaviour
{
    public UnityEvent TriggerEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TriggerEvent.Invoke();
        }
    }
}
