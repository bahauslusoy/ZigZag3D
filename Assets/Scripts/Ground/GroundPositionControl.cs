using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPositionControl : MonoBehaviour
{
    private GroundSpawnControl groundSpawnControl;
    private Rigidbody rb;
    [SerializeField] private float endYvalue;
    private int groundDirection;
    void Start()
    {
        groundSpawnControl = FindObjectOfType<GroundSpawnControl>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGroundVerticalPos();
    }
    private void CheckGroundVerticalPos()
    {
        if (transform.position.y <= endYvalue)
        {
            SetRigidbodyValues();
            groundDirection = Random.Range(0, 2);
            if (groundDirection == 0)
            {
                transform.position = new Vector3(groundSpawnControl.lastGroundObject.transform.position.x - 1f,
                groundSpawnControl.lastGroundObject.transform.position.y, groundSpawnControl.lastGroundObject.transform.position.z);
            }
            else
            {
                transform.position = new Vector3(groundSpawnControl.lastGroundObject.transform.position.x,
                                groundSpawnControl.lastGroundObject.transform.position.y, groundSpawnControl.lastGroundObject.transform.position.z + 1f);
            }
             groundSpawnControl.lastGroundObject = gameObject ;
        }
    }
    private void SetRigidbodyValues()
    {
        rb.isKinematic = true;
        rb.useGravity = false;
    }
}
