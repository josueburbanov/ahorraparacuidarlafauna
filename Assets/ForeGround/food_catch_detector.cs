using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class food_catch_detector : MonoBehaviour
{
    public static int foodCounter = 0;
    public static int comodinesPositivos = 0;
    public static int comodinesNegativos = 0;
    public Text foodTextUI;
    public Text foodAguacatillosUI;
    public Text foodMortinosUI;
    private bool isHit = false;
    private bool isCatched = false;
    private Animator anim;
    public bool isMortino;
    public bool isAguacatillo;
    public GameObject dashEffectNormal;
    public GameObject dashEffectMortino;
    public GameObject dashEffectAguacatillo;
    AudioSource audioSource;
    public AudioClip audioClip;
    private GameObject aux;
    public Sprite alimentoOsoSprite;
    public Sprite alimentoTapirSprite;
    public Sprite alimentoArmadilloSprite;



    IEnumerator lateInstantiaton(float time, GameObject gameObject)
    {
        yield return new WaitForSeconds(time);
        Instantiate(gameObject, transform.position, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        int randomNum;
        if (!isHit && (collider.name == "Oso piezasperfil34" || collider.name == "OsoEspaldas2"))
        {
            if (isMortino)
            {
                randomNum = UnityEngine.Random.Range(3, 8);
                foodCounter -= randomNum;
                if (foodCounter < 0)
                {
                    foodCounter = 0;
                }
                else
                {
                    comodinesNegativos -= randomNum;
                }

                aux = Instantiate(dashEffectMortino, transform.position, Quaternion.identity);
                aux.GetComponent<Renderer>().sortingOrder = 2;
                aux.SetActive(true);
                StartCoroutine(destroyInstantiation(aux));

            }
            else if (isAguacatillo)
            {
                randomNum = UnityEngine.Random.Range(3, 8);
                foodCounter += randomNum;
                comodinesPositivos += randomNum;
                aux = Instantiate(dashEffectAguacatillo, transform.position, Quaternion.identity);
                aux.GetComponent<Renderer>().sortingOrder = 2;
                aux.SetActive(true);
                StartCoroutine(destroyInstantiation(aux));
            }
            else
            {
                foodCounter++;
                aux = Instantiate(dashEffectNormal, transform.position, Quaternion.identity);
                aux.SetActive(true);
                aux.GetComponent<Renderer>().sortingOrder = 2;
                StartCoroutine(destroyInstantiation(aux));
                isCatched = true;
            }

            if (foodTextUI != null && foodAguacatillosUI != null && foodMortinosUI != null)
            {
                foodTextUI.text = "X " + foodCounter + " / " + InicializadorNivelPlayer.minReqAlimento;
                foodAguacatillosUI.text = "X " + comodinesPositivos;
                foodMortinosUI.text = "X " + Math.Abs(comodinesNegativos);
            }

            isHit = true;

            if (audioClip != null)
            {
                audioSource.PlayOneShot(audioClip, 0.7f);
            }
            GetComponent<Renderer>().enabled = false;
        }
    }

    IEnumerator destroyInstantiation(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        Destroy(gameObject);

    }

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        if (followPlayerX.isOso && !isMortino && !isAguacatillo)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = alimentoOsoSprite;
        }
        else if (followPlayerX.isTapir && !isMortino && !isAguacatillo)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = alimentoTapirSprite;
            gameObject.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        }
        else if (followPlayerX.isArmadillo && !isMortino && !isAguacatillo)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = alimentoArmadilloSprite;
            gameObject.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isCatched)
        {
            if (!audioSource.isPlaying)
            {
                transform.gameObject.SetActive(false);
                Destroy(this);
            }
        }
    }

}
