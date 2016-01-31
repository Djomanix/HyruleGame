using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PLayerController : MonoBehaviour
{

    AudioSource rockGet = new AudioSource();
    Rigidbody2D rb;
    public float speed;
    int playerScore;

    public Text textbox;

    Vector3 temp;
    Vector3 movement;

    float moveHorizontal;

    bool Moving;

    // Use this for initialization
    void Start()
    {
        rockGet = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        playerScore = 0;
        Moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Moving)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

            temp = rb.transform.position;
            temp += movement * speed;

            if (temp.x > -20 && temp.x < 20)
                rb.position = temp;
        }
        
        rb.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -moveHorizontal * 15);

        textbox.text = "Score: " + playerScore;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        rockGet.Play();
        other.gameObject.GetComponent<Animator>().SetTrigger("explode");
        playerScore += 25;
    }

    public void SetMoving(bool moving)
    {
        Moving = moving;
    }
}
