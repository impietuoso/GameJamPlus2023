using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMove : MonoBehaviour {
    public float turnSpeed;
    public bool canRotate;
    public float maxSpeed;
    public Vector2 pivot;
    public Vector2 movingMouse;
    public float dif;

    private void Update() {
        if (!canRotate) return;

        if (Input.GetMouseButtonDown(1)) pivot = Input.mousePosition;
        if (Input.GetMouseButton(1)) movingMouse = Input.mousePosition;
        if (Input.GetMouseButtonUp(1)) {
            movingMouse = Vector2.zero;
            pivot = Vector2.zero;
            dif = 0;
        }

        dif = movingMouse.x - pivot.x;
        dif = Mathf.Clamp(dif, -maxSpeed, maxSpeed);

        if (dif > 2 || dif < -2) transform.Rotate(0, dif * turnSpeed * Time.deltaTime, 0);
    }
}