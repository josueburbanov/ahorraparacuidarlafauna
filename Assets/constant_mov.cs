using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constant_mov : MonoBehaviour
{
    // Start is called before the first frame update
    public float movingSpeed = 5f;
    private Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * movingSpeed;
    }
}
