using UnityEngine;
using System.Collections;
using System.Linq;
using System;
using System.Text;
public class NewGameButton : MonoBehaviour {

	bool showWeaponChooser;
	Texture[] aviableWeapons;
	bool[] selectedWeapons;
	Texture[] selectedWeaponsTextures;
	int selectedGrid;
	// Use this for initialization
	void OnClick()
	{
		showWeaponChooser  =!showWeaponChooser;
		aviableWeapons = Resources.LoadAll("Interface/").Select(item => (Texture)item).ToArray();
		selectedGrid = -1;
		selectedWeapons = new bool[4];
	}
	
	void OnGUI()
	{
		if(showWeaponChooser)
		{
			GUI.Box(new Rect(0,0,800,480),"Choose your weapons");
			GUILayout.BeginArea(new Rect(50,30,700,200));
			selectedGrid = GUILayout.SelectionGrid(selectedGrid,aviableWeapons,2);
			if(selectedGrid >= 0)
				selectedWeapons[selectedGrid] = true;
			selectedWeaponsTextures = aviableWeapons.Where(item => selectedWeapons[Array.IndexOf(aviableWeapons,item)]).ToArray();
			selectedGrid = -1;
			GUILayout.EndArea();

			GUILayout.BeginArea(new Rect(50,250, 700,200));
			selectedGrid = GUILayout.SelectionGrid(selectedGrid,selectedWeaponsTextures,4);
			if(selectedGrid >=0)
			{
				print(selectedGrid);
				selectedWeapons[Array.IndexOf(aviableWeapons, selectedWeaponsTextures[selectedGrid])] = false;
			}
			selectedGrid = -1;
			GUILayout.EndArea();

			if(GUI.Button(new Rect(680,400,100,50),"Begin"))
			{
				StringBuilder weapons = new StringBuilder();
				for(int i = 0; i < selectedWeapons.Length; i++)
					if(selectedWeapons[i])
						weapons.Append(i).Append(",");
				PlayerPrefs.SetString("SpecialWeapons",weapons.ToString().TrimEnd(','));
				Application.LoadLevel(1);
			}
		}
	}
}
