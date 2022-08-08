using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player7_controller : MonoBehaviour
{
    private Animator anim;
    public Rigidbody2D rb;
    public float jumpForce;
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

    //UI
    public static int health = 5;
    public Text healthText;

    float moveInput = 1;

    private rock_coll_detector rock_Coll_Detector;
    private food_catch6 food_Catch6;
    public float speed;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        if (healthText != null)
        {
            healthText.text = "x " + health;
        }
        speed = formerSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        //if someone clicks on UI
        //if (EventSystem.current.IsPointerOverGameObject()) return;
        //if (EventSystem.current.currentSelectedGameObject) return;

        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Vector3 mousePos = ((Camera)FindObjectOfType(typeof(Camera))).ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if (!hit.collider.name.Equals("Oso piezasperfil34"))
                {
                    string realNameCollider = hit.collider.name.Split('(')[0];
                    if (realNameCollider.Equals("alimento-oso"))
                    {
                        food_Catch6 = hit.collider.gameObject.GetComponent<food_catch6>();
                        food_Catch6.onHit();
                    }
                    else if (realNameCollider.Equals("roca5"))
                    {
                        rock_Coll_Detector = hit.collider.gameObject.GetComponent<rock_coll_detector>();
                        rock_Coll_Detector.onHit();
                    }

                    return;
                }

            }
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
        if (rb.velocity != Vector2.zero) rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (rb.velocity.x == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
    }



}
