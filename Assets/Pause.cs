using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    private bool paused = false;
    //public AudioSource audio;
    Animator anim;
    private Rigidbody2D rbPlayerAux;
    private float angularVelAux;
    public player_controller1 controlador;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
