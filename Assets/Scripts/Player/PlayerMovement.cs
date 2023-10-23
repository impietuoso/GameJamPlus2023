using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	Rigidbody rb;
	public float maxSpeed;
	public float stopSpeed;
	public bool moving;
	float curretStopedTime;
	public float stopedTime;
	public GameObject stopIndicator;
	[SerializeField] AudioSource trailSFX;
	[SerializeField] AnimationCurve trailVolumecale;

	private void Awake() {
		rb = GetComponent<Rigidbody>();
	}

	private void Start() {
		stopIndicator.SetActive(true);
	}

	public void Impulse(Vector3 dir, float forceImpulse) {
		moving = true;
		stopIndicator.SetActive(false);
		rb.AddForce(new Vector3(dir.x, 0, dir.z) * (forceImpulse * maxSpeed * 1000));
		AudioManager.instance.PlaySFX(PlayerSounds.instance.speed);
	}

	private void Update() {
		if(moving) {
			if(curretStopedTime >= stopedTime) {
				curretStopedTime = 0;
				stopIndicator.SetActive(true);
				rb.velocity = Vector3.zero;
				moving = false;
			}
			if(rb.velocity.magnitude < stopSpeed) {
				curretStopedTime += Time.deltaTime;
			}
		}

		if(GameManager.instance.gameOver) trailSFX.loop = false;
		if(trailSFX) trailSFX.volume = trailVolumecale.Evaluate(rb.velocity.magnitude)
				* AudioManager.instance.sfxAs.volume;
	}

	private void OnTriggerEnter(Collider col) {
		if(col.gameObject.CompareTag("WinBlock")) {
			col.gameObject.GetComponent<WinBlock>().Win();
			AudioManager.instance.PlaySFX(PlayerSounds.instance.win);
		}
	}

	private void OnCollisionEnter(Collision col) {
		if(col.gameObject.CompareTag("EspulsionBlock")) {
			col.gameObject.GetComponent<EspulsionBlock>().Espulsion(rb);
		}
		if(col.gameObject.CompareTag("JumpBlock")) {
			col.gameObject.GetComponent<JumpBlock>().Jump(rb);
		}
		if(col.gameObject.CompareTag("SpeedBlock")) {
			AudioManager.instance.PlaySFX(PlayerSounds.instance.speed);
		}
	}

	private void OnCollisionStay(Collision col) {
		if(col.gameObject.CompareTag("SpeedBlock")) {
			col.gameObject.GetComponent<SpeedBlock>().Speed(rb);
		}
	}
}
