using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initLevel : MonoBehaviour
{
    private int nivel;
    public change_next_scene changer;
    void Start()
    {
        string nivelNombre = (gameObject.name.Split('(')[1]).Trim(')');
        print(nivelNombre);
        if (nivelNombre.Equals("1"))
        {
            nivel = 1;
        }
    }

    public void goLevelSelected()
    {
        changer.changeLevelActivator(nivel);
    }
}
