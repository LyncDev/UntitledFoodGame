using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CustomerController2 : MonoBehaviour
{
    //---------------Public Variables-------------------------//
    private Transform[] waypoint = new Transform [5];

    private GameObject wp1, wp2, wp3, wp4, wp5;
    private GameObject sp;
    private Transform endpoint;
    public static float customerSpeed = 2f;
    int j = 0;


    //---------------Private Variables-------------------------//
    private Transform currentwaypoint;
    public int i = 0;
    private string[] foodname = { "Food1_1", "Food1_2", "Food2_1", "Food2_2", "Food3_1", "Food3_2", "Food4_1", "Food4_2" };
    private string checkfoodname, wantfood;
    private bool done = false;

    

    // Start is called before the first frame update
    void Start()
    {
        
        getcomponents();

        wantfood = foodname[Random.Range(0, foodname.Length)];
        currentwaypoint = waypoint[0];
        Debug.Log(wantfood);

    }

    // Update is called once per frame
    void Update()
    {
        movement();
        checkfood();

        if (i > 5)
        {
            i = 5;
        }
    }

    //-----------------Movement----------------------//
    private void movement()
    {
        //----------Coming-----------------------//
        if (!done)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentwaypoint.position, customerSpeed * Time.deltaTime);
        }

        //---------------Adding Unhappy Custommers--------------//
        if(currentwaypoint == waypoint[4] && j == 0)
        {
            j++;
            Debug.Log("ABC");
            ScoreController.unscorecounter();
        }


        //---------Going Back---------------------//

        if (done)
        {  
            StartCoroutine(buying());
        }
    }

    //-----------------CheckFood----------------------//
    private void checkfood()
    {
        if (checkfoodname == wantfood)
        { 
            if(wantfood == "Food1_1")
                Inventory.foodname[0]--;
            else if(wantfood == "Food1_2")
                Inventory.foodname[1]--;
            else if(wantfood == "Food2_1")
                Inventory.foodname[2]--;
            else if(wantfood == "Food2_2")
                Inventory.foodname[3]--;
            else if(wantfood == "Food3_1")
                Inventory.foodname[4]--;
            else if (wantfood == "Food3_2")
                Inventory.foodname[5]--;
            else if (wantfood == "Food4_1")
                Inventory.foodname[6]--;
            else if (wantfood == "Food4_2")
                Inventory.foodname[7]--;

            wantfood = "";
            done = true;
        }
        else if (!done)
        {
            currentwaypoint = waypoint[i];
        }
    }

    //-----------------Collision----------------------//
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "WayPoint (5)" || collision.gameObject.name == "EndPoint")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Food"))
        {
            checkfoodname = collision.gameObject.name;
            i++;

      
        }/*else if (collision.gameObject.CompareTag("Empty"))
        {
            checkfoodname = collision.gameObject.name;
            i++;
        }*/

        if (collision.gameObject.CompareTag("Finish"))
        {
            done = true;
            endpoint.position = transform.position;
        }

    }

    //-----------------Coroutine----------------------//


    //-------------Waiting While Buying--------------//
    IEnumerator buying()
    {
        float customspeed = 3;
        
        if(customerSpeed == 2)
            customspeed = 3;
        
        else if(customerSpeed == 4) 
            customspeed = 1.5f;
        
        yield return new WaitForSeconds(customspeed);


        //----Adding Happy Customer Score // && //----Giving Moneyyyyyyy-------------//
        if (wantfood == "") 
        {
            ScoreController.scorecounter();
            Inventory.money += 10;
            wantfood = "Done";        
        }
       
        
        
        transform.position = Vector3.MoveTowards(transform.position, endpoint.position, customerSpeed * Time.deltaTime);
    }

    //-----------------GetComponents----------------------//
    void getcomponents()
    {

        //------EndPoint----------------------------//
        sp = GameObject.Find("EndPoint");
        endpoint = sp.transform;
        

        //--------------WayPoints-------------------//

        wp1 = GameObject.Find("WayPoint (1)");  
        waypoint[0] = wp1.transform;

        wp2 = GameObject.Find("WayPoint (2)");
        waypoint[1] = wp2.transform;
        
        wp3 = GameObject.Find("WayPoint (3)");
        waypoint[2] = wp3.transform;
       
        wp4 = GameObject.Find("WayPoint (4)");
        waypoint[3] = wp4.transform;
        
        wp5 = GameObject.Find("WayPoint (5)");
        waypoint[4] = wp5.transform;


    }
}
