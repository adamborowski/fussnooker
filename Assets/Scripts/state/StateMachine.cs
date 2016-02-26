using System;
using AssemblyCSharp;
using UnityEngine;

namespace AssemblyCSharp
{
	public class StateMachine
	{
		public Component component{ get; set; }

		private AbstractState currentState;


		public StateMachine (Component component)
		{
			this.component = component;
		}

		public void SetState (AbstractState state)
		{
			if (currentState != null) {
				currentState.Finish ();
			}
			currentState = state;
			currentState.Init (this);
			currentState.Start ();
			//propably we need run update in creating frame
			currentState.Update();
		}

		public AbstractState GetState ()
		{
			return currentState;
		}

		public void Update ()
		{
			if (currentState != null) {
				currentState.Update ();
			}
		}

		public void OnCollisionEnter (Collision col)
		{
			if (currentState != null) {
				currentState.OnCollisionEnter (col);
			}
		}
	}
}

