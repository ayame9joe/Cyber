using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject food;
	bool hasInitialized = false;
	// Use this for initialization
	void Start () {
		//StartCoroutine (FoodGeneration ());

	
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasInitialized)
		{
			hasInitialized = true;
			
			FoodGeneration();
			
			
			
		}


	
	}

	void FoodGeneration ()
	{
		for (int i = 0; i < 10; i++) {
			GameObject go = Instantiate(food, transform.position, transform.rotation) as GameObject;
			go.transform.parent = GameObject.Find("Food").transform;	
			
		}

		
	}
}
