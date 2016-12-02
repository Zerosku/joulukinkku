using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimpleInventory : MonoBehaviour {  // tai sit älä käytä tag systeemii ja luo omat scriptit itemin tuhoomista ja keräämistä varten

	/*public Sprite Slot1;  // vai pitäiskö olla gameobject
	public Sprite Slot2;
	public Sprite Slot3;    //aluksi sprite antidote jne
	public Sprite Slot4;
	public Sprite Slot5; */
	public GameObject Antidote;
	public GameObject Key;
	public GameObject Map;				//aluksi GO antidoteicon jne
	public GameObject CandyCane;
	public GameObject Book;


	void Start () {


		Antidote= GameObject.Find ("I_Antidote").GetComponent<GameObject> ();
		Key = GameObject.Find ("I_Key01").GetComponent<GameObject> ();  //aluksi oli antidote = "antidotenimi" <sprite>
		Map = GameObject.Find ("I_Map").GetComponent<GameObject> ();
		CandyCane = GameObject.Find ("W_Mace010").GetComponent<GameObject> ();
		Book = GameObject.Find ("I_Book").GetComponent<GameObject> (); 

	

		//this.Antidote.GetComponent<Image>().enabled = true;


	
	}

	void OnTriggerEnter2D(Collider2D col)
	{


		if (col.CompareTag("Key"))
		{
			Destroy(col.gameObject);
			Debug.Log ("found key");
			Key.SetActive (true);

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


	// Update is called once per frame

}
