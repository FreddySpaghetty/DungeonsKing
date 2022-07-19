using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    Transform player;
    private float _smooth = 1f;
    Vector3 velocity = Vector3.zero;
    Camera myCamera;
    void Start()
    {
        SetCameraClipPlane();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null){
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, 0f);
            transform.position= Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, _smooth);
        }
    }
     void SetCameraClipPlane(){
        myCamera = GetComponent<Camera>();
        myCamera.nearClipPlane = 0.0f;
        myCamera.farClipPlane = 1000f;
    }
}
