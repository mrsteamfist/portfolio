using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

	static readonly string MAIN_MENU_TEXT = "MAIN MENU";
	static readonly string GAME_OVER_TEXT = "GAME OVER";

	public Canvas GameMenu;
	public TextMeshProUGUI MenuText;
	public Button QuitButton;

	public bool CanPlay
	{
		get
		{
			return !GameMenu.enabled;
		}
	}

	public void ShowMenu()
	{
		GameMenu.enabled=true;
	}

	public void PressPlay()
	{
		GameMenu.enabled=false;
		MenuText.SetText(GAME_OVER_TEXT);
	}

	public void PressOptions()
	{

	}

	public void PressQuit()
	{
		Application.Quit();
	}
}
