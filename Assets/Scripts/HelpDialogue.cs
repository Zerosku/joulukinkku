using UnityEngine;
using System.Collections;

public class HelpDialogue : MonoBehaviour {
	
	public GUISkin Dialogue;

	string scene = "start";

	// dialogiboksin keskittämistä varten
	private float DialogueWidth = Screen.width/2;

	private float DialogueHeight = Screen.height/2;


	// liitty x-napin painamiseen
	private bool DialogueAction = false;
	// koskettaako puhuttava possua
	private bool DialogueTouch = false;

	private Texture2D background;


	void Start () {
		background = Resources.Load ("Image/red") as Texture2D;
		DialogueWidth = DialogueWidth - 125;
	}

	void Update () {

		if (Input.GetKeyDown ("x") && DialogueTouch == true) {
			DialogueAction = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			DialogueTouch = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag != "Player") {
			DialogueTouch = false;
		}
	}
		

	void OnGUI() {
		GUI.skin = Dialogue;

		/**if (DialogueTouch == true && DialogueAction == true) {
			
			GUILayout.BeginArea (new Rect (DialogueWidth, DialogueHeight, 200, 150));
		}
				GUILayout.BeginVertical ();
				GUILayout.Label ("Hey, I need your help piggy!");

				if (GUILayout.Button ("What can I do you for?")) {
					scene = "yes";
					
				}

				if (GUILayout.Button ("I don't have time for you!")) {
					scene = "no";
				}

				

			if (scene == "yes") {
				scene = "dialog2";
			}

			if (scene == "no") {
				GUILayout.BeginVertical ();
				GUILayout.Label ("Oh, sorry...");
				GUILayout.EndVertical ();
			}
			

			GUILayout.EndArea ();

		if (scene == "dialog2") {
			GUILayout.BeginArea (new Rect (DialogueWidth, DialogueHeight, 200, 150));
			scene = "dialog21";
			}

		if (scene == "dialog21") {
			GUILayout.BeginVertical ();
			GUILayout.Label ("I need 5 coins to get some food for the holiday.");
			GUILayout.EndVertical ();

			GUILayout.BeginVertical ();
			GUILayout.Label ("Will you help?");

			if (GUILayout.Button ("Okay")) {
				scene = "ok";
			}

			if (GUILayout.Button ("Not now")) {
				scene = "no2";
			}

			GUILayout.EndVertical ();

			if (scene == "ok") {
				GUILayout.BeginVertical ();
				GUILayout.Label ("You are the best!");
				GUILayout.EndVertical ();
				// coin++
				// karma++
			}

			if (scene == "no2") {
				GUILayout.BeginVertical ();
				GUILayout.Label ("Oh, okay");
				GUILayout.EndVertical ();
				// karma --
			}
		} **/
	}
}