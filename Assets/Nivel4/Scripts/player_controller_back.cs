using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class player_controller_back : MonoBehaviour
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

    //UI
    public static int health = 5;
    //public Text healthText;

    float moveInput = 1;

    int TapCount;
    public float MaxDubbleTapTime;
    float NewTime;
    private Rigidbody2D rbPlayerAux;
    private float angularVelAux;
    public GameObject oso34;

    //////////end

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        TapCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            //GameObject oso34new = oso34.gameObject;
            this.gameObject.SetActive(false);
            var oso34New = Instantiate(oso34, transform.position, Quaternion.identity);
            oso34New.transform.localScale = new Vector3(-oso34New.transform.localScale.x, oso34New.transform.localScale.y, oso34New.transform.localScale.z);
            oso34New.SetActive(true);
            Rigidbody2D rb = oso34New.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-1,1) * speed;
            //Destroy(this);
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

