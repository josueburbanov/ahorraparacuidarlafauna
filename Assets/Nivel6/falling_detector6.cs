using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class falling_detector6 : MonoBehaviour
{
    public Canvas canvas;
    public CameraShake cameraShake;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name.Equals("Oso piezasperfil34"))
        {
            collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            collider.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player_controller5.isFinish = true;
            collider.gameObject.GetComponent<Animator>().SetTrigger("isFalling");
            //StartCoroutine(cameraShake.Shake(.3f, 0.4f, (Camera)GameObject.FindObjectOfType(typeof(Camera))));
            canvas.GetComponent<Animator>().SetTrigger("GameOver");
        }
    }

    void Start()
    {

    }

    void Update()
    {
        
    }
}
