using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class PickUpController : MonoBehaviour {
    
	public Text countText;
	public string Joueur_Gagnant;

	public int Score_Joueur;


	void Start()
	{
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
		if (Score_Joueur >= 20) 
		{
			if (this.name == "Player") {
				Joueur_Gagnant = "Joueur 1";
			} 
			else 
			{
				Joueur_Gagnant = "Joueur 2"; //Faire démarrer cinématique de fin
			}
		}
	}

}
