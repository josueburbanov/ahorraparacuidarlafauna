using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class player_controller4 : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    public float jumpForce;
    public float speed;
    private bool isGrounded;
    public float checkRadius;
    public Transform groundPos;
    public LayerMask whatIsGround;
    public static bool movingRight;
    public static bool movingLeft;
    private bool isJumping;
    private float jumpTimeCounter;
    private bool doubleJump;
    private bool isAbleToDJump;
    public float jumpTime = 0.3f;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //StartCoroutine(Pause(3));
    }

    private IEnumerator Pause(int p)
    {
        Time.timeScale = 0.0001f;
        float pauseEndTime = Time.realtimeSinceStartup + p;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;

        }
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //if someone clicks on UI
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (EventSystem.current.currentSelectedGameObject) return;


        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);

        if (Input.GetMouseButtonDown(0) && isGrounded == true)
        {
            anim.SetTrigger("takeOf");
            isJumping = true;
            isGrounded = false;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.one * jumpForce;
            
        }

        if (isGrounded)
        {
            doubleJump = false;
            isAbleToDJump = false;
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }

        if(movingRight || movingLeft)
        {
            if (Input.GetMouseButton(0) && isJumping)
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

            if (Input.GetMouseButtonUp(0) && !isAbleToDJump)
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
        if (movingRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            anim.SetBool("isRunning", true);
        }
        else if(movingLeft)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            anim.SetBool("isRunning", true);
        }
    }
}
