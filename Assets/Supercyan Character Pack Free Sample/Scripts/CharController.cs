using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public Transform rayStart;
    private Rigidbody rb;
    private bool walkingRight=true;
    private Animator animator;

    // Start is called before the first frame update
    void Awake()
        //fixed update to move the player forward
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
        //forward movement of the player depending on its rotation
    {
        rb.transform.position= transform.position+transform.forward*2*Time.deltaTime;
    }

    // Update is called once per frame
    void Update()

    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Switch();
        }
        //start ray from the bottom of the character to see if it would hit the ground or not, if it doesnot hit then start the trigger
        RaycastHit hit;
        if (Physics.Raycast(rayStart.position,-transform.up,out hit, Mathf.Infinity)) 
        {
            animator.SetTrigger("isFalling");
        }
    }

    private void Switch()
        // change the variable if walking right was true, its going to be false and vice versa
    {
        walkingRight = !walkingRight;

        if (walkingRight )
        
            transform.rotation=Quaternion.Euler(0,45,0);

            else
                transform.rotation = Quaternion.Euler(0, -45, 0);
        
    }
}
