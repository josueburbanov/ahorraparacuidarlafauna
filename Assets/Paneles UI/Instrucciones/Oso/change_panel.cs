using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class change_panel : MonoBehaviour
{
    Animator anim;
    public player_cont_Ins oso;
    public GameObject instruccionesSiguiente;
    public int stepNumber;
    private bool stepComplete;
    public GameObject alimentoOso;
    private bool changeOneTime;
    public change_next_scene change_Next_Scene;
    private bool isFinished;
    public GameObject creditoIns;

    void Start()
    {
        anim = GetComponent<Animator>();
        if (stepNumber == 1)
        {
            stepComplete = oso.firstStepIns;
        }
        else if (stepNumber == 2)
        {
            stepComplete = oso.secondStepIns;
        }
        else if (stepNumber == 3)
        {
            stepComplete = oso.thirdStepIns;
        }
        else if (stepNumber == 4)
        {
            stepComplete = oso.fourthStepIns;
            if (alimentoOso != null)
            {
                Instantiate(alimentoOso, new Vector3(38f, 1f, 0f), Quaternion.identity);
            }
        }
        else if (stepNumber == 5)
        {
            stepComplete = oso.fifthStepIns;
            if (alimentoOso != null)
            {
                Instantiate(alimentoOso, new Vector3(49f, -2.04f, 0f), Quaternion.identity);
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("End");
            oso.gameObject.SetActive(true);
            Time.timeScale = 1;
            if (instruccionesSiguiente == null && !changeOneTime)
            {
                isFinished = true;
                changeOneTime = true;
            }
        }

        if (stepNumber == 1)
        {
            stepComplete = oso.firstStepIns;
        }
        else if (stepNumber == 2)
        {
            stepComplete = oso.secondStepIns;
        }
        else if (stepNumber == 3)
        {
            stepComplete = oso.thirdStepIns;
        }
        else if (stepNumber == 4)
        {
            stepComplete = oso.fourthStepIns;
        }
        else if (stepNumber == 5)
        {
            stepComplete = oso.fifthStepIns;
        }
        else if (stepNumber == 6)
        {
            stepComplete = isFinished;
        }

        if (stepComplete == true)
        {
            if (instruccionesSiguiente != null)
            {
                instruccionesSiguiente.gameObject.SetActive(true);
                Time.timeScale = 0;
                gameObject.SetActive(false);
            }
            else
            {
                isFinished = false;
                creditoIns.SetActive(true);

            }
        }
    }
}
