using UnityEngine;
using System.Collections;

public class FollowPlayerScript : MonoBehaviour {

	public GameObject playerPos;

	Vector3 camPos;

	// Use this for initialization
	void Start () {

		camPos = new Vector3(playerPos.transform.position.x,
		                     playerPos.transform.position.y, -10.0f);
	}
	
	// Update is called once per frame
	void Update () {
		camPos = new Vector3(playerPos.transform.position.x,
		                     playerPos.transform.position.y + 5.0f, -10.0f);
		transform.position = camPos;
	}
}
