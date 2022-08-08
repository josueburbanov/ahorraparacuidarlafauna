using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxAngle : MonoBehaviour
{
    private float length, startpos, startposy;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        startpos = transform.position.x;
        startposy = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = cam.transform.position.x * (1 - parallaxEffect);
        float distance = cam.transform.position.x * parallaxEffect;
        float distancey = cam.transform.position.y * parallaxEffect;
        transform.position = new Vector3(startpos + distance, startposy , transform.position.z);

        if (temp > startpos + length)
        {
            startpos += length;
            startposy -= Mathf.Tan(Mathf.Deg2Rad * -14.46f) * length;
        }
        else if (temp < startpos - length)
        {
            startpos -= length;
        }

    }



}
