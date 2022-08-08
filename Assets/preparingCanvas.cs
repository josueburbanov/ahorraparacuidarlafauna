using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class preparingCanvas : MonoBehaviour
{
    public Sprite alimentoOsoSprite;
    public Sprite positivoOsoSprite;
    public Sprite negativoOsoSprite;
    public Sprite alimentoArmadilloSprite;
    public Sprite positivoArmadilloSprite;
    public Sprite negativoArmadilloSprite;
    public Sprite alimentoTapirSprite;
    public Sprite positivoTapirSprite;
    public Sprite negativoTapirSprite;
    public Sprite imageCredito80Oso;
    public Sprite imageCredito100Oso;
    public Sprite imageCredito80Armadillo;
    public Sprite imageCredito100Armadillo;
    public Sprite imageCredito80Tapir;
    public Sprite imageRecordatorio100Oso;
    public Sprite imageRecordatorio80Oso;
    public Sprite imageCredito100Tapir;
    public Sprite imageRecordatorio100Armadillo;
    public Sprite imageRecordatorio80Armadillo;
    public Sprite imageRecordatorio100Tapir;
    public Sprite imageRecordatorio80Tapir;

    void Start()
    {
        if (followPlayerX.isOso)
        {
            GameObject.Find("ImageFood").GetComponent<Image>().sprite = alimentoOsoSprite;
            GameObject.Find("ImagePositivos").GetComponent<Image>().sprite = positivoOsoSprite;
            GameObject.Find("ImageNegativos").GetComponent<Image>().sprite = negativoOsoSprite;
            FindInActiveObjectByName("AlimentoImageStat").GetComponent<Image>().sprite = alimentoOsoSprite;
            FindInActiveObjectByName("ImageCredito80").GetComponent<Image>().sprite = imageCredito80Oso;
            FindInActiveObjectByName("ImageCredito100").GetComponent<Image>().sprite = imageCredito100Oso;
            FindInActiveObjectByName("ImageRecordatorio80").GetComponent<Image>().sprite = imageRecordatorio80Oso;
            FindInActiveObjectByName("ImageRecordatorio100").GetComponent<Image>().sprite = imageRecordatorio100Oso;
            FindInActiveObjectByName("ImageOfrecerPrestamo").GetComponent<Image>().sprite = alimentoOsoSprite;
            FindInActiveObjectByName("ImageReqsMonedas").GetComponent<Image>().sprite = alimentoOsoSprite;
        }
        else if (followPlayerX.isTapir)
        {
            GameObject.Find("ImageFood").GetComponent<Image>().sprite = alimentoTapirSprite;
            GameObject.Find("ImagePositivos").GetComponent<Image>().sprite = positivoTapirSprite;
            GameObject.Find("ImageNegativos").GetComponent<Image>().sprite = negativoTapirSprite;
            FindInActiveObjectByName("AlimentoImageStat").GetComponent<Image>().sprite = alimentoTapirSprite;
            FindInActiveObjectByName("ImageCredito80").GetComponent<Image>().sprite = imageCredito80Tapir;
            FindInActiveObjectByName("ImageCredito100").GetComponent<Image>().sprite = imageCredito100Tapir;
            FindInActiveObjectByName("ImageRecordatorio80").GetComponent<Image>().sprite = imageRecordatorio80Tapir;
            FindInActiveObjectByName("ImageRecordatorio100").GetComponent<Image>().sprite = imageRecordatorio100Tapir;
            FindInActiveObjectByName("ImageOfrecerPrestamo").GetComponent<Image>().sprite = alimentoTapirSprite;
            FindInActiveObjectByName("ImageReqsMonedas").GetComponent<Image>().sprite = alimentoTapirSprite;
        }
        else if (followPlayerX.isArmadillo)
        {
            GameObject.Find("ImageFood").GetComponent<Image>().sprite = alimentoArmadilloSprite;
            GameObject.Find("ImagePositivos").GetComponent<Image>().sprite = positivoArmadilloSprite;
            GameObject.Find("ImageNegativos").GetComponent<Image>().sprite = negativoArmadilloSprite;
            FindInActiveObjectByName("AlimentoImageStat").GetComponent<Image>().sprite = alimentoArmadilloSprite;
            FindInActiveObjectByName("ImageCredito80").GetComponent<Image>().sprite = imageCredito80Armadillo;
            FindInActiveObjectByName("ImageCredito100").GetComponent<Image>().sprite = imageCredito100Armadillo;
            FindInActiveObjectByName("ImageRecordatorio80").GetComponent<Image>().sprite = imageRecordatorio80Armadillo;
            FindInActiveObjectByName("ImageRecordatorio100").GetComponent<Image>().sprite = imageRecordatorio100Armadillo;
            FindInActiveObjectByName("ImageOfrecerPrestamo").GetComponent<Image>().sprite = alimentoArmadilloSprite;
            FindInActiveObjectByName("ImageReqsMonedas").GetComponent<Image>().sprite = alimentoArmadilloSprite;
        }
    }

    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}
