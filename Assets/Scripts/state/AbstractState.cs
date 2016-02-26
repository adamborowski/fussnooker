using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public abstract class AbstractState
	{
		protected StateMachine machine;

		public void Init (StateMachine machine)
		{
			this.machine = machine;
			this.Init ();
		}

		public abstract void Init();

		public abstract void Start ();

		public abstract void Update ();

		public abstract void Finish ();

		public void ChangeState (AbstractState newState)
		{
			machine.SetState (newState);
		}

		public abstract void OnCollisionEnter(Collision col);
	}
}

