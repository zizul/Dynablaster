using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {

    [SerializeField] private float m_TimeOut = 0.10f;
    [SerializeField] private bool m_DetachChildren = false;

    // Use this for initialization
    void Awake () {
        DestroyObject(gameObject, m_TimeOut);
        //Invoke("DestroyNow", m_TimeOut);
    }

    private void DestroyNow()
    {
        if (m_DetachChildren)
        {
            transform.DetachChildren();
        }
        Debug.Log("destroy = ");
        DestroyObject(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
