using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public GunController gunControllerScriptEnemy;
    //public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.rigidbody.gameObject.transform.tag == "bullet")
    //    {
    //        Debug.Log(collision.collider.gameObject.transform.name);
    //        Destroy(this.gameObject);
    //    }

    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "bullet")
        {
            Debug.Log(other.gameObject.transform.name);
            Destroy(this.gameObject);
        }
    }
}
