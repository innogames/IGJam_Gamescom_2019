using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeController : ListUI
{

	public GameState CurrentState;
	
	// Start is called before the first frame update
	void Start()
	{
		SelectNextSlot();
		
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonUp("X"))
		{
			SelectNextSlot();
		}
	}
}

public class GameState : SelectableControl
{
	public override void Select()
	{
		Activate();
	}

	public override void Deselect()
	{
		gameObject.SetActive(false);
	}

	public override void Activate()
	{
		gameObject.SetActive(true);
	}
}




