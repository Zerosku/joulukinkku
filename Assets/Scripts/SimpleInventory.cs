using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimpleInventory : MonoBehaviour {  // tai sit älä käytä tag systeemii ja luo omat scriptit itemin tuhoomista ja keräämistä varten

	public Sprite Slot1;  // vai pitäiskö olla gameobject
	public Sprite Slot2;
	public Sprite Slot3;    //aluksi sprite antidote jne
	public Sprite Slot4;
	public Sprite Slot5;
	public GameObject Antidote;
	public GameObject Key;
	public GameObject Map;				//aluksi GO antidoteicon jne
	public GameObject CandyCane;
	public GameObject Book;




	// onko spritet oikein määritelty jne? 
	void Start () {
		Slot1 = GameObject.Find ("Slot1").GetComponent<Sprite> ();
		Slot2 = GameObject.Find ("Slot2").GetComponent<Sprite> ();  //aluksi oli antidote = "antidotenimi" <sprite>
		Slot3 = GameObject.Find ("Slot3").GetComponent<Sprite> ();
		Slot4 = GameObject.Find ("Slot4").GetComponent<Sprite> ();
		Slot5 = GameObject.Find ("Slot5").GetComponent<Sprite> ();

		/*Antidote = GameObject.Find ("I_Antidote").GetComponent<GameObject> ();
		Key = GameObject.Find ("I_Key01").GetComponent<GameObject> ();  //aluksi oli antidote = "antidotenimi" <sprite>
		Map = GameObject.Find ("I_Map").GetComponent<GameObject> ();
		CandyCane = GameObject.Find ("W_Mace010").GetComponent<GameObject> ();
		Book = GameObject.Find ("I_Book").GetComponent<GameObject> (); */

		/*AntidoteSlot = GameObject.Find ("Slot1").GetComponent<Sprite> ();
		KeySlot = GameObject.Find ("Slot2").GetComponent<Sprite> ();
		MapSlot = GameObject.Find ("Slot3").GetComponent<Sprite> ();
		CandyCaneSlot = GameObject.Find ("Slot4").GetComponent<Sprite> ();
		BookSlot = GameObject.Find ("Slot5").GetComponent<Sprite> (); */  // <==== vai noin? tarkista espr. riittää ehk vaa slot1 jne
		  
		Antidote = GameObject.FindGameObjectWithTag ("Antidote");
		Key = GameObject.FindGameObjectWithTag ("Key");					//aluksi oli antidoteIcon
		Map = GameObject.FindGameObjectWithTag ("Map");
		CandyCane = GameObject.FindGameObjectWithTag ("CandyCane");
		Book = GameObject.FindGameObjectWithTag ("Book");
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Antidote"))
		{ 
			Destroy(col.gameObject);
			Debug.Log ("found antidote");
			Antidote.SetActive (true);  // or Antidote.SetActive(false); (att. antidote is slot1)
		}
		if (col.CompareTag("Key"))
		{
			Destroy(col.gameObject);
			Debug.Log ("found key");
			Key.SetActive (true);

		}
		if (col.CompareTag("Map"))
		{ 
			Destroy(col.gameObject);
			Debug.Log ("found map");
			Antidote.SetActive (true);  // or Antidote.SetActive(false); (att. antidote is slot1)
		}
		if (col.CompareTag("CandyCane"))
		{
			Destroy(col.gameObject);
			Debug.Log ("found candy cane");
			Key.SetActive (true);

		}
		if (col.CompareTag("Book"))
		{ 
			Destroy(col.gameObject);
			Debug.Log ("found book");
			Antidote.SetActive (true);  // or Antidote.SetActive(false); (att. antidote is slot1)
		}


	}

	void Update () {
		
	}


	// Update is called once per frame

}
