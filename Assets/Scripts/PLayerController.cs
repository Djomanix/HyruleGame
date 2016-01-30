using UnityEngine;
using System.Collections;

public class PLayerController : MonoBehaviour {

    private AudioSource rockGet = new AudioSource();
    private Rigidbody rb;
    public float speed;
    Vector3 movement;


    // Use this for initialization
    void Start () {
        rockGet = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        rb.transform.position += movement * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "allo")
        {
            Debug.Log("hit");
            rockGet.Play();
            Destroy(other.gameObject);
        }
    }

}
