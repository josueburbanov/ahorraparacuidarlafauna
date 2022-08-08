using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDetector : MonoBehaviour
{

    private bool isHit = false;
    private Animator anim;
    public bool hitted = false;
    public change_next_scene change_Next_Scene;
    public bool isIns;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        anim = collider.GetComponent<Animator>();
        if (collider.name.Equals("Oso piezasperfil34"))
        {
            if (!isHit)
            {
                anim.SetTrigger("isFalling");
                isHit = true;
                hitted = true;
                if (isIns)
                {
                    StartCoroutine(WaitTilFalling());
                }
                
            }

        }
    }

    IEnumerator WaitTilFalling()
    {
        yield return new WaitForSeconds(0.1f);
        change_Next_Scene.resetLevelActivator();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
