using UnityEngine;

public abstract class SelectableControl : MonoBehaviour
{
	public abstract void Select();
	public abstract void Deselect();
	public abstract void Activate();
}