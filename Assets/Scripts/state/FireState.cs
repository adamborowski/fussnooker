using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class FireState:AbstractState	// when user has no controll over the ball and 
	{
		float loadingTime;
		Vector3 aimDirection;
		TimeDurationLock locker;

		BallController ballController;

		Rigidbody rb;

		public FireState (Vector3 aimDirection, float loadingTime)
		{
			this.aimDirection = aimDirection;
			this.loadingTime = loadingTime;

		}

		override public void Init ()
		{
			locker = new TimeDurationLock (1, TimeDurationLock.LockMode.RESET);
			ballController = machine.component.GetComponent<BallController> ();
			rb = ballController.GetComponent<Rigidbody> ();
		}

		override public void Update ()
		{
			if (locker.isNotLocked ()) {
				ChangeState (new IdleState ());
			}
		}

		override public void Start ()
		{
//			Debug.Log ("Fire State " + aimDirection + " : " + loadingTime + ballController.gameObject.transform);
			locker.setLock ();
			ballController.hideArrowIndicator ();

			loadingTime += 1;// (1;inf)
			float power = 0.2f / Mathf.Log (loadingTime);
			power = Mathf.Clamp (power, 0.2f, 3f);

			rb.AddForce (aimDirection * power, ForceMode.Impulse);
			//ballController.setBallColor (Color.red);
		}

		override public void Finish ()
		{
			ballController.setBallColor ();
		}


		private BallController.COLLISION_TYPE lastCollision = BallController.COLLISION_TYPE.NONE;

		public override void OnCollisionEnter (Collision col)
		{
			var newCollisionType = ballController.GetCollisionType (col);
			switch (lastCollision) {
			case BallController.COLLISION_TYPE.OWN_OBJECT:
				// skoro uderzylismy w nasza kule, nie robimy penaty
				break;
			case BallController.COLLISION_TYPE.OTHER_OBJECT:
				//
				break;
			case BallController.COLLISION_TYPE.NONE:
				// nie było jeszcze kolizji
				switch (newCollisionType) {
				case BallController.COLLISION_TYPE.OWN_OBJECT:
					// wszystko jest ok, kolizja w naszą kulę jest wskazana
					break;
				case BallController.COLLISION_TYPE.OTHER_OBJECT:
					ChangeState (new PenaltyState (PenaltyState.PENALTY_TYPE.BIG, col));
					break;
				}
				break;
			}



			lastCollision = newCollisionType;
		}
	}
}

