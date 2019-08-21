using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienGenerator : MonoBehaviour
{
	private int seed = 1111;
	public List<GameObject> AvailableHeadShapes;

	public Transform HeadPosition;
	private Alien _alien;

	// Start is called before the first frame update
	void Start()
	{
		GenerateAlien();
	}

	private void GenerateAlien()
	{
		_alien = new Alien();
		_alien.HeadId = UnityEngine.Random.Range(0, AvailableHeadShapes.Count);
	}

	public void GenerateAlien(Alien alien)
	{
		var headObject = Instantiate(AvailableHeadShapes[alien.HeadId]);
		PlaceObject(headObject.transform, HeadPosition);
	}

	private void PlaceObject(Transform objectToPlace, Transform target)
	{
		objectToPlace.transform.SetParent(HeadPosition);
		objectToPlace.transform.localPosition = Vector3.zero;
		objectToPlace.transform.localScale = Vector3.one;
		objectToPlace.transform.localRotation = Quaternion.identity;
	}

	public Alien GetAlien()
	{
		return _alien;
	}

}

public class Alien
{
	public int HeadId;
}