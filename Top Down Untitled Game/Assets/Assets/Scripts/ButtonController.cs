using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    
    public Image menu;
    public Image Inventory;
    public Image Shop;
    public Image Options;

    public Button[] speedbuttons;


    //---Gets Customer Speed Before Opening Menu----------//
    private float getCustomerSpeed = 2;


    private void Update()
    {
        
    }
    //-----------------------Menu Controller-----------------------//
    public void openmenu()
    {
        //----Set Menu to False----//
        if (menu.gameObject.active == true)
        {
            menu.gameObject.active = false;
            CustomerSpawner.canspawn = true;
            CustomerController2.customerSpeed = getCustomerSpeed;


            int i = 0;
            while(i < 3)
            {
                speedbuttons[i].interactable = true;
                i++;
            }
        }

        //----Set Menu to True----//
        else if (menu.gameObject.active == false)
        {
            menu.gameObject.active = true;
            CustomerSpawner.canspawn = false;
            getCustomerSpeed = CustomerController2.customerSpeed;
            CustomerController2.customerSpeed = 0;


            int i = 0;
            while (i < 3)
            {
                speedbuttons[i].interactable = false;
                i++;
            }
        }
    }
    public void openinventory()
    {
        Inventory.gameObject.active = true;
        Shop.gameObject.active = false;
        Options.gameObject.active = false;
    }
    public void openshop()
    {
        Shop.gameObject.active = true;
        Inventory.gameObject.active = false;
        Options.gameObject.active = false;
    }
    public void openoptions()
    {
        Options.gameObject.active = true; ;
        Inventory.gameObject.active = false;
        Shop.gameObject.active = false;
    }

    //--------------Game Speed Controller---------------------//
    public void SpeedStop()
    {
        CustomerController2.customerSpeed = 0f;
    }
    public void SpeedNorm()
    {
        CustomerController2.customerSpeed = 2f;
    }
    public void SpeedFast()
    {
        CustomerController2.customerSpeed = 4f;
    }

}
