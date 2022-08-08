using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogManagere : MonoBehaviour
{
    public GameObject canvasDialog;
    public Text greatText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        canvasDialog.gameObject.SetActive(true);
        greatText.text = "!Muy bien!\nAhorrar requiere persistencia.";
        Time.timeScale = 0;
    }
}
