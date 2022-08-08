using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ch_pickPlayer : MonoBehaviour
{
    public bool isClicked = false;
    // Start is called before the first frame update
    void Start()
    {
        SaveManager.LoadJuego();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isClicked){
            if(SaveManager.Juego.Jugadores.Count != 0)
            {
                change_next_scene.changeInitLevel = true;
            }else
            {
                change_next_scene.changeLevel = true;
                isClicked = true;
            }
        }
    }
}
