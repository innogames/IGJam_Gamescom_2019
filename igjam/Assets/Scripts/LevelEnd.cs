using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private string LevelName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var ship = other.gameObject.GetComponent<Ship>();
        if (ship != null)
        {
            SceneManager.LoadScene(LevelName);
        }
    }

    
}
