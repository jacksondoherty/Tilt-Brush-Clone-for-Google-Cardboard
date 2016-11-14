using UnityEngine;
using System.Collections;

public class severalPositions : MonoBehaviour 
{
	public Vector3 newPosition;
	public float smooth = 2;

	public int Xx = 0;
	public int Yy = 0;
	public int Zz = 0;
	// Use this for initialization
	void Awake () 
	{
		newPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		nextPosition();
	}
	void nextPosition()
	{
		Vector3 A = new Vector3(Xx,Yy,Zz);
	
	

		if(Input.GetKeyDown(KeyCode.N))
		{
			newPosition = A;
			Xx += 5;
		}
		if(Input.GetKeyDown(KeyCode.P))
		{
			Xx -= 5;
			newPosition = A;

		}

		transform.position = Vector3.Lerp(transform.position, newPosition, smooth * Time.deltaTime);
			
	}
}
