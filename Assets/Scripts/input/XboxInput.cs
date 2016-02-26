using System;
using XboxCtrlrInput;
using UnityEngine;


namespace AssemblyCSharp
{
	public class 	XboxInput: AbstractInput
	{
		XboxButton SHOOT_BUTTON = XboxButton.A;
		XboxButton BRAKE_BUTTON = XboxButton.X;
		XboxButton RESET_BUTTON = XboxButton.B;

		private XboxController controller;

		public XboxInput (XboxController controller)
		{
			this.controller = controller;
		}

		public Vector2 LeftKnob {
			get {
				return new Vector2 (XCI.GetAxis (XboxAxis.LeftStickX, controller), XCI.GetAxis (XboxAxis.LeftStickY, controller));
			}
		}

		public Vector2 RightKnob {
			get {
				return new Vector2 (XCI.GetAxis (XboxAxis.RightStickX, controller), XCI.GetAxis (XboxAxis.RightStickY, controller));
			}
		}

		public bool ShootButtonPressed {
			get {
				return XCI.GetButtonDown (SHOOT_BUTTON, controller);
			}
		}

		public bool ShootButtonReleased {
			get {
				return XCI.GetButtonUp (SHOOT_BUTTON, controller);
			}
		}

		public bool ShootButtonDown {
			get {
				return XCI.GetButton (SHOOT_BUTTON, controller);
			}
		}

		public bool BrakeButtonPressed {
			get {
				return XCI.GetButtonDown (BRAKE_BUTTON, controller);
			}
		}

		public bool BrakeButtonReleased {
			get {
				return XCI.GetButtonUp (BRAKE_BUTTON, controller);
			}
		}

		public bool BrakeButtonDown {
			get {
				return XCI.GetButton (BRAKE_BUTTON, controller);
			}
		}

		public bool ResetButtonPressed {
			get {
				return XCI.GetButtonDown (RESET_BUTTON, controller);
			}
		}

		public bool RightBumperPressed {
			get {
				return XCI.GetButtonDown (XboxButton.RightBumper, controller);
			}
		}

		public bool RightBumperReleased {
			get {
				return XCI.GetButtonUp (XboxButton.RightBumper, controller);
			}
		}

		public bool RightBumperDown {
			get {
				return XCI.GetButton (XboxButton.RightBumper, controller);
			}
		}

		public bool LeftBumperPressed {
			get {
				return XCI.GetButtonDown (XboxButton.LeftBumper, controller);
			}
		}

		public bool LeftBumperReleased {
			get {
				return XCI.GetButtonUp (XboxButton.LeftBumper, controller);
			}
		}

		public bool LeftBumperDown {
			get {
				return XCI.GetButton (XboxButton.LeftBumper, controller);
			}
		}

		public bool DPadLeftButtonPressed {
			get {
				return XCI.GetButtonDown (XboxButton.DPadLeft, controller);
			}
		}

		public bool DPadLeftButtonReleased {
			get {
				return XCI.GetButtonUp (XboxButton.DPadLeft, controller);
			}
		}

		public bool DPadLeftButtonDown {
			get {
				return XCI.GetButton (XboxButton.DPadLeft, controller);
			}
		}

		public bool DPadUpButtonPressed {
			get {
				return XCI.GetButtonDown (XboxButton.DPadUp, controller);
			}
		}

		public bool DPadUpButtonReleased {
			get {
				return XCI.GetButtonUp (XboxButton.DPadUp, controller);
			}
		}

		public bool DPadUpButtonDown {
			get {
				return XCI.GetButton (XboxButton.DPadUp, controller);
			}
		}

		public bool DPadRightButtonPressed {
			get {
				return XCI.GetButtonDown (XboxButton.DPadRight, controller);
			}
		}

		public bool DPadRightButtonReleased {
			get {
				return XCI.GetButtonUp (XboxButton.DPadRight, controller);
			}
		}

		public bool DPadRightButtonDown {
			get {
				return XCI.GetButton (XboxButton.DPadRight, controller);
			}
		}

		public bool DPadDownButtonPressed {
			get {
				return XCI.GetButtonDown (XboxButton.DPadDown, controller);
			}
		}

		public bool DPadDownButtonReleased {
			get {
				return XCI.GetButtonUp (XboxButton.DPadDown, controller);
			}
		}

		public bool DPadDownButtonDown {
			get {
				return XCI.GetButton (XboxButton.DPadDown, controller);
			}
		}

		// triggers

		public float LeftTrigger {
			get {
				return XCI.GetAxis (XboxAxis.LeftTrigger, controller);
			}
		}

		public float RightTrigger {
			get {
				return XCI.GetAxis (XboxAxis.RightTrigger, controller);
			}
		}

		public bool LeftStickDown {

			get {
				return XCI.GetButton (XboxButton.LeftStick, controller);
			}
		}

		public bool LeftStickPressed {

			get {
				return XCI.GetButtonDown (XboxButton.LeftStick, controller);
			}
		}

		public bool LeftStickReleased {

			get {
				return XCI.GetButtonUp (XboxButton.LeftStick, controller);
			}
		}

		public bool RightStickDown {

			get {
				return XCI.GetButton (XboxButton.RightStick, controller);
			}
		}

		public bool RightStickPressed {

			get {
				return XCI.GetButtonDown (XboxButton.RightStick, controller);
			}
		}

		public bool RightStickReleased {

			get {
				return XCI.GetButtonUp (XboxButton.RightStick, controller);
			}
		}

		public bool StartPressed{
			get{
				return XCI.GetButtonDown (XboxButton.Start, controller);
			}
		}

		public bool BackPressed{
			get{
				return XCI.GetButtonDown (XboxButton.Back, controller);
			}
		}
	}
}

