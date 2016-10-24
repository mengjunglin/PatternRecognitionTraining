using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameScript : MonoBehaviour {
	private float spawnTime = .5f; //time to wait before spawning the next object
	private bool spawn = true;
	private int targetIndex;
	private List<string> lstObjName;
	private static int score;

	private static Dictionary<GameObject, bool> spawnDictionary;
	public List<GameObject> lstShapeObj;
	public List<GameObject> lstChemObj;
	public Text txtTarget;
	public Text txtScore;
	public Text txtObjective;
	public Sprite spCorrect;
	public Sprite spIncorrect;

	// Use this for initialization
	void Start () {
		spawnDictionary = new Dictionary<GameObject, bool>();
		//lstObjName = new List<string>{ "Triangle", "Square", "Pentagon", "Hexagon", "Octagon"};
		score = 0;
		targetIndex = Random.Range (0, 5);
		//txtTarget.text = lstObjName[targetIndex];
		txtScore.text = 0.ToString();
		txtObjective.text = FrameworkCore.currentContent.getTerm();

		//StartCoroutine(Spawnning());
		if (FrameworkCore.currentContent.name == "Geometry")
			GeometryGame ();
		else
			ChemistryGame ();
	}
	
	// Update is called once per frame
	void Update () {
		txtScore.text = score.ToString();
	}

	void GeometryGame()
	{
		lstObjName = new List<string>{ "Triangle", "Square", "Pentagon", "Hexagon", "Octagon"};
		txtTarget.text = lstObjName[targetIndex];
		StartCoroutine(SpawnningShape());
	}

	void ChemistryGame()
	{
		lstObjName = new List<string>{ "Water", "Ammonia", "Methane", "Trimethylamine", "Chloroform"};
		txtTarget.text = lstObjName[targetIndex];
		StartCoroutine(SpawnningChem());
	}

	IEnumerator SpawnningShape()
	{
		while (true) {
			yield return new WaitForSeconds (spawnTime);
			SpawnShape ();
		}
	}

	void SpawnShape()
	{
		if (spawn) {
			int shapeIndex = Random.Range (0, 5);
			GameObject spawnObject = lstShapeObj[shapeIndex];

			// Where to spawn
			Vector3 spawnPosition = Camera.main.ScreenToWorldPoint (new Vector3 (Random.Range (170, 2310), 1500, 0)); //x(1):110=2370, x(1.5):170=2310
			spawnPosition.z = 0;

			// resize
			float coef = Random.Range (.5f, 1.5f);
			RectTransform rt = (RectTransform)spawnObject.transform;
			rt.localScale = new Vector3(coef,coef,coef); // resize

			rt.rotation = Quaternion.identity;

			// game over if object will overlap another object at spawning
			/*if (Physics2D.OverlapBox (spawnPosition, new Vector2 (w, h), 0f) != null)
				GameOver ();
			else {*/
			GameObject obj = Instantiate (spawnObject, spawnPosition, Quaternion.identity) as GameObject;
			if (shapeIndex == targetIndex) spawnDictionary.Add (obj, true);
			else spawnDictionary.Add (obj, false);
			//}
		}
	}

	IEnumerator SpawnningChem()
	{
		while (true) {
			yield return new WaitForSeconds (spawnTime);
			SpawnChem ();
		}
	}

	void SpawnChem()
	{
		if (spawn) {
			int chemIndex = Random.Range (0, 5);
			GameObject spawnObject = lstChemObj[chemIndex];

			// Where to spawn
			Vector3 spawnPosition = Camera.main.ScreenToWorldPoint (new Vector3 (Random.Range (170, 2310), 1500, 0)); //x(1):110=2370, x(1.5):170=2310
			spawnPosition.z = 0;

			// resize
			float coef = Random.Range (.5f, 1.5f);
			RectTransform rt = (RectTransform)spawnObject.transform;
			rt.localScale = new Vector3(coef,coef,coef); // resize

			rt.rotation = Quaternion.identity;

			// game over if object will overlap another object at spawning
			/*if (Physics2D.OverlapBox (spawnPosition, new Vector2 (w, h), 0f) != null)
				GameOver ();
			else {*/
			GameObject obj = Instantiate (spawnObject, spawnPosition, Quaternion.identity) as GameObject;
			if (chemIndex == targetIndex) spawnDictionary.Add (obj, true);
			else spawnDictionary.Add (obj, false);
			//}
		}
	}

	public static void Check(GameObject go)
	{
		if (spawnDictionary.ContainsKey (go))
		{
			if (spawnDictionary [go])
				score++;
			else
				score--;
		}
	}
}
