using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Detector : MonoBehaviour
{
    public GameObject player;
    public LayerMask layer;
    public float radius = 3f;
    public Vector3 radiusLimitFront;
    public Vector3 radiusLimitBack;
    public Vector3 radiusLimitLeft;
    public Vector3 radiusLimitRight;
    public Vector3 radiusLimitUp;
    public Vector3 radiusLimitDown;


    private void Start()
    {
        radiusLimitFront = player.transform.position;
        radiusLimitFront.z += radius;

        radiusLimitBack = player.transform.position;
        radiusLimitBack.z -= radius;

        radiusLimitDown = player.transform.position;
        radiusLimitDown.y -= radius;
    }


    public void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(player.transform.position, radius, layer);
        
        foreach (Collider collider in colliders)
        {
            Debug.Log("Wykryto obiekt: " + collider.gameObject.name);
            
            Debug.DrawLine(player.transform.position, radiusLimitFront, Color.red, Time.deltaTime, false);
            Debug.DrawLine(player.transform.position, radiusLimitBack, Color.red, Time.deltaTime, false);
            Debug.DrawLine(player.transform.position, radiusLimitDown, Color.red, Time.deltaTime, false);
            
            // Debug.DrawLine(center, collider.transform.position, Color.red);
            // Debug.DrawRay(collider.transform.position, Vector3.up, Color.green);
            // Debug.DrawRay(collider.transform.position, Vector3.right, Color.blue);
            // Debug.DrawRay(collider.transform.position, Vector3.forward, Color.yellow);
        }
    }
}