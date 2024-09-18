using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public Transform target_pos;
    public float speed = 1;
    public Vector3 velocity = Vector3.zero;
    public Transform target;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target_pos.position, ref velocity, speed * Time.deltaTime);

        transform.LookAt(target, Vector3.up);
    }
}
