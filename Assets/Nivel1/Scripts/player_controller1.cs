﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player_controller1 : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    public float jumpForce;
    public float speed = 10f;
    public float formerSpeed;
    private bool isGrounded;
    public float checkRadius;
    public Transform groundPos;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    private bool doubleJump;
    private bool isAbleToDJump;
    private bool isAbleToLand;
    public GameObject buttonPause;
    private bool letsmove;

    //UI
    public static int health = 5;

    public int set_Health { get => health; set => health = value; }

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        formerSpeed = speed;
        speed = 0;
        StartCoroutine(Pause(1));
    }

    private IEnumerator Pause(int p)
    {
        yield return new WaitForSeconds(p);
        speed = formerSpeed;
        print("letsmove");
        letsmove = true;
        Time.timeScale = 1f;
        buttonPause.SetActive(true);
        anim.SetBool("isRunning", true);
    }


    // Update is called once per frame
    void Update()
    {
        ////if someone clicks on UI
        if (EventSystem.current.IsPointerOverGameObject())
        {
            anim.SetBool("isJumping", false);
            return;
        }
        if (EventSystem.current.currentSelectedGameObject)
        {
            anim.SetBool("isJumping", false);
            return;
        }
        if (!letsmove)
        {
            return;
        }else
        {
            anim.SetBool("isRunning", true);
        }


        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);

        if (Input.GetMouseButtonDown(0) && isGrounded == true  )
        {
            anim.SetTrigger("takeOf");
            isJumping = true;
            isGrounded = false;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        

        if (isGrounded)
        {
            doubleJump = false;
            anim.SetBool("isJumping", false);
            if(speed > 0) { 
            anim.SetBool("isRunning", true);
            }else
            {
                anim.SetBool("isRunning", false);
            }
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

        if (Input.GetMouseButtonUp(0) && !isAbleToDJump)
        {
            isJumping = false;
            isAbleToDJump = true;
            isAbleToLand = true;
        }

        if (isAbleToLand && isGrounded)
        {

            anim.SetBool("isJumping",false);
            isAbleToLand = false;
           
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
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
}
