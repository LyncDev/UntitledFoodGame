using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    //----------private Components---------------//
    private Rigidbody2D rb;
    private Animator anim;


    //----------private Variables------------------//
    private float movementx, movementy;

    [HideInInspector]
    private float score;

    //----------Public Variables-------------------//
    public float speed;

    //----------Animation string-bools----------------//
    private string walkup = "WalkUp";
    private string walkdown = "WalkDown";
    private string walkright = "WalkRight";
    private string walkleft = "WalkLeft";
    
    //---------Start---------------------//
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();   
    }


    //----------Update---------------------//
    void Update()
    {
        movement();
    }


    //---------------Movement-----------------------//
    void movement()
    {

        movementx = Input.GetAxisRaw("Horizontal");
        movementy = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(movementx, movementy, 0f) * Time.deltaTime * speed;

        //----Walk Animation---------------//

        if (Input.GetKey(KeyCode.W))
            anim.SetBool(walkup, true);
        else
            anim.SetBool(walkup, false);

        //----------------------------------------------------
        
        if (Input.GetKey(KeyCode.S))
            anim.SetBool(walkdown, true);
        else
            anim.SetBool(walkdown, false);
        
        //-----------------------------------------------------
        
        if (Input.GetKey(KeyCode.D))
            anim.SetBool(walkright, true);
        else
            anim.SetBool(walkright, false);
        
        //-----------------------------------------------------
        
        if (Input.GetKey(KeyCode.A))
            anim.SetBool(walkleft, true);
        else
            anim.SetBool(walkleft, false);
        
        //-----------------------------------------------------


    }

    public void Score()
    {
        score += 10;
        Debug.Log(score);
    }
}
