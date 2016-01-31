using UnityEngine;
using System.Collections;

public class PlayerDanceScript : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(anim.GetInteger("DancingDir") == 0)
		{
			if(Input.GetKeyDown (KeyCode.LeftArrow))
				anim.SetInteger ("DancingDir", 1);

			if(Input.GetKeyDown (KeyCode.UpArrow))
				anim.SetInteger ("DancingDir", 2);

			if(Input.GetKeyDown (KeyCode.DownArrow))
				anim.SetInteger ("DancingDir", 3);

			if(Input.GetKeyDown (KeyCode.RightArrow))
				anim.SetInteger ("DancingDir", 4);
		}
		else
		{
			anim.SetInteger ("DancingDir", 0);
		}
	}
}
