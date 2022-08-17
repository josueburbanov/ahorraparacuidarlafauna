using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controladorDialogo : MonoBehaviour
{
    public GameObject canvasDialogo;
    private GameObject transicion;
    private GameObject buttonPause;
    public Text greatText;
    public static bool compradorOneTime20;
    public static bool compradorOneTime60;
    public static bool compradorOneTime90;

    public void Start()
    {
        compradorOneTime20 = true;
        compradorOneTime60 = true;
        compradorOneTime90 = true;
        transicion = GameObject.FindGameObjectWithTag("CanvasPrincipal");
        buttonPause = FindInActiveObjectByName("ButtonPause");
    }

    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }

    private void Update()
    {
        if(food_catch_detector.foodCounter >= 50 && food_catch_detector.foodCounter <= 58 && compradorOneTime20 && Time.timeScale == 1)
        {
            canvasDialogo.SetActive(true);
            greatText.text = "Genial! Has <b>ahorrado</b> 50 continúa así.\n<b>Ahorrar</b> requiere persistencia.";
            compradorOneTime20 = false;
            StartCoroutine(waitSomeSeconds());

        }
        else if(food_catch_detector.foodCounter >= 100 && food_catch_detector.foodCounter <= 108 && compradorOneTime60 && Time.timeScale == 1)
        {
            canvasDialogo.SetActive(true);
            greatText.text = "Has <b>ahorrado</b> 100!\nContinua <b>ahorrando</b> y lograrás pasar de nivel.";
            compradorOneTime60 = false;
            StartCoroutine(waitSomeSeconds());

        }
        else if (food_catch_detector.foodCounter >= 120 && food_catch_detector.foodCounter <= 128 && compradorOneTime90 && Time.timeScale == 1)
        {
            canvasDialogo.SetActive(true);
            greatText.text = "Genial has <b>ahorrado</b> 120!\n<b>Ahorrar</b> te ayudará a abrir el siguiente nivel.";
            compradorOneTime90 = false;
            StartCoroutine(waitSomeSeconds());
        }
    }

    IEnumerator waitSomeSeconds()
    {
        yield return new WaitForSeconds(3.5f);
        canvasDialogo.SetActive(false);
    }

    private IEnumerator Pause(int p)
    {
        buttonPause.SetActive(false);
        
        Time.timeScale = 0.0001f;
        float pauseEndTime = Time.realtimeSinceStartup + p;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;

        }
        Time.timeScale = 1f;
        buttonPause.SetActive(true);
        canvasDialogo.SetActive(false);
    }
}
