using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver3 : MonoBehaviour
{
    
    public float restDelay = 5f;

    Animator anim;
    float restTimer;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (planta_detector.hitted)
        {
            anim.SetTrigger("GameOver");
            restTimer += Time.deltaTime;
            if (restTimer >= restDelay)
            {

                food_catch_detector.foodCounter = 0;
                player_controller.health -= 1;

                if (player_controller.health == 0)
                {
                    print("Game Over");
                    print("Cargando mapa inicial...");
                    //TO DO: Cargar mapa inicial
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }

    }
}
