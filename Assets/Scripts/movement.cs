using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
    private Rigidbody rb;
    private bool sense;
    private bool moving;
    private int i;
    private AudioSource[] getSons;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        sense = false;
        moving = true;
        getSons = GetComponents<AudioSource>();
        i = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (moving)
        {
            if (Input.GetKeyDown(KeyCode.Space) )
            {
                moving = false;
                StartCoroutine(MoveAgain());

                if (rb.transform.position.x > -1.3 && rb.transform.position.x < 1.3)
                {
                    getSons[0].Play();
                    Destroy(GameObject.Find("LogMiniJeux" + i));
                    i++;
                }
                else
                {
                    print("miss");
                    getSons[1].Play();
                    getSons[3].Play();
                }
                if (i == 4)
                {
                    
                    getSons[2].Play();
                    
                    Application.LoadLevel(2);
                    
                }
            }


            else
            {
                if (sense == false)
                {
                    transform.Translate(20f * Time.deltaTime, 0f, 0f);
                }
                else
                {
                    transform.Translate(-20f * Time.deltaTime, 0f, 0f);
                }

                if (rb.transform.position.x >= 7)
                {
                    sense = true;
                }
                if (rb.transform.position.x <= -7)
                {
                    sense = false;
                }
            }
          

        }
              
    }

    IEnumerator MoveAgain()
    {
        yield return new WaitForSeconds(2);

        moving = true;
    }

    
}
