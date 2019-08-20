using Zenject;

public class FlyState : BaseState
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
		_signalBus.Fire(new SystemSignal.GameMode.FlyMode.Activate());
	}

	public override void Deselect()
	{
		base.Deselect();
		_signalBus.Fire(new SystemSignal.GameMode.FlyMode.Deactivate());
	}
}