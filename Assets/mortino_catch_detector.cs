using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mortino_catch_detector : MonoBehaviour
{
    public static int foodCounter = 0;
    public Text foodTextUI;
    private bool isHit = false;
    private Animator anim;
    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.name.Equals("Oso piezasperfil34"))
        {
            if (!isHit)
            {
                foodCounter = Int32.Parse(foodTextUI.text.Split('X')[1]);
                foodCounter -= UnityEngine.Random.Range(2, 7);
                foodTextUI.text = "X " + foodCounter;
                isHit = true;
                transform.gameObject.SetActive(false);
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
