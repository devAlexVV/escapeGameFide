using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraFollower : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    float smoothTransitionTime = 0.5f;

    Vector3 offset;
    Vector3 zero = Vector3.zero;
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref zero, smoothTransitionTime * Time.deltaTime);
    }
}
