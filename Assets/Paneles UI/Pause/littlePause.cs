using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class littlePause : MonoBehaviour
{
    bool flag;
    public GameObject canvasInicioNivel;
    private void Start()
    {
        if(player_controller1.health == 5)
        {
            Stop();
        }
        else
        {
            if (gameObject.activeSelf)
            {
                gameObject.SetActive(false);
                canvasInicioNivel.SetActive(true);
            }
        }
    }

    public void littlePausar()
    {
        StartCoroutine(Pause(3));
    }

    public void Stop()
    {
        Time.timeScale = 0;
        FindInActiveObjectByName("ButtonPause").SetActive(false);
        littlePausar();
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
        if (Time.timeScale == 1 && !flag && player_controller1.health == 5)
        {
            Stop();
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        flag = true;
    }

    private IEnumerator Pause(int p)
    {
        Time.timeScale = 0.0001f;
        float pauseEndTime = Time.realtimeSinceStartup + p;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        //Time.timeScale = 1;
        FindInActiveObjectByName("BtnInstrucciones (1)").SetActive(true);

    }
}
