using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBlock : MonoBehaviour {
    public float force;

    public void Speed(Rigidbody rb) {
        Vector3 forceDir = Vector3.zero;
        switch (transform.parent.eulerAngles.y) {
            case 0:
                forceDir = new Vector3(0, 0, 1);
                break;
            case 90:
                forceDir = new Vector3(1, 0, 0);
                break;
            case 180:
                forceDir = new Vector3(0, 0, -1);
                break;
            case 270:
                forceDir = new Vector3(-1, 0, 0);
                break;
        }
        rb.AddForce(forceDir * force, ForceMode.VelocityChange);
    }
}
