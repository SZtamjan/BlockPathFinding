using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Mover : MonoBehaviour
{
    public Button mover;
    
    public GameObject ratatui;
    private Vector3 ratatuiPos;
    private Vector3 obrotnik;
    
    private int j; //Ruch Counter

    private float xCheck;
    private float zCheck;

    private LayerMask lejer = 1;
    
    private bool isGround = false;
    
    void Start()
    {
        ratatui.transform.position = new Vector3(0, 1, 0);
        ratatuiPos = ratatui.transform.position;

        xCheck = ratatuiPos.x;
        zCheck = ratatuiPos.z;
    }
    
    public void Move()
    {
        if (isGround == false) GoTo1();
        if (isGround == false) GoTo2();
        if (isGround == false) GoTo3();
        if (isGround == false) GoTo4();
        isGround = false;
    }


    private void GoTo1()
    {
        obrotnik.z = ratatuiPos.z;
        obrotnik.z += 2;

        obrotnik.y = ratatuiPos.y;
        obrotnik.y = 0;

        Check();
        if (!isGround)
        {
            obrotnik.z = ratatuiPos.z;
        }
        
    }

    private void GoTo2()
    {
        obrotnik.x = ratatuiPos.x;
        obrotnik.x += 2;

        obrotnik.y = ratatuiPos.y;
        obrotnik.y = 0;

        Check();
        if (!isGround)
        {
            obrotnik.x = ratatuiPos.x;
            
        }

    }
    private void GoTo3()
    {
        obrotnik.z = ratatuiPos.z;
        obrotnik.z -= 2;

        obrotnik.y = ratatuiPos.y;
        obrotnik.y = 0;



        Check();
        if (!isGround)
        {
            obrotnik.z = ratatuiPos.z;
            
        }

    }

    private void GoTo4()
    {
        obrotnik.x = ratatuiPos.x;
        obrotnik.x -= 2;

        obrotnik.y = ratatuiPos.y;
        obrotnik.y = 0;

        Check();
        if (!isGround)
        {
            obrotnik.x = ratatuiPos.x;
            
        }

    }
    
    private void Check()
    {
        Debug.Log("Lejer: " + lejer);
            GameObject obj = null;
            Collider[] colliders = Physics.OverlapSphere(obrotnik, 0);
            Debug.Log("Enemies: " + colliders[0]);
            foreach (Collider collider in colliders) //Ten foreach to zabezpieczenie jakby nie było bloku w miejscu gdzie aktualnie jest sprawdzany
            {
                Debug.Log("Kolider: " + collider);
                obj = collider.gameObject;
            }
            
            Debug.Log("Wykryto ojbekt: " + obj);
            if (obj != null) //Sprawdzanie czy obiekt wgl jest tam
            {
                if (colliders[0].gameObject.tag == "Ground") //Sprawdzanie czy można iść
                {

                    //Tutaj storować pozycje i później w Moving ją sprawdzać i ew pominąć poruszenie klocka
                    Debug.Log("Very yes at " + obrotnik);
                    isGround = true;

                    if (xCheck == obrotnik.x && zCheck == obrotnik.z)
                    {
                        Debug.Log("Tutaj już byłem " + obrotnik);
                        isGround = false;
                    }
                    else
                    {
                        xCheck = ratatuiPos.x;
                        zCheck = ratatuiPos.z;
                        ActualMoving();
                        
                    }
                }
                else if (colliders[0].gameObject.tag == "NotGround")
                {
                    Debug.Log("Very no " + obrotnik);
                    isGround = false;

                }
                else
                {
                    Debug.Log("There is literally nothing " + obrotnik.x + obrotnik.y + obrotnik.z);
                    isGround = false;

                }
            }
            else
            {
                Debug.Log("Tutaj nie ma nic");
            }

    }
    private void ActualMoving()
    {
        j++;
        Debug.Log("To " + j + " ruch");
        Vector3 target = new Vector3(obrotnik.x, obrotnik.y + 1, obrotnik.z);
        StartCoroutine(MoveTowardsPos(target));
    }

    IEnumerator MoveTowardsPos(Vector3 target)
    {
        mover.interactable = false;
        while(transform.position != target)
        {
            ratatui.transform.position = Vector3.MoveTowards(transform.position, target, 5 * Time.deltaTime);
            yield return null;
        }
        mover.interactable = true;
        RatatuiPosReset();
    }

    private void RatatuiPosReset()
    {
        ratatuiPos = ratatui.transform.position;
        obrotnik = ratatuiPos;
    }
}