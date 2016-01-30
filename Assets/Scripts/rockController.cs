using UnityEngine;
using System.Collections;

public class rockController : MonoBehaviour {

    private float speed;
    private const float MAX_ROTATION_Z = 20.0f;
    private Quaternion rotation;


	// Use this for initialization
	void Start () {
        speed = (Random.Range(0.1f, 0.17f));
        rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        print("Speed: " + speed);
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position -= new Vector3(0.0f, speed);
        if (Input.GetKey(KeyCode.A) && rotation.z < MAX_ROTATION_Z && rotation.z > -MAX_ROTATION_Z)
        {
            rotation.z++;
        }
        if (Input.GetKey(KeyCode.D) && rotation.z < MAX_ROTATION_Z && rotation.z > -MAX_ROTATION_Z)
        {
            rotation.z--;
        }
    }
}
