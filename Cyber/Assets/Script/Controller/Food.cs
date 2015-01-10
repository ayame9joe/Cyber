using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

	public float dieOutTime;
	// Use this for initialization
	void Start () {
		this.transform.localPosition = new Vector3(Random.Range(0, 480), Random.Range(0, 800),0);
		//StartCoroutine (DieOut ());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	IEnumerator DieOut() {
		//Debug.Log("Before Waiting 2 seconds");
		yield return new WaitForSeconds(dieOutTime);
		//Debug.Log("After Waiting 2 Seconds");
		Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log("On Trigger Enter");
		if (other.tag == "Player") {
			//PlayerController		
		}
		else if (other.tag == "Shot")
		{
			Destroy(this.gameObject);
		}
	}
}



