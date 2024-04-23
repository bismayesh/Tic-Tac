using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForObjects : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()


    {
        Ray ray= Camera.main.ScreenPointToRay( Input.mousePosition );

        RaycastHit hit;

        if (Physics.Raycast(ray,out hit, 100))
        {
            print("hit"+ hit.collider.gameObject.name);
        }




        //RaycastHit hit;

        //if (Physics.Raycast(transform.position, -Vector3.up, out hit, 100f)) ;
        //{
           // print(" we hit something" + hit.transform.position);
        //}
    }
}
