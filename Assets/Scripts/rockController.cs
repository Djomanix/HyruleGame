using UnityEngine;
using System.Collections;

public class rockController : MonoBehaviour {

    private float speed;
    private Animator animator;


	// Use this for initialization
	void Start () {
        speed = (Random.Range(0.1f, 0.17f));
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position -= new Vector3(0.0f, speed);
    }
}
