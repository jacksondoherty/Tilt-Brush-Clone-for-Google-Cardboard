using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PaintbrushControl : MonoBehaviour {

	public float speed;
	public float lineWidth;
	public Material color1;
	public Material color2;
	public Material color3;
	public Material color4;
	public GameObject colorIndicator;

	private Material currentColor;
	private Renderer renderer;
	private Renderer indicatorRenderer;
	private LineRenderer currentLine;
	private int numPoints;
	private List<LineRenderer> lines;

	void Start () {
		renderer = GetComponent<Renderer> ();
		indicatorRenderer = colorIndicator.GetComponent < Renderer> ();
		lines = new List<LineRenderer> ();
		renderer.material = color1;
		currentColor = color1;
	}
	
	void Update () {
		Movement ();
		Painting ();
	}

	void Movement() {
		float x = Input.GetAxis ("PaintbrushHorizontal");
		float y = 0;
		float z = Input.GetAxis ("PaintbrushVertical");
		Vector3 desiredMove = new Vector3 (x, y, z);
		desiredMove = desiredMove * speed;
		transform.localPosition += desiredMove;

		if (Input.GetButtonDown ("ResetPaintbrushPosition")) {
			transform.localPosition = new Vector3 (0, 0, 2);
		}
	}

	void Painting () {
		if (!Input.GetButton ("Paint")) {
			if (Input.GetButtonDown ("SelectColor1")) {
				renderer.material = color1;
				indicatorRenderer.material = color1;
			} else if (Input.GetButtonDown ("SelectColor2")) {
				renderer.material = color2;
				indicatorRenderer.material = color2;
			} else if (Input.GetButtonDown ("SelectColor3")) {
				renderer.material = color3;
				indicatorRenderer.material = color3;
			} else if (Input.GetButtonDown ("SelectColor4")) {
				renderer.material = color4;
				indicatorRenderer.material = color4;
			}
		}
			
		// recieved help from https://www.youtube.com/watch?v=eMJATZI0A7c
		if (Input.GetButtonDown ("Paint")) {
			GameObject paint = new GameObject ();
			currentLine = paint.AddComponent<LineRenderer> ();
			currentLine.SetWidth (lineWidth, lineWidth);
			currentLine.material = renderer.material;
			numPoints = 0;
		} else if (Input.GetButton ("Paint")) {
			currentLine.SetVertexCount (numPoints + 1);
			currentLine.SetPosition (numPoints, transform.position);
			numPoints++;
			lines.Add (currentLine);
		}

		if (Input.GetButtonDown ("DeleteLines")) {
			lines.ForEach (delegate(LineRenderer line) {
				lines.Remove(line);
				Destroy(line);
			});
		}
	}
}
