using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player_controller : MonoBehaviour
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

    float moveInput = 1;

    private Rigidbody2D rbPlayerAux;
    private float angularVelAux;

    //////////end



    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    StartCoroutine(Pause(3));
    }

    private IEnumerator Pause(int p)
    {
        Time.timeScale = 0.0001f;
        float pauseEndTime = Time.realtimeSinceStartup + p;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //if someone clicks on UI
        //if (EventSystem.current.IsPointerOverGameObject()) return;
        //if (EventSystem.current.currentSelectedGameObject) return;

        //UI

        if(healthText != null)
        {
            healthText.text = "x " + health;
        }
        


        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);


        if (isGrounded == true && Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetTrigger("takeOf");
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
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

        if (Input.GetKey(KeyCode.Z) && isJumping == true)
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

        if (Input.GetKeyUp(KeyCode.Z))
        {
            isJumping = false;
            isAbleToDJump = true;
        }


        if (isGrounded == false && doubleJump == false && isAbleToDJump == true && Input.GetKeyDown(KeyCode.Z))
        {
            isAbleToDJump = false;
            isJumping = true;
            doubleJump = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }


        //Mobile


        if (Input.GetMouseButtonDown(0) && isGrounded == true)
        {

            anim.SetTrigger("takeOf");
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
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

    private void FixedUpdate()
    {
        if(rb.velocity != Vector2.zero)rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
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
