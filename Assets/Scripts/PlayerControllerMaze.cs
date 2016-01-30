using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControllerMaze : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    Vector3 movement;
    private AudioSource[] impactSons;
    private Vector3 wall_save;

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
        bool play = false;
        if
        (other.gameObject.name == "maze_wall(Clone)" && !other.gameObject.transform.position.y.Equals(wall_save.y))
        {
            // impactGet.Play();
            wall_save = other.gameObject.transform.position;
            foreach (AudioSource son in impactSons)
            {
                if (!son.isPlaying && Input.GetAxis("Vertical") == 0)
                {
                    play = true;
                }
                else 
                { 
                    play = false;
                }
            }
            if (play) { impactSons[Random.Range(0, 4)].Play(); play = false; }
        }
    }


    void OnTriggerEnter2D(Collider2D other)    
    {
        Application.LoadLevel(2);    
    }
}
