using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {
    public Text gameOverText;
    public GameObject CameraGameOver;
    void Start()
    {
        CameraGameOver.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        CameraGameOver.SetActive(true);
        gameOverText.text = "Game Over";
        other.gameObject.SetActive(false);
    }
}
