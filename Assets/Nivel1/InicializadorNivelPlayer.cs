using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InicializadorNivelPlayer : MonoBehaviour
{
    public SaveManager player;
    public int nivel;
    public Text textMoney;
    public static int minReqAlimento;
    public Text textAlimento;
    public Text textAlimentoInit;
    public Text textBestLevel;
    public Toggle toogle;
    public Text textCantidadPrestamo;
    public Text lifeText;
    public Text textInstruccionesInicio;
    public Text textNivelSuperado;


    void Start()
    {
        if (nivel == 1)
        {
            player.crearNivel(1);
            minReqAlimento = ReqsMonedas.MONEDAS_REQ_LVL1;
            anotarValoresSegunPrestamo();
            textInstruccionesInicio.text = "Salta y evita caer al precipicio.";
        }
        else if (nivel == 2)
        {
            player.crearNivel(2);
            minReqAlimento = ReqsMonedas.MONEDAS_REQ_LVL2;
            anotarValoresSegunPrestamo();
            textInstruccionesInicio.text = "Salta y evita caer al agua.";
        }
        else if (nivel == 3)
        {
            player.crearNivel(3);
            minReqAlimento = ReqsMonedas.MONEDAS_REQ_LVL3;
            anotarValoresSegunPrestamo();
            textInstruccionesInicio.text = "Ten cuidado con las hojas.";
        }
        else if (nivel == 4)
        {
            player.crearNivel(4);
            minReqAlimento = ReqsMonedas.MONEDAS_REQ_LVL4;
            anotarValoresSegunPrestamo();
            textInstruccionesInicio.text = "Ten cuidado con las escaleras rotas.";
        }
        else if (nivel == 5)
        {
            player.crearNivel(5);
            minReqAlimento = ReqsMonedas.MONEDAS_REQ_LVL5;
            anotarValoresSegunPrestamo();
            textInstruccionesInicio.text = "Cuidado con los troncos.";
        }
        else if (nivel == 6)
        {
            player.crearNivel(6);
            minReqAlimento = ReqsMonedas.MONEDAS_REQ_LVL6;
            anotarValoresSegunPrestamo();
            textInstruccionesInicio.text = "Aplasta las piedras antes que caigan sobre ti. Aplasta sobre el alimento para capturarlo.";
        }
        else if (nivel == 7)
        {
            player.crearNivel(7);
            minReqAlimento = ReqsMonedas.MONEDAS_REQ_LVL7;
            anotarValoresSegunPrestamo();
            textInstruccionesInicio.text = "Descubre las cosas fantásticas que ocurren en este nivel.";
        }

    }

    private void anotarValoresSegunPrestamo()
    {
        resetearContadores();
        if(player.getLastFinishedLevel() > nivel)
        {
            textNivelSuperado.gameObject.SetActive(true);
        }
        textBestLevel.text = "X" + player.getBest(nivel);
        textMoney.text = "X" + player.getMonedasOverall();
        lifeText.text = "X " + player_controller1.health.ToString();
        int valorPrestamoAnterior = player.getValorPrestamoAnterior();
        if (valorPrestamoAnterior == 0 && !player.tienePrestamosImpagos())
        {
            textAlimento.text = "x " + food_catch_detector.foodCounter + " / " + minReqAlimento;
            textAlimentoInit.text = "x " + minReqAlimento;
            textCantidadPrestamo.text = "0";
            toogle.isOn = false;
        }
        else if (player.getPrestamoAnterior() != null)
        {
            if (player.getPrestamoAnterior().Nivel == SceneManager.GetActiveScene().buildIndex - 4)
            {
                textAlimento.text = "x " + food_catch_detector.foodCounter + " / " + minReqAlimento;
                textAlimentoInit.text = "x " + minReqAlimento;
                textCantidadPrestamo.text = "0";
                toogle.isOn = false;
                if (player.tienePrestamosImpagos() && player_controller1.health == 5)
                {
                    print("--------Prestamo eliminado");
                    player.pagarPrestamo();
                }
            }
            else
            {
                textAlimentoInit.text = "x " + minReqAlimento + " + " + valorPrestamoAnterior;
                textCantidadPrestamo.text = "x " + valorPrestamoAnterior.ToString();
                minReqAlimento = minReqAlimento + valorPrestamoAnterior;
                textAlimento.text = "x " + food_catch_detector.foodCounter + "/ " + minReqAlimento;
                toogle.isOn = true;
            }
        }
        else
        {
            textAlimentoInit.text = "x " + minReqAlimento + " + " + valorPrestamoAnterior;
            textCantidadPrestamo.text = "x " + valorPrestamoAnterior.ToString();
            minReqAlimento = minReqAlimento + valorPrestamoAnterior;
            textAlimento.text = "x " + food_catch_detector.foodCounter + "/ " + minReqAlimento;
            toogle.isOn = true;
        }
    }

    private void resetearContadores()
    {
        if (!checkpoint.isCheckedIn)
        {
            food_catch_detector.foodCounter = 0;
            food_catch_detector.comodinesPositivos = 0;
            food_catch_detector.comodinesNegativos = 0;
        }
        if (player_controller1.health == 5)
        {
            food_catch_detector.foodCounter = 0;
            food_catch_detector.comodinesPositivos = 0;
            food_catch_detector.comodinesNegativos = 0;
        }

    }

}
