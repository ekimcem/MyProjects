using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	
	Vector3 startPos, endPos, direction; // touch start position, touch end position, swipe direction
	float touchTimeStart, touchTimeFinish, timeInterval; // to calculate swipe time to sontrol throw force in Z direction


	public CollisonDestroy cd;

	[SerializeField]
	public float throwForceInXandZ = 3f; 

	

	Rigidbody rb;

	public float zBound=10.0f, xBound = 5.0f;
	public Vector3 SpawnPos = new Vector3(0, 0.5f, -5.4f);


	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		if(transform.position.z >=zBound || transform.position.z <= -zBound || transform.position.x >= xBound || transform.position.x <= -xBound  ){
			
			cd.top_cagir();
			Destroy(gameObject);
			
		

		}
		

		
		if (Input.GetMouseButtonDown(0))
		{

			
			touchTimeStart = Time.time;
			startPos = Input.mousePosition;

		}

		
		if (Input.GetMouseButtonUp(0))
		{
			

			touchTimeFinish = Time.time;

			// calculate swipe time interval 
			timeInterval = touchTimeFinish - touchTimeStart;

			// getting release  position

			endPos = Input.mousePosition; 

			// calculating swipe direction
			direction = startPos - endPos; // 


			Debug.Log(" x = " +Mathf.Abs(direction.x));
			Debug.Log("y = "+Mathf.Abs(direction.y));

			rb.AddForce(direction.x * throwForceInXandZ, 0, direction.y * throwForceInXandZ);

			



		}

	}
}



