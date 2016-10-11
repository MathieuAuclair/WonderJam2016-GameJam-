using UnityEngine;
using System.Collections;

public class Transfert : MonoBehaviour {

    public int score_j1, score_j2;
    public string gagnant;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Use this for initialization
    void Start () {
        score_j1 = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
