using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class falling_detector6 : MonoBehaviour
{
    public Canvas canvas;
    public CameraShake cameraShake;
    private bool isGameOver;
    private float restTimer;
    private float restDelay = 5f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name.Equals("Oso piezasperfil34"))
        {
            collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            collider.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player_controller5.isFinish = true;
            collider.gameObject.GetComponent<Animator>().SetTrigger("isFalling");
            //StartCoroutine(cameraShake.Shake(.3f, 0.4f, (Camera)GameObject.FindObjectOfType(typeof(Camera))));
            canvas.GetComponent<Animator>().SetTrigger("GameOver");
            isGameOver = true;

        }
    }

    void Start()
    {

    }

    void Update()
    {
        //if (isGameOver)
        //{
        //    restTimer += Time.deltaTime;
        //    if (restTimer >= restDelay)
        //    {
        //        food_catch6.foodCounter = 0;
        //        player_controller6.health -= 1;

        //        if (player_controller.health == 0)
        //        {
        //            print("Game Over");
        //            print("Cargando mapa inicial...");
        //            //TO DO: Cargar mapa inicial
        //        }
        //        else
        //        {
        //            print("scene");
        //            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //        }
        //    }
        //}
    }
}
