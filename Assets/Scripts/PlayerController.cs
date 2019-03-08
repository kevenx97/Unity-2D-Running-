using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Animator anime;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public Rigidbody2D playerRigidBody;
    public Transform colision;
    public int forceJump;
    public bool grounded;
    private bool slide;
    public float slideTemp;
    private float timeTemp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetButtonDown("Jump") && grounded) {
            playerRigidBody.AddForce(new Vector2(0, forceJump));

            if(slide)
            {
                colision.position = new Vector3(colision.position.x, colision.position.y + 0.3f, colision.position.z);
                slide = false;
            }
            
        }

        if(Input.GetButtonDown("Slide") && grounded && !slide)
        {
            slide = true;
            timeTemp = 0;
            colision.position = new Vector3(colision.position.x, colision.position.y - 0.3f, colision.position.z);
        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, whatIsGround);

        if(slide)
        {
            timeTemp += Time.deltaTime;

            if(timeTemp >= slideTemp)
            {
                slide = false;
                colision.position = new Vector3(colision.position.x, colision.position.y + 0.3f, colision.position.z);
            }
        }

        anime.SetBool("jump", !grounded);
        anime.SetBool("slide", slide);

	}

    void OnTriggerEnter2D()
    {
        Debug.Log("teste");
    }
}
