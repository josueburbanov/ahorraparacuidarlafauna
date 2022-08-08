using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InicializadorNivel2Player : MonoBehaviour
{
    public GetPlayerPrevScene player;
    public Text textMoney;
    public static int minReqAlimento;
    public Text textAlimento;
    public int nivel;
    public Text textAlimentoInit;
    public bool isTest = false;
    void Start()
    {
        if (nivel == 1)
        {
            if (player.PrevPlayer is null)
            {
                //test/////////////////////////////////////////////////////////////////
                if (isTest)
                {
                    player.tag = "Player";
                    DontDestroyOnLoad(player);
                    player.PrevPlayer = new Main();
                    player.PrevPlayer.createTestPlayerForNivel1();
                }
                //test/////////////////////////////////////////////////////////////////
            }

            player.CrearNivel(1);
            resetearContadores();
            minReqAlimento = ReqsMonedas.MONEDAS_REQ_LVL1;
            textAlimento.text = "x 0 / " + minReqAlimento;
            textAlimentoInit.text = "x " + minReqAlimento;
        }
        else if (nivel == 2)
        {
            player.CrearNivel(2);
            minReqAlimento = ReqsMonedas.MONEDAS_REQ_LVL2;
            resetearContadores();
            print("Monedas general: " + player.getMonedasGeneral());
            textMoney.text = "X" + player.getMonedasGeneral();
            int valorPrestamoAnterior = player.getValorPrestamoAnterior(2);
            print("Valor prestamo anterior: " + valorPrestamoAnterior);
            if (valorPrestamoAnterior == 0)
            {
                textAlimento.text = "x 0 / " + minReqAlimento;
                textAlimentoInit.text = "x " + minReqAlimento;
            }
            else
            {
                textAlimentoInit.text = "x " + minReqAlimento + " + " + valorPrestamoAnterior;
                minReqAlimento = minReqAlimento + valorPrestamoAnterior;
                textAlimento.text = "x 0 / " + minReqAlimento;
            }
        }
        else if (nivel == 3)
        {
            /////////////////////////////////////////////
            ///TEST PLAYER NIVEL 3
            ///
            if (isTest)
            {
                player.PrevPlayer = new Main();
                DontDestroyOnLoad(player);
                player.PrevPlayer.createTestPlayerForNivel3PrestamoPago();
            }
            /////////////////////

            player.CrearNivel(3);
            minReqAlimento = ReqsMonedas.MONEDAS_REQ_LVL3;
            resetearContadores();
            print("Monedas general: " + player.getMonedasGeneral());
            textMoney.text = "X" + player.getMonedasGeneral();
            int valorPrestamoAnterior = player.getValorPrestamoAnterior(3);
            print("Valor prestamo anterior: " + valorPrestamoAnterior);
            if (valorPrestamoAnterior == 0)
            {
                textAlimento.text = "x 0 / " + minReqAlimento;
                textAlimentoInit.text = "x " + minReqAlimento;
            }
            else
            {
                textAlimentoInit.text = "x " + minReqAlimento + " + " + valorPrestamoAnterior;
                minReqAlimento = minReqAlimento + valorPrestamoAnterior;
                textAlimento.text = "x 0 / " + minReqAlimento;
            }
        }else if(nivel == 4)
        {
            /////////////////////////////////////////////
            ///TEST PLAYER NIVEL 4
            ///
            if (isTest)
            {
                player.PrevPlayer = new Main();
                DontDestroyOnLoad(player);
                player.PrevPlayer.createTestPlayerForNivel4PrestamoPago();
            }
            /////////////////////

            player.CrearNivel(4);
            minReqAlimento = ReqsMonedas.MONEDAS_REQ_LVL4;
            resetearContadores();
            print("Monedas general: " + player.getMonedasGeneral());
            textMoney.text = "X" + player.getMonedasGeneral();
            int valorPrestamoAnterior = player.getValorPrestamoAnterior(4);
            print("Valor prestamo anterior: " + valorPrestamoAnterior);
            if (valorPrestamoAnterior == 0)
            {
                textAlimento.text = "x 0 / " + minReqAlimento;
                textAlimentoInit.text = "x " + minReqAlimento;
            }
            else
            {
                textAlimentoInit.text = "x " + minReqAlimento + " + " + valorPrestamoAnterior;
                minReqAlimento = minReqAlimento + valorPrestamoAnterior;
                textAlimento.text = "x 0 / " + minReqAlimento;
            }
        }
        else if (nivel == 5)
        {
            /////////////////////////////////////////////
            ///TEST PLAYER NIVEL 5
            ///
            if (isTest)
            {
                player.PrevPlayer = new Main();
                DontDestroyOnLoad(player);
                player.PrevPlayer.createTestPlayerForNivel5PrestamoPago();
            }
            /////////////////////

            player.CrearNivel(5);
            minReqAlimento = ReqsMonedas.MONEDAS_REQ_LVL5;
            resetearContadores();
            print("Monedas general: " + player.getMonedasGeneral());
            textMoney.text = "X" + player.getMonedasGeneral();
            int valorPrestamoAnterior = player.getValorPrestamoAnterior(5);
            print("Valor prestamo anterior: " + valorPrestamoAnterior);
            if (valorPrestamoAnterior == 0)
            {
                textAlimento.text = "x 0 / " + minReqAlimento;
                textAlimentoInit.text = "x " + minReqAlimento;
            }
            else
            {
                textAlimentoInit.text = "x " + minReqAlimento + " + " + valorPrestamoAnterior;
                minReqAlimento = minReqAlimento + valorPrestamoAnterior;
                textAlimento.text = "x 0 / " + minReqAlimento;
            }
        }
        else if (nivel == 6)
        {
            /////////////////////////////////////////////
            ///TEST PLAYER NIVEL 6
            ///
            if (isTest)
            {
                player.PrevPlayer = new Main();
                DontDestroyOnLoad(player);
                player.PrevPlayer.createTestPlayerForNivel6PrestamoPago();
            }
            /////////////////////

            player.CrearNivel(6);
            minReqAlimento = ReqsMonedas.MONEDAS_REQ_LVL6;
            resetearContadores();
            print("Monedas general: " + player.getMonedasGeneral());
            textMoney.text = "X" + player.getMonedasGeneral();
            int valorPrestamoAnterior = player.getValorPrestamoAnterior(6);
            print("Valor prestamo anterior: " + valorPrestamoAnterior);
            if (valorPrestamoAnterior == 0)
            {
                textAlimento.text = "x 0 / " + minReqAlimento;
                textAlimentoInit.text = "x " + minReqAlimento;
            }
            else
            {
                textAlimentoInit.text = "x " + minReqAlimento + " + " + valorPrestamoAnterior;
                minReqAlimento = minReqAlimento + valorPrestamoAnterior;
                textAlimento.text = "x 0 / " + minReqAlimento;
            }
        }
        else if (nivel == 7)
        {
            /////////////////////////////////////////////
            ///TEST PLAYER NIVEL 7
            ///
            if (isTest)
            {
                player.PrevPlayer = new Main();
                DontDestroyOnLoad(player);
                player.PrevPlayer.createTestPlayerForNivel7PrestamoPago();
            }
            /////////////////////

            player.CrearNivel(7);
            minReqAlimento = ReqsMonedas.MONEDAS_REQ_LVL7;
            resetearContadores();
            print("Monedas general: " + player.getMonedasGeneral());
            textMoney.text = "X" + player.getMonedasGeneral();
            int valorPrestamoAnterior = player.getValorPrestamoAnterior(7);
            print("Valor prestamo anterior: " + valorPrestamoAnterior);
            if (valorPrestamoAnterior == 0)
            {
                textAlimento.text = "x 0 / " + minReqAlimento;
                textAlimentoInit.text = "x " + minReqAlimento;
            }
            else
            {
                textAlimentoInit.text = "x " + minReqAlimento + " + " + valorPrestamoAnterior;
                minReqAlimento = minReqAlimento + valorPrestamoAnterior;
                textAlimento.text = "x 0 / " + minReqAlimento;
            }
        }
    }

    void resetearContadores()
    {
        food_catch_detector.foodCounter = 0;
        food_catch_detector.comodinesPositivos = 0;
        food_catch_detector.comodinesNegativos = 0;
    }

}
