using UnityEngine;
using System.Collections;

public class RitualController : MonoBehaviour {

	public GameObject objParent;

	public Transform upArrowSpawn;
	public Transform rightArrowSpawn;
	public Transform leftArrowSpawn;
	public Transform downArrowSpawn;

	public Vector3[] spawnLocations = new Vector3[4];

	public GameObject arrow;

	public GameObject pressTop;
	public GameObject pressRight;
	public GameObject pressLeft;
	public GameObject pressBot;

	private int rand;
	// Use this for initialization
	void Start () 
	{
		spawnLocations[0] = upArrowSpawn.position;
		spawnLocations[1] = leftArrowSpawn.position;
		spawnLocations[2] = downArrowSpawn.position;
		spawnLocations[3] = rightArrowSpawn.position;

		StartCoroutine ("RitualDance");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	IEnumerator RitualDance()
	{
		while(true)
		{
			yield return new WaitForSeconds(1);

			rand = Random.Range (0, 4);
			GameObject instance =
				Instantiate (arrow, spawnLocations[rand], Quaternion.Euler(0.0f, 0.0f, rand*90)) as GameObject;
			instance.transform.SetParent(objParent.transform);
		}

	}
}
