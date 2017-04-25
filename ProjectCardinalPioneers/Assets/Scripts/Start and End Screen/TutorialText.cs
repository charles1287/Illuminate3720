using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour {

	public float letterPause = 0.02f;

	string message;
	Text tutTextComp;

	// Use this for initialization
	void Start () {
		tutTextComp = GetComponent<Text>();
		//message = tutTextComp.text;
		message = "Blue platform is stable.\nCommand Pod has been secured.\nRover communication is stable.\nRover movement with WASD.\nRover to object tether with R-CLICK.\nGather resources within timeframe.";
		StartCoroutine (TypeText ());
	}
	
	IEnumerator TypeText(){
		foreach (char letter in message.ToCharArray()) {
			tutTextComp.text += letter;
			yield return new WaitForSeconds (letterPause);
		}
		yield return new WaitForSeconds (letterPause * 16);
		Destroy (tutTextComp.gameObject);
	}
}
