using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instrucciones : MonoBehaviour
{
    private Animator anim;
    private bool isHit;
    public GameObject canvasInstruccion;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!isHit && collider.name == "Oso piezasperfil34")
        {
            canvasInstruccion.SetActive(true);
            FindInActiveObjectByName("ButtonPause").SetActive(false);
            FindInActiveObjectByName("ButtonPlay").SetActive(false);
            isHit = true;
            Time.timeScale = 0f;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isHit)
        {
            print("ssssss");
            canvasInstruccion.GetComponent<Animator>().SetTrigger("End");
            Time.timeScale = 1;
            FindInActiveObjectByName("ButtonPause").SetActive(true);
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
