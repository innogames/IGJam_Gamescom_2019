
using Zenject;

public class ConfigureShipState : GameState
{
	private SignalBus _signalBus;

	[Inject]
	public void Init(SignalBus signalBus)
	{
		_signalBus = signalBus;
	}

	public override void Activate()
	{
		base.Activate();
		_signalBus.Fire(new SystemSignal.GameMode.ConfigureShip.Activate());
	}

	public override void Deselect()
	{
		base.Deselect();
		_signalBus.Fire(new SystemSignal.GameMode.ConfigureShip.Deactivate());
	}
}