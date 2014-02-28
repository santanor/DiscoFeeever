using UnityEngine;
using System.Linq;
using System.Collections;

public class Shop : MonoBehaviour {

	int _selectedWeapon;
	GUIStyle _nobackground;
	Texture[] _aviabbleWeapons;

	// Use this for initialization
	void Start () {
		_aviabbleWeapons = Resources.LoadAll("Shop/").Select(item => (Texture)item).ToArray();
		_nobackground = new GUIStyle();
		_nobackground.onNormal.background = null;
	}

	void OnGUI()
	{
		GUI.Box(new Rect(ScreenExtension.GetPercentWidth(10),ScreenExtension.GetPercentHeight(15),ScreenExtension.GetPercentWidth(80),ScreenExtension.GetPercentHeight(65)),"It's time to buy some s**t");
		GUILayout.BeginArea(new Rect(ScreenExtension.GetPercentWidth(10),ScreenExtension.GetPercentHeight(15),ScreenExtension.GetPercentWidth(80),ScreenExtension.GetPercentHeight(65)));
		//Extintor Nivel 1
		GUILayout.BeginArea(new Rect(0,0, ScreenExtension.GetPercentWidth(26.6666667f),ScreenExtension.GetPercentHeight(32.5f)));
			Weapon(_aviabbleWeapons[0], "extintorNivel1");
		GUILayout.EndArea();
		//Muñeca nivel 1
		GUILayout.BeginArea(new Rect(ScreenExtension.GetPercentWidth(26.6666667f),0, ScreenExtension.GetPercentWidth(26.6666667f),ScreenExtension.GetPercentHeight(32.5f)));
			Weapon(_aviabbleWeapons[1], "muñecaNivel1");
		GUILayout.EndArea();
		//ChupitoNivel1
		GUILayout.BeginArea(new Rect(ScreenExtension.GetPercentWidth(26.6666667f *2),0, ScreenExtension.GetPercentWidth(26.6666667f),ScreenExtension.GetPercentHeight(32.5f)));
			Weapon(_aviabbleWeapons[2], "chupitoNivel1");
		GUILayout.EndArea();
		//ExtintorNivel2
		GUILayout.BeginArea(new Rect(0,ScreenExtension.GetPercentHeight(32.5f), ScreenExtension.GetPercentWidth(26.6666667f),ScreenExtension.GetPercentHeight(32.5f)));
			Weapon(_aviabbleWeapons[3], "extintorNivel2");
		GUILayout.EndArea();
		//MuñecaNivel2
		GUILayout.BeginArea(new Rect(ScreenExtension.GetPercentWidth(26.6666667f),ScreenExtension.GetPercentHeight(32.5f), ScreenExtension.GetPercentWidth(26.6666667f),ScreenExtension.GetPercentHeight(32.5f)));
			Weapon(_aviabbleWeapons[4], "muñecaNivel2");
		GUILayout.EndArea();
		//ChupitoNivel2
		GUILayout.BeginArea(new Rect(ScreenExtension.GetPercentWidth(26.6666667f*2),ScreenExtension.GetPercentHeight(32.5f), ScreenExtension.GetPercentWidth(26.6666667f),ScreenExtension.GetPercentHeight(32.5f)));
			Weapon(_aviabbleWeapons[5], "chupitoNivel2");
		GUILayout.EndArea();
		GUILayout.EndArea();
	}


	void Weapon(Texture image, string playerPrefName)
	{
		GUI.Box(new Rect (ScreenExtension.GetPercentWidth(8.88889f),ScreenExtension.GetPercentHeight(10.89f),ScreenExtension.GetPercentWidth(8.88889f),ScreenExtension.GetPercentHeight(10.89f)),image, _nobackground);
		GUIStyle textStyle = new GUIStyle();
		textStyle.fontSize = 50;
		textStyle.alignment = TextAnchor.UpperCenter;
		GUI.TextArea(new Rect (0,ScreenExtension.GetPercentHeight(10.89f),ScreenExtension.GetPercentWidth(8.88889f),ScreenExtension.GetPercentHeight(10.89f)), PlayerPrefs.GetInt("extintorNivel1").ToString(),textStyle);
		if(GUI.Button(new Rect (ScreenExtension.GetPercentWidth(8.88889f),0,ScreenExtension.GetPercentWidth(8.88889f),ScreenExtension.GetPercentHeight(10.89f)), "+",textStyle))
			PlayerPrefs.SetInt(playerPrefName, PlayerPrefs.GetInt(playerPrefName)+1);
		if(GUI.Button(new Rect (ScreenExtension.GetPercentWidth(8.88889f),ScreenExtension.GetPercentHeight(10.89f*2),ScreenExtension.GetPercentWidth(8.88889f),ScreenExtension.GetPercentHeight(10.89f)), "-",textStyle))
			PlayerPrefs.SetInt(playerPrefName, PlayerPrefs.GetInt(playerPrefName)-1);
		if(PlayerPrefs.GetInt(playerPrefName) <= 0)
			PlayerPrefs.SetInt(playerPrefName,0);
	}
}
