using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class madera_rota_detector : MonoBehaviour
{
    private bool isHit = false;
    private Animator anim;
    public CameraShake cameraShake;
    private bool isGameOver;
    public SaveManager player;
    public float restDelay = 5f;
    float restTimer;
    public Canvas canvas;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim = collision.collider.GetComponent<Animator>();
        if (!isHit)
        {
            isHit = true;
            collision.collider.enabled = false;            
            StartCoroutine(cameraShake.Shake(.3f, 0.4f, (Camera)GameObject.FindObjectOfType(typeof(Camera))));
            isGameOver = true;
            canvas.GetComponent<Animator>().SetTrigger("GameOver");
        }
    }

    void Start()
    {

    }

    void Update()
    {
        if (isGameOver)
        {
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
