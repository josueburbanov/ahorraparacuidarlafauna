using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class planta_detector : MonoBehaviour
{
    private bool isHit = false;
    private Animator anim;
    public static bool hitted = false;
    public CameraShake cameraShake;
    public Canvas canvas;
    public float restDelay = 5f;
    float restTimer;
    private bool isGameOver;
    public SaveManager player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim = collision.collider.GetComponent<Animator>();
        //if (collider.name.Equals("OsoEspaldas"))
        //{
        if (!isHit)
        {
            isHit = true;
            Rigidbody2D rb = collision.collider.gameObject.GetComponent<Rigidbody2D>();
            anim.SetTrigger("isFalling");
            rb.angularVelocity = 0;
            rb.velocity = Vector2.zero;
            rb.Sleep();
            collision.collider.enabled = false;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(cameraShake.Shake(.3f, 0.4f, (Camera)GameObject.FindObjectOfType(typeof(Camera))));
            canvas.GetComponent<Animator>().SetTrigger("GameOver");

        }

        //}
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!isHit)
        {
            isHit = true;
            collider.gameObject.GetComponent<Animator>().SetTrigger("isFalling");
            if (cameraShake != null)
                StartCoroutine(cameraShake.Shake(.3f, 0.4f, (Camera)GameObject.FindObjectOfType(typeof(Camera))));
            canvas.GetComponent<Animator>().SetTrigger("GameOver");
            rb = collider.gameObject.GetComponent<Rigidbody2D>();
            rb.Sleep();

            isGameOver = true;
            //gameObject.transform.parent = collider.gameObject.transform;
        }
    }

    void Start()
    {
        hitted = false;
    }

    Rigidbody2D rb;
    void Update()
    {
        if(!(rb is null))
        {
            rb.angularVelocity = 0;
            rb.AddForce(new Vector2(-10f,-100f));
        }
        
        if (isGameOver)
        {
            gameObject.transform.Translate(new Vector3(0, -2f * Time.deltaTime, 0));
            restTimer += Time.deltaTime;
            if (restTimer >= restDelay)
            {
                isGameOver = false;
                food_catch_detector.foodCounter = 0;
                player_controller1.health -= 1;
                if (player_controller1.health == 0)
                {
                    player.terminarNivelIncompleto();
                    player_controller1.health = 5;
                    GameObject.Find("LevelChanger").GetComponent<change_next_scene>().changeLevelActivator(0);
                }
                else
                {
                    GameObject.Find("LevelChanger").GetComponent<change_next_scene>().changeLevelActivator(
                        SceneManager.GetActiveScene().buildIndex - 4);
                }
            }
        }
    }
}
