using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private Toggle toogle;

    private void Start()
    {
        toogle = GetComponent<Toggle>();
        if (AudioListener.pause)
        {
            toogle.isOn = false;
        }
        else
        {
            toogle.isOn = true;
        }
    }
    public void ChangeState()
    {
        if (toogle.isOn)
        {
            AudioListener.pause = false;
        }
        else
        {
            AudioListener.pause = true;
        }
    }
}
