using UnityEngine;
using System.Collections;

public class rotateObject : MonoBehaviour 
{


	// Use this for initialization
	void Start () 
	{
	
	}
	
	
	void Update()
	{
		transform.Rotate(20 * Time.deltaTime,20 * Time.deltaTime,0);
	}

}

