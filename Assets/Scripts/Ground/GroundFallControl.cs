using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFallControl : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator SetRigidbodyValues()
    {
        yield return new WaitForSeconds(0.75f);
        rb.isKinematic = false ;
        rb.useGravity = true ;
    }
}
