using UnityEngine;
using System.Collections;

public class SightController : MonoBehaviour {

    public GameObject rock;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(rock, new Vector2(0,0), transform.rotation);
            //Instantiate(rock, GameObject.Find("Sight").transform.position, transform.rotation);
        }
    }
}
