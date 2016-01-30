using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PLayerController : MonoBehaviour
{

    private AudioSource rockGet = new AudioSource();
    private Rigidbody rb;
    public float speed;
    Vector3 movement;
    private int playerScore;

    public Text textbox;


    // Use this for initialization
    void Start()
    {
        rockGet = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        
        rb.transform.position += movement * speed;
        Vector3 temp = rb.position;
        temp.x = Mathf.Clamp(rb.position.x, -20.0f, 20.0f);
        rb.position = temp;

        rb.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -moveHorizontal * 10 + 1);

        textbox.text = "Score: " + playerScore;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "allo")
        {
            rockGet.Play();
            Destroy(other.gameObject);
            playerScore += 25;
        }
    }
}
