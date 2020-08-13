using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 10000;
    private Vector3 dir;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        float randx = Random.Range(-1.0f, 1.0f);
        float randy = Random.Range(-1.0f, 1.0f);
        dir = new Vector3(randx, randy, 0);
        rb.AddForce(dir.normalized*force);
    }

    // Update is called once per frame
    void Update()
    {
       Quaternion desiredRotation = Quaternion.LookRotation(rb.velocity);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, 0.02f);
    }
    private void OnCollisionEnter(Collision col)
    {
        
        //rb.AddForce(Vector3.Reflect(dir, col.contacts[0].normal).normalized * force);
        
        if (col.gameObject.tag == "Player")
        {
            GM.instance.TakeDamage();
            Destroy(gameObject);
        }
    }
}
