using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class activateCanvas80 : MonoBehaviour
{
    private bool isHit;
    public GameObject canvas80;
    public SaveManager player;
    public GameObject canvasOfrecePrestamo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(!(player.getLastFinishedLevel() > SceneManager.GetActiveScene().buildIndex - 4));
        print(player.getLastFinishedLevel());
        if (!isHit && !(player.getLastFinishedLevel() > SceneManager.GetActiveScene().buildIndex - 4))
        {
            if (!player.tienePrestamosImpagos())
            {
                canvasOfrecePrestamo.SetActive(true);
                print("Sin prestamos impagos");
            }
            else
            {
                print("Tiene prestamos impagos");
            }
        }
    }

    public void activateCanvas()
    {
        if (player.tienePrestamosImpagos())
        {
            //Recordatorio pagar préstamo, en este caso no ofrece préstamo xq no hay la posibilidad
            print("Tiene préstamos impagos");
        }
        else
        {
            print("Activate canvas 80");
            canvas80.SetActive(true);
            Time.timeScale = 0;
            isHit = true;
            GameObject.Find("ButtonPause").SetActive(false);
        }

    }
}
