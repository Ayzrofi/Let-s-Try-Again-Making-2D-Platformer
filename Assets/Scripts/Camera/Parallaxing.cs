using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

    public Transform[] bgLayers;
    private float[] parallaxScale;
    public float Smoothing;

    //private Transform Cam;
    private Vector3 CurrentCamPos;
    //private void Awake()
    //{
    //    Cam = this.transform;
    //}

    private void Start()
    {
        CurrentCamPos = transform.position;

        parallaxScale = new float[bgLayers.Length];
        for (int i = 0; i < bgLayers.Length; i++)
        {
            parallaxScale[i] = bgLayers[i].position.z * -1;
        }
    }

    private void Update()
    {
        for (int i = 0; i < bgLayers.Length; i++)
        {
            float parallax = (CurrentCamPos.x - transform.position.x) * parallaxScale[i];

            float BackgroundTargetPosX = bgLayers[i].position.x + parallax;

            Vector3 BackgroundTargetPos = new Vector3(BackgroundTargetPosX, bgLayers[i].position.y, bgLayers[i].position.z);

            bgLayers[i].position = Vector3.Lerp(bgLayers[i].position, BackgroundTargetPos, Smoothing * Time.deltaTime);
        }

        CurrentCamPos = transform.position;
    }

}// end Class

