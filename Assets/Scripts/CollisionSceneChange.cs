using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollisionSceneChange : MonoBehaviour {





	void OnTriggerEnter2D (Collision2D collider){
	
		if (collider.gameObject.tag == "player") {
			SceneManager.LoadScene (2);
	
		}
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
