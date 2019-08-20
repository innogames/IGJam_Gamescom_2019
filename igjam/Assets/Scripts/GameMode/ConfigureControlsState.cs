using Zenject;

public class ConfigureControlsState : GameState
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
		_signalBus.Fire(new SystemSignal.GameMode.ConfigureControls.Activate());
	}

	public override void Deselect()
	{
		base.Deselect();
		_signalBus.Fire(new SystemSignal.GameMode.ConfigureControls.Deactivate());
	}
}