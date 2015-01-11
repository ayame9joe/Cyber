using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

	public float dieOutTime;
	//float speed = Random.Range(10, 30);
	// Use this for initialization
	void Start () {
		int i = Random.Range (1, 100);
		if (i < 25)
		{
			this.transform.localPosition = new Vector3(Random.Range(0, 480), 0,0);
			this.rigidbody2D.velocity = new Vector2 (0, 50);
		}
		else if (i < 50 && i > 25)
		{
			this.transform.localPosition = new Vector3(Random.Range(0, 480), 800,0);
			this.rigidbody2D.velocity = new Vector2 (0, -50);
		}
		else if (i < 70 && i > 50)
		{
			this.transform.localPosition = new Vector3(0, Random.Range(0, 800),0);
			this.rigidbody2D.velocity = new Vector2 (50, 0);
		}
		else if (i < 100 && i > 75)
		{
			this.transform.localPosition = new Vector3(480, Random.Range(0, 800),0);
			this.rigidbody2D.velocity = new Vector2 (-50, 0);
		}
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void FixedUpdate ()
	{

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
		if (this.tag != "Enemy")
		{
			if (other.tag == "Player") {
				Destroy(this.gameObject);
				if (PlayerController.health < 100)
				{
					PlayerController.health += 10;	
				}
			}
			else if (other.tag == "Shot")
			{
				Destroy(this.gameObject);
				GameManager.score--;
			}
		}
		else 
		{
			if (other.tag == "Player") {
				Destroy(this.gameObject);
				if (PlayerController.health < 100)
				{
					PlayerController.health -= 10;	
				}
			}
			else if (other.tag == "Shot")
			{
				Destroy(this.gameObject);
				GameManager.score++;
			}
		}
	}
}



