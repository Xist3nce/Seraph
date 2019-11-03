using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementspeed;

    public Vector2 movementVec;

    public bool stunned;

    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator anim;



    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    private void Update()
    {

       movementVec = new Vector2 (Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized; //Movement Vector is HorizontalX and VerticalY and is normalized.

        anim.SetFloat("Horizontal", movementVec.x);
        anim.SetFloat("Vertical", movementVec.y);
        anim.SetFloat("Speed",movementVec.sqrMagnitude);
        if (movementVec.x < .5f)
        {
            sr.flipX = true;
        }
        if (movementVec.x > .5f)
        {
            sr.flipX = false;
        }



    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!stunned)
        {
            rb.MovePosition(rb.position + movementVec * movementspeed * Time.fixedDeltaTime);
        }


    }
}
