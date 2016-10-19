using UnityEngine;
using System.Collections;

public class ShapeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		GameScript.Check(this.gameObject);
		Destroy (this.gameObject);
	}   
}
