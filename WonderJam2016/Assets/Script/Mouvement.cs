using UnityEngine;
using System.Collections;

public class Mouvement : MonoBehaviour
{
    public float vitesseDeplacement = 0.1f; //Vitesse horizontale
    public float hauteurSaut = 150f;
    public string joueur;

    private Vector3 initialScale;
    private float axeDeplacement;
    private float axeSaut;
    private Rigidbody2D rigidBody;
    public bool aTerre;

    // Use this for initialization
    void Start()
    {
        aTerre = true;
        initialScale = transform.localScale;
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.freezeRotation = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Orientation du sprite
        axeDeplacement = Input.GetAxis("Deplacement" + joueur);
        if (axeDeplacement > 0) //Bouge vers la droite
            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
        if (axeDeplacement < 0)
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
    }

    //Gestion du rigid body
    void FixedUpdate()
    {
        //Gestion déplacement horizontal
        axeDeplacement = Input.GetAxis("Deplacement" + joueur);
            rigidBody.AddForce(Vector2.right * 150 * axeDeplacement); //Donne une forte force dans la direction du mouvement
            //Attenuation de la vitesse
            if (rigidBody.velocity.x > vitesseDeplacement)
                rigidBody.velocity = new Vector2(vitesseDeplacement, rigidBody.velocity.y);
            if (rigidBody.velocity.x < -vitesseDeplacement)
                rigidBody.velocity = new Vector2(-vitesseDeplacement, rigidBody.velocity.y);
        //Saut
        axeSaut = Input.GetAxis("Saut" + joueur);
        if (axeSaut != 0 && aTerre)
            rigidBody.AddForce(Vector2.up * hauteurSaut);
    }

    //Gestion de collision
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Sol")
            aTerre = true;
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Sol")
            aTerre = true;
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Sol")
            aTerre = false;
    }
}
