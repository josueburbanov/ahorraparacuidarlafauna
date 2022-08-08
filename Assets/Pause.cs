using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
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
