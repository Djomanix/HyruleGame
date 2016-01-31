using UnityEngine;
using System.Collections;

public class TransitionScreen : MonoBehaviour {
    public float horizontalSpeed;
    public float verticalSpeed;
    public float amplitude;

    private Vector3 tempPosition;

    int opacity;

    void Start()
    {
        tempPosition = transform.position;
        opacity = 100;

    }

    void Update()
    {
        opacity--;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.LoadLevel(1); 
        }
    }

    void FixedUpdate()
    {
        tempPosition.x += horizontalSpeed;
        tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude;
        transform.position = tempPosition;
    }
}
