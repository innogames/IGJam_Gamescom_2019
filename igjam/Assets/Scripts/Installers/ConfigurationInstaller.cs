using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ConfigurationInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Bind<ITickable>().To<InputDispatcher>().AsSingle().NonLazy();
		
		SignalBusInstaller.Install(Container);
		Container.Bind<GameModel>().AsSingle();

		Container.DeclareSignal<SystemSignal.Ship.SlotSelected>();
		Container.DeclareSignal<SystemSignal.Ship.PartAttached>();
		Container.DeclareSignal<SystemSignal.Ship.ControlUpdated>();
		Container.DeclareSignal<SystemSignal.GameMode.ConfigureShip.Activate>();
		Container.DeclareSignal<SystemSignal.GameMode.ConfigureShip.Deactivate>();
		Container.DeclareSignal<SystemSignal.GameMode.ConfigureControls.Activate>();
		Container.DeclareSignal<SystemSignal.GameMode.ConfigureControls.Deactivate>();
		Container.DeclareSignal<SystemSignal.GameMode.FlyMode.Activate>();
		Container.DeclareSignal<SystemSignal.GameMode.FlyMode.Deactivate>();

		Container.DeclareSignal<SystemSignal.GameMode.ConfigureInput.FullConfigured>();
		Container.DeclareSignal<SystemSignal.GameMode.ConfigureInput.ConfigureMode>();
		Container.DeclareSignal<SystemSignal.GameMode.ConfigureInput.ConfigureLeft>();
		Container.DeclareSignal<SystemSignal.GameMode.ConfigureInput.ConfigureRight>();
		
		Container.DeclareSignal <SystemSignal.Ship.ConfigureControls>();
		Container.DeclareSignal<SystemSignal.Ship.ConfigureSlots>();

		Container.DeclareSignal<InputSignal.ModeSwitch>();
		Container.DeclareSignal<InputSignal.LeftButton>();
		Container.DeclareSignal<InputSignal.RightButton>();
		Container.DeclareSignal<InputSignal.UnbufferedLeftButton>();
		Container.DeclareSignal<InputSignal.UnbufferedRightButton>();
		


	}
}