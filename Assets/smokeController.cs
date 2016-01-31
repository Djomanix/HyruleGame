using UnityEngine;
using System.Collections;

public class smokeController : MonoBehaviour {

    Animator anim;

    private float moveHorizontal;
    private float moveVertical;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        moveHorizontal = 0.0f;
        moveVertical = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal != 0 || moveVertical != 0)
            anim.SetBool("smoking", true);
        else
        {
            anim.SetBool("smoking", false);
        }
            
    }
}
