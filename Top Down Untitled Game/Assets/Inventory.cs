using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Toggle[] foodtoggle;
    public Button[] BuyFoodButton;
    public GameObject[] Food;
    public TextMeshProUGUI Money;
    


    static public int[] foodname = new int[8];

    static public int money = 100;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Money: " + money + "G");
        int i = 0;
        while ( i < 8)
        {
            foodname[i] = 0;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkFood();
        checkMoney();
    }

    void checkFood()
    {
        int i = 0;
        while (i < 8) {
            if (foodname[i] == 0)
            {
                Food[i].active = false;
                foodtoggle[i].interactable = false;
                foodtoggle[i].isOn = false;

            }
            else if (foodname[i] > 0)
            { 
                foodtoggle[i].interactable = true; 
            }
            
            i++;
        }
        
    }
    void checkMoney()
    {
        Money.text = money + "G";

        int i = 0;

        if(money < 8)
        {
            while(i < 8)
            {
                BuyFoodButton[i].interactable = false;
                i++;
            }
        }else if(money > 7)
        {
            while(i < 8)
            {
                BuyFoodButton[i].interactable = true;
                i++;
            }
        }
        
    }
    
    public void addfood(GameObject button)
    {
        int i = 0;
        Debug.Log(button.name);
        while (i < 8)
        {
            if (button.name == ("Food" + (i+1)))
            {
                foodname[i]++;
                money -= 8;
                Debug.Log("Money: " + money + "G");
                
            }
            i++;
        }
    }



}
