using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject[] groundTile;
    int randNum = 0;
    int count = 0;
    bool startSpawnerIsdone = false;
    Vector3 nextSpawnPoint;

    public void SpawnTile()
    {
        if (startSpawnerIsdone == true)
        {
            randNum = Random.Range(1, 8);
        }
        else if (count == 1)
        {
            startSpawnerIsdone = true;
        } else {
            count++;
        }

        Debug.Log("Tile: " + randNum);
        GameObject temp = Instantiate(groundTile[randNum], nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
        for (int i = 0; i <= 8; i++)
        {
            SpawnTile();
        }
    }

}
