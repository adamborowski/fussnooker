using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class PenaltyState:AbstractState
	{
		PENALTY_TYPE type;

		Collision col;

		public enum PENALTY_TYPE
		{
			BIG,
			SMALL

		}

		public PenaltyState (PenaltyState.PENALTY_TYPE type, Collision col)
		{
			this.type = type;
			this.col = col;
		}




		TimeDurationLock locker;


		BallController ballController;

		override public void Init ()
		{
			locker = new TimeDurationLock (type == PENALTY_TYPE.BIG ? 2.6f : 1f, TimeDurationLock.LockMode.MAXIMUM);
			ballController = machine.component.GetComponent<BallController> ();
			if (col != null) {
				ballController.GetComponent<Rigidbody> ().AddExplosionForce (20, col.transform.position, 20);
			}
		}

		override public void Update ()
		{
			if (locker.isNotLocked ()) {
				ChangeState (new IdleState ());
			}
		}

		override public void Start ()
		{
			locker.setLock ();
			ballController.setBallColor (new Color (0.5f, 0.5f, 0.5f));

//			Debug.Log ("Penalty State" + " : " + ballController.gameObject.transform);
			//TODO indicate in UI
		}

		override public void Finish ()
		{
			//TODO indicate in UI
			ballController.setBallColor ();

		}

		public override void OnCollisionEnter (Collision col)
		{


		}
	}
}

