using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Pause(2));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Pause(int p)
    {
        Time.timeScale = 0.0001f;
        float pauseEndTime = Time.realtimeSinceStartup + p;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;

        }
        Time.timeScale = 1f;
    }
}
