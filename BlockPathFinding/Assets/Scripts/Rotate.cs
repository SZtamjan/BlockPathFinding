using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float i; //Obrót playera
    
    void Update()
    {
        i++;
        gameObject.GetComponent<Mover>().ratatui.transform.rotation = Quaternion.Euler(i, 0, 0);
        if (i == 360) i = 0;
    }
}
