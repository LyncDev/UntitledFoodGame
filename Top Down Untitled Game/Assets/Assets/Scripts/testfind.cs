using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testfind : MonoBehaviour
{
    private GameObject cherry;
    private Transform[] cherrypos = new Transform[5];
    // Start is called before the first frame update
    void Start()
    {   
        
        cherry = GameObject.Find("Food1_2");
        Debug.Log(cherry.name);
        cherrypos[0] = cherry.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, cherrypos[0].position, 2f * Time.deltaTime);
    }
}
