using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBlock : MonoBehaviour {
    public float force;
    bool xStop;
    bool zStop;
    public void Jump(Rigidbody rb) {
        if (rb.velocity.x < 0.5f && rb.velocity.x > -0.5f) xStop = true;
        else xStop = false;
        if (rb.velocity.z < 0.5f && rb.velocity.z > -0.5f) zStop = true;
        else zStop = false;
        if (xStop && zStop) {
            int randomX = Random.Range(-10, 10);
            int randomZ = Random.Range(-10, 10);
            rb.AddForce(new Vector3(randomX, force, randomZ) * 10, ForceMode.Impulse);
        } else rb.AddForce(new Vector3(0, force, 0) * 10, ForceMode.Impulse);
        xStop = false;
        zStop = false;
        AudioManager.instance.PlaySFX(PlayerSounds.instance.jump);
    }
}