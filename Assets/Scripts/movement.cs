using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
    private Rigidbody rb;
    private bool sense;
    private bool moving;
    private int i;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        sense = false;
        moving = true;
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

                if (rb.transform.position.x > -1.5 && rb.transform.position.x < 1.5)
                {
                    Destroy(GameObject.Find("LogMiniJeux" + i));
                    i++;
                }
                if (i == 3)
                {
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
        else 
        {
            int i = 5;
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
