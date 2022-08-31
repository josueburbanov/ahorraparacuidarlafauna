using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class checkReqFields : MonoBehaviour
{
    public TextMeshProUGUI textNickName;
    public TextMeshProUGUI textCorreo;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        //button.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (textNickName != null && textCorreo != null)
        //{
        //    if (textNickName.text.Length != 1 && textCorreo.text.Length != 1)
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
