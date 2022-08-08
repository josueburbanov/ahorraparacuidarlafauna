using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class llegada_detector : MonoBehaviour
{
    private bool isHit = false;
    public GameObject canvasPrestamo100;
    public GameObject canvasFinGanador;
    public GameObject canvasFinPerdedor;
    public SaveManager player;
    public GameObject canvasNoPuedeHacerPrestamo;
    public GameObject canvasDigMas30;
    public GameObject buttonPause;
    public GameObject canvasNoPuedePorSuperado;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name.Equals("Oso piezasperfil34") || collider.name.Equals("OsoEspaldas2"))
        {
            if (!isHit)
            {
                isHit = true;
                buttonPause.SetActive(false);
                checkPassLevel();
                Time.timeScale = 0;
            }

        }
    }

    public void checkPassLevel()
    {
        if (food_catch_detector.foodCounter < InicializadorNivelPlayer.minReqAlimento)
        {
            canvasFinPerdedor.SetActive(true);
        }
        else
        {
            canvasFinGanador.SetActive(true);
            if (player.tienePrestamosImpagos() && player.getPrestamoAnterior().Nivel != SceneManager.GetActiveScene().buildIndex - 4)
            {
                player.pagarPrestamo();
            }
        }
    }

    public void activateCanvasPrestamo100()
    {
        if ((player.getLastFinishedLevel() > SceneManager.GetActiveScene().buildIndex - 4) ||
            SceneManager.GetActiveScene().buildIndex - 4 == 7 || SceneManager.GetActiveScene().buildIndex - 4 == 8 ||
            SceneManager.GetActiveScene().buildIndex - 4 == 9)
        {
            canvasNoPuedePorSuperado.SetActive(true);
        }
        else if (food_catch_detector.foodCounter + 30 < InicializadorNivelPlayer.minReqAlimento)
        {
            canvasDigMas30.SetActive(true);
        }

        else if (player.tienePrestamosImpagos())
        {
            canvasNoPuedeHacerPrestamo.SetActive(true);
        }


        else if (!player.tienePrestamoActual())
        {
            canvasPrestamo100.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
