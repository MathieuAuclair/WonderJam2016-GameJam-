using UnityEngine;
using System.Collections;

public class RockController : MonoBehaviour {

	// Use this for initialization
	void Start () {

        float dir = GameObject.Find("Player").transform.localScale.x;

        GetComponent<Rigidbody2D>().AddForce(new Vector2(500*dir,600));
    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if ( other.gameObject.name == "Player" )
        {
            PlayerMovementController playerMvmt = other.gameObject.GetComponent<PlayerMovementController>();
            playerMvmt.hurtPlayer();
        }
        Destroy(this.gameObject);
    }
}
