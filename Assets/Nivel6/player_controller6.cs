using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class player_controller6 : MonoBehaviour
{
    private Animator anim;
    public Rigidbody2D rb;
    public float jumpForce;
    public static float speed = 5.5f;
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

    private rock_coll_detector rock_Coll_Detector;
    private food_catch6 food_Catch6;

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

        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            anim.SetBool("isRunning", true);
            Vector3 mousePos = ((Camera)FindObjectOfType(typeof(Camera))).ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if(!hit.collider.name.Equals("Oso piezasperfil34"))
                {
                    string realNameCollider = hit.collider.name.Split('(')[0];
                    if (realNameCollider.Equals("alimento-oso")|| realNameCollider.Equals("aguacatillo")|| realNameCollider.Equals("mortino"))
                    {
                        food_Catch6 = hit.collider.gameObject.GetComponent<food_catch6>();
                        food_Catch6.onHit();
                    }
                    else if (realNameCollider.Equals("roca5")|| realNameCollider.Equals("roca2")|| realNameCollider.Equals("roca1")|| realNameCollider.Equals("roca3")|| realNameCollider.Equals("roca4"))
                    {
                        rock_Coll_Detector = hit.collider.gameObject.GetComponent<rock_coll_detector>();
                        rock_Coll_Detector.onHit();
                    }
                    
                    return;
                }
                
            }
        }

        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);


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
