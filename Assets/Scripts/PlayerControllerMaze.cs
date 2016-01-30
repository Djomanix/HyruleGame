using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControllerMaze : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    Vector3 movement;
    private AudioSource[] impactSons;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        impactSons = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        Vector3 temp = rb.transform.position;
        temp += movement * speed;
        if (temp.x > -20 && temp.x < 20)
            rb.position = temp;
        rb.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -moveHorizontal * 10 + 1);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if
        (
            other.gameObject.name == "maze_wall(Clone)"
        )
        {
            // impactGet.Play();
            impactSons[Random.Range(0,4)].Play();

        }

    }


    void OnTriggerEnter2D(Collider2D other)    
    {
        Application.LoadLevel(0);    
    }
}
