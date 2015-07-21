using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {
	
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//4 directions movement
		if (Input.GetKeyDown ("space") || Input.GetButton("Jump")) {
			
			animation.Stop ("Walk");
			animation.Stop ("Idle");
			animation.Play ("Jump");
			
		} else if ((Input.GetKey ("w") || Input.GetAxis ("Vertical") > 0.2 || Input.GetAxis ("Vertical") < -0.2) && !animation.IsPlaying ("Jump")) {
			animation.Play ("Walk");
		} else if ((Input.GetKey ("a") || Input.GetAxis ("Horizontal") > 0.2 || Input.GetAxis ("Horizontal") < -0.2) && !animation.IsPlaying ("Jump")) {
			animation.Play ("Walk");
		} else if (Input.GetKey ("d") && !animation.IsPlaying ("Jump")) {
			animation.Play ("Walk");
		} else if (Input.GetKey ("s") && !animation.IsPlaying ("Jump")) {
			animation.Play ("Walk");
		} else if (Input.GetKeyUp ("w") || (Input.GetAxis ("Vertical") < 0.2 && Input.GetAxis ("Vertical") > -0.2)) {
			animation.Stop ("Walk");
		} else if (Input.GetKeyUp ("s")) {
			animation.Stop ("Walk");
		} else if (Input.GetKeyUp ("a") || (Input.GetAxis ("Horizontal") < 0.2 && Input.GetAxis ("Horizontal") > -0.2)) {
			animation.Stop ("Walk");
		} else if (Input.GetKeyUp ("d")) {
			animation.Stop ("Walk");
		} 

		if (Input.GetKey ("q") || (Input.GetAxis("Triggers") == 1) && !animation.IsPlaying ("Jump")) {
			animation.Stop ("Idle");
			animation.Play ("LeftBell");
		} else if (Input.GetKey ("e") || (Input.GetAxis("Triggers") == -1) && !animation.IsPlaying ("Jump")) {
			animation.Stop ("Idle");
			animation.Play ("RightBell");
		}
		//|| (Input.GetAxis("Triggers") == 1)
		
		if (!animation.isPlaying){
			animation.Play ("Idle");
		}
		
	}
}