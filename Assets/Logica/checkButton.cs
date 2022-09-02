using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class checkButton : MonoBehaviour
{
    public Button button;
    private TextMeshProUGUI textNickName;
    // Start is called before the first frame update
    void Start()
    {
        textNickName = GetComponent<TextMeshProUGUI>();
        //button.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if(textNickName != null)
        //{
        //    if (textNickName.text.Length != 1)
        //    {
        //        button.enabled = true;
        //    }
        //    else
        //    {
        //        button.enabled = false;
        //    }
        //}
    }
}
