using System.Collections;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject road;
    public Vector3 lastPos;
    public float offset = 0.707f;
    public float creationDelay = 0.2f; // Delay between creating new road parts
    private int roadCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine for creating new road parts
        StartCoroutine(CreateRoadParts());
    }

    // Coroutine for creating new road parts
    IEnumerator CreateRoadParts()
    {
        while (true)
        {
            yield return new WaitForSeconds(creationDelay); // Wait for the specified delay
            CreateNewRoadPart(); // Create a new road part
        }
    }

    // Method to create a new road part
    public void CreateNewRoadPart()
    {

        Vector3 spawnPos = Vector3.zero;
        float chance = Random.Range(0, 100);
        if (chance < 50)
        {
            spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
        }
        else
        {
            spawnPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);
        }

        GameObject g = Instantiate(road, spawnPos, Quaternion.Euler(0, 45, 0));
        lastPos = g.transform.position;

        roadCount++;
        if (roadCount% 5==0)
        {
            g.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (roadCount % 13 == 0)
            {
                g.transform.GetChild(1).gameObject.SetActive(true);
            }
    }


}
