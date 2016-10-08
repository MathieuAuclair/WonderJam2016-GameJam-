using UnityEngine;
using System.Collections;

public class TeleporterController : MonoBehaviour {

    public GameObject destination;
    private float timeLeft;
    private bool tp;

    public void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.position = destination.transform.position;
        destination.GetComponent<CircleCollider2D>().enabled = false;
        timeLeft = 2;
        tp = true;
    }

    public void Update()
    {
        if(tp)
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            destination.GetComponent<CircleCollider2D>().enabled = true;
        }
    }

}
