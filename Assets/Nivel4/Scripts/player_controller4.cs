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
    private bool letsmove;

    public float jumpTime;

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
        letsmove = true;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //if someone clicks on UI
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (EventSystem.current.currentSelectedGameObject) return;
        if (!letsmove)return;


        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);

        if (Input.GetMouseButtonDown(0) && isGrounded == true)
        {
            anim.SetTrigger("takeOf");
            rb.velocity = Vector2.one * jumpForce; 
        }

        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }
    }
}
