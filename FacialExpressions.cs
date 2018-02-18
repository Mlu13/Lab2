using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Animator))]
public class FacialExpressions : MonoBehaviour {

	//public Renderer FaceRenderer;

	//private Material faceMaterial;
	//private Vector2 uvOffset;
	//private Animator animator;

//	// Use this for initialization
//	void Start () {
//		uvOffset = Vector2.zero;
//		faceMaterial = FaceRenderer.materials[1];
//		animator = gameObject.GetComponent<Animator>();
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		// This is hardcoded to set the correct face based on the Animator state
//		AnimatorStateInfo animState = animator.GetCurrentAnimatorStateInfo (0);
//
//		if (animState.IsName ("Idle"))
//			uvOffset = new Vector2(0, 0);
//		else if (animState.IsName ("Happy"))
//			uvOffset = new Vector2(0.25f, 0);
//		else if (animState.IsName ("Sad"))
//			uvOffset = new Vector2(0, -0.25f);
//		else
//			uvOffset = new Vector2(0.25f, -0.25f);
//
//		faceMaterial.SetTextureOffset ("_MainTex", uvOffset);
//	}

	//----------------------------------------------------------

	//Script containing levels of emotions
	ImageResultsParser userEmotions;

	//player Transform used to obtain reference to UserEmotions script
	Transform player;

	//Used to change the face from smiling to frowning
	public Renderer faceRenderer;

	private Material faceMaterial;
	private Vector2 uvOffset;




	// Initialization and Setting references
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Sailor").transform;
		userEmotions = player.GetComponent<ImageResultsParser> ();
		uvOffset = Vector2.zero;
		faceMaterial = faceRenderer.materials[1];


	}

	// Setting the user's dominant emotion every frame
	void Update () {
		// TODO for Question 2
		//userEmotions.joyLevel;

		float joy = userEmotions.joyLevel;
		float sad = userEmotions.sadnessLevel;
		float surprise = userEmotions.surpriseLevel;

		if (joy > 10 || sad > 10 || surprise > 10) {
			if (joy > 40) {
				setJoyful ();
	
			}else if (sad > 50) {
				setSad ();
			}else if (surprise > 60) {
				setSurprise ();
			}
		}
		else{
			setIdle ();
		}


//		

	

	}

	//sets the Character's emotion to Idle (Emotionless)
	void setIdle(){
		// TODO for Question 2
		uvOffset = new Vector2(0,0);
		faceMaterial.SetTextureOffset ("_MainTex", uvOffset);
		player.position = new Vector3 (0, 0, 0);


	}


	//sets the Character's emotion to Joyful (Smiling)
	void setJoyful() {
		// TODO for Question 2
		uvOffset = new Vector2(0.25f, 0);
		faceMaterial.SetTextureOffset ("_MainTex", uvOffset);

		player.position =  Vector3.up * 0.5f;

	}

	//sets the Character's emotion to Sad (Frowning)
	void setSad() {
		// TODO for Question 2
		uvOffset = new Vector2(0,-0.25f);
		faceMaterial.SetTextureOffset ("_MainTex", uvOffset);

		player.position = Vector3.left * 0.5f;
	}

	void setSurprise(){
		uvOffset = new Vector2 (0.25f, -0.25f);
		faceMaterial.SetTextureOffset ("_MainTex", uvOffset);

		player.position = Vector3.right * 0.5f;
	}

}
