using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PickUpController : MonoBehaviour {
    
	public Text countText;
	public string Joueur_Gagnant;
    public GameObject winCam;
	public int Score_Joueur;
    public Text winText;
    public static int score_j1, score_j2;
    public static string Gagnant;

	void Start()
	{
        Gagnant = null;
        winCam.SetActive(false);
        Score_Joueur = 0;
		SetCountText ();
	}



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp")) //Sur collision avec un PickUp
        {
            other.gameObject.SetActive(false); //Désactive le pickup
            Score_Joueur = Score_Joueur + other.gameObject.GetComponent<JewelScore>().Score_PickUp; //Augmente le score du joueur (à adapter)
			SetCountText();
		}
    }

	void SetCountText()
	{
		countText.text = "Score: " + Score_Joueur.ToString ();

		//Condition de victoire
		if (Score_Joueur >= 500) 
		{
			if (this.name == "Player") {
				Joueur_Gagnant = "Joueur 1";
                GameObject.Find("Player 2").GetComponent<PickUpController>().Joueur_Gagnant = "Joueur 1";

            }
            else 
			{
				Joueur_Gagnant = "Joueur 2"; //Faire démarrer cinématique de fin
                GameObject.Find("Player").GetComponent<PickUpController>().Joueur_Gagnant = "Joueur 2";
                end();
            }

            score_j1 = GameObject.Find("Player").GetComponent<PickUpController>().Score_Joueur;
            score_j2 = GameObject.Find("Player 2").GetComponent<PickUpController>().Score_Joueur;
            Gagnant = Joueur_Gagnant;
            end();
           
            
            //Scene victoire
        }
        
	}
    void end()
    {
        winCam.SetActive(true);
        winText.text = Joueur_Gagnant + " va au Paradis!";
    }

}
