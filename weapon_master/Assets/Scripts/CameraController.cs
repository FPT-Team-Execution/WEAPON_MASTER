using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //camera follow props
    [SerializeField]private float cameraSpeed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    //Player follow props
    //[SerializeField]private Transform player;
 

    // Update is called once per frame
    void Update()
    {
        //scene camera
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, cameraSpeed);

        //player camera
        //transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }

    public void MoveToNewScene(Transform _newPos)
    {
        currentPosX = _newPos.position.x;
    }
}
