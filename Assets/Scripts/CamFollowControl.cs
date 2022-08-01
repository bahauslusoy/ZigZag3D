using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowControl : MonoBehaviour
{
    [SerializeField] private Transform ballTransform ; 
    private Vector3 offset;
    private Vector3 newPosition;
    [SerializeField] private float lerpValue;
    void Start()
    {
        offset = transform.position-ballTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        newPosition = Vector3.Lerp(transform.position, ballTransform.position + offset, lerpValue * Time.deltaTime);
        transform.position = newPosition;
    }
}
