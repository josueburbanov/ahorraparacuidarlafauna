using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class touchVasija : MonoBehaviour
{
    // Start is called before the first frame update

    private bool isHit = false;
    private Animator anim;
    public GameObject dashEffectMortino;
    public GameObject dashEffectAguacatillo;
    public float delayInstantiation;
    public Text positivosTextUI;
    public Text negativosTextUI;
    private GameObject aux;
    public Text foodText;
    AudioSource audioSource;
    public AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name.Equals("Oso piezasperfil34") || collider.name.Equals("OsoEspaldas2"))
        {
            if (!isHit)
            {
                int aleatorio = UnityEngine.Random.Range(1, 3);
                int randNumer = 0;
                if (aleatorio == 1)
                {
                    randNumer = UnityEngine.Random.Range(3, 8);
                    food_catch_detector.foodCounter -= randNumer;
                    if (food_catch_detector.foodCounter < 0)
                    {
                        food_catch_detector.foodCounter = 0;
                    }
                    else
                    {
                        food_catch_detector.comodinesNegativos -= randNumer;
                    }
                    foodText.text = "X " + food_catch_detector.foodCounter + " / " + InicializadorNivelPlayer.minReqAlimento;
                    negativosTextUI.text = "X "+ Math.Abs(food_catch_detector.comodinesNegativos);
                    StartCoroutine(lateInstantiaton(delayInstantiation, dashEffectMortino));
                }
                else if (aleatorio == 2)
                {
                    randNumer = UnityEngine.Random.Range(3, 8);
                    food_catch_detector.foodCounter += randNumer;
                    food_catch_detector.comodinesPositivos += randNumer;
                    foodText.text = "X " + food_catch_detector.foodCounter + " / " + InicializadorNivelPlayer.minReqAlimento;
                    positivosTextUI.text = "X " + food_catch_detector.comodinesPositivos;
                    StartCoroutine(lateInstantiaton(delayInstantiation, dashEffectAguacatillo));

                }

                isHit = true;
                anim.SetTrigger("touch");
                if (audioClip != null)
                {
                    audioSource.PlayOneShot(audioClip, 0.7f);
                }
            }

        }

    }
    IEnumerator lateInstantiaton(float time, GameObject dashEffect)
    {
        yield return new WaitForSeconds(time);
        aux = Instantiate(dashEffect, transform.localPosition, Quaternion.identity);
        aux.GetComponent<Renderer>().sortingOrder = 10;
        aux.SetActive(true);
        StartCoroutine(destroyInstantiation(aux));
    }

    IEnumerator destroyInstantiation(GameObject aux)
    {
        yield return new WaitForSeconds(2f);
        aux.SetActive(false);
        Destroy(aux);
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
