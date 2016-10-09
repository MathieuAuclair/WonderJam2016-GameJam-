using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour {

    public float maxSpeed;
    public int puissanceSaut;
    public LayerMask layerPlatform;
    public int hurtDurationMax;
    public int playerNum;

    private bool onGround;
    private bool facingRight = true;
    private bool hurt = false;
    private int hurtDuration;
    private Animator anim;


    void Start () {
        anim = GetComponent<Animator>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colision Detected");
        onGround = true;
    }

        void FixedUpdate () {

        if (!hurt)
        {
            // Déplacement gauche droite

            float move = Input.GetAxisRaw("Horizontal_P"+playerNum);
            anim.SetFloat("speed", Mathf.Abs(move));
            transform.position += new Vector3(move * maxSpeed, 0, 0);
            if ((move > 0 && !facingRight) || (move < 0 && facingRight))
                Flip();

            // Saut

         

                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.9f, layerPlatform);
            if (Input.GetButton("Jump_P"+playerNum)&&onGround==true && hit.collider != null)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector3(0, puissanceSaut, 0));
                onGround = false;
            }
                anim.SetBool("grounded", hit.collider != null);
        }
        else
        {
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
