using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingData : MonoBehaviour

{
    int number = 0;

    void Start()
    {
        Debug.Log("Stored Number is:"+GetNumber());
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space)) {
        number++;
      if (number > GetNumber())
            {
                PlayerPrefs.SetInt("MyNumber",number);
                
            }
            Debug.Log(number);
        }  
    }

    int GetNumber()
    {

        int myNumber = PlayerPrefs.GetInt("myNumber", 0);
        return myNumber;
    }
}
