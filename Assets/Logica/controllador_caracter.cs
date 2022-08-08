using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllador_caracter : MonoBehaviour
{
    public static void VerificarPersonaje()
    {
        switch (SaveManager.getPersonaje())
        {
            case "oso":
                followPlayerX.isOso = true;
                followPlayerX.isArmadillo = false;
                followPlayerX.isTapir = false;
                print("isOso");
                break;
            case "armadillo":
                followPlayerX.isArmadillo = true;
                followPlayerX.isOso = false;
                followPlayerX.isTapir = false;
                print("isArmadillo");
                break;
            case "tapir":
                print("isTapir");
                followPlayerX.isTapir = true;
                followPlayerX.isOso = false;
                followPlayerX.isArmadillo = false;
                break;
            default:
                break;
        }
        
    }
}
