using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.x < 0 ||
		    this.transform.position.x > 480 ||
		    this.transform.position.y < 0 ||
		    this.transform.position.y > 800)
		{
			Destroy(this.gameObject);
		}
	
	}
}