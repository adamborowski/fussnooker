using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class IdleState:AbstractState //user normally controls the ball with xy axes
	{
		private Vector3 direction;
		private Rigidbody rb;
		private Camera camera;
		private float brakeFriction = 0.96f;
		private BallController ballController;

		GameObject arrow;

		Material material;

		override public void Init ()
		{
			ballController = machine.component.GetComponent<BallController> ();
			direction = new Vector3 (0, 0, 0);
			rb = machine.component.GetComponent<Rigidbody> ();
			camera = (machine.component.GetComponent<BallController> ()).camera;

			arrow = (machine.component.GetComponent<BallController> ()).arrow;
			material = machine.component.GetComponent<Renderer> ().material;
		}

		override public void Update ()
		{
			handleMoving ();
			handleAiming ();
		}

		void handleMoving ()
		{
			Vector2 direction2 = ballController.input.LeftKnob;
			direction.x = direction2.x;
			direction.z = direction2.y;
			direction = camera.transform.rotation * direction;
			direction.y = 0;
			rb.AddForce (direction * 1.4f, ForceMode.Acceleration);
			if (ballController.input.BrakeButtonDown) {
				rb.velocity *= brakeFriction;
				rb.angularVelocity *= brakeFriction;
				if (rb.velocity.magnitude < 0.05) {
					rb.velocity *= 0f;
					rb.angularVelocity *= 0f;
				}
			}
		}

		private void handleAiming ()
		{

			Vector2 direction2 = ballController.input.RightKnob;

			var pos = ballController.transform.position;
			arrow.transform.position = pos;


			Vector3 aimDirection = new Vector3 (direction2.x, 0, direction2.y);
			aimDirection = camera.transform.rotation * aimDirection;
			aimDirection.y = 0;
			ballController.showArrowIndicator (aimDirection);

			if (ballController.input.RightTrigger > 0) {
				ChangeState (new LoadingState (aimDirection));
			}



		}

		override public void Start ()
		{
//			Debug.Log ("Idle State" + " : " + ballController.gameObject.transform);
			arrow.SetActive (true);
//			Color c = material.color;
//			c.a = 0.5f;
//			material.color = c;
		}

		override public void Finish ()
		{
			arrow.SetActive (false);
//			Color c = material.color;
//			c.a = 1f;
//			material.color = c;
		}

		private void SetBallAlpha (float a)
		{
			Color c = material.color;
			c.a = a;
			material.color = c;		
		}

		public override void OnCollisionEnter (Collision col)
		{
			switch (ballController.GetCollisionType (col)) {
			case BallController.COLLISION_TYPE.OWN_OBJECT:
				ChangeState (new PenaltyState (PenaltyState.PENALTY_TYPE.SMALL, col));
				break;
			case BallController.COLLISION_TYPE.OTHER_OBJECT:
				ChangeState (new PenaltyState (PenaltyState.PENALTY_TYPE.BIG, col));
				break;
			}
		}

	}
}

