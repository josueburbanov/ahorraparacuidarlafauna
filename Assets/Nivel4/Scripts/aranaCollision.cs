using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class aranaCollision : MonoBehaviour
{
    private bool isHit = false;
    public bool hitted = false;
    public CameraShake cameraShake;
    public Canvas canvas;
    public float restDelay = 5f;
    float restTimer;
    private bool isGameOver;
    public SaveManager player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name.Equals("Oso piezasperfil34"))
        {
            if (!isHit)
            {
                isHit = true;
                hitted = true;
                collision.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                collision.collider.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                collision.otherCollider.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                collision.collider.gameObject.GetComponent<Animator>().SetTrigger("isFalling");
                StartCoroutine(cameraShake.Shake(.3f, 0.4f, (Camera)GameObject.FindObjectOfType(typeof(Camera))));
                canvas.GetComponent<Animator>().SetTrigger("GameOver");
                isGameOver = true;
                player_controller4.movingLeft = false;
                player_controller4.movingRight = false;
            }
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
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }
}
