using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// This script is attached to all the inventory item icons. 
/// When the game starts it deactivates the item's icon in the inventory. 
/// </summary>
public  class InventoryManager : MonoBehaviour {
	

	void Start () { 

		gameObject.SetActive(false);  // Deactivates the icon from the inventory. 

	}
		
	void Update () {
	}
}
