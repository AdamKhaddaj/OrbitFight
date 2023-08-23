using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotation : MonoBehaviour
{
    public Transform playerpos;
    public float orbitspeed, orbitradius;

    private void Start()
    {
        transform.position = new Vector3(0, 0, 0);    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float angle = Time.time * orbitspeed;
        Vector3 offset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * orbitradius;
        transform.position = playerpos.position + offset;
    }
}
