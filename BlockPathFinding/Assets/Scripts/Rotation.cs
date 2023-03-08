using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;


public class Rotation : MonoBehaviour
{
    public GameObject ratatui;
    public Vector3 ratatuiPos;

    public float i;
    
    public float xObrotnik;
    public float yObrotnik;
    public float zObrotnik;

    public LayerMask lejer = 1;
    GameObject obj;

    private bool isGround;

    void Start()
    {
        ratatui.transform.position = new Vector3(0, 1, 0);
        ratatuiPos = ratatui.transform.position;
    }


    void Update()
    {
        i++;
        ratatui.transform.rotation = Quaternion.Euler(i, 0, 0);
        if (i == 360) i = 0;

    }

    /*
     * Funkcja1 wywo³uje funkcjê która porusza siê o 25 do przodu i sprawdza objekt
     * Funkcja1 wywo³uje kolejn¹ funkcjê która porusza o 25 w bok itd. w cztery strony
     
     */
    /*public void Move()
    {
        GoTo1();
        GoTo2();
        GoTo3(); 
        GoTo4();
    }*/

    public void Move()
    {
        while (isGround == false)//NIE MA ZABEZPIECZENIA NA COFANIE SIÊ WIÊC ZAWSZE BÊDZIE TRUE - mo¿na zapamiêtaæ x i z ostatniego klocka na którym siê by³o
        {
            if (isGround == false) GoTo1();
            if (isGround == false) GoTo2();
            if (isGround == false) GoTo3();
            if (isGround == false) GoTo4();
        }
        isGround = false;
    }


    public void GoTo1()
    {
        zObrotnik = ratatuiPos.z;
        zObrotnik += 2;

        yObrotnik = ratatuiPos.y;
        yObrotnik = 0;

        Check();

        RatatuiPosReset();
    }

    public void GoTo2()
    {
        xObrotnik = ratatuiPos.x;
        xObrotnik += 2;

        yObrotnik = ratatuiPos.y;
        yObrotnik = 0;

        Check();

        RatatuiPosReset();
    }
    public void GoTo3()
    {
        zObrotnik = ratatuiPos.z;
        zObrotnik -= 2;

        yObrotnik = ratatuiPos.y;
        yObrotnik = 0;

        Check();

        RatatuiPosReset();
    }
    public void GoTo4()
    {
        xObrotnik = ratatuiPos.x;
        xObrotnik -= 2;

        yObrotnik = ratatuiPos.y;
        yObrotnik = 0;

        Check();

        RatatuiPosReset();
    }
    public void Check()
    {
        Collider[] colliders = Physics.OverlapSphere(new Vector3(xObrotnik, yObrotnik, zObrotnik), 0, lejer);
        foreach (Collider collider in colliders)
        {
            obj = collider.gameObject;
        }
        Debug.Log("Wykryto ojbekt: " + obj);
        //Debug.Log("Wykryto ojbekt at: " + obj.transform.position);

        if (obj != null) //Sprawdzanie czy obiekt wgl jest tam
        {
            if (colliders[0].gameObject.tag == "Ground") //Sprawdzanie czy mo¿na iœæ
            {
                Debug.Log("Very yes at " + xObrotnik + yObrotnik + zObrotnik);
                isGround = true;

            }
            else if (colliders[0].gameObject.tag == "NotGround")
            {
                Debug.Log("Very no " + xObrotnik + yObrotnik + zObrotnik);
                isGround = false;

            }
            else
            {
                Debug.Log("There is literally nothing " + xObrotnik + yObrotnik + zObrotnik);
                isGround = false;

            }
            obj = null;
        }
        else
        {
            Debug.Log("Tutaj nie ma nic");
        }
    }

    public void RatatuiPosReset()
    {
        xObrotnik = ratatuiPos.x;
        yObrotnik = ratatuiPos.y;
        zObrotnik = ratatuiPos.z;
    }

}
