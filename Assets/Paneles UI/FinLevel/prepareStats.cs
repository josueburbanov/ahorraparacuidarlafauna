using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prepareStats : MonoBehaviour
{
    private Text foodText;
    private Text mortinoText;
    private Text aguacatilloText;
    private Text moneyText;
    public SaveManager player;

    private void Awake()
    {
        foodText = GameObject.Find("FoodTextStats").GetComponent<Text>();
        mortinoText = GameObject.Find("MortinoTextStats").GetComponent<Text>();
        aguacatilloText = GameObject.Find("AguacatilloTextStats").GetComponent<Text>();
        moneyText = GameObject.Find("MoneyTextStats").GetComponent<Text>();

        foodText.text = "" + (food_catch_detector.foodCounter + Math.Abs( food_catch_detector.comodinesNegativos) - food_catch_detector.comodinesPositivos);
        mortinoText.text = "" + food_catch_detector.comodinesNegativos;
        aguacatilloText.text = "" + food_catch_detector.comodinesPositivos;
        moneyText.text = "" + food_catch_detector.foodCounter;
        player.anotarStats(food_catch_detector.foodCounter, food_catch_detector.comodinesPositivos, food_catch_detector.comodinesNegativos,
            food_catch_detector.foodCounter);        
        if (player.tienePrestamosImpagos())
        {
            print("Finish con préstamo");
            player.terminarNivelConPrestamo();
            player.agregarMonedasAsociadasPrestamo(food_catch_detector.foodCounter);
        }
        else
        {
            print("Finish sin préstamo");
            player.terminarNivelSinPrestamo();
        }
        player_controller1.health = 5;
    }
}

