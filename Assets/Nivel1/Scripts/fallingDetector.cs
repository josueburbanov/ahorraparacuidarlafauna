using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fallingDetector : MonoBehaviour
{
    private bool isHit = false;
    private Animator anim;
    public bool hitted = false;
    public CameraShake cameraShake;
    public Canvas canvas;
    public float restDelay = 5f;
    float restTimer;
    private bool isGameOver;
    public SaveManager player;

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.name.Equals("Oso piezasperfil34"))
        {
            if (!isHit)
            {
                //anim.SetTrigger("isFalling");
                isHit = true;
                hitted = true;
                collider.gameObject.GetComponent<Animator>().SetTrigger("isFalling");
                if (cameraShake != null)
                    StartCoroutine(cameraShake.Shake(.3f, 0.4f, (Camera)GameObject.FindObjectOfType(typeof(Camera))));
                canvas.GetComponent<Animator>().SetTrigger("GameOver");
                isGameOver = true;
                
            }

        }
        else
        {
            collider.gameObject.SetActive(false);
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
