using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_const : MonoBehaviour
{
    public float force = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(force,0,0));
    }
}
