using UnityEngine;
using System.Collections;

public class webLoad : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()
	{
		
       if (GUI.Button (new Rect (20,20,140,20), "Asset Store Link")) 
       	{
			Application.OpenURL("https://www.assetstore.unity3d.com/#/content/13868");
		}
	}
}
