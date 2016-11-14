using UnityEngine;
using System.Collections;

public class TextureChanger : MonoBehaviour 
{
	public GameObject [] DiffuseTexture1;
	public GameObject [] ParallaxTexture1;


	void OnGUI()
	{

		GUI.Box(new Rect(-100,20,1000,20),"Press N or P to scroll horizontally between textures");

		if(GUI.Button(new Rect(40,40,100,20), "Diffuse"))
		{
			
			for(int i = 0; i < DiffuseTexture1.Length; i++)
			{
				DiffuseTexture1[i].active = true;
			}
			for(int j = 0; j < ParallaxTexture1.Length; j++)
			{
				ParallaxTexture1[j].active = false;
			}
			

		}
		if(GUI.Button(new Rect(40,60,100,20), "Normal Map"))
		{

			for(int i = 0; i < DiffuseTexture1.Length; i++)
			{
				DiffuseTexture1[i].active = false;
			}
			for(int j = 0; j < ParallaxTexture1.Length; j++)
			{
				ParallaxTexture1[j].active = true;
			}

		}
	}

}
