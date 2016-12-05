using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This script is attached to the player gameobject and to the simple inventoy panel.
/// Here we first create and find the item icon objects. Then we define what happens when the player's
///  collider reacts to the quest items' colliders. 
/// </summary>

public class SimpleInventory : MonoBehaviour {  
	//Item icons
	public GameObject Antidote;
	public GameObject Key;
	public GameObject Map;				
	public GameObject CandyCane;
	public GameObject Book;


	void Start () {
		//Finding item icons 
		Antidote= GameObject.Find ("I_Antidote").GetComponent<GameObject> ();
		Key = GameObject.Find ("I_Key01").GetComponent<GameObject> ();  
		Map = GameObject.Find ("I_Map").GetComponent<GameObject> ();
		CandyCane = GameObject.Find ("W_Mace010").GetComponent<GameObject> ();
		Book = GameObject.Find ("I_Book").GetComponent<GameObject> (); 

	}


	//When the player character collides with a QuestItem, the item is destroyed and 
	//the corresponding icon is set active in the inventory bar

	void OnTriggerEnter2D(Collider2D col)
	{


		if (col.CompareTag("Key"))	  //If the player collides with an item tagged "Key"...
		{
			Destroy(col.gameObject);  //QuestKey is destroyed
			Debug.Log ("found key");  
			Key.SetActive (true);     //The Key inventory icon is set active. 

		}
		if (col.CompareTag("Antidote")) 
		{ 
			Destroy(col.gameObject);
			Debug.Log ("found antidote");
			Antidote.SetActive(true); 

		}
		if (col.CompareTag("Map"))
		{ 
			Destroy(col.gameObject);
			Debug.Log ("found map");
			Map.SetActive (true);
		}
		if (col.CompareTag("CandyCane"))
		{
			Destroy(col.gameObject);
			Debug.Log ("found candy cane");
			CandyCane.SetActive (true);

		}
		if (col.CompareTag("Book"))
		{ 
			Destroy(col.gameObject);
			Debug.Log ("found book");
			Book.SetActive (true);
		}

	}

	void Update () {
		
	}

}
