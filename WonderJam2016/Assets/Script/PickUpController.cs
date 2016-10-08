using UnityEngine;
using System.Collections;

public class PickUpController : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp")) //Sur collision avec un PickUp
        {
            other.gameObject.SetActive(false); //Désactive le pickup
            //GameManager.augmenterScore(other.gameObject.GetComponent<JewelScore>().Score_PickUp); //Augmente le score du joueur (à adapter)
        }
    }
}
