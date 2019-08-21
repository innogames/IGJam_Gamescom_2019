using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public Transform NextLevelStart;
    public Camera CurrentCamera;
    public Camera NextCamera;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        var ship = other.gameObject.GetComponent<Ship>();
        if (ship != null)
        {
            ship.transform.position = NextLevelStart.position;
            CurrentCamera.gameObject.SetActive(false);
            NextCamera.gameObject.SetActive(true);
        }
    }

    
}
