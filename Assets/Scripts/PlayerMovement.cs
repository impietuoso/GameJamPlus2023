using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    PlayerInput pi;
    public float maxSpeed;
    public float stopSpeed;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        pi = GetComponent<PlayerInput>();
    }

    public void Impulse(Vector3 dir, float forceImpulse) {
        rb.AddForce(new Vector3(dir.x, 0, dir.z) * (forceImpulse * maxSpeed));
    }

    private void Update() {
        if (rb.velocity.magnitude < stopSpeed) {
            rb.velocity = Vector3.zero;
            pi.Stoped();
        }
    }
}
