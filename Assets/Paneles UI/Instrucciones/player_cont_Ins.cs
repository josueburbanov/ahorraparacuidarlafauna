using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class player_cont_Ins : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
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

    float moveInput = 1;

    private Rigidbody2D rbPlayerAux;
    private float angularVelAux;

    public bool hasJumped;
    public bool hasDoubleJumped;
    public bool firstStepIns = false;
    public bool secondStepIns = false;
    public bool thirdStepIns = false;
    public bool fourthStepIns = false;
    public bool fifthStepIns = false;
    public bool fifthStepInsAux = false;
    public float vasijaCounter = 0;

    public Text greatText;
    public GameObject dialogo;
    public GameObject detector;
    private bool oneOnly5;
    private bool oneOnly4;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.collider.name.Equals("suelo100 (1)") && !thirdStepIns)
        {
            StartCoroutine(WaitTilCheckFalling3());
            
        }
        else if (collision.collider.name.Equals("suelo100"))
        {
            if (hasJumped)
            {
                firstStepIns = true;
                greatText.gameObject.SetActive(true);
                dialogo.SetActive(true);
                greatText.text = "Genial! Eso fue un salto simple.";
                //greatText.transform.localPosition = new Vector3(-189, greatText.transform.localPosition.y, greatText.transform.localPosition.z);
                StartCoroutine(waitTilFadeOutText());

            }
            if (hasDoubleJumped)
            {
                secondStepIns = true;
                greatText.gameObject.SetActive(true);
                greatText.text = "Súper! Eso fue un salto doble. ";
                dialogo.SetActive(true);
                //greatText.transform.localPosition = new Vector3(223, greatText.transform.localPosition.y, greatText.transform.localPosition.z);
                StartCoroutine(waitTilFadeOutText());
                detector.SetActive(false);
                hasDoubleJumped = false;
            }
        }
    }

    IEnumerator WaitTilCheckFalling3()
    {
        yield return new WaitForSeconds(1f);
        thirdStepIns = true;
        greatText.gameObject.SetActive(true);
        greatText.text = "Eso fue un salto largo doble.";
        dialogo.SetActive(true);
        //greatText.transform.localPosition = new Vector3(223, greatText.transform.localPosition.y, greatText.transform.localPosition.z);
        yield return new WaitForSeconds(1f);
        greatText.gameObject.SetActive(false);
        dialogo.SetActive(false);
        detector.transform.localPosition = new Vector3(detector.transform.localPosition.x + 10f, detector.transform.localPosition.y, detector.transform.localPosition.z);
    }

    IEnumerator WaitTilCheckFalling5()
    {
        yield return new WaitForSeconds(1f);
        fifthStepIns = true;
        greatText.gameObject.SetActive(true);
        if (vasijaCounter < 0)
        {
            greatText.text = vasijaCounter + "!";
        }
        else
        {
            greatText.text = "+" + vasijaCounter + "!";
        }

        dialogo.SetActive(true);
        //greatText.transform.localPosition = new Vector3(223, greatText.transform.localPosition.y, greatText.transform.localPosition.z);
        yield return new WaitForSeconds(1f);
        greatText.gameObject.SetActive(false);
        dialogo.SetActive(false);
        detector.transform.localPosition = new Vector3(detector.transform.localPosition.x + 10f, detector.transform.localPosition.y, detector.transform.localPosition.z);
        

    }

    IEnumerator waitTilFadeOutText()
    {
        yield return new WaitForSeconds(1.5f);
        greatText.gameObject.SetActive(false);
        dialogo.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name.Equals("alimento-oso"))
        {
            thirdStepIns = true;
        }
    }


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if someone clicks on UI
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (EventSystem.current.currentSelectedGameObject) return;
        if (Time.timeScale == 0) return;

        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);

        //Mobile
        if (fifthStepInsAux && !oneOnly5)
        {
            oneOnly5 = true;
            StartCoroutine( WaitTilCheckFalling5());
            
        }

        if (fourthStepIns && !oneOnly4)
        {
            
            oneOnly4 = true;
            greatText.gameObject.SetActive(true);
            greatText.text = "+1! ";
            dialogo.SetActive(true);
            //greatText.transform.localPosition = new Vector3(223, greatText.transform.localPosition.y, greatText.transform.localPosition.z);
            StartCoroutine(waitTilFadeOutText());
            detector.transform.localPosition = new Vector3(detector.transform.localPosition.x + 10f, detector.transform.localPosition.y, detector.transform.localPosition.z);
        }


        if (Input.GetMouseButtonDown(0) && isGrounded == true)
        {
            anim.SetTrigger("takeOf");
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            hasJumped = true;
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


        if (isGrounded == false && doubleJump == false && isAbleToDJump == true && Input.GetMouseButtonDown(0) && firstStepIns)
        {
            hasDoubleJumped = true;
            isAbleToDJump = false;
            isJumping = true;
            doubleJump = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
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
}
