using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollisionSceneChange : MonoBehaviour {

	/// <summary>
	/// This script changes the scene when the player gameobject collides with a 2D box collider on the edge of the screen.
	/// This script is attached to the collider.
	/// </summary>
	/// <param name="collider">Collider.</param>



	void OnTriggerEnter2D (Collider2D collider){   
	
		if (collider.CompareTag("Player")) {  //If the collider collides with a gameobject tagged "Player"...
			SceneManager.LoadScene (1);             //The next scene begins
	
		}
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
