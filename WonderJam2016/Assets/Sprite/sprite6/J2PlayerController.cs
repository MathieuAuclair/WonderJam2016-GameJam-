using UnityEngine;
using System.Collections;

public class J2PlayerController : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start () 
	{
		animator = this.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () 
	{
		var horizontal = Input.GetAxis("Horizontal");

		if (horizontal > 0) 
		{
			animator.SetInteger ("DirectionJ2", 0);
		} 
		else 
		{
			animator.SetInteger ("DirectionJ2", 1);
		}
	}
}