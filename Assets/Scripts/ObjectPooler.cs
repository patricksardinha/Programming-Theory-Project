using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;

    public List<GameObject> pooledGroundTiles;
    public List<GameObject> pooledMovableGroundTiles;
    public List<GameObject> pooledDecorLeft;
    public List<GameObject> pooledDecorRight;
    public List<GameObject> pooledDecorDown;

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
            obj.transform.SetParent(this.transform); // set as children of Spawn Manager
        }

        pooledMovableGroundTiles = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(movableGroundTileToPool[i % movableGroundTileToPool.Length]);
            obj.SetActive(false);
            pooledMovableGroundTiles.Add(obj);
            obj.transform.SetParent(this.transform); 
        }

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

    void Start()
    {
    }

    public GameObject GetPooledGroundTile()
    {
        int randomTile = Random.Range(0, pooledGroundTiles.Count);

        if (!pooledGroundTiles[randomTile].activeInHierarchy)
        {
            return pooledGroundTiles[randomTile];
        }
        else
        {
            // For as many objects as are in the pooledObjects list
            for (int i = 0; i < pooledGroundTiles.Count; i++)
            {
                // if the pooled objects is NOT active, return that object 
                if (!pooledGroundTiles[i].activeInHierarchy)
                {
                    return pooledGroundTiles[i];
                }
            }
            // otherwise, return null   
            return null;
        }
    }


    public GameObject GetPooledMovableGroundTile()
    {
        int randomMovableTile = Random.Range(0, pooledMovableGroundTiles.Count);

        if (!pooledMovableGroundTiles[randomMovableTile].activeInHierarchy)
        {
            return pooledMovableGroundTiles[randomMovableTile];
        }
        else
        {
            // For as many objects as are in the pooledObjects list
            for (int i = 0; i < pooledMovableGroundTiles.Count; i++)
            {
                // if the pooled objects is NOT active, return that object 
                if (!pooledMovableGroundTiles[i].activeInHierarchy)
                {
                    return pooledMovableGroundTiles[i];
                }
            }
            // otherwise, return null   
            return null;
        }
    }

    public GameObject GetPooledDecorLeft()
    {
        // For as many objects as are in the pooledObjects list
        for (int i = 0; i < pooledDecorLeft.Count; i++)
        {
            // if the pooled objects is NOT active, return that object 
            if (!pooledDecorLeft[i].activeInHierarchy)
            {
                return pooledDecorLeft[i];
            }
        }
        // otherwise, return null   
        return null;
    }

    public GameObject GetPooledDecorRight()
    {
        // For as many objects as are in the pooledObjects list
        for (int i = 0; i < pooledDecorRight.Count; i++)
        {
            // if the pooled objects is NOT active, return that object 
            if (!pooledDecorRight[i].activeInHierarchy)
            {
                return pooledDecorRight[i];
            }
        }
        // otherwise, return null   
        return null;
    }

    public GameObject GetPooledDecorDown()
    {
        // For as many objects as are in the pooledObjects list
        for (int i = 0; i < pooledDecorDown.Count; i++)
        {
            // if the pooled objects is NOT active, return that object 
            if (!pooledDecorDown[i].activeInHierarchy)
            {
                return pooledDecorDown[i];
            }
        }
        // otherwise, return null   
        return null;
    }
}

