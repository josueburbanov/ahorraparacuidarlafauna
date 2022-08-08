using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class posibleprestamo80 : MonoBehaviour
{
    public SaveManager player;
    public GameObject CanvasRecordatorioPago;
    public GameObject buttonPause;
    public Text foodText;
    public Toggle prestamoToogle;
    public Text prestamoText;

    private void Start()
    {
        if (Time.timeScale != 1)
        {
            StartCoroutine(waitSecurityTime());
        }
        else
        {
            checkPosiblePrestamo();
        }
    }

    private IEnumerator waitSecurityTime()
    {
        yield return new WaitForSeconds(3);
        checkPosiblePrestamo();

    }
    public void checkPosiblePrestamo()
    {
        if (player.tienePrestamosImpagos())
        {
            print("tiene prestamos impagos");
        }

        else if (player.tienePrestamoActual())
        {
            gameObject.SetActive(true);
            buttonPause.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void hacerPrestamo(int prestamo)
    {
        food_catch_detector.foodCounter += prestamo;
        foodText.text = "X " + food_catch_detector.foodCounter + " / " + InicializadorNivelPlayer.minReqAlimento;
        prestamoText.text = prestamo.ToString();
        prestamoToogle.isOn = true;
        player.hacerPrestamo(prestamo, food_catch_detector.foodCounter, SceneManager.GetActiveScene().buildIndex - 4);
        CanvasRecordatorioPago.SetActive(true);
        gameObject.SetActive(false);
    }
}
