using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    PlayerInput pi;
    public float maxSpeed;
    public float stopSpeed;
    public bool moving;
    float curretStopedTime;
    public float stopedTime;
    public GameObject stopIndicator;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        pi = GetComponent<PlayerInput>();
    }

    private void Start() {
        stopIndicator.SetActive(true);
    }

    public void Impulse(Vector3 dir, float forceImpulse) {
        moving = true;
        stopIndicator.SetActive(false);
        rb.AddForce(new Vector3(dir.x, 0, dir.z) * (forceImpulse * maxSpeed * 1000));
    }

    private void Update() {
        if (moving) {
            if(curretStopedTime >= stopedTime) {
                curretStopedTime = 0;
                stopIndicator.SetActive(true);
                rb.velocity = Vector3.zero;
                moving = false;
            }
            if (rb.velocity.magnitude < stopSpeed) {
                curretStopedTime += Time.deltaTime;
            }
        }
    }

    private void OnCollisionStay(Collision col) {
        if(col.gameObject.tag == "SpeedBlock") {
            float forcePush = col.gameObject.GetComponent<SpeedBlock>().force;
            Vector3 forceDir = Vector3.zero;
            switch (col.transform.rotation.y) {
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
            rb.AddForce(forceDir * forcePush, ForceMode.VelocityChange);
        }
    }
}
