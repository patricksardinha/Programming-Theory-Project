using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;

    public List<GameObject> pooledGroundTiles;
    public List<GameObject> pooledMovableGroundTiles;

    public GameObject[] groundTileToPool;
    public GameObject[] movableGroundTileToPool;

    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
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
    }

    public GameObject GetPooledGroundTile()
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


    public GameObject GetPooledMovableGroundTile()
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
