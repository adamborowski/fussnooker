using UnityEngine;
using System.Collections;
using XboxCtrlrInput;
using AssemblyCSharp;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
	public GameObject arrow;
	public GameObject indicator;
	public Camera camera;

	public AbstractInput input;
	public int playerIndex;

	public Transform myBalls;

	//	public Rigidbody rb;
	//	Vector3 direction;
	Vector3 startPos;


	//	TimeDurationLock shootLock;
	StateMachine stateMachine;

	Material ballMaterial;

	Color initialColor;

	// Use this for initialization
	void Start ()
	{
		input = new XboxInput ((XboxController)playerIndex);
		ballMaterial = GetComponent<Renderer> ().material;
		initialColor = ballMaterial.color;

		arrow.SetActive (false);
		//
		stateMachine = new StateMachine (this);
		stateMachine.SetState (new IdleState ());

//		direction = new Vector3 (0, 0, 0);
//		rb = GetComponent<Rigidbody> ();
		startPos = transform.position;

//		shootLock = new TimeDurationLock (1);


	}

	public void showArrowIndicator (Vector3 aimDirection)
	{





		if (aimDirection.magnitude > 0.1) {
			//aiming occured
			arrow.SetActive (true);
			arrow.transform.LookAt (arrow.transform.position - aimDirection, new Vector3 (0, 1, 0));
			//arrow.transform.localScale = new Vector3 (1, 1, aimDirection.magnitude);
			//SetBallAlpha (0.9f);
		} else {
			arrow.SetActive (false);
			//SetBallAlpha (1);
		}
	}

	public void hideArrowIndicator ()
	{
		arrow.SetActive (false);
	}


	public void setBallColor ()
	{
		setBallColor (initialColor);
	}

	public void setBallColor (Color color)
	{
		ballMaterial.color = color;
	}

	
	// Update is called once per frame
	void Update ()
	{
		stateMachine.Update ();
		if (input.ResetButtonPressed) {
			GetComponent<Rigidbody> ().position = startPos;
			GetComponent<Rigidbody> ().velocity *= 0f;

		}

		if (indicator != null) {
			Vector3 pos = new Vector3 (transform.position.x, indicator.transform.position.y, transform.position.z);
			indicator.transform.position = pos;
		}

	

//		var fx = -XCI.GetAxis (XboxAxis.LeftStickX, XboxController.All); 
//		var fz = -XCI.GetAxis (XboxAxis.LeftStickY, XboxController.All); 
//
//		direction.x = fx;
//		direction.z = fz;
//
//		if (shootLock.isNotLocked ()) {
//			if (XCI.GetButtonUp (SHOOT_BUTTON)) {
//				shootLock.setLock ();
//				rb.AddForce (60 * direction, ForceMode.Force);
//			}
//			if (!XCI.GetButton (SHOOT_BUTTON)) {
//				rb.AddForce (direction);
//			}
//		}
//
//	
//
//
//
//
//
//		if (XCI.GetButton (XboxButton.B)) {
//			rb.transform.position = startPos;
//			rb.velocity = new Vector3 (0, 0, 0);
//		}
		if (input.StartPressed) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}

	public enum COLLISION_TYPE
	{
		OWN_OBJECT,
		OTHER_OBJECT,
		NONE

	}

	public COLLISION_TYPE GetCollisionType (Collision col)
	{
		if (col.transform.parent.name.Contains ("Kule Gracza")) {
			
			var speed1 = GetComponent<Rigidbody> ().velocity.magnitude;
			var speed2 = col.transform.GetComponent<Rigidbody> ().velocity.magnitude;
			if (speed1 < speed2 || true) {
				if (col.transform.parent == myBalls) {
					// my balls
					return COLLISION_TYPE.OWN_OBJECT;
				} else {
					//not my balls
					return COLLISION_TYPE.OTHER_OBJECT;
				}
			}

		}
		if (col.transform.name == "Czarna Kula") {
			return COLLISION_TYPE.OWN_OBJECT;
		}
		if (col.transform.name.Contains ("Bila Gracza")) {
			return COLLISION_TYPE.OTHER_OBJECT;
		}
		return COLLISION_TYPE.NONE;
	}



	void OnCollisionEnter (Collision col)
	{
		stateMachine.OnCollisionEnter (col);



	}
}
