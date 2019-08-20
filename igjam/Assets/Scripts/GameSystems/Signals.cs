using System.Collections.Generic;
using UnityEngine.Experimental.UIElements;

public interface IInputSignal
{
	float Value { get; }
}

public class InputSignal 
{
	public class None : IInputSignal
	{
		public float Value { get; }
	}
	
	public class XAxis : IInputSignal
	{
		public float Value { get; }
		public XAxis(float value)
		{
			Value = value;
		}

	}
	
	public class YAxis : IInputSignal
	{
		public float Value { get; }
		public YAxis(float value)
		{
			Value = value;
		}
	}
	
	public class Axis3 : IInputSignal
	{
		public float Value { get; }
		public Axis3(float value)
		{
			Value = value;
		}
	}
	
	public class Axis4 : IInputSignal
	{
		public float Value { get; }
		public Axis4(float value)
		{
			Value = value;
		}
	}
	
	public class Axis5 : IInputSignal
	{
		public float Value { get; }
		public Axis5(float value)
		{
			Value = value;
		}
	}
	
	public class Axis6 : IInputSignal
	{
		public float Value { get; }
		public Axis6(float value)
		{
			Value = value;
		}
	}
	
	public class Axis7 : IInputSignal
	{
		public float Value { get; }
		public Axis7(float value)
		{
			Value = value;
		}
	}
	
	public class Axis8 : IInputSignal
	{
		public float Value { get; }
		public Axis8(float value)
		{
			Value = value;
		}
	}

	public class Button0 : IInputSignal
	{
		public float Value { get; }
	}
	
	public class Button1 : IInputSignal
	{
		public float Value { get; }
	}
}


public interface IGameSignal
{
}

public class GameSignal
{
	public class None : IGameSignal
	{
	}
	public class Rebind: IGameSignal
	{
	}

	public class Attack: IGameSignal
	{
	}
	
	public class Jump: IGameSignal
	{
	}
	
	public class MoveHorizontal: IGameSignal
	{
		public readonly float Value;
		public MoveHorizontal(float value)
		{
			Value = value;
		}
	}
	
	public class MoveVertical: IGameSignal
	{
		public readonly float Value;
		public MoveVertical(float value)
		{
			Value = value;
		}
	}

	public class ActivateCoreInputMap: IGameSignal
	{
	}
}

public class SystemSignal
{
	public class Rebind
	{
		public class WaitForCurrentKey
		{
		}

		public class WaitForNewKey
		{
		}

		public class Finished
		{
		}

	}

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
		
		
	}


}

