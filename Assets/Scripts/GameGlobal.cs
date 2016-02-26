using System;

namespace AssemblyCSharp
{
	public class GameGlobal
	{

		public static AbstractInput input = new XboxInput(XboxCtrlrInput.XboxController.All);
	}
}

