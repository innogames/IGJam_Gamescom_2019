using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ConfigurationInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
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
		
	}
}