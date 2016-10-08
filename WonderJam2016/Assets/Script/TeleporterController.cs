using UnityEngine;
using System.Collections;

public class TeleporterController : MonoBehaviour {

    public TeleporterController destination;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void Teleportation ( GameObject obj )
    {
        obj.transform.position = destination.transform.position;
    }
}
