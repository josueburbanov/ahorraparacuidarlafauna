using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class food_catch6 : MonoBehaviour
{
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        int randomNum;

        if (!isHit)
        {
            if (isMortino)
            {
                randomNum = UnityEngine.Random.Range(3, 8);
                food_catch_detector.foodCounter -= randomNum;
                if (food_catch_detector.foodCounter < 0)
                {
                    food_catch_detector.foodCounter = 0;
                }
                else
                {
                    food_catch_detector.comodinesNegativos -= randomNum;
                }

                aux = Instantiate(dashEffectMortino, transform.position, Quaternion.identity);
                aux.SetActive(true);
                StartCoroutine(destroyInstantiation(aux));

            }
            else if (isAguacatillo)
            {
                randomNum = UnityEngine.Random.Range(3, 8);
                food_catch_detector.foodCounter += randomNum;
                food_catch_detector.comodinesPositivos += randomNum;
                aux = Instantiate(dashEffectAguacatillo, transform.position, Quaternion.identity);
                aux.SetActive(true);
                StartCoroutine(destroyInstantiation(aux));
            }
            else
            {
                food_catch_detector.foodCounter++;
                aux = Instantiate(dashEffectNormal, transform.position, Quaternion.identity);
                aux.SetActive(true);
                StartCoroutine(destroyInstantiation(aux));
                isCatched = true;
            }

            if (foodTextUI != null)
            {
                foodTextUI.text = "X " + food_catch_detector.foodCounter + " / " + InicializadorNivelPlayer.minReqAlimento;
                foodAguacatillosUI.text = "X " + food_catch_detector.comodinesPositivos;
                foodMortinosUI.text = "X " + Math.Abs(food_catch_detector.comodinesNegativos);
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

    public void onHit()
    {
        int randomNum;
        if (!isHit)
        {
            if (isMortino)
            {
                randomNum = UnityEngine.Random.Range(3, 8);
                food_catch_detector.foodCounter -= randomNum;
                if (food_catch_detector.foodCounter < 0)
                {
                    food_catch_detector.foodCounter = 0;
                }
                else
                {
                    food_catch_detector.comodinesNegativos -= randomNum;
                }

                aux = Instantiate(dashEffectMortino, transform.position, Quaternion.identity);
                aux.SetActive(true);
                StartCoroutine(destroyInstantiation(aux));

            }
            else if (isAguacatillo)
            {
                randomNum = UnityEngine.Random.Range(3, 8);
                food_catch_detector.foodCounter += randomNum;
                food_catch_detector.comodinesPositivos += randomNum;
                aux = Instantiate(dashEffectAguacatillo, transform.position, Quaternion.identity);
                aux.SetActive(true);
                StartCoroutine(destroyInstantiation(aux));
            }
            else
            {
                food_catch_detector.foodCounter++;
                aux = Instantiate(dashEffectNormal, transform.position, Quaternion.identity);
                aux.SetActive(true);
                StartCoroutine(destroyInstantiation(aux));
                isCatched = true;
            }

            if (foodTextUI != null)
            {
                foodTextUI.text = "X " + food_catch_detector.foodCounter + " / " + InicializadorNivelPlayer.minReqAlimento;
                foodAguacatillosUI.text = "X " + food_catch_detector.comodinesPositivos;
                foodMortinosUI.text = "X " + Math.Abs(food_catch_detector.comodinesNegativos);
            }

            isHit = true;
            isCatched = true;

            if (audioClip != null)
            {
                audioSource.PlayOneShot(audioClip, 0.7f);
            }
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
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
            }
        }
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 38));
    }
}
