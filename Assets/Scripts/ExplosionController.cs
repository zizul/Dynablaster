using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {

    [SerializeField] private float m_TimeOut = 1.0f;
    [SerializeField] private bool m_DetachChildren = false;

    // Use this for initialization
    void Awake () {
        Invoke("DestroyNow", m_TimeOut);
    }

    private void DestroyNow()
    {
        if (m_DetachChildren)
        {
            transform.DetachChildren();
        }
        DestroyObject(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
