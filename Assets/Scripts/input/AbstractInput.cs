using UnityEngine;

using System;

namespace AssemblyCSharp
{
	public interface AbstractInput
	{
		Vector2 LeftKnob{ get; }

		Vector2 RightKnob{ get; }

		bool ShootButtonPressed{ get; }

		bool ShootButtonReleased{ get; }

		bool ShootButtonDown{ get; }

		bool BrakeButtonPressed{ get; }

		bool BrakeButtonReleased{ get; }

		bool BrakeButtonDown{ get; }

		// reset button

		bool ResetButtonPressed{ get; }

		// right bumper

		bool RightBumperPressed{ get; }

		bool RightBumperReleased{ get; }

		bool RightBumperDown{ get; }

		// left bumper

		bool LeftBumperPressed{ get; }

		bool LeftBumperReleased{ get; }

		bool LeftBumperDown{ get; }

		// DPad

		bool DPadLeftButtonPressed{ get; }

		bool DPadLeftButtonReleased{ get; }

		bool DPadLeftButtonDown{ get; }

		bool DPadUpButtonPressed{ get; }

		bool DPadUpButtonReleased{ get; }

		bool DPadUpButtonDown{ get; }

		bool DPadRightButtonPressed{ get; }

		bool DPadRightButtonReleased{ get; }

		bool DPadRightButtonDown{ get; }

		bool DPadDownButtonPressed{ get; }

		bool DPadDownButtonReleased{ get; }

		bool DPadDownButtonDown{ get; }

		// triggers
		float LeftTrigger{ get; }

		float RightTrigger{ get; }


		bool LeftStickDown { get; }

		bool LeftStickPressed { get; }

		bool LeftStickReleased { get; }
		bool RightStickDown { get; }

		bool RightStickPressed { get; }

		bool RightStickReleased { get; }

		bool StartPressed {get;}

		bool BackPressed { get;}
	}
}

