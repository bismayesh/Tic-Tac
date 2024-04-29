using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public Transform rayStart;
    public GameObject crystalEffect;
    public GameObject obstacleEffect;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private bool walkingRight = true;
    private Animator animator;
    private GameManager gameManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        if (!gameManager.gameStarted)
        {
            return;
        }
        else
        {
            animator.SetTrigger("gameStarted");
        }
        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            SwitchDirection();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        RaycastHit hit;
        if (Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity))
        {
            animator.SetTrigger("isFalling");
        }
        if (transform.position.y < -1.5)
        {
            gameManager.EndGame();
        }
    }

    private void SwitchDirection()
    {
        if (!gameManager.gameStarted)
        {
            return;
        }

        walkingRight = !walkingRight;

        if (walkingRight)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
    }


    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameManager.gameStarted)
        {
            return;
        }

        if (other.tag == "Crystal")
        {
            Destroy(other.gameObject);
            gameManager.IncreaseScore();

            GameObject g = Instantiate(crystalEffect, rayStart.transform.position, Quaternion.identity);
            Destroy(g, 2);
        }

        if (other.tag == "Obstacle")
        {
            Destroy(other.gameObject);
            gameManager.DecreaseScore();

            GameObject g = Instantiate(obstacleEffect, rayStart.transform.position, Quaternion.identity);
            Destroy(g, 2);
        }
    }
}

