using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class OrbitCameraController : MonoBehaviour
{

	public GameObject targetObject;
	private Transform target;
	private float distance = 5.0f;
	private float xSpeed = 38.0f;
	private float ySpeed = 38.0f;

	private float yMinLimit = 10f;
	private float yMaxLimit = 45f;

	private float distanceMin = .5f;
	private float distanceMax = 2f;


	public float x = 150.0f;
	float y = 42.0f;

	BallController bc;

	bool autoMove=false;

	// Use this for initialization
	void Start ()
	{
		target = targetObject.transform;

		bc = gameObject.transform.parent.gameObject.GetComponent<BallController> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (bc.input.ShootButtonPressed) {
			//autoMove = !autoMove;
		}
		x -= (bc.input.RightBumperDown ? 1 : -1) * xSpeed * 0.04f;
		x += (bc.input.LeftBumperDown ? 1 : -1) * xSpeed * 0.04f;

		x -= (bc.input.DPadRightButtonDown ? 1 : 0) * xSpeed * 0.04f;
		x += (bc.input.DPadLeftButtonDown ? 1 : 0) * xSpeed * 0.04f;
		y -= (bc.input.DPadDownButtonDown ? 1 : 0) * ySpeed * 0.04f;
		y += (bc.input.DPadUpButtonDown ? 1 : 0) * ySpeed * 0.04f;


		y = ClampAngle (y, yMinLimit, yMaxLimit);

		var rotation = Quaternion.Euler (y, x, 0);


		distance = Mathf.Clamp (y * 0.05f, distanceMin, distanceMax);


		var position = rotation * new Vector3 (0.0f, 0.0f, -distance) + target.position;

		transform.rotation = rotation;
		transform.position = position;

		if (bc.input.BackPressed) {
			x = bc.arrow.transform.rotation.eulerAngles.y+180;

		}
		if (autoMove) {
			bc.camera.GetComponent<OrbitCameraController> ().reportLastMoveDirection (bc.GetComponent<Rigidbody>().velocity);
		}
	}

	public static float ClampAngle (float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp (angle, min, max);
	}

	public void reportLastMoveDirection (Vector3 direction)
	{
		if (direction.magnitude > 0) {


			
			Quaternion q = new Quaternion ();
			q.SetLookRotation (direction);

			var targetX = new Vector3(q.eulerAngles.y,0,0);

			var sourceX = new Vector3(x, 0,0);

			var stepX = Vector3.Slerp (sourceX, targetX,0.7f );

			Debug.Log (sourceX.ToString() + targetX.ToString() + stepX.ToString());
			x = stepX.x;

			//x = q.eulerAngles.y;


		}
	}
}
