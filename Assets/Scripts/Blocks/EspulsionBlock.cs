using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspulsionBlock : MonoBehaviour {
    public float force;

    public void Espulsion(Rigidbody rb) {
        Vector3 forceDir = transform.parent.position - rb.position;
        rb.AddForce(forceDir * force * 100, ForceMode.Impulse);
    }
}
