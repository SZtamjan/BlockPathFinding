using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorV2 : MonoBehaviour
{
    public GameObject player;
    public int numPoints = 20;
    public float radius = 1f;
    private List<Vector3> points;

    private void Update()
    {
        points = GenerateCirclePoints(player.transform.position, numPoints, radius);
        foreach (Vector3 point in points)
        {
        
            Debug.DrawLine(player.transform.position, point, Color.red, Time.deltaTime, false);
        }
    }

    private List<Vector3> GenerateCirclePoints(Vector3 center, int numPoints, float radius)
    {
        List<Vector3> points = new List<Vector3>();
        
        float angleIncrement = (2f * Mathf.PI) / numPoints;

        for (int i = 0; i < numPoints; i++)
        {
            float angle = i * angleIncrement;
            
            Vector3 offset = new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * radius;
            Vector3 point = center + offset;
            points.Add(point);
        }

        return points;
    }
}