using UnityEngine;
using System.Collections;

public class PlayerDanceScript : MonoBehaviour {

	Animator anim;
	int danceNum = 0;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(anim.GetInteger("DancingDir") == 0 || anim.GetInteger("DancingDir") == 5)
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
			anim.SetInteger ("DancingDir", danceNum);
		}
	}

	public void SetDance(int num)
	{
		danceNum = 5;
	}
}
