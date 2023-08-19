using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodController : MonoBehaviour
{
    public GameObject[] food;
    public Toggle[] foodtoggle;
    public GameObject[] EmptyFood;

    int x, y;
    private void Start()
    {


    }
    private void Update()
    {
        
        //EmptyCheck(0);
       // EmptyCheck(1);
        x = 0;
        y = 0;
        while (x < 8)
        {
            Debug.Log("Check1");
            if (food[x].gameObject.active == true)
            {
                EmptyFood[x].gameObject.active = false;
            }
            x++;
        }
        while (y < 8)
        {
            Debug.Log("Check2");
            if (food[y].gameObject.active == false)
            {
                EmptyFood[y].gameObject.active = true;
            }
            y++;
        }
    }

    IEnumerator EmptyCheck(int j)
    {
        if (j == 0)
        {
            Debug.Log("Hello2");
            int i = 0;
            while (true)
            {
                i = 0;
                yield return new WaitForSeconds(0.01f);
                while (i < 8)
                {
                    if (food[i].gameObject.active == true)
                    {
                        EmptyFood[i].gameObject.active = false;
                    }
                    i++;
                }
            }

        }

        if (j == 1)
        {
            Debug.Log("Hello3");
            int i = 0;

        }
    


       
    }
    public void MasterFood1(int i)
    {
        if (food[i].gameObject.active == false)
        {
            food[i].gameObject.active = true;
            food[i + 1].gameObject.active = false;
            //EmptyFood[i].gameObject.active = false;
           
        }
        else
        {
            //EmptyFood[i].gameObject.active = true;
            food[i].gameObject.active = false;
        }
    }
    private void MasterFood2(int i)
    {
        if (food[i].gameObject.active == false)
        {
            food[i].gameObject.active = true;
            food[i - 1].gameObject.active = false;
            //EmptyFood[i].gameObject.active = false;
        }
        else
        {
            //EmptyFood[i].gameObject.active = true;
            food[i].gameObject.active = false;
        }
    }


    public void Food1_1()
    {
        MasterFood1(0);
    }
    public void Food1_2()
    {
        MasterFood2(1);
    }
    public void Food2_1()
    {
        MasterFood1(2);
    }
    public void Food2_2()
    {
        MasterFood2(3);
    }
    public void Food3_1()
    {
        MasterFood1(4);
    }
    public void Food3_2()
    {
        MasterFood2(5);
    }
    public void Food4_1()
    {
        MasterFood1(6);
    }
    public void Food4_2()
    {
        MasterFood2(7);
    }

}
