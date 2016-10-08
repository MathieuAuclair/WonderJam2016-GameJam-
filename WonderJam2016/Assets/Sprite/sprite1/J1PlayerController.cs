using UnityEngine;
using System.Collections;

public class J1PlayerController : MonoBehaviour {

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
			animator.SetInteger ("Direction", 0);
		} 
		else 
		{
			animator.SetInteger ("Direction", 1);
		}
	}
}
