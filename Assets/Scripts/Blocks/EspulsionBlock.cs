using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspulsionBlock : MonoBehaviour {
    public float force;

    public void Espulsion(Rigidbody rb) {
        Vector3 forceDir = rb.position - transform.parent.position;
        rb.AddForce(forceDir * force * 10, ForceMode.Impulse);
        AudioManager.instance.PlaySFX(PlayerSounds.instance.hit);
    }
}
