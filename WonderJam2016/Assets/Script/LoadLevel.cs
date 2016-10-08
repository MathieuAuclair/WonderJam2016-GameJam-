using UnityEngine;
using System.Collections;
//add this script on door not the the player!!!
public class LoadLevel : MonoBehaviour {

    public float Xteleport;
    public float Yteleport;

    void OnTriggerEnter(Collider other)
    {
        other.transform.position = new Vector3(Xteleport, Yteleport, 0);
    }
}
