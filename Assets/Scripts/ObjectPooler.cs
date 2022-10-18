using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;

    // Define list of GameObject using the pool like the tiles and the decors
    public List<GameObject> pooledGroundTiles;
    public List<GameObject> pooledMovableGroundTiles;
    public List<GameObject> pooledDecorLeft;
    public List<GameObject> pooledDecorRight;
    public List<GameObject> pooledDecorDown;

    // Define arrays containing the objects to pool
    public GameObject[] groundTileToPool;
    public GameObject[] movableGroundTileToPool;
    public GameObject[] decorLeftToPool;
    public GameObject[] decorRightToPool;
    public GameObject[] decorDownToPool;

    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;

        // Loop through list of pooled objects, deactivating them and adding them to the list 
        pooledGroundTiles = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(groundTileToPool[i % groundTileToPool.Length]);
            obj.SetActive(false);
            pooledGroundTiles.Add(obj);

            // Set as children of Spawn Manager
            obj.transform.SetParent(this.transform); 
        }

        pooledMovableGroundTiles = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(movableGroundTileToPool[i % movableGroundTileToPool.Length]);
            obj.SetActive(false);
            pooledMovableGroundTiles.Add(obj);
            obj.transform.SetParent(this.transform); 
        }

        // Same process for the decors prefabs
        pooledDecorLeft = new List<GameObject>();
        pooledDecorRight = new List<GameObject>();
        pooledDecorDown = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject objLeft = (GameObject)Instantiate(decorLeftToPool[0]);
            GameObject objRight = (GameObject)Instantiate(decorRightToPool[0]);
            GameObject objDown = (GameObject)Instantiate(decorDownToPool[0]);

            objLeft.SetActive(false);
            pooledDecorLeft.Add(objLeft);
            objLeft.transform.SetParent(this.transform);

            objRight.SetActive(false);
            pooledDecorRight.Add(objRight);
            objRight.transform.SetParent(this.transform);

            objDown.SetActive(false);
            pooledDecorDown.Add(objDown);
            objDown.transform.SetParent(this.transform);
        }
    }

    public GameObject GetPooledGroundTile()
    {
        // Choose a random Tile
        int randomTile = Random.Range(0, pooledGroundTiles.Count);

        // And try to pool it if the object is not active 
        if (!pooledGroundTiles[randomTile].activeInHierarchy)
        {
            return pooledGroundTiles[randomTile];
        }
        // In case the object is already used
        else
        {
            // For as many objects as are in the pooledObjects list
            for (int i = 0; i < pooledGroundTiles.Count; i++)
            {
                // If the pooled objects is NOT active, return that object 
                // (Get the first one found)
                if (!pooledGroundTiles[i].activeInHierarchy)
                {
                    return pooledGroundTiles[i];
                }
            }
            // Otherwise, return null   
            return null;
        }
    }


    // Same process for the movable tiles
    // [NOT IN USAGE: SEE SpawnManager.cs]
    public GameObject GetPooledMovableGroundTile()
    {
        int randomMovableTile = Random.Range(0, pooledMovableGroundTiles.Count);

        if (!pooledMovableGroundTiles[randomMovableTile].activeInHierarchy)
        {
            return pooledMovableGroundTiles[randomMovableTile];
        }
        else
        {
            for (int i = 0; i < pooledMovableGroundTiles.Count; i++)
            {
                if (!pooledMovableGroundTiles[i].activeInHierarchy)
                {
                    return pooledMovableGroundTiles[i];
                }
            }
            return null;
        }
    }

    // Same process for the decors (left, right sides & down)
    public GameObject GetPooledDecorLeft()
    {
        for (int i = 0; i < pooledDecorLeft.Count; i++)
        {
            if (!pooledDecorLeft[i].activeInHierarchy)
            {
                return pooledDecorLeft[i];
            }
        }
        return null;
    }

    public GameObject GetPooledDecorRight()
    {
        for (int i = 0; i < pooledDecorRight.Count; i++)
        {
            if (!pooledDecorRight[i].activeInHierarchy)
            {
                return pooledDecorRight[i];
            }
        }
        return null;
    }

    public GameObject GetPooledDecorDown()
    {
        for (int i = 0; i < pooledDecorDown.Count; i++)
        {
            if (!pooledDecorDown[i].activeInHierarchy)
            {
                return pooledDecorDown[i];
            }
        }
        return null;
    }
}

