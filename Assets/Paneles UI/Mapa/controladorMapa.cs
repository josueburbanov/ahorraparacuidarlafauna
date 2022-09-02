using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controladorMapa : MonoBehaviour
{
    public GameObject ImagenNivelCompleto1;
    public GameObject ImagenNivelCompleto2;
    public GameObject ImagenNivelCompleto3;
    public GameObject ImagenNivelCompleto4;
    public GameObject ImagenNivelCompleto5;
    public GameObject ImagenNivelCompleto6;
    public GameObject ImagenNivelCompleto7;
    public SaveManager player;
    private traerPin pin;
    public GameObject oso;
    public GameObject armadillo;
    public GameObject tapir;
    public Text textInit;
    public Text textMonedas;


    void Start()
    {
        textInit.text = "Hola, " + SaveManager.getNickActual()+"!";
        textMonedas.text = "X" + player.getMonedasOverall();
        switch (SaveManager.getPersonaje())
        {
            case "oso":
                oso.SetActive(true);
                break;
            case "armadillo":
                armadillo.SetActive(true);
                break;
            case "tapir":
                tapir.SetActive(true);
                break;

        }



        //switch (player.getLastFinishedLevel() + 1)
        switch (7)
        {
            case 1:
                ImagenNivelCompleto1.SetActive(true);
                pin = ImagenNivelCompleto1.GetComponent<traerPin>();
                pin.justTraerPinMethod();
                break;
            case 2:
                ImagenNivelCompleto1.SetActive(true);
                ImagenNivelCompleto2.SetActive(true);
                pin = ImagenNivelCompleto2.GetComponent<traerPin>();
                pin.justTraerPinMethod();
                break;
            case 3:
                ImagenNivelCompleto1.SetActive(true);
                ImagenNivelCompleto2.SetActive(true);
                ImagenNivelCompleto3.SetActive(true);
                pin = ImagenNivelCompleto3.GetComponent<traerPin>();
                pin.justTraerPinMethod();
                break;
            case 4:
                ImagenNivelCompleto1.SetActive(true);
                ImagenNivelCompleto2.SetActive(true);
                ImagenNivelCompleto3.SetActive(true);
                ImagenNivelCompleto4.SetActive(true);
                pin = ImagenNivelCompleto4.GetComponent<traerPin>();
                pin.justTraerPinMethod();
                break;
            case 5:
                ImagenNivelCompleto1.SetActive(true);
                ImagenNivelCompleto2.SetActive(true);
                ImagenNivelCompleto3.SetActive(true);
                ImagenNivelCompleto4.SetActive(true);
                ImagenNivelCompleto5.SetActive(true);
                pin = ImagenNivelCompleto5.GetComponent<traerPin>();
                pin.justTraerPinMethod();
                break;
            case 6:
                ImagenNivelCompleto1.SetActive(true);
                ImagenNivelCompleto2.SetActive(true);
                ImagenNivelCompleto3.SetActive(true);
                ImagenNivelCompleto4.SetActive(true);
                ImagenNivelCompleto5.SetActive(true);
                ImagenNivelCompleto6.SetActive(true);
                pin = ImagenNivelCompleto6.GetComponent<traerPin>();
                pin.justTraerPinMethod();
                break;
            case 7:
                ImagenNivelCompleto1.SetActive(true);
                ImagenNivelCompleto2.SetActive(true);
                ImagenNivelCompleto3.SetActive(true);
                ImagenNivelCompleto4.SetActive(true);
                ImagenNivelCompleto5.SetActive(true);
                ImagenNivelCompleto6.SetActive(true);
                ImagenNivelCompleto7.SetActive(true);
                pin = ImagenNivelCompleto7.GetComponent<traerPin>();
                pin.justTraerPinMethod();
                break;
            case 8:
                ImagenNivelCompleto1.SetActive(true);
                ImagenNivelCompleto2.SetActive(true);
                ImagenNivelCompleto3.SetActive(true);
                ImagenNivelCompleto4.SetActive(true);
                ImagenNivelCompleto5.SetActive(true);
                ImagenNivelCompleto6.SetActive(true);
                ImagenNivelCompleto7.SetActive(true);
                pin = ImagenNivelCompleto7.GetComponent<traerPin>();
                pin.justTraerPinMethod();
                break;
            default:
                //ImagenNivelCompleto1.SetActive(false);
                ImagenNivelCompleto2.SetActive(false);
                ImagenNivelCompleto3.SetActive(false);
                ImagenNivelCompleto4.SetActive(false);
                ImagenNivelCompleto5.SetActive(false);
                ImagenNivelCompleto6.SetActive(false);
                ImagenNivelCompleto7.SetActive(false);
                pin = ImagenNivelCompleto1.GetComponent<traerPin>();
                pin.justTraerPinMethod();
                break;
        }
    }
}
