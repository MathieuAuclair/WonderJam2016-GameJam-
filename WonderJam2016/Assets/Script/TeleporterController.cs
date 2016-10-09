using UnityEngine;
using System.Collections;

public class TeleporterController : MonoBehaviour {

    public GameObject destination;
    private bool tp = false;
    private float timeLeft;

    public void OnTriggerEnter2D(Collider2D other)
    {
        destination.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        other.transform.position = destination.transform.position;
        timeLeft = 2;
        tp = true;
    }
    void Update()
    {
        if (tp)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                tp = false;
                destination.gameObject.GetComponent<CircleCollider2D>().enabled = true;
            }
        }
    }
}
