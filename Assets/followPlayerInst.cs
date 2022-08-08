using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayerInst : MonoBehaviour
{
    public Transform targetTransform;
    Vector3 tempVec3 = new Vector3();

    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        tempVec3.x = targetTransform.position.x + 5f;
        //tempVec3.y = this.transform.position.y;
        tempVec3.y = targetTransform.position.y + 4f;


        tempVec3.x = targetTransform.position.x + 2f;
        tempVec3.y = targetTransform.position.y + 4.2f;

        tempVec3.z = this.transform.position.z;
        this.transform.position = tempVec3;
    }
}
