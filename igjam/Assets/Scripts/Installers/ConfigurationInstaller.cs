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
	}
}