using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class LoadingState:AbstractState	 // RELEASE A: when user released button it is loading, press again to shoot (after some time, ie 0.7s) automatically go to shooting
	{
		Vector3 aimDirection;
		StatefulAxis rightTriggerAxis;
		StatefulAxis leftTriggerAxis;
		BallController ballController;

		public LoadingState (Vector3 aimDirection)
		{
			this.aimDirection = aimDirection;
		}


		override public void Init ()
		{
			rightTriggerAxis = new StatefulAxis ();
			leftTriggerAxis = new StatefulAxis ();
			ballController = machine.component.GetComponent<BallController> ();
		}

		override public void Update ()
		{
			// update trigger stateful axis
			rightTriggerAxis.update (ballController.input.RightTrigger);
			leftTriggerAxis.update (ballController.input.LeftTrigger);

			ballController.showArrowIndicator (aimDirection);


			var powerValue = rightTriggerAxis.getMaxValue ();
			powerValue = Mathf.Sqrt(powerValue);
			Color fireColor = Color.Lerp (new Color (1f, 1f, 1f), Color.red, powerValue);

			ballController.setBallColor(fireColor);
			arrowMat.SetColor ("_EmissionColor", fireColor);

			if (leftTriggerAxis.pressEnded ()) {
				ChangeState (new PenaltyState (PenaltyState.PENALTY_TYPE.SMALL,null));
			}
			else if (rightTriggerAxis.pressCancelled ()||rightTriggerAxis.pressEnded()) {
				ChangeState (new FireState (aimDirection, 1f - powerValue));
			}



		}

		Color lastColor;
		Material arrowMat;

		override public void Start ()
		{
			ballController.arrow.SetActive (true);
//			Debug.Log ("Loading State" + " : " + ballController.gameObject.transform);

			arrowMat = ballController.arrow.transform.GetChild (0).GetComponent<Renderer> ().material;

			lastColor = arrowMat.GetColor ("_EmissionColor");

			arrowMat.SetColor ("_EmissionColor", new Color (0.6f, 0, 0));
			//ballController.setBallColor (new Color (1f, 0.6f, 0.2f));
		}

		override public void Finish ()
		{
			arrowMat.SetColor ("_EmissionColor", lastColor);
			//ballController.setBallColor ();
			ballController.hideArrowIndicator ();
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

