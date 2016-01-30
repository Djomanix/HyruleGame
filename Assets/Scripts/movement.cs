using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
    private Rigidbody rb;
    private bool sense;
    private bool moving;
    
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        sense = false;
        moving = true;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (moving)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moving = false;
                StartCoroutine(MoveAgain());
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
        else
        {
            if (rb.transform.position.x > -1.5 && rb.transform.position.x < 1.5)
            {
            }
        }
        
    }

    IEnumerator MoveAgain()
    {
        yield return new WaitForSeconds(2);

        moving = true;
    }

    
}
