using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject ground;
    // Start is called before the first frame update
    void Start()
    {
        ground.transform.localScale = new Vector3(20,0.1f,20);
        ground.transform.position = new Vector3(0, -1, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
