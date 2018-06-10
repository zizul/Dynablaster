using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {

    public GameObject explosionPrefab;
    public float explosionDelay;
    public float explosionRange;
    public float explosionStepDelay;

    // Use this for initialization
    void Start () {
        Invoke("Explode", explosionDelay);
	}
	
    private void Explode()
    {
        GameObject o = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Debug.Log("explode start at = " + transform.position);
        StartCoroutine(ContinueExplode(Vector3.right));
        StartCoroutine(ContinueExplode(Vector3.left));
        StartCoroutine(ContinueExplode(Vector3.forward));
        StartCoroutine(ContinueExplode(Vector3.back));
        GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject, GetComponent<ParticleSystem>().main.duration + (explosionRange * explosionStepDelay));
    }

    private IEnumerator ContinueExplode(Vector3 direction)
    {
        for (int i = 1; i <= explosionRange; i++)
        {
            Debug.Log("explode at = " + (transform.position + (direction * i)));
            

            RaycastHit result;
            Physics.Raycast(
                this.transform.position + new Vector3(0, .5f, 0),
                direction,
                out result,
                i
            );

            if (result.collider == false)
            {
                GameObject o = Instantiate(explosionPrefab, transform.position + (direction * i), Quaternion.identity);
            }
            else
            {
                break;
            }

            yield return new WaitForSeconds(explosionStepDelay);
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<Collider>().isTrigger = false;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
