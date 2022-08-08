using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changetolevel4 : MonoBehaviour
{
    private bool isHit = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name.Equals("Oso piezasperfil34"))
        {
            if (!isHit)
            {
                isHit = true;
                SceneManager.LoadSceneAsync(3);
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
