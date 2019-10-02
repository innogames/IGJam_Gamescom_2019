using System.Collections.Generic;

public class InputSignal
{
	public class ModeSwitch
	{
	}

	public class LeftButton
	{
	}

	public class RightButton
	{
		
	}
	
	public class UnbufferedLeftButton
	{
	}

	public class UnbufferedRightButton
	{
		
	}

	public class AnyButton
	{
	}
}

public class SystemSignal
{
	public class Ship
	{
		public class SlotSelected
		{
			public readonly int SlotId;

			public SlotSelected(int slotId)
			{
				SlotId = slotId;
			}
		}
		
		public class PartAttached
		{
			public readonly ShipPart NewPart;
			public readonly int SlotId;

			public PartAttached(ShipPart newPart, int slotId)
			{
				NewPart = newPart;
				SlotId = slotId;
			}
		}

		public class ControlUpdated
		{
			public readonly int SlotId;
			public readonly string NewControlName;

			public ControlUpdated(int slotId, string newControlName)
			{
				SlotId = slotId;
				NewControlName = newControlName;
			}
		}

		public class ConfigureControls
		{
		}

		public class ConfigureSlots
		{
		}
	}

	public class GameMode
	{
		public class FlyMode
		{
			public class Activate
			{
			}

			public class Deactivate
			{
			}

		}
		
		public class ConfigureShip
		{
			public class Activate
			{
			}

			public class Deactivate
			{
			}

		}
		
		public class ConfigureControls
		{
			public class Activate
			{
			}

			public class Deactivate
			{
			}

		}
		
		public class ConfigureInput
		{
			public class ConfigureMode
			{
			}

			public class ConfigureLeft
			{
			}
			
			public class ConfigureRight
			{
			}
			
			public class FullConfigured
			{
			}
		}
		
		
	}


}

