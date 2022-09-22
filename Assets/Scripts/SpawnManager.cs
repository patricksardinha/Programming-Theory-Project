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
    [SerializeField] private float gapOffset;

    public GameObject groundTileInstance;
        
    void Start()
    {
        StartCoroutine("RoutineSpawnGroundTiles");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Routine which manage ground tiles spawn 
    IEnumerator RoutineSpawnGroundTiles()
    {
        // Get ground tile gameobject
        GameObject groundTile = SpawnRandomGroundTile();

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
            // If true call SpawnRandomDecor()
            Debug.Log(sizeGroundTile);
            if (positionGroundTile.z < posSpawnGroundTile.z - (sizeGroundTile + gapOffset))
            {
                groundTile = SpawnRandomGroundTile();
            }
        }
    }

    // Select a random decor in the list of the prefabs decors & return the object
    public GameObject SpawnRandomGroundTile()
    {
        int randomGroundTile = Random.Range(0, groundTilePrefabs.Length);

        // The parity indicates if the decor which should spawn will be in the right or left side
        groundTileInstance = Instantiate(groundTilePrefabs[randomGroundTile], posSpawnGroundTile, groundTilePrefabs[randomGroundTile].gameObject.transform.rotation);

        return groundTileInstance;
    }
}
