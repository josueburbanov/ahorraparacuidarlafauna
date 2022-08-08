using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arana_activate : MonoBehaviour
{
    private bool firstTime;
    public GameObject aranaGO;
    public bool activate;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!firstTime)
        {
            if (activate) {  
            aranaGO.SetActive(true);
            
            }
            else
            {
                aranaGO.SetActive(false);
            }
            firstTime = true;

        }
    }
}
