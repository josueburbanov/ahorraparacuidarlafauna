using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changing_level6 : MonoBehaviour
{
    private bool isHit = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isHit)
        {
            isHit = true;
            SceneManager.LoadSceneAsync(1);
        }
    }
    void Start()

    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
