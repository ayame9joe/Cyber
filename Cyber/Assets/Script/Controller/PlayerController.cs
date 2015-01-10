using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
	public float speed;
	float sp;
	public float tilt;
	public Boundary boundary;
	
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	public float shootSpeed;
	
	private float nextFire;
	Vector3 shootDir;


	
	void Update ()
	{


		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			sp = speed;
			nextFire = Time.time + fireRate;
			GameObject s = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
			s.transform.parent = GameObject.Find("Shots").transform;

			shootDir = new Vector3(Input.mousePosition.x - this.transform.position.x,
			                       Input.mousePosition.y - this.transform.position.y,
			                       0);
			s.rigidbody2D.velocity = shootSpeed * shootDir;
			float h = Input.GetAxis ("Mouse X");
			float v = Input.GetAxis ("Mouse Y");


			
			rigidbody2D.velocity = shootDir * sp * (-1);
//			audio.Play ();
		}
		else
		{
			if (sp > 0)
			{
				sp -= 0.05f;
				rigidbody2D.velocity = shootDir * sp * (-1);
			}

		}
	}
	
	void FixedUpdate ()
	{



		rigidbody2D.position = new Vector3 
			(
				Mathf.Clamp (rigidbody2D.position.x, boundary.xMin, boundary.xMax), 
				Mathf.Clamp (rigidbody2D.position.y, boundary.yMin, boundary.yMax),
				0.0f
				);

		
		//rigidbody2D.rotation = Quaternion.Euler (0.0f, 0.0f, (float)rigidbody2D.velocity.x * -tilt);
	}
}
