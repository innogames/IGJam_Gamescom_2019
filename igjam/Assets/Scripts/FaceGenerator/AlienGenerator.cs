using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AlienGenerator : MonoBehaviour
{
	private int seed = 1111;
	public List<AlienHead> AvailableHeadShapes;
	public List<GameObject> AvailableMouthShapes;
	public List<GameObject> AvailableNoseShapes;
	public List<GameObject> AvailableEyeShapes;

	public Transform HeadPosition;
	private Alien _alien;
	public bool Generate;

	// Start is called before the first frame update
	void Start()
	{
		GenerateAlien();
	}


	void Update()
	{
		if (Generate)
		{
			var children = GetComponentsInChildren<Transform>();
			foreach (var child in children)
			{
				if (child.transform != transform)
				{
                    if (Application.isPlaying)
                    {
                        Object.Destroy(child.gameObject);
                    }
                    else {
                        Object.DestroyImmediate(child.gameObject);
                    }
                    
				}

			}
			Generate = false;
			GenerateAlien();
		}
	}

	private void GenerateAlien()
	{
		_alien = new Alien();
		_alien.HeadId = UnityEngine.Random.Range(0, AvailableHeadShapes.Count);
		_alien.MouthId = UnityEngine.Random.Range(0, AvailableMouthShapes.Count);
		_alien.NoseId = UnityEngine.Random.Range(0, AvailableNoseShapes.Count);
		_alien.EyesId = UnityEngine.Random.Range(0, AvailableEyeShapes.Count);
		GenerateAlien(_alien);
	}

	public void GenerateAlien(Alien alien)
	{
		var headObject = Instantiate(AvailableHeadShapes[alien.HeadId]);
		PlaceObject(headObject.transform, HeadPosition);
		var mouthObject = Instantiate(AvailableMouthShapes[alien.MouthId]);
		PlaceObject(mouthObject.transform, headObject.MouthSlot);
		var noseObject = Instantiate(AvailableNoseShapes[alien.NoseId]);
		PlaceObject(noseObject.transform, headObject.NoseSlot);
		var eyesObject = Instantiate(AvailableEyeShapes[alien.EyesId]);
		PlaceObject(eyesObject.transform, headObject.EyesSlot);
	}

	private void PlaceObject(Transform objectToPlace, Transform target)
	{
		objectToPlace.transform.SetParent(target);
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
	public int MouthId;
	public int NoseId;
	public int EyesId;
}