using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class play : MonoBehaviour
{
    public GameObject pause;
    public GameObject transicion;
    public GameObject menu;
    public void playM()
    {
        menu.SetActive(false); 
        transicion.GetComponent<Animator>().SetTrigger("Resume");
        Time.timeScale = 0.0000001f;
        gameObject.SetActive(true);
        StartCoroutine(Pause(3));
        gameObject.GetComponent<Button>().interactable = false;
        pause.GetComponent<Button>().interactable = false;
        pause.SetActive(false);
    }

    private IEnumerator Pause(int p)
    {
        Time.timeScale = 0.0001f;
        float pauseEndTime = Time.realtimeSinceStartup + p;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1;
        pause.SetActive(true);
        gameObject.GetComponent<Button>().interactable = true;
        pause.GetComponent<Button>().interactable = true;
        gameObject.SetActive(false);
        

    }
}
