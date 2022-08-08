using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class llegada_detector2 : MonoBehaviour
{
    // Start is called before the first frame update

    private bool isHit = false;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name.Equals("Oso piezasperfil34"))
        {
            if (!isHit)
            {
                print("Level 2 finished");
                isHit = true;
                Application.Quit();
            }

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
