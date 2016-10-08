using UnityEngine;
using System.Collections;

public class Mouvement : MonoBehaviour
{
    public float vitesseDeplacement = 0.1f; //Vitesse horizontale
    public float hauteurSaut = 150f;

    private Vector3 initialScale;
    private float axeDeplacement;
    private float axeSaut;
    private Rigidbody2D rigidBody;
    public bool aTerre;
    public bool toucheMur;

    // Use this for initialization
    void Start()
    {
        aTerre = true;
        initialScale = transform.localScale;
        rigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Orientation du sprite
        axeDeplacement = Input.GetAxis("Horizontal");
        if (axeDeplacement > 0) //Bouge vers la droite
            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
        if (axeDeplacement < 0)
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
    }

    //Gestion du rigid body
    void FixedUpdate()
    {
        //Gestion déplacement horizontal
        axeDeplacement = Input.GetAxis("Horizontal");
        if (!toucheMur)
        {
            rigidBody.AddForce(Vector2.right * 150 * axeDeplacement); //Donne une forte force dans la direction du mouvement
            //Attenuation de la vitesse
            if (rigidBody.velocity.x > vitesseDeplacement)
                rigidBody.velocity = new Vector2(vitesseDeplacement, rigidBody.velocity.y);
            if (rigidBody.velocity.x < -vitesseDeplacement)
                rigidBody.velocity = new Vector2(-vitesseDeplacement, rigidBody.velocity.y);
        }
        //Saut
        axeSaut = Input.GetAxis("Jump");
        if (axeSaut != 0 && aTerre)
            rigidBody.AddForce(Vector2.up * hauteurSaut);
    }

    //Gestion de collision
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Mur")
            toucheMur = true;
        if (coll.gameObject.tag == "Sol")
        {
            aTerre = true;
            toucheMur = false;
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Sol")
        {
            aTerre = true;
            toucheMur = false;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Sol")
            aTerre = false;
        if (coll.gameObject.tag == "Mur")
            toucheMur = false;
    }
}
