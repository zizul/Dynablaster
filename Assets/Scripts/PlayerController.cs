using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject bombPrefab;

    private Rigidbody rbody;

    public float velocidad = 5f;

    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rbody.velocity = new Vector3(rbody.velocity.x, rbody.velocity.y, this.velocidad);
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rbody.velocity = new Vector3(this.velocidad, rbody.velocity.y, rbody.velocity.z);
            this.transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rbody.velocity = new Vector3(rbody.velocity.x, rbody.velocity.y, -this.velocidad);
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rbody.velocity = new Vector3(-this.velocidad, rbody.velocity.y, rbody.velocity.z);
            this.transform.rotation = Quaternion.Euler(0, 270, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlantBomb();
        }
    }

    private void PlantBomb()
    {
        GameObject o = Instantiate(
            bombPrefab,
            new Vector3(
                Mathf.RoundToInt(this.transform.position.x),
                Mathf.RoundToInt(this.transform.position.y),
                Mathf.RoundToInt(this.transform.position.z)
            ),
            Quaternion.identity);
    }
}
