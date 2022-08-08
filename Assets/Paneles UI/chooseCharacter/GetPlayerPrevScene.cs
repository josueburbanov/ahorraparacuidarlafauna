using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPlayerPrevScene : MonoBehaviour
{
    private Main prevPlayer;
    public food_catch_detector food_Catch_Detector;
    public Text foodText;
    public bool isTest;

    public Main PrevPlayer { get => prevPlayer; set => prevPlayer = value; }

    void Awake()
    {


        ////test----------------------------------
        if (isTest)
        {

            if (!(GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<GetPlayerPrevScene>() is null))
            {
                if (GameObject.FindGameObjectsWithTag("Player").Length == 1)
                {
                    PrevPlayer = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<GetPlayerPrevScene>().PrevPlayer;
                    print(PrevPlayer);
                    //print(prevPlayer.Partida.Niveles.Count);
                }
                else
                {
                    PrevPlayer = GameObject.FindGameObjectsWithTag("Player")[GameObject.FindGameObjectsWithTag("Player").Length - 1].GetComponent<GetPlayerPrevScene>().PrevPlayer;
                    print(PrevPlayer);
                }

            }
        }
        ////test----------------------------------
        //else
        {
            if (!(GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Main>() is null))
            {
                prevPlayer = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Main>();
            }
            print(prevPlayer);
        }
    }

    public void createTestPlayer()
    {
        PrevPlayer = new Main();
        PrevPlayer.createTestPlayerForNivel1();
    }

    public void SeleccionarCaracter(string personaje)
    {
        PrevPlayer.seleccionarCaracter(personaje);
    }

    public void CrearNivel(int nivel)
    {
        PrevPlayer.crearNivel(nivel);
    }
    public void TerminarNivelConPrestamo()
    {
        PrevPlayer.terminarNivel();
        print(PrevPlayer);
    }

    public void TerminarNivelSinPrestamo()
    {
        PrevPlayer.terminarNivelSinPrestamo();
        print(PrevPlayer);
    }

    public void hacerPrestamo(int cantidad)
    {
        PrevPlayer.hacerPrestamo(cantidad);
        food_catch_detector.foodCounter += cantidad;
        foodText.text = "X " + food_catch_detector.foodCounter + " / " + InicializadorNivel2Player.minReqAlimento;
    }

    public void anotarAlimento()
    {
        PrevPlayer.anotarAlimento(food_catch_detector.foodCounter);
    }

    public void anotarComodinesPositivos()
    {
        PrevPlayer.anotarComodinesPositivos(food_catch_detector.comodinesPositivos);
    }
    public void anotarComodinesNegativos()
    {
        PrevPlayer.anotarComodinesNegativos(food_catch_detector.comodinesNegativos);
    }
    public void anotarMonedas()
    {
        PrevPlayer.anotarMonedas(food_catch_detector.foodCounter);
    }
    public int getValorPrestamoAnterior(int currentLevel)
    {
        //return PrevPlayer.getValorPrestamoAnterior(currentLevel);
        return 0;
    }

    public int getMonedasGeneral()
    {
        return PrevPlayer.getMonedasOverall();
    }

    public void reiniciarNivel()
    {
        PrevPlayer.prepararNivelReiniciar();
    }

    public void terminarNivelAMapa()
    {
        player_controller1.health = 5;
    }

    public void reiniciarVidas()
    {
        player_controller1.health = 5;
    }

    public void terminarNivelXTerminoVidas()
    {
        PrevPlayer.terminarNivelXTerminoVidas();
    }
    public void resume()
    {
        Time.timeScale = 1;
    }

    public int getLastFinishedLevel()
    {
        return PrevPlayer.getLastFinishedLevel();
    }
}
