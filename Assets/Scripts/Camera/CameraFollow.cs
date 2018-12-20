using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    public float Speed;
    public float xOffset, yOffset;
    public static bool IsFolowing = true;
    Vector3 velocity =Vector3.zero;
    private void Start()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            //if (!target.gameObject.active)
            //    Debug.Log("Player null");
            //    return;
        }
           

        IsFolowing = true;
        
    }
    void LateUpdate () {
        //if (IsFolowing  )
        //{
        //    //if(InputAndroid.IsMoving)
        //    transform.position = new Vector3
        //                       (target.transform.position.x + xOffset,
        //                       target.transform.position.y + yOffset,
        //                       transform.position.z);
        //}


        //Vector3 camPos = transform.position;
        //if (InputAndroid.FacingRight)
        //    camPos.x += xOffset;
        //else
        //    camPos.x -= xOffset;

        //camPos.y += yOffset;
        //camPos.z = target.transform.position.z;
        ////if (InputAndroid.IsMoving)
        //    transform.position = Vector3.Lerp(camPos, target.transform.position, Time.deltaTime * Speed);
        if (target == null)
            return;

        Vector3 LockTarget = target.position;
        if (InputAndroid.FacingRight)
            LockTarget.x -= xOffset;
        else
            LockTarget.x += xOffset;

        LockTarget.y += yOffset;
        LockTarget.z = transform.position.z;
        //transform.position = Vector3.LerpUnclamped(transform.position, LockTarget, Time.deltaTime * Speed);
        if(IsFolowing)
        transform.position = Vector3.SmoothDamp(transform.position, LockTarget, ref velocity, Speed);
    }
}
