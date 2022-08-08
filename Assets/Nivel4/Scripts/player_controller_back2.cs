using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class player_controller_back2 : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    public float jumpForce;
    public float speed;
    private bool isGrounded;
    public float checkRadius;
    public Transform groundPos;
    public LayerMask whatIsGround;
    public GameObject player34;
    public float jumpTime;

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
        



        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            if(transform.position.x == 6.49f)
            {
                player34.transform.position = transform.position;
                player34.SetActive(true);
                player34.GetComponent<Animator>().SetTrigger("takeOf");
                player34.GetComponent<Animator>().SetBool("isJumping", true);
                player34.transform.localScale = new Vector3(-player34.transform.localScale.x, player34.transform.localScale.y, player34.transform.localScale.z);
                gameObject.SetActive(false);
                Rigidbody2D rb = player34.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(-1,1) * speed;
            }
            else if(transform.position.x == -5.5f)
            {
                player34.transform.position = transform.position;
                player34.SetActive(true);
                player34.GetComponent<Animator>().SetTrigger("takeOf");
                player34.GetComponent<Animator>().SetBool("isJumping", true);
                player34.transform.localScale = new Vector3(-player34.transform.localScale.x, player34.transform.localScale.y, player34.transform.localScale.z);
                gameObject.SetActive(false);
                Rigidbody2D rb = player34.GetComponent<Rigidbody2D>();
                rb.velocity = Vector2.one * speed;
            }
        }
    }
}

