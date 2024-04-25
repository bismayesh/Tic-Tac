using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject road;
    public Vector3 lastPos;
    public float offset = 0.707f;
    public void CreateNewRoadPart()
    {
        Debug.Log("Create new road part");

        Vector3 spawnPos = Vector3.zero;
        float chance = Random.Range(0, 100);
        if (chance < 50)
        {
            spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
        }
        else
            spawnPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);

        GameObject g = Instantiate(road, spawnPos, Quaternion.Euler(0, 45, 0));

        lastPos = g.transform.position;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
                CreateNewRoadPart();
        }
    }
}
