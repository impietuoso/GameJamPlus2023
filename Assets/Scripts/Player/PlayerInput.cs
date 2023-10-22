using Drafts;
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
    Camera cmain;
    public Vector3 arrowDirection;
    Vector3 biladaPosition;
    public float inputDistance;

    private void Awake() {
        pm = GetComponent<PlayerMovement>();
    }

    private void Start() {
        cmain = Camera.main;
    }

    private void Update() {
        if (pm.moving) return;

        if(Time.timeScale == 0) return;

        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cmain.ScreenPointToRay(Input.mousePosition);
            VectorUtil.RaycastPlane(ray, transform.up, transform.position, out biladaPosition);
            impulse = Vector3.Distance(biladaPosition, transform.position);
            if (impulse <= inputDistance) {
                canMove = true;
                arrow.gameObject.SetActive(true);
            }            
        }

        if (canMove) {
            if (Input.GetMouseButton(0) && arrow.gameObject.activeInHierarchy) {
                Ray ray = cmain.ScreenPointToRay(Input.mousePosition);
                VectorUtil.RaycastPlane(ray, transform.up, transform.position, out biladaPosition);
                impulse = Vector3.Distance(biladaPosition, transform.position);
                arrow.transform.localScale = new Vector3(arrow.transform.localScale.x, arrow.transform.localScale.y, impulse);
                direction = Vector3.Normalize(transform.position - biladaPosition);
                arrow.LookAt(biladaPosition, arrowDirection);
            }
            if (Input.GetMouseButtonUp(0) && arrow.gameObject.activeInHierarchy) {
                canMove = false;
                arrow.gameObject.SetActive(false);
                pm.Impulse(direction, impulse);
            }
        }
    }
}
