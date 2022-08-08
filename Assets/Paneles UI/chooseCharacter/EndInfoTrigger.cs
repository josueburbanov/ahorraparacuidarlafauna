using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndInfoTrigger : MonoBehaviour
{
    public GameObject anim;

    public void endInfoTrigger()
    {
        anim.GetComponent<Animator>().SetTrigger("End");
        StartCoroutine(waitTilEndsAnimation());
    }

    IEnumerator waitTilEndsAnimation()
    {
        yield return new WaitForSeconds(1f);
        anim.SetActive(false);
    }
}
