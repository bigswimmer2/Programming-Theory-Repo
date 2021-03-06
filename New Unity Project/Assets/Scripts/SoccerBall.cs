using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerBall : Ball
{
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Kick(other);
            Debug.Log(other.gameObject.tag);
        }
        else
        {
            Debug.Log("Not touching");
        }
        
    }

    public virtual void Kick(Collision other)
    {
        Vector3 awayFromPlayer = transform.position - other.gameObject.transform.position;
        rb.AddForce(awayFromPlayer * kickForce, ForceMode.Impulse);
    }
}
