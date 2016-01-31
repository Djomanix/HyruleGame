using UnityEngine;
using System.Collections;

public class amuletteController : MonoBehaviour {

    public float horizontalSpeed;
    public float verticalSpeed;
    public float amplitude;
    public float xPos;
    public float yOffset;

    Vector3 tempPosition;

	// Use this for initialization
	void Start () {
        tempPosition = new Vector3(transform.position.x, transform.position.y);
    }
	
	// Update is called once per frame
	void Update () {
        tempPosition.x = xPos;

        tempPosition.y = (Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude) + yOffset;
        
        transform.position = tempPosition;
    }
}
