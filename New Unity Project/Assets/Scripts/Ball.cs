using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float kickForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Kick(other);
        }
    }

    private void Kick(Collision other)
    {
        Vector3 awayFromPlayer = transform.position - other.gameObject.transform.position;
        rb.AddForce(awayFromPlayer * kickForce, ForceMode.Impulse);
    }
}
