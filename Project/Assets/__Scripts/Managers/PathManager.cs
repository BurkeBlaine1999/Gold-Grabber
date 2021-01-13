using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    //Variables
    public GameObject[] pathPrefabs;
    private Transform playerTransform;

    private float spawnZ = -22.0f;//Initially Spawns the tiles behind the player so they dont see the edge

    private float pathLength = 44.0f;
    private float safeZone = 150.0f;
    private int amnPathsOnScreen = 8;
    private int lastPrefabNum = 0;
    private List<GameObject> activePaths;


    void Start()
    {
        //Instantiate a new list for paths that are active
        activePaths = new List<GameObject>();

        //Find the player object by its tag
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < amnPathsOnScreen; i++)
        {
            //Spawn empty paths for the first 4 paths.
            if (i < 4)
            {
                SpawnPath(0);
            }
            //Spawn random paths for the rest of the paths.
            else
            {
                SpawnPath();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Delete the paths that are a safe distance behind the player and spawn another in the front
        if (playerTransform.position.z - safeZone > (spawnZ - amnPathsOnScreen * pathLength))
        {
            SpawnPath();
            deletePath();
        }
    }

    //Spawn a path at the front of the path
    private void SpawnPath(int prefabIndex = -1)
    {
        GameObject gameObject;

        if (prefabIndex == -1)
        {
            gameObject = Instantiate(pathPrefabs[randomPrefabspawner()]) as GameObject;
        }
        else
        {
            gameObject = Instantiate(pathPrefabs[prefabIndex]) as GameObject;
        }

        gameObject.transform.SetParent(transform);
        gameObject.transform.position = Vector3.forward * spawnZ;
        spawnZ += pathLength;
        activePaths.Add(gameObject);

    }

    //Remove the oldest path in the list as the player has passed it
    private void deletePath()
    {
        Destroy(activePaths[0]);
        activePaths.RemoveAt(0);
    }

    private int randomPrefabspawner()
    {

        //If the list is empty or has only one item , spawn the first item.
        if (pathPrefabs.Length <= 1)
            return 0;

        /* Set randomPath equal to the lastPrefabNum to 
        prevent duplicates spawning next to each other 
        */
        int randomPath = lastPrefabNum;

        while (randomPath == lastPrefabNum)
        {
            randomPath = Random.Range(0, pathPrefabs.Length);
        }

        lastPrefabNum = randomPath;
        return randomPath;

    }
}
