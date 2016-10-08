using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour {

    public int speed;
    public int distance;
    public bool facingRight;

    private float xStart;

    // Use this for initialization
    void Start () {
        xStart = transform.position.x;
        if (!facingRight)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
	
	// Update is called once per frame
	void Update () {
        int dir = 1;
        if (!facingRight)
            dir *= -1;
        GetComponent<Rigidbody2D>().velocity = new Vector2(dir * speed, GetComponent<Rigidbody2D>().velocity.y);

        if (facingRight && transform.position.x - xStart >= distance)
            transform.position = new Vector2(xStart - distance, transform.position.y);
        if (!facingRight && xStart - transform.position.x >= distance)
            transform.position = new Vector2(xStart + distance, transform.position.y);
    }
}
