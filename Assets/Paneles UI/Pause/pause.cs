using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject play;
    public GameObject menu;
    public void pausarJuego()
    {
        play.SetActive(true);
        menu.SetActive(true);
        gameObject.SetActive(false);
        Time.timeScale = 0;
    }
}
