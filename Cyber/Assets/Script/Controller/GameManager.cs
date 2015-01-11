using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public GameObject food;
	public GameObject enemy;
	List<GameObject> foods = new List<GameObject>();
	bool hasInitialized = false;

	public static int score;
	// Use this for initialization
	void Start () {
		StartCoroutine (FoodGeneration ());

	
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasInitialized)
		{
			hasInitialized = true;
			
			FoodGeneration();
			
			
			
		}


	
	}

	IEnumerator FoodGeneration ()
	{
		yield return new WaitForSeconds (3);
		for (int i = 0; i < 10; i++) {
			GameObject go = Instantiate(food, transform.position, transform.rotation) as GameObject;
			go.transform.parent = GameObject.Find("Food").transform;	
			//foods.Add(go);
			
		}
		for (int i = 0; i < 10; i++) {
			GameObject go = Instantiate(enemy, transform.position, transform.rotation) as GameObject;
			go.transform.parent = GameObject.Find("Enemy").transform;	
			//foods.Add(go);
			
		}
		StartCoroutine (FoodGeneration ());

		
	}
}
