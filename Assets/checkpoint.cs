using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    private bool isHit;
    public static Vector3 checkedInPosition;
    public static bool isCheckedIn;
    public GameObject canvasCheckPoint;
    public static int foodCounter;
    public static int positiveCounter;
    public static int negativeCounter;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!isHit)
        {
            foodCounter = food_catch_detector.foodCounter;
            positiveCounter = food_catch_detector.comodinesPositivos;
            negativeCounter = food_catch_detector.comodinesNegativos;
            Vector3 positionToSave = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            checkedInPosition = positionToSave;
            if (canvasCheckPoint.activeSelf)
            {
                canvasCheckPoint.GetComponent<Animator>().SetTrigger("checkpoint");
            }
            else
            {
                canvasCheckPoint.SetActive(true);
            }

            print("CheckPoint Active");
            isCheckedIn = true;
            isHit = true;
        }
    }

    private void Start()
    {
        if(player_controller1.health == 5 && isCheckedIn)
        {
            isCheckedIn = false;
        }
    }
}
