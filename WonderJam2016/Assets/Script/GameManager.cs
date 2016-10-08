using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static int score = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void augmenterScore( int n )
    {
        if (n > 0)
            score += n;
    }

    public static void baisserScore ( int n )
    {
        if (n > 0)
            score -= n;
        if (score < 0)
            score = 0;
    }
}
