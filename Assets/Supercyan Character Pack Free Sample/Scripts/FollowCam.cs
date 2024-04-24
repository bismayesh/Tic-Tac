using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    void Awake()
        //we take the position of the camera and we substract the position of the target
    {
        offset = transform.position-target.position;
    }

    // Update is called once per frame
    private void LateUpdate()
        //used for camera, this would set the camera to the distance that is set from the start, by adding offset this is what we did 
    {
        transform.position=target.position+offset;
    }
}
