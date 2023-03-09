using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class Rotation : MonoBehaviour
{
    public GameObject ratatui;
    public Vector3 ratatuiPos;

    public float i; //Obr�t playera
    public float j; //Ruch Counter
    
    public float xObrotnik;
    public float yObrotnik;
    public float zObrotnik;

    public LayerMask lejer = 1;
    
    private bool isGround = false;

    private bool goTo1;
    private bool goTo2;
    private bool goTo3;
    private bool goTo4;

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
     * Funkcja1 wywo�uje funkcj� kt�ra porusza si� o 25 do przodu i sprawdza objekt
     * Funkcja1 wywo�uje kolejn� funkcj� kt�ra porusza o 25 w bok itd. w cztery strony
     
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
        while (isGround == false)//NIE MA ZABEZPIECZENIA NA COFANIE SI� WI�C ZAWSZE B�DZIE TRUE - mo�na zapami�ta� x i z ostatniego klocka na kt�rym si� by�o
        {
            if (isGround == false) GoTo1();
            if (isGround == false) GoTo2();
            if (isGround == false) GoTo3();
            if (isGround == false) GoTo4();
        }
        isGround = false;
    }


    public void GoTo1()
    {//Tutaj si� pierdoli z cofaniem zmian
        goTo1 = true;
        zObrotnik = ratatuiPos.z;
        zObrotnik += 2;

        yObrotnik = ratatuiPos.y;
        yObrotnik = 0;

        Check();
        if (!isGround)
        {
            zObrotnik = ratatuiPos.z;
        }
        
    }

    public void GoTo2()
    {
        goTo2 = true;
        xObrotnik = ratatuiPos.x;
        xObrotnik += 2;

        yObrotnik = ratatuiPos.y;
        yObrotnik = 0;

        Check();
        if (!isGround)
        {
            xObrotnik = ratatuiPos.x;
            
        }

    }
    public void GoTo3()
    {
        goTo3 = true;
        zObrotnik = ratatuiPos.z;
        zObrotnik -= 2;

        yObrotnik = ratatuiPos.y;
        yObrotnik = 0;



        Check();
        if (!isGround)
        {
            zObrotnik = ratatuiPos.z;
            
        }

    }

    public void GoTo4()
    {
        goTo4 = true;
        xObrotnik = ratatuiPos.x;
        xObrotnik -= 2;

        yObrotnik = ratatuiPos.y;
        yObrotnik = 0;

        Check();
        if (!isGround)
        {
            xObrotnik = ratatuiPos.x;
            
        }

    }
    
    public void Check()
    {
        //void Start zapisa� kordy pierwszego klocka
        //Zapisa� kordy po ruchu i przed ruchem sprawdzi�, jak do dupy to instant zwraca isGround false i leci do nast�pnego GoTox()
        GameObject obj = null;
        Collider[] colliders = Physics.OverlapSphere(new Vector3(xObrotnik, yObrotnik, zObrotnik), 0, lejer);
        foreach (Collider collider in colliders)
        {
             obj = collider.gameObject;
        }
        Debug.Log("Wykryto ojbekt: " + obj);
        //Debug.Log("Wykryto ojbekt at: " + obj.transform.position);

        if (obj != null) //Sprawdzanie czy obiekt wgl jest tam
        {
            
            if (colliders[0].gameObject.tag == "Ground") //Sprawdzanie czy mo�na i��
            {
                Debug.Log("Very yes at " + xObrotnik + yObrotnik + zObrotnik);
                isGround = true;

                //if (j == 0) FirstMoving();
                FirstMoving();
                //if(goTo3) MoveForward();

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
        }
        else
        {
            Debug.Log("Tutaj nie ma nic");
        }
    }
    public void FirstMoving()
    {
        Vector3 target = new Vector3(xObrotnik, yObrotnik + 1, zObrotnik);
        StartCoroutine(MoveTowardsPos(target));
    }
    public void ActualMoving()
    {
        if (!goTo3) 
        {
            Vector3 target = new Vector3(xObrotnik, yObrotnik + 1, zObrotnik);
            StartCoroutine(MoveTowardsPos(target));
        }
    }

    IEnumerator MoveTowardsPos(Vector3 target)
    {
        while(transform.position != target)
        {
            ratatui.transform.position = Vector3.MoveTowards(transform.position, target, 5 * Time.deltaTime);
            yield return null;
        }
        RatatuiPosReset();
        
    }

    public void RatatuiPosReset()
    {
        ratatuiPos = ratatui.transform.position;
        xObrotnik = ratatuiPos.x;
        yObrotnik = ratatuiPos.y;
        zObrotnik = ratatuiPos.z;
    }

}
