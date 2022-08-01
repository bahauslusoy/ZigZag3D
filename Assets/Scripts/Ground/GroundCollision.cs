using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{

    [SerializeField] private GroundDataTransmitter groundDataTransmitter;
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
             groundDataTransmitter.SetGroundRigidbodyValues();
        }
    }
}
