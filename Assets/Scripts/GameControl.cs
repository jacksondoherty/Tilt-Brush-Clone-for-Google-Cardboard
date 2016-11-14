using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameControl : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject paintbrush;
	public FirstPersonController fpcScript;
	public GameObject backgroundMenu;

	public Button playButton;
	public Button backgroundButton;
	public Button quitButton;
	public Button spaceButton;

	public Material spaceSkybox;
	public Material saturnSkybox;
	public Material skySkybox;

	private bool closeMainMenu = false;

	void Start() {
		backgroundMenu.SetActive (false);
		OpenMainMenu ();
	}

	void Update () {
		if (Input.GetButtonDown ("OpenCloseMainMenu")) {
			if (mainMenu.activeSelf) {
				CloseBackgroundMenu ();
				CloseMainMenu ();
			} else {
				OpenMainMenu ();
			}
		}
		if (mainMenu.activeSelf) {
			if (Input.GetAxis ("PlayerHorizontal") > 0) {
				if (EventSystem.current.currentSelectedGameObject.name == "BackgroundButton") {
					OpenBackgroundMenu ();
				}
			}
		}
		if (backgroundMenu.activeSelf) {
			if (Input.GetButtonDown ("CloseBackgroundMenu") ||
				Input.GetAxis ("PlayerHorizontal") < 0) {
				CloseBackgroundMenu ();
			}
		}
	}

	void OpenMainMenu() {
		mainMenu.SetActive (true);
		paintbrush.SetActive (false);
		fpcScript.enabled = false;
		playButton.interactable = true;
		backgroundButton.interactable = true;
		quitButton.interactable = true;
		playButton.Select ();
	}

	void CloseMainMenu() {
		mainMenu.SetActive (false);
		paintbrush.SetActive (true);
		fpcScript.enabled = true;
	}

	void OpenBackgroundMenu() {
		backgroundMenu.SetActive (true);
		playButton.interactable = false;
		backgroundButton.interactable = false;
		quitButton.interactable = false;
		spaceButton.Select ();
	}

	void CloseBackgroundMenu() {
		backgroundMenu.SetActive (false);
		playButton.interactable = true;
		backgroundButton.interactable = true;
		quitButton.interactable = true;
		backgroundButton.Select ();
	}

	public void PlayButtonClick() {
		EventSystem.current.SetSelectedGameObject (null);
		CloseMainMenu ();
	}

	public void BackgroundButtonClick() {
		OpenBackgroundMenu ();
	}

	public void QuitButtonClick() {
		Application.Quit ();
	}

	public void SpaceButtonClick() {
		RenderSettings.skybox = spaceSkybox;
		DynamicGI.UpdateEnvironment ();
	}

	public void SaturnButtonClick() {
		RenderSettings.skybox = saturnSkybox;
		DynamicGI.UpdateEnvironment ();
	}

	public void SkyButtonClick() {
		RenderSettings.skybox = skySkybox;
		DynamicGI.UpdateEnvironment ();
	}

	//IEnumerator SelectDefaultButton() {
		
	//}
}
