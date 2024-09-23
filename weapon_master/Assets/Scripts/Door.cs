using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]private Transform previousScene;
    [SerializeField]private Transform nextScene;
    private CameraController cameraController;
    
    
   

    private void Awake()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //print(collision.tag == "Player");
        var isHitPLayer = collision.tag == "Player";
       
        if (isHitPLayer)
        {
            //print($"collision.transform.position.x < this.transform.position.x {collision.transform.position.x < this.transform.position.x}");
            //player hit and its position < door position -> player go through door
            if (collision.transform.position.x < this.transform.position.x)
            {
                cameraController.MoveToNewScene(nextScene);
                AudioManagement.instance.PlayEventually("next");
            }
            else
            {
                cameraController.MoveToNewScene(previousScene);
                AudioManagement.instance.PlayEventually("previous");
            }
        }
    }
}
