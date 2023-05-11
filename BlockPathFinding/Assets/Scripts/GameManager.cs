using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        cam.transform.rotation = Quaternion.Euler(15, -45, 0);
        cam.transform.position = new Vector3(4,2,-1);
    }
}
