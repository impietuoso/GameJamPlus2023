using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (PlayerMovement))]
public class PlayerInput : MonoBehaviour {
    [SerializeField]
    bool canMove;
    PlayerMovement pm;
    public Transform arrow;
    Vector3 direction;
    float impulse;

    private void Awake() {
        pm = GetComponent<PlayerMovement>();
    }

    private void Update() {
        if (canMove) {
            if (Input.GetMouseButton(0)) {
                impulse = Vector3.Distance(Input.mousePosition, transform.position);
                arrow.transform.localScale = new Vector3(arrow.transform.localScale.x, impulse, arrow.transform.localScale.z);
                direction = Vector3.Normalize(transform.position - Input.mousePosition);
                arrow.transform.rotation = Quaternion.Euler(direction);
            }
            if (Input.GetMouseButtonUp(0)) {
                canMove = false;
                pm.Impulse(direction, impulse);
            }
        }
    }

    public void Stoped() {
        canMove = true;
    }
}
