using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DefaultExecutionOrder(-1)]
public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Vector3 posSpawnGroundTile;
    [SerializeField] private Vector3 posSpawnMovableGroundTile;
    [SerializeField] private Vector3 posSpawnDecors;

    [SerializeField] private float gapOffset;
    [SerializeField] private float offSetDecor;

    public GameObject[] movableTiles;

    // Set the movable ground tile in the right or left side
    private List<Vector3> listParity = new List<Vector3>() { new Vector3(1,1,1), new Vector3(-1,1,1) };

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // Start spawn for the running path
        StartCoroutine("RoutineSpawnRunningPath");
    }
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

        // Generate decors gameobjects
        GameObject decorLeft = SpawnDecor("Left", listParity[1]);
        GameObject decorRight = SpawnDecor("Right", listParity[0]);
        GameObject decorDown = SpawnDecor("Down", new Vector3(0,1,1));

        // Get the position
        Vector3 positionGroundTile = groundTile.transform.position;

        // Get decor down pos & size since decors right & left will spawn according to decor down
        Vector3 positionDecor = decorDown.transform.position;

        // Get the size to know when the new spawn should be done
        float sizeGroundTile = groundTile.GetComponent<BoxCollider>().size.z * groundTile.transform.localScale.z;
        float sizeDecor = decorDown.GetComponent<BoxCollider>().size.z;

        // Looping until the game is over
        while (gameManager.isGameActive)
        {
            yield return new WaitForSeconds(0);
            // Compute the actual position & size of the tile
            positionGroundTile = groundTile.transform.position;
            sizeGroundTile = groundTile.GetComponent<BoxCollider>().size.z * groundTile.transform.localScale.z;

            // Same process for decors
            positionDecor = decorDown.transform.position;
            sizeDecor = decorDown.GetComponent<BoxCollider>().size.z;

            // Check if new ground tile should be spawn
            // If true call the spawn function
            if (positionGroundTile.z < posSpawnGroundTile.z - (sizeGroundTile + gapOffset))
            {
                groundTile = SpawnRandomGroundTile();
                movableGroundTile = SpawnRandomMovableGroundTile(listParity[Random.Range(0, listParity.Count)]);
            }

            // Same for decors
            if (positionDecor.z < posSpawnDecors.z - (sizeDecor - offSetDecor))
            {
                decorLeft = SpawnDecor("Left", listParity[1]);
                decorRight = SpawnDecor("Right", listParity[0]);
                decorDown = SpawnDecor("Down", new Vector3(0, 1, 1));
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

    // For the movable tiles, instantiate the objects in order to destroy them fast after they bypass the player
    public GameObject SpawnRandomMovableGroundTile(Vector3 parity)
    {
        //GameObject pooledMovableGroundTile = ObjectPooler.SharedInstance.GetPooledMovableGroundTile();
        //pooledMovableGroundTile.SetActive(true);
        
        GameObject pooledMovableGroundTile = Instantiate(movableTiles[Random.Range(0, movableTiles.Length)]);
        pooledMovableGroundTile.transform.position = Vector3.Scale(posSpawnMovableGroundTile, parity);

        return pooledMovableGroundTile;
    }

    public GameObject SpawnDecor(string decorSide, Vector3 parity)
    {
        // Switch case according the side where the decor should spawn
        switch (decorSide)
        {
            // First: pool the object
            // Second: set the object as active
            // Third: position the object (parity defines the side (left, right, down))
            case "Left":
                GameObject pooledDecorLeft = ObjectPooler.SharedInstance.GetPooledDecorLeft();
                pooledDecorLeft.SetActive(true);
                pooledDecorLeft.transform.position = Vector3.Scale(posSpawnDecors, parity);
                return pooledDecorLeft;

            case "Right":
                GameObject pooledDecorRight = ObjectPooler.SharedInstance.GetPooledDecorRight();
                pooledDecorRight.SetActive(true);
                pooledDecorRight.transform.position = Vector3.Scale(posSpawnDecors, parity);
                return pooledDecorRight;

            case "Down":
                GameObject pooledDecorDown = ObjectPooler.SharedInstance.GetPooledDecorDown();
                pooledDecorDown.SetActive(true);
                pooledDecorDown.transform.position = Vector3.Scale(posSpawnDecors, parity);
                return pooledDecorDown;

            default: return null;
        }

    }

    public List<string> SpawnRandomSchemaInGame()
    {
        // Define the schema generated in game
        List<string> schemaList = new List<string>();

        // For each element, select a random shapes and add it into the list
        for (int i = 0; i < gameManager.difficultyScore; i++)
        {
            int rndShapeInd = Random.Range(0, BaseShape.bf_shapeList.Count);
            schemaList.Add(BaseShape.bf_shapeList[rndShapeInd]);
        }

        return schemaList;
    }
}
