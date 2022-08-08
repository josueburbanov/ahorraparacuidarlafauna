using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_controller5 : MonoBehaviour
{
    private Animator anim;
    public Rigidbody2D rb;
    public float jumpForce;
    public float speed;
    private bool isGrounded;
    public float checkRadius;
    public Transform groundPos;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    private bool doubleJump;
    private bool isAbleToDJump;

    //UI
    public static int health = 5;
    public Text healthText;
    public static bool isFinish;

    float moveInput = 1;

    public float MaxDubbleTapTime;
    private Rigidbody2D rbPlayerAux;
    private float angularVelAux;

    //////////end



    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if someone clicks on UI
        //if (EventSystem.current.IsPointerOverGameObject()) return;
        //if (EventSystem.current.currentSelectedGameObject) return;

        //UI
        healthText.text = "x " + health;


        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);



        //Mobile

        if (isFinish)
        {



            if (Input.GetMouseButtonDown(0) && isGrounded == true)
            {

                anim.SetTrigger("takeOf");
                isJumping = true;
                jumpTimeCounter = jumpTime;
                rb.velocity = Vector2.up * jumpForce;
                print("take of");
            }

            if (isGrounded == true)
            {
                doubleJump = false;
                anim.SetBool("isJumping", false);
                isAbleToDJump = false;
            }
            else
            {
                anim.SetBool("isJumping", true);
            }

            if (Input.GetMouseButton(0) && isJumping == true)
            {
                if (jumpTimeCounter > 0)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }
            }


            if (Input.GetMouseButtonUp(0))
            {
                isJumping = false;
                isAbleToDJump = true;
            }


            if (isGrounded == false && doubleJump == false && isAbleToDJump == true && Input.GetMouseButtonDown(0))
            {
                isAbleToDJump = false;
                isJumping = true;
                doubleJump = true;
                jumpTimeCounter = jumpTime;
                rb.velocity = Vector2.up * jumpForce;
            }

        }






    }

    private void FixedUpdate()
    {
        if (rb.velocity != Vector2.zero) rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (rb.velocity == Vector2.zero)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
    }

    public void pauseRigidBody()
    {
        rbPlayerAux = rb;
        angularVelAux = rb.angularVelocity;
        rb.angularVelocity = 0;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        rb.Sleep();
    }

    public void resumeRigidBody()
    {
        rb.velocity = new Vector2(speed, rbPlayerAux.velocity.y);
        rb.isKinematic = false;
        rb.angularVelocity = angularVelAux;
    }


}
