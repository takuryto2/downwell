using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public Transform playerTransform;
    private Transform cam;

    private void Start()
    {
        cam = GetComponent<Transform>();
    }

    private void Update()
    {
        cam.position = new Vector3(cam.position.x, playerTransform.position.y, -10);
    }
}
