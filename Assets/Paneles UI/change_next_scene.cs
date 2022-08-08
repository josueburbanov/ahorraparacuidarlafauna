using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change_next_scene : MonoBehaviour
{
    public Animator anim;
    public static bool changeLevel;
    public static bool changeCustomLevel;
    public static bool changeInitLevel;
    public static bool resetLevel;
    private int nivel;
    private SaveManager player;

    public void changeLevelActivator()
    {
        changeLevel = true;
    }

    public void resetLevelActivator()
    {
        resetLevel = true;
    }

    public void changeLevelActivator(int nivel)
    {
        changeCustomLevel = true;
        this.nivel = nivel;
        if (nivel == 0)
        {
            player = GameObject.FindGameObjectWithTag("LogicalPlayer").GetComponent<SaveManager>();
            if (player.tienePrestamosImpagos())
            {
                player.quitarMonedasXNoPago(player.getValorMonedasPrestamo());
                player.pagarPrestamo();
            }
            checkpoint.isCheckedIn = false;
        }
    }

    public void terminarJuego()
    {
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (changeLevel)
        {
            changeLevel = false;
            StartCoroutine(LoadNextLevel());
        }
        else if (resetLevel)
        {
            resetLevel = false;
            StartCoroutine(LoadSameLevel());
        }
        else if (changeCustomLevel)
        {
            changeCustomLevel = false;
            StartCoroutine(LoadCustomLevel(nivel));
        }
        else if (changeInitLevel)
        {
            changeInitLevel = false;
            StartCoroutine(LoadInitLevel());
        }

    }

    IEnumerator LoadNextLevel()
    {
        anim.SetTrigger("start");
        Time.timeScale = 1;
        yield return new WaitForSeconds(1f);
        SaveManager.SaveJuego();
        if (SceneManager.GetActiveScene().buildIndex + 1 == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
        else
        {
            if (SceneManager.GetActiveScene().buildIndex == 10)
            {
                if (followPlayerX.isArmadillo)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
                }
                else if (followPlayerX.isTapir)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

        }
    }

    IEnumerator LoadCustomLevel(int nivel)
    {
        anim.SetTrigger("start");
        Time.timeScale = 1;
        yield return new WaitForSeconds(1f);
        SaveManager.SaveJuego();
        SceneManager.LoadScene(nivel + 4);
    }

    IEnumerator LoadInitLevel()
    {
        anim.SetTrigger("start");
        Time.timeScale = 1;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }

    IEnumerator LoadSameLevel()
    {
        anim.SetTrigger("start");
        Time.timeScale = 1;
        yield return new WaitForSeconds(1f);
        SaveManager.SaveJuego();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
