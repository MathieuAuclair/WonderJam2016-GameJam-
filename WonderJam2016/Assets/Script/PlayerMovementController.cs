using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour {

    public float maxSpeed;
    public int puissanceSaut;
    public LayerMask layerPlatform;
    public LayerMask layerLadder;
    public int hurtDurationMax;
    public int playerNum;

    private bool onGround;
    private bool facingRight = true;
    private bool hurt = false;
    private int hurtDuration;
    private bool grimpe = false;
    private Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colision Detected");
        onGround = true;
    }

    // Update is called once per frame
    void FixedUpdate () {

        if (!hurt)
        {
            if (grimpe)
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            // Déplacement gauche droite

            float move = Input.GetAxisRaw("Horizontal_P"+playerNum);
            anim.SetFloat("speed", Mathf.Abs(move));
            if (!grimpe)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
                anim.SetInteger("typeGrimpe", -1);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed / 2, GetComponent<Rigidbody2D>().velocity.y);
                if ( move != 0 )
                    anim.SetInteger("typeGrimpe", 2);
                else
                    anim.SetInteger("typeGrimpe", 0);
            }
            if ((move > 0 && !facingRight) || (move < 0 && facingRight))
                Flip();

            // Saut

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.9f, layerPlatform);
            if (Input.GetButton("Jump_P" + playerNum) && onGround == true && hit.collider != null)
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, puissanceSaut));
            anim.SetBool("grounded", hit.collider != null);

            // Monter descendre échelle
            
            hit = Physics2D.Raycast(transform.position, Vector2.zero, 0.9f, layerLadder);
            if (Input.GetButton("Jump_P" + playerNum) && onGround == true && hit.collider != null)
                grimpe = true;
            if (hit.collider == null)
                grimpe = false;

            if ( grimpe )
            {
                GetComponent<Rigidbody2D>().gravityScale = 0;
                move = Input.GetAxisRaw("Vertical");
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, move * maxSpeed/2);
                if (move != 0 && anim.GetInteger("typeGrimpe") != 2)
                    anim.SetInteger("typeGrimpe", 1);
            } else
            {
                GetComponent<Rigidbody2D>().gravityScale = 1;
                anim.SetInteger("typeGrimpe", -1);
            }
        }
        else
        {
            grimpe = false;
            GetComponent<Rigidbody2D>().gravityScale = 1;
            hurtDuration += 1;
            if (hurtDuration >= hurtDurationMax)
            {
                hurt = false;
                anim.SetBool("hurt", false);
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void hurtPlayer()
    {
        hurt = true;
        hurtDuration = 0;
        anim.SetBool("hurt", true);
    }
}
