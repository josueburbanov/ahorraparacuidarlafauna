using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class food_catch_Ins : MonoBehaviour
{
    public static int foodCounter = 0;
    private bool isHit = false;
    private bool isCatched = false;
    private Animator anim;
    private int randomInt;
    public GameObject dashEffectNormal;
    public GameObject dashEffectMortino;
    public GameObject dashEffectAguacatillo;
    AudioSource audioSource;
    public AudioClip audioClip;
    public player_cont_Ins oso;
    public bool isVasija;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (isVasija)
        {
            randomInt = Random.Range(0, 2);
        }
        else
        {
            randomInt = 3;
        }

        if (!isHit && collider.name == "Oso piezasperfil34")
        {

            GameObject go;
            if (randomInt == 0)
            {
                foodCounter -= Random.Range(3, 8);
                go = Instantiate(dashEffectMortino, transform.position, Quaternion.identity);
                go.gameObject.SetActive(true);
                print("instanttion " + go.transform.position);
                oso.vasijaCounter = foodCounter;
                anim = GetComponent<Animator>();
                anim.SetTrigger("touch");
                oso.fifthStepInsAux = true;
            }
            else if (randomInt == 1)
            {
                foodCounter += Random.Range(3, 8);
                 go =  Instantiate(dashEffectAguacatillo, transform.position, Quaternion.identity);
                go.gameObject.SetActive(true);
                print("instanttion " + go.transform.position);
                oso.vasijaCounter = foodCounter;
                anim = GetComponent<Animator>();
                anim.SetTrigger("touch");
                oso.fifthStepInsAux = true;
            }
            else
            {
                foodCounter++;
                Instantiate(dashEffectNormal, transform.position, Quaternion.identity);
                oso.fourthStepIns = true;
                isCatched = true;
            }

            isHit = true;
            
            if (audioClip != null)
            {
                audioSource.PlayOneShot(audioClip, 0.7f);
            }
        }
    }
        void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        
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
