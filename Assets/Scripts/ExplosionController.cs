using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {

    [SerializeField] private float m_TimeOut = 0.1f;
    [SerializeField] private bool m_DetachChildren = true;

    // Use this for initialization
    void Awake () {

        var exp = GetComponent<ParticleSystem>();
        exp.Play();
        Destroy(gameObject, exp.main.duration);

        //DestroyObject(gameObject, m_TimeOut);
        //Invoke("DestroyNow", m_TimeOut);
    }

    private void DestroyNow()
    {
        if (m_DetachChildren)
        {
            transform.DetachChildren();
        } 
        Destroy (gameObject);
        Debug.Log("exp destroy");
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //GetComponent<Collider>().isTrigger = false;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Brick"))
        {
            //GetComponent<Collider>().isTrigger = false;
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
