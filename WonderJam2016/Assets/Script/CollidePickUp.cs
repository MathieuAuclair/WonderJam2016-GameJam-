using UnityEngine;
using System.Collections;

public class CollidePickUp : MonoBehaviour {
	public int Mon_Score; //Score du joueur

	//Script à ajouter au player
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("PickUp")) //Sur collision avec un PickUp
		{
			other.gameObject.SetActive(false); //Désactive le pickup
			Mon_Score = Mon_Score + other.gameObject.GetComponent<JewelScore>().Score_PickUp; //Augmente le score du joueur (à adapter)
		}
	}
}
