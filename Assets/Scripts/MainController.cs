using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

    private Vector3 lastPlayerPos;
    public GameObject playerPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
    public void SetPlayerLastPosition(Vector3 pos)
    {
        lastPlayerPos = pos;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(
            playerPrefab,
            new Vector3(
                Mathf.RoundToInt(lastPlayerPos.x),
                Mathf.RoundToInt(lastPlayerPos.y),
                Mathf.RoundToInt(lastPlayerPos.z)
            ),
            Quaternion.identity);
        }
    }
}
