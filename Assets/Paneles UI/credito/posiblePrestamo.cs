using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class posiblePrestamo : MonoBehaviour
{
    public SaveManager player;
    public GameObject CanvasRecordatorioPago;
    public Text foodText;
    public void checkPosiblePrestamo(int prestamo)
    {
        if (prestamo + food_catch_detector.foodCounter < InicializadorNivelPlayer.minReqAlimento)
        {
            //No alcanza prestamo
            GameObject.Find("CanvasDialogoNoAlcanza").SetActive(true);
        }
        else
        {
            food_catch_detector.foodCounter += prestamo;
            foodText.text = "X " + food_catch_detector.foodCounter + " / " + InicializadorNivelPlayer.minReqAlimento;
            player.hacerPrestamo(prestamo + 10, food_catch_detector.foodCounter, SceneManager.GetActiveScene().buildIndex - 4); //Hacer prestamo al final del nivel cuesta 10+
            CanvasRecordatorioPago.SetActive(true);
            gameObject.SetActive(false);


        }
    }
}
