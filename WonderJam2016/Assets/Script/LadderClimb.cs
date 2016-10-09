using UnityEngine;
using System.Collections;

public class LadderClimb : MonoBehaviour {

    public int jump;
    private bool up;
    private GameObject Player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("collision ok");
            other.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, jump, 0));
        }
        Player = other.gameObject;
    }

}
