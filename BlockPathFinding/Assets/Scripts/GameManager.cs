using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        cam.transform.rotation = Quaternion.Euler(15, -45, 0);
        cam.transform.position = new Vector3(4,2,-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
