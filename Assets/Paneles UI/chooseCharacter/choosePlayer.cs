using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choosePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SaveManager.LoadJuego();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chooseOso()
    {
        print("Oso Selected");
    }

    public void chooseTapir()
    {
        print("Tapir Selected");
    }

    public void chooseArmadillo()
    {
        print("Armadillo Selected");
    }

    
}
