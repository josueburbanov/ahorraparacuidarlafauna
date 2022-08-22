using System;
using
    System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class followPlayerX : MonoBehaviour
{
    public Transform targetTransformOso;
    private Transform targetTransform;
    public Transform targetTransformArmadillo;
    public Transform targetTransformTapir;
    private Transform targetTransform2;
    public Transform targetTransform2Oso;
    public Transform targetTransform2Armadillo;
    public Transform targetTransform2Tapir;
    public static bool isOso;
    public static bool isArmadillo;
    public static bool isTapir;
    Vector3 tempVec3 = new Vector3();
    public bool isDialog;
    public bool needToBeCentered;
    public bool notJumper;
    public bool smoothed;

    private void Awake()
    {
        prueba.crearJugadorPrueba();
        controllador_caracter.VerificarPersonaje();
    }

    private void Start()
    {
        if (isOso)
        {
            targetTransformOso.gameObject.SetActive(true);
            targetTransformArmadillo.gameObject.SetActive(false);
            targetTransformTapir.gameObject.SetActive(false);
            targetTransform = targetTransformOso;
            print("Oso armed");
        }
        else if (isArmadillo)
        {
            targetTransformArmadillo.gameObject.SetActive(true);
            targetTransformTapir.gameObject.SetActive(false);
            targetTransformOso.gameObject.SetActive(false);
            targetTransform = targetTransformArmadillo;
            print("Armadillo armed");
        }
        else if (isTapir)
        {
            targetTransformTapir.gameObject.SetActive(true);
            targetTransformOso.gameObject.SetActive(false);
            targetTransformArmadillo.gameObject.SetActive(false);
            targetTransform = targetTransformTapir;
            print("Tapir armed");
        }


        if (isOso)
        {
            targetTransform2 = targetTransform2Oso;
        }
        else if (isArmadillo)
        {
            targetTransform2 = targetTransform2Armadillo;
        }
        else if (isTapir)
        {
            targetTransform2 = targetTransform2Tapir;
        }

        if (player_controller1.health < 5)
        {
            if (checkpoint.isCheckedIn)
            {
                print("was checked in");
                targetTransform.transform.position = checkpoint.checkedInPosition;
                food_catch_detector.foodCounter = checkpoint.foodCounter;
                food_catch_detector.comodinesPositivos = checkpoint.positiveCounter;
                food_catch_detector.comodinesNegativos = checkpoint.negativeCounter;
                GameObject.Find("Text_positivos").GetComponent<Text>().text = "X " + food_catch_detector.comodinesPositivos.ToString();
                GameObject.Find("Text_negativos").GetComponent<Text>().text = "X " + Math.Abs(food_catch_detector.comodinesNegativos).ToString();
                GameObject.Find("Text_food").GetComponent<Text>().text = "X " + food_catch_detector.foodCounter + " / " + InicializadorNivelPlayer.minReqAlimento;
                SaveManager player = GameObject.FindGameObjectWithTag("LogicalPlayer").GetComponent<SaveManager>();
                if (player.getPrestamoAnterior() != null)
                {
                    if (player.getPrestamoAnterior().Nivel == SceneManager.GetActiveScene().buildIndex - 4)
                    {
                        if (player.tienePrestamosImpagos())
                        {
                            player.pagarPrestamo();
                        }
                    }
                }
            }
        }
    }

    void FixedUpdate()
    {
        bool checker = targetTransform2 != null ? targetTransform2.gameObject.activeSelf : false;
        if (checker)
        {
            tempVec3.x = targetTransform2.position.x + 5f;
            tempVec3.y = targetTransform2.position.y + 4f;

            if (isDialog)
            {
                tempVec3.x = targetTransform2.position.x + 2f;
                tempVec3.y = targetTransform2.position.y + 4.2f;
            }
            else if (needToBeCentered)
            {
                tempVec3.x = targetTransform2.position.x;
                tempVec3.y = targetTransform2.position.y - 2f;
            }
            else if (notJumper)
            {
                tempVec3.x = targetTransform2.position.x;
            }
            else if (smoothed)
            {
                tempVec3.x = targetTransform.position.x + 5f;
                tempVec3.y = targetTransform.position.y + 2f;
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, tempVec3, 0.125f);
                tempVec3 = smoothedPosition;
            }


            tempVec3.z = this.transform.position.z;
            this.transform.position = tempVec3;
        }
        else
        {
            tempVec3.x = targetTransform.position.x + 5f;
            tempVec3.y = targetTransform.position.y + 4f;

            if (isDialog)
            {
                tempVec3.x = targetTransform.position.x + 2f;
                tempVec3.y = targetTransform.position.y + 4.2f;
            }
            else if (needToBeCentered)
            {
                tempVec3.x = targetTransform.position.x;
                tempVec3.y = targetTransform.position.y - 2f;
            }
            else if (notJumper)
            {
                tempVec3.x = targetTransform.position.x;
                tempVec3.y = transform.position.y;
            }
            else if (smoothed)
            {
                tempVec3.x = targetTransform.position.x + 5f;
                tempVec3.y = targetTransform.position.y + 1f;
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, tempVec3, 0.125f);
                tempVec3 = smoothedPosition;
            }

            tempVec3.z = this.transform.position.z;
            this.transform.position = tempVec3;
        }
    }
}

