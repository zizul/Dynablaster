using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class MapGenerator : MonoBehaviour
{

    public GameObject groundElementPrefab;
    private static string GROUND_TAG = "Ground";

    public GameObject wallElementPrefab;
    private static string WALL_TAG = "Wall";

    public GameObject brickElementPrefab;
    public GameObject playerPrefab;

    public int mapSize = 20;
    private List<GameObject> groundElementList = new List<GameObject>();
    private List<GameObject> wallsElementList = new List<GameObject>();

    // Use this for initialization
    void Awake()
    {
        groundElementList = new List<GameObject>(GameObject.FindGameObjectsWithTag(GROUND_TAG));
        DestroyGround();
        GenerateGround();
        GenerateWalls();
        GenerateWallsInside();
        GenerateBricks();
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        GameObject o = Instantiate(playerPrefab, new Vector3(-mapSize / 2 + 1, 1, mapSize / 2 - 1), Quaternion.identity);
    }

    private void GenerateBricks()
    {
        var currentPosition = new Vector3(0, 0, 0);
        int innerSize = mapSize - 5;

        for (int x = -innerSize / 2; x <= innerSize / 2; x += 1)
        {
            for (int z = -innerSize / 2; z <= innerSize / 2; z += 1)
            {
                currentPosition = new Vector3(x, 1, z);
                if(checkIfPosEmpty(currentPosition, wallsElementList))
                {
                    GameObject o = Instantiate(brickElementPrefab, currentPosition, Quaternion.identity);
                    wallsElementList.Add(o);
                }
            }
        }
    }
    public bool checkIfPosEmpty(Vector3 targetPos, List<GameObject> list)
    {
        foreach (GameObject current in list)
        {
            if (current.transform.position == targetPos)
                return false;
        }
        return true;
    }

    private void GenerateWallsInside()
    {
        var currentPosition = new Vector3(0, 0, 0);

        int innerSize = mapSize - 3;

        for (int x = -innerSize / 2; x <= innerSize / 2; x += 2)
        {
            for (int z = -innerSize / 2; z <= innerSize / 2; z += 2)
            {
                currentPosition = new Vector3(x, 1, z);
                GameObject o = Instantiate(wallElementPrefab, currentPosition, Quaternion.identity);
                wallsElementList.Add(o);
            }
        }
    }

    private void GenerateWalls()
    {
        var currentPosition = new Vector3(0, 0, 0);

        for (int x = -mapSize / 2; x <= mapSize / 2; x++)
        {
            if (x == -mapSize / 2 || x == mapSize / 2)
            {
                for (int z = -mapSize / 2; z <= mapSize / 2; z++)
                {
                    currentPosition = new Vector3(x, 1, z);
                    GameObject o = Instantiate(wallElementPrefab, currentPosition, Quaternion.identity);
                    wallsElementList.Add(o);
                }
            }
            else
            {
                currentPosition = new Vector3(x, 1, -mapSize / 2);
                GameObject o = Instantiate(wallElementPrefab, currentPosition, Quaternion.identity);
                wallsElementList.Add(o);

                currentPosition = new Vector3(x, 1, mapSize / 2);
                GameObject o2 = Instantiate(wallElementPrefab, currentPosition, Quaternion.identity);
                wallsElementList.Add(o2);
            }
        }
    }

    private void DestroyGround()
    {
        foreach (var element in groundElementList)
        {
            DestroyImmediate(element);
        }
    }

    private void GenerateGround()
    {
        var currentPosition = new Vector3(0, 0, 0);

        for (int x = -mapSize / 2; x <= mapSize / 2; x++)
        {
            for (int z = -mapSize / 2; z <= mapSize / 2; z++)
            {
                currentPosition = new Vector3(x, 0, z);
                GameObject o = Instantiate(groundElementPrefab, currentPosition, Quaternion.identity);
                groundElementList.Add(o);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    groundElementList = new List<GameObject>(GameObject.FindGameObjectsWithTag(GROUND_TAG));
        //    DestroyGround();
        //    GenerateWalls();
        //}
    }
}
