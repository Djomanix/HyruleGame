using UnityEngine;
using System.Collections;

public class PlayerOverworldController : MonoBehaviour {

	Animator anim;
	Rigidbody2D rb;

	Vector3 dir;

	public float speed = 1.0f;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		dir = rb.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {

		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3(horizontal, vertical, 0.0f);

		if(horizontal != 0 || vertical != 0)
		{
			anim.SetBool("IsWalking", true);
		}
		else
		{
			anim.SetBool("IsWalking", false);
		}

		rb.transform.position += movement * speed;

		if(horizontal < 0)
			dir.x = -1;
		else if (horizontal > 0)
			dir.x = 1;

		rb.transform.localScale = dir;
	
	}
}
