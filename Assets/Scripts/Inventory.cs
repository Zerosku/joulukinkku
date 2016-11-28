using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {


	public GameObject slots;
	int x = -109;
	int y = 111;

	// Use this for initialization
	void Start () {
	
		for(int i = 1; i < 6; i ++)
		{
			for (int k = 1; k < 6; k++) 
			{
				GameObject slot = (GameObject)Instantiate (slots);
				slot.transform.parent = this.gameObject.transform;
				slot.name = "Slot" + i + "." + k;
				slot.GetComponent<RectTransform> ().localPosition = new Vector3 (x, y, 0);
				x = x + 55;

				if (k == 5) {
				
					x = -109;
					y = y - 55;
				
				}

			}
		}
			

	}
	

}
