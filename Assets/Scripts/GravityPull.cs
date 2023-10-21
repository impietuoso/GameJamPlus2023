using UnityEngine;

public class GravityPull : MonoBehaviour {

	[SerializeField] float pullSpeed = .5f;
	[SerializeField] AnimationCurve distanceMultiply = AnimationCurve.Linear(0, 0, 1, 1);
	[SerializeField] new SphereCollider collider;

	private void OnTriggerStay(Collider o) {
		var other = o.attachedRigidbody;
		if(!other.CompareTag("Player")) return;
		var curr = other.position;
		var mult = 1 - Vector3.Distance(curr, transform.position) / collider.radius;
		mult = distanceMultiply.Evaluate(mult);
		curr = Vector3.MoveTowards(curr, transform.position, pullSpeed * mult * Time.deltaTime);
		other.position = curr;
	}

	private void OnDrawGizmosSelected() {
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, collider.radius);
	}
}
