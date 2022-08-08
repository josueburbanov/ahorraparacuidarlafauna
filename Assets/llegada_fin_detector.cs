using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llegada_fin_detector : MonoBehaviour
{
    private bool isHit = false;
    public GameObject canvasFinGanador;
    public GameObject canvasFinTotalPerdedor;
    public GetPlayerPrevScene player;
    public GameObject buttonPause;
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
            canvasFinTotalPerdedor.SetActive(true);
        }
        else
        {
            canvasFinGanador.SetActive(true);
            if (player.PrevPlayer.tienePrestamosImpagos())
            {
                player.PrevPlayer.pagarPrestamo();
                print("prestamo pagado");
            }
        }
    }
}
