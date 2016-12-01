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



/*	void itemPicked(){
		if (CompareTag ("Antidote")) {
			Antidote.SetActive (true);
		} else if (CompareTag ("Key")) {
			Key.SetActive (true);	
		} else if (CompareTag ("Map")) {
			Map.SetActive (true);
		} else if (CompareTag ("CandyCane")) {
			CandyCane.SetActive (true);
		} else if (CompareTag ("Book")) {
			Book.SetActive (true);
		}
	} */





	// onko spritet oikein määritelty jne? 
	void Start () {

		//q = GameObject.Find ("q").GetComponent<GameObject> ();


		/*Slot1 = GameObject.Find ("Slot1").GetComponent<Sprite> ();
		Slot2 = GameObject.Find ("Slot2").GetComponent<Sprite> ();  //aluksi oli antidote = "antidotenimi" <sprite>
		Slot3 = GameObject.Find ("Slot3").GetComponent<Sprite> ();
		Slot4 = GameObject.Find ("Slot4").GetComponent<Sprite> ();
		Slot5 = GameObject.Find ("Slot5").GetComponent<Sprite> (); */

		Antidote = GameObject.Find ("I_Antidote").GetComponent<GameObject> ();
		Key = GameObject.Find ("I_Key01").GetComponent<GameObject> ();  //aluksi oli antidote = "antidotenimi" <sprite>
		Map = GameObject.Find ("I_Map").GetComponent<GameObject> ();
		CandyCane = GameObject.Find ("W_Mace010").GetComponent<GameObject> ();
		Book = GameObject.Find ("I_Book").GetComponent<GameObject> (); 


		//this.Antidote.GetComponent<Image>().enabled = true;


		/*AntidoteSlot = GameObject.Find ("Slot1").GetComponent<Sprite> ();
		KeySlot = GameObject.Find ("Slot2").GetComponent<Sprite> ();
		MapSlot = GameObject.Find ("Slot3").GetComponent<Sprite> ();
		CandyCaneSlot = GameObject.Find ("Slot4").GetComponent<Sprite> ();
		BookSlot = GameObject.Find ("Slot5").GetComponent<Sprite> (); */  // <==== vai noin? tarkista espr. riittää ehk vaa slot1 jne
		  
		/*Antidote = GameObject.FindGameObjectWithTag ("Antidote");
		Key = GameObject.FindGameObjectWithTag ("Key");					//aluksi oli antidoteIcon
		Map = GameObject.FindGameObjectWithTag ("Map");
		CandyCane = GameObject.FindGameObjectWithTag ("CandyCane");
		Book = GameObject.FindGameObjectWithTag ("Book");*/
	
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{

		if (col.CompareTag("Antidote"))
		{ 
			Destroy(col.gameObject);
			Debug.Log ("found antidote");
			//Antidote.GetComponent<Image>().enabled = true; 
			Antidote.SetActive(true); 
										//InventoryManager.itemPicked();
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
