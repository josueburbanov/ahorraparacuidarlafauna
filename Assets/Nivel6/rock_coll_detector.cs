using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rock_coll_detector : MonoBehaviour
{
    private bool isHit = false;
    private bool isHitOso = false;
    public bool isCatched = false;
    public bool hitted = false;
    private Animator anim;
    public bool isMortino;
    public bool isAguacatillo;
    public GameObject dashEffect;
    AudioSource audioSource;
    public AudioClip audioClip;
    public CameraShake cameraShake;
    public Canvas canvas;
    public bool isGameOver;
    private float restTimer;
    private float restDelay = 5f;
    private bool firstTime;
    public SaveManager player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name.Equals("Oso piezasperfil34"))
        {
            if (!isHitOso)
            {
                isHitOso = true;
                hitted = true;
                collision.collider.enabled = false;
                collision.collider.gameObject.GetComponent<Animator>().SetTrigger("isFalling");
                StartCoroutine(cameraShake.Shake(.3f, 0.4f, (Camera)GameObject.FindObjectOfType(typeof(Camera))));
                canvas.GetComponent<Animator>().SetTrigger("GameOver");
                isGameOver = true;
            }

        }
    }

    public void onHit()
    {
        if (!isHit)
        {
            isHit = true;
            isCatched = true;
            Instantiate(dashEffect, transform.position, Quaternion.identity);
            if (audioClip != null)
            {
                audioSource.PlayOneShot(audioClip, 0.7f);
            }
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isCatched)
        {
            if (!audioSource.isPlaying)
            {
                transform.gameObject.SetActive(false);
                Destroy(this);
            }
        }

        if (isGameOver && !firstTime)
        {
            firstTime = false;
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
                    GameObject.FindGameObjectWithTag("LevelChanger").GetComponent<change_next_scene>().changeLevelActivator(0);
                }
                else
                {
                    GameObject.FindGameObjectWithTag("LevelChanger").GetComponent<change_next_scene>().changeLevelActivator(
                        SceneManager.GetActiveScene().buildIndex - 4);
                }
            }
        }


    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 38));
    }
}
