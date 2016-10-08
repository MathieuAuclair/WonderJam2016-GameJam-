using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public int maxSpeed;
    public int puissanceSaut;
    public bool facingRight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        float move = Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        if ((move > 0 && !facingRight) || (move < 0 && facingRight))
            Flip();

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.9f);
        if (Input.GetKeyDown(KeyCode.Space) && hit.collider != null)
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, puissanceSaut));
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
