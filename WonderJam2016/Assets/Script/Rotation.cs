using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
    public float speed;
	void LateUpdate () {
        transform.Rotate(new Vector3(0, 0, speed));  
	}
}
