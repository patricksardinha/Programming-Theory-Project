using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Array of ground tiles, movable ground tiles & decors 
    public GameObject[] groundTilePrefabs;
    public GameObject[] groundTileMovablePrefabs;
    public GameObject[] decorsPrefabs;

    [SerializeField] private Vector3 posSpawnGroundTile;
    [SerializeField] private Vector3 posSpawnMovableGroundTile;

    [SerializeField] private float gapOffset;

    // Set the movable ground tile in the right or left side
    private List<Vector3> listParity = new List<Vector3>() { new Vector3(1,1,1), new Vector3(-1,1,1) };

    void Start()
    {
        StartCoroutine("RoutineSpawnRunningPath");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Routine which manage ground tiles spawn 
    IEnumerator RoutineSpawnRunningPath()
    {
        // Generate ground tile gameobject
        GameObject groundTile = SpawnRandomGroundTile();

        // Generate movable ground tile gameobject
        GameObject movableGroundTile = SpawnRandomMovableGroundTile(listParity[Random.Range(0, listParity.Count)]);

        // Get the position
        Vector3 positionGroundTile = groundTile.transform.position;

        // Get the size to know when the new spawn should be done
        float sizeGroundTile = groundTile.GetComponent<BoxCollider>().size.z * groundTile.transform.localScale.z;

        while (true)
        {
            yield return new WaitForSeconds(0);

            // Compute the actual position & size of the tile
            positionGroundTile = groundTile.transform.position;
            sizeGroundTile = groundTile.GetComponent<BoxCollider>().size.z * groundTile.transform.localScale.z;

            // Check if new ground tile should be spawn
            // If true call SpawnRandomGroundTile()
            Debug.Log(sizeGroundTile);
            if (positionGroundTile.z < posSpawnGroundTile.z - (sizeGroundTile + gapOffset))
            {
                groundTile = SpawnRandomGroundTile();
                movableGroundTile = SpawnRandomMovableGroundTile(listParity[Random.Range(0, listParity.Count)]);
            }
        }
    }

    // Select a random ground tile in the list of the prefabs & return the object
    public GameObject SpawnRandomGroundTile()
    {
        GameObject pooledGroundTile = ObjectPooler.SharedInstance.GetPooledGroundTile();

        pooledGroundTile.SetActive(true);
        pooledGroundTile.transform.position = posSpawnGroundTile;

        return pooledGroundTile;
    }

    public GameObject SpawnRandomMovableGroundTile(Vector3 parity)
    {
        GameObject pooledMovableGroundTile = ObjectPooler.SharedInstance.GetPooledMovableGroundTile();

        pooledMovableGroundTile.SetActive(true);
        pooledMovableGroundTile.transform.position = Vector3.Scale(posSpawnMovableGroundTile, parity);

        return pooledMovableGroundTile;
    }
}
