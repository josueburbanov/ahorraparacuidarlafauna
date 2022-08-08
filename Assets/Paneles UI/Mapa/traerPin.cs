using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traerPin : MonoBehaviour
{
    public GameObject pin;
    public change_next_scene changer;
    public int nivel;

    public void traerPinMethod()
    {
        Vector3 newPosition = transform.position;
        newPosition.y += 1f;
        pin.transform.position = newPosition;
        StartCoroutine(waitForSomeTime(0.5f));

    }

    public void justTraerPinMethod()
    {
        Vector3 newPosition = transform.position;
        newPosition.y += 1f;
        pin.transform.position = newPosition;
    }

    IEnumerator waitForSomeTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (followPlayerX.isArmadillo && nivel == 7)
        {
            changer.changeLevelActivator(nivel + 1);
        }
        else if (followPlayerX.isTapir && nivel == 7)
        {
            changer.changeLevelActivator(nivel + 2);
        }
        else
        {
            changer.changeLevelActivator(nivel);
        }


    }
    private void Start()
    {
        controllador_caracter.VerificarPersonaje();

    }
}
