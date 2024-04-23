using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour { 

    public Transform prefab;
    int counter = 0;


    private void Start()
    {
        InvokeRepeating("CreateNewCube", 1f, 1f);
    }
    public void CreateNewCube()
    {
        
        Instantiate (prefab, new Vector3 (-10+counter*3.0f,0,0),Quaternion. identity);
            counter++;
        
        
    }
}
