using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : SeraphLibrary
{
    public float movementspeed;

    public Vector2 movementVec;
    public Vector2 lastMovementVec;
    public Vector2 lockedMovementVec;
    [Space]
    public bool stunned;
    public bool rolling;
    public bool moving;
    [Space]
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator anim;
    private int initialLayer;
    [Space]
    public static PlayerMovement instance;



    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        DontDestroyOnLoad(this.gameObject);
        initialLayer = gameObject.layer;
        instance = this;

    }


    private void Update()
    {

        movementVec = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized; //Movement Vector is HorizontalX and VerticalY and is normalized.

        //this was for the movement manager that I didn't use //movementVec = PlayerInputManager.movementVectorNormalized;
        anim.SetFloat("Horizontal", movementVec.x);
        anim.SetFloat("Vertical", movementVec.y);
        anim.SetFloat("Speed", movementVec.sqrMagnitude);
        if (lastMovementVec.x < -.1f)
        {
            sr.flipX = true;
        }
        if (lastMovementVec.x > .1f)
        {
            sr.flipX = false;
        }

        if ((Input.GetButtonDown("roll")) && moving && !stunned)
        //failed movemet manager// if ((PlayerInputManager.roll) && moving && !stunned)
        {
            lockedMovementVec = movementVec;
            StartCoroutine(Roll());
        }



    }
    void FixedUpdate()
    {
        if (!stunned && !rolling)
        {
            if (movementVec.sqrMagnitude > 0)//((movementVec.x >= 0.1) || (movementVec.y >= 0.1) || (movementVec.x <= -0.1) || (movementVec.y <= -0.1))
            {
                rb.MovePosition(rb.position + movementVec * movementspeed * Time.fixedDeltaTime);
                moving = true;
                lastMovementVec = movementVec;
            }
            if ((movementVec.x == 0) && (movementVec.y == 0))
            {
                moving = false;
            }
        }
        if (rolling && !stunned)
        {
            rb.MovePosition((rb.position + lockedMovementVec * movementspeed * 2 * Time.fixedDeltaTime));
        }



    }


    IEnumerator Roll()
    {
        if ((moving) && (!rolling))
        {
            anim.SetTrigger("Roll");
            gameObject.layer = 11;
            rolling = true;
            yield return new WaitForSeconds(0.4f);
            RollComplete();
        }
        if (rolling)
        {
            Debug.Log("Already Rolling");
        }
    }
    void RollComplete()
    {
        rolling = false;
        gameObject.layer = initialLayer;
        anim.SetTrigger("RollComplete");


    }

    public void StunFor(float seconds)
    {

    }
}
