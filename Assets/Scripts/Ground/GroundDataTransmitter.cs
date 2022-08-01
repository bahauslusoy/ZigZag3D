using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDataTransmitter : MonoBehaviour
{
    [SerializeField] private GroundFallControl groundFallControl ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetGroundRigidbodyValues()
    {
        StartCoroutine(groundFallControl.SetRigidbodyValues());
    }
}
