using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class choosePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SaveManager.LoadJuego();
        GameObject.Find("Username").GetComponent<Text>().text = "Hola, "+SaveManager.Jugador.NickName;
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
