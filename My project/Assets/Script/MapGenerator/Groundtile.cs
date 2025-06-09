using UnityEngine;

public class Groundtile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        groundSpawner = GameObject.FindFirstObjectByType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other){
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
