using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

	public GameObject player;

	public Text scoreText;

	private int rand;

	private bool start = false;

	private int[] spawnOrder;
	private float[] beatsAtSeconds = new float[12];
	private int nextBeat = 0;

	private int score;


	AudioSource ritualMusic;
	// Use this for initialization
	void Start () 
	{
		score = 0;

		setupTimeFrames();

		spawnLocations[0] = upArrowSpawn.position;
		spawnLocations[1] = leftArrowSpawn.position;
		spawnLocations[2] = downArrowSpawn.position;
		spawnLocations[3] = rightArrowSpawn.position;

		ritualMusic = GetComponent<AudioSource>();

		//StartCoroutine ("RitualDance");
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(!start)
		{
			if(Input.GetKeyDown (KeyCode.Space))
			{
				start = true;
				ritualMusic.Play ();
				//timer = 0;
				StartCoroutine ("RitualDance");
			}
		}

		scoreText.text = "Score: " + score;
	}

	IEnumerator RitualDance()
	{
		while(nextBeat < 12)
		{
			yield return new WaitForSeconds(beatsAtSeconds[nextBeat]);

			rand = Random.Range (0, 4);
			GameObject instance =
				Instantiate (arrow, spawnLocations[rand], Quaternion.Euler(0.0f, 0.0f, rand*90)) as GameObject;
			instance.transform.SetParent(objParent.transform);
			nextBeat++;
		}

		while(ritualMusic.time < 45.0f)
		{
			if(nextBeat == 13)
				player.GetComponent<PlayerDanceScript>().SetDance(5);

			yield return new WaitForSeconds(0.5f);
		
			rand = Random.Range (0, 4);
			GameObject newInstance =
				Instantiate (arrow, spawnLocations[rand], Quaternion.Euler(0.0f, 0.0f, rand*90)) as GameObject;
			newInstance.transform.SetParent(objParent.transform);
			nextBeat++;
		}
	}

	private void setupTimeFrames()
	{

		//Intro Sequence: Repeat x2
		beatsAtSeconds[0] = 3.0f; //5
		beatsAtSeconds[1] = 1.2f; //6.5
		beatsAtSeconds[2] = 1.2f;
		beatsAtSeconds[3] = 0.4f;
		beatsAtSeconds[4] = 0.4f;
		beatsAtSeconds[5] = 0.4f;

		beatsAtSeconds[6] = 1.2f; //10
		beatsAtSeconds[7] = 1.2f;
		beatsAtSeconds[8] = 1.2f;
		beatsAtSeconds[9] = 0.5f;
		beatsAtSeconds[10] = 0.4f;
		beatsAtSeconds[11] = 0.4f;
	}

	public void UpdateScore(int val)
	{
		score += val;
	}
}
