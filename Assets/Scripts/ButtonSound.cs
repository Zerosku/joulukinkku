using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour {

    //plays a sound on button click

    public AudioClip sound;
    
    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }


    // Use this for initialization
    void Start () {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;

        button.onClick.AddListener(() => PlaySound());
	}
	
	// Update is called once per frame
	void PlaySound () {
        source.PlayOneShot(sound);
	}
}
