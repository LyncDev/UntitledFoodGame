using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    static public bool canspawn = false;

    public GameObject customer;
    public Transform startpoint;
    float i;
    public float j;
    void Start()
    {
        StartCoroutine(Waitfor2());
        j = 2;
    }

    private void Update()
    {
        i = CustomerController2.customerSpeed;
        switch (i)
        {
            case 0:
                j = 8;
                break;
            case 2:
                j = 2; 
                break;
            case 4:
                j = 1;
                break;
        }
    }


    IEnumerator Waitfor2()
    {
        while (true)
        {
            while (canspawn == true && j != 8)
            {
                yield return new WaitForSeconds(j);
                Instantiate(customer, startpoint.transform.position, transform.rotation);
                Debug.Log(canspawn);
            }
            yield return new WaitForSeconds(1);
        }
    }
}
