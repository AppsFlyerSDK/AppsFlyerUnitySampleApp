using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class AF_Sample_BGScript : MonoBehaviour {
	// Use this for initialization
	public GameObject Button;
	public GameObject ButtonText;
	public GameObject Check;
	public GameObject text;

	private static bool isPressed=false;
	void Start () {
		Check.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (isPressed) {
			StartCoroutine (PressAnim ());
			isPressed = false;
		}
	}
	public static void pressed(){
		isPressed = true;
	}

	IEnumerator PressAnim() {
		Check.SetActive (true);
		ButtonText.GetComponent<Text> ().text = "Event Tracked!";
		Button.SetActive (false);
		yield return new WaitForSeconds(3.5f);

		Check.SetActive (false);
		ButtonText.GetComponent<Text> ().text = "Track Event";
		Button.SetActive (true);
	}	

}
