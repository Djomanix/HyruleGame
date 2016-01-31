using UnityEngine;
using System.Collections;

public class PlayerOverworldController : MonoBehaviour {

	Animator anim;
	Rigidbody2D rb;

	public Transform spawnPoint;

	int sortOrder = 1;
	public bool isBehind = false;

	Vector3 dir;
	//Vector3 temp = new Vector3(0, 0, 0);

	public float speed = 0.1f;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		dir = rb.transform.localScale;

		transform.position = spawnPoint.position;
	}
	
	// Update is called once per frame
	void Update () {

		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3(horizontal, vertical, 0.0f);

		if(Input.GetKey (KeyCode.LeftShift))
		{
			speed = 0.5f;
		}
		else
		{
			speed = 0.1f;
		}

		if(Input.GetKeyDown(KeyCode.F))
		{
			anim.SetBool("IsDancing", true);
		}

		if(horizontal != 0 || vertical != 0)
		{
			anim.SetBool("IsWalking", true);
			anim.SetBool("IsDancing", false);
        }
		else
		{
			anim.SetBool("IsWalking", false);
		}
        


		rb.transform.position += movement * speed;

		if(horizontal < 0 && dir.x == 2)
			dir.x = -2;
		else if (horizontal > 0 && dir.x == -2)
			dir.x = 2;

		rb.transform.localScale = dir;	
	}

	void OnTriggerStay2D(Collider2D other)
	{
		isBehind = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(!isBehind)
		{
			GetComponent<Renderer>().sortingOrder = sortOrder;
		}

		isBehind = false;
	}

}
