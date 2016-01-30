using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PLayerController : MonoBehaviour
{

    private AudioSource rockGet = new AudioSource();
    private Rigidbody2D rb;
    public float speed;
    Vector3 movement;
    private int playerScore;

    public Text textbox;


    // Use this for initialization
    void Start()
    {
        rockGet = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        Vector3 temp = rb.transform.position;

        temp += movement * speed;

        if (temp.x > -20 && temp.x < 20)
            rb.position = temp;

        rb.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -moveHorizontal * 10 + 1);

        textbox.text = "Score: " + playerScore;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        rockGet.Play();
        Destroy(other.gameObject);
        playerScore += 25;
    }
}
