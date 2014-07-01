using UnityEngine;
using System.Linq;
using System.Collections;

/**
 * Esto ye una gochada, lo se, pero no me apetecia romperme la cabeza con ello
 */
public class Shop : MonoBehaviour {

	int _selectedWeapon;
	GUIStyle _nobackground;
	Texture[] _aviabbleWeapons;
	bool _showShop;

	// Use this for initialization
	void Start () {
		_aviabbleWeapons = Resources.LoadAll("Shop/").Select(item => (Texture)item).ToArray();
		_nobackground = new GUIStyle();
		_nobackground.onNormal.background = null;
		_showShop = true;
	}

	void OnGUI()
	{
		if (_showShop) {
			GUI.Box (new Rect (0, 0, ScreenExt.Width (100), ScreenExt.Height (100)), "It's time to buy some s**t");
			GUILayout.BeginArea (new Rect (ScreenExt.Width (10), ScreenExt.Height (15), ScreenExt.Width (80), ScreenExt.Height (65)));
			//Extintor Nivel 1
			GUILayout.BeginArea (new Rect (0, 0, ScreenExt.Width (26.6666667f), ScreenExt.Height (32.5f)));
			ExtinguisherLevel1 ();
			GUILayout.EndArea ();
			//Muñeca nivel 1
			GUILayout.BeginArea (new Rect (ScreenExt.Width (26.6666667f), 0, ScreenExt.Width (26.6666667f), ScreenExt.Height (32.5f)));
			DollLevel1 ();
			GUILayout.EndArea ();
			//ChupitoNivel1
			GUILayout.BeginArea (new Rect (ScreenExt.Width (26.6666667f * 2), 0, ScreenExt.Width (26.6666667f), ScreenExt.Height (32.5f)));
			StrogLevel1 ();
			GUILayout.EndArea ();
			//ExtintorNivel2
			GUILayout.BeginArea (new Rect (0, ScreenExt.Height (32.5f), ScreenExt.Width (26.6666667f), ScreenExt.Height (32.5f)));
			ExtinguisherLevel2 ();
			GUILayout.EndArea ();
			//MuñecaNivel2
			GUILayout.BeginArea (new Rect (ScreenExt.Width (26.6666667f), ScreenExt.Height (32.5f), ScreenExt.Width (26.6666667f), ScreenExt.Height (32.5f)));
			DollLevel2 ();
			GUILayout.EndArea ();
			//ChupitoNivel2
			GUILayout.BeginArea (new Rect (ScreenExt.Width (26.6666667f * 2), ScreenExt.Height (32.5f), ScreenExt.Width (26.6666667f), ScreenExt.Height (32.5f)));
			StrogLevel2 ();
			GUILayout.EndArea ();
			//CancelButton
			GUILayout.EndArea ();
			GUI.Button (new Rect (ScreenExt.Width (10), ScreenExt.Height (85), 40, 40), (Texture)Resources.Load ("Interface/cancel"), _nobackground);
			if (GUI.Button (new Rect (ScreenExt.Width (85), ScreenExt.Height (85), 40, 40), (Texture)Resources.Load ("Interface/play"), _nobackground))
			{	
				this._showShop=false;
				FindObjectOfType<GameController> ().StartGameAfterShop ();
			}
			}
		}


	void ExtinguisherLevel1()
	{
		GUI.Box(new Rect (ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f),ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f)),_aviabbleWeapons[0], _nobackground);
		GUIStyle textStyle = new GUIStyle();
		textStyle.fontSize = 50;
		textStyle.alignment = TextAnchor.UpperCenter;
		GUI.TextArea(new Rect (0,ScreenExt.Height(10.89f),ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f)), PlayerPrefs.GetInt("extintorNivel1").ToString(),textStyle);
		if(GUI.Button(new Rect (ScreenExt.Width(8.88889f),0,ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f)), "+",textStyle))
			PlayerPrefs.SetInt("extintorNivel1", PlayerPrefs.GetInt("extintorNivel1")+1);
		if(GUI.Button(new Rect (ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f*2),ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f)), "-",textStyle))
			PlayerPrefs.SetInt("extintorNivel1", PlayerPrefs.GetInt("extintorNivel1")-1);
		if(PlayerPrefs.GetInt("extintorNivel1") <= 0)
			PlayerPrefs.SetInt("extintorNivel1",0);
	}

	void DollLevel1()
	{
		GUI.Box(new Rect (ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f),ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f)),_aviabbleWeapons[1], _nobackground);
		GUIStyle textStyle = new GUIStyle();
		textStyle.fontSize = 50;
		textStyle.alignment = TextAnchor.UpperCenter;
		GUI.TextArea(new Rect (0,ScreenExt.Height(10.89f),ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f)), PlayerPrefs.GetInt("muñecaNivel1").ToString(),textStyle);
		if(GUI.Button(new Rect (ScreenExt.Width(8.88889f),0,ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f)), "+",textStyle))
			PlayerPrefs.SetInt("muñecaNivel1", PlayerPrefs.GetInt("muñecaNivel1")+1);
		if(GUI.Button(new Rect (ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f*2),ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f)), "-",textStyle))
			PlayerPrefs.SetInt("muñecaNivel1", PlayerPrefs.GetInt("muñecaNivel1")-1);
		if(PlayerPrefs.GetInt("muñecaNivel1") <= 0)
			PlayerPrefs.SetInt("muñecaNivel1",0);
	}

	void StrogLevel1()
	{
		GUI.Box(new Rect (ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f),ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f)),_aviabbleWeapons[2], _nobackground);
		GUIStyle textStyle = new GUIStyle();
		textStyle.fontSize = 50;
		textStyle.alignment = TextAnchor.UpperCenter;
		GUI.TextArea(new Rect (0,ScreenExt.Height(10.89f),ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f)), PlayerPrefs.GetInt("chupitoNivel1").ToString(),textStyle);
		if(GUI.Button(new Rect (ScreenExt.Width(8.88889f),0,ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f)), "+",textStyle))
			PlayerPrefs.SetInt("chupitoNivel1", PlayerPrefs.GetInt("chupitoNivel1")+1);
		if(GUI.Button(new Rect (ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f*2),ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f)), "-",textStyle))
			PlayerPrefs.SetInt("chupitoNivel1", PlayerPrefs.GetInt("chupitoNivel1")-1);
		if(PlayerPrefs.GetInt("chupitoNivel1") <= 0)
			PlayerPrefs.SetInt("chupitoNivel1",0);
	}

	void ExtinguisherLevel2()
	{
		GUI.Box(new Rect (ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f),ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f)),_aviabbleWeapons[3], _nobackground);
		GUIStyle textStyle = new GUIStyle();
		textStyle.fontSize = 50;
		textStyle.alignment = TextAnchor.UpperCenter;
		GUI.TextArea(new Rect (0,ScreenExt.Height(10.89f),ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f)), PlayerPrefs.GetInt("extintorNivel2").ToString(),textStyle);
		if(GUI.Button(new Rect (ScreenExt.Width(8.88889f),0,ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f)), "+",textStyle))
			PlayerPrefs.SetInt("extintorNivel2", PlayerPrefs.GetInt("extintorNivel2")+1);
		if(GUI.Button(new Rect (ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f*2),ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f)), "-",textStyle))
			PlayerPrefs.SetInt("extintorNivel2", PlayerPrefs.GetInt("extintorNivel2")-1);
		if(PlayerPrefs.GetInt("extintorNivel2") <= 0)
			PlayerPrefs.SetInt("extintorNivel2",0);
	}

	void DollLevel2()
	{
		GUI.Box(new Rect (ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f),ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f)),_aviabbleWeapons[4], _nobackground);
		GUIStyle textStyle = new GUIStyle();
		textStyle.fontSize = 50;
		textStyle.alignment = TextAnchor.UpperCenter;
		GUI.TextArea(new Rect (0,ScreenExt.Height(10.89f),ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f)), PlayerPrefs.GetInt("muñecaNivel2").ToString(),textStyle);
		if(GUI.Button(new Rect (ScreenExt.Width(8.88889f),0,ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f)), "+",textStyle))
			PlayerPrefs.SetInt("muñecaNivel2", PlayerPrefs.GetInt("muñecaNivel2")+1);
		if(GUI.Button(new Rect (ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f*2),ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f)), "-",textStyle))
			PlayerPrefs.SetInt("muñecaNivel2", PlayerPrefs.GetInt("muñecaNivel2")-1);
		if(PlayerPrefs.GetInt("muñecaNivel2") <= 0)
			PlayerPrefs.SetInt("muñecaNivel2",0);
	}

	void StrogLevel2()
	{
		GUI.Box(new Rect (ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f),ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f)),_aviabbleWeapons[5], _nobackground);
		GUIStyle textStyle = new GUIStyle();
		textStyle.fontSize = 50;
		textStyle.alignment = TextAnchor.UpperCenter;
		GUI.TextArea(new Rect (0,ScreenExt.Height(10.89f),ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f)), PlayerPrefs.GetInt("chupitoNivel2").ToString(),textStyle);
		if(GUI.Button(new Rect (ScreenExt.Width(8.88889f),0,ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f)), "+",textStyle))
			PlayerPrefs.SetInt("chupitoNivel2", PlayerPrefs.GetInt("chupitoNivel2")+1);
		if(GUI.Button(new Rect (ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f*2),ScreenExt.Width(8.88889f),ScreenExt.Height(10.89f)), "-",textStyle))
			PlayerPrefs.SetInt("chupitoNivel2", PlayerPrefs.GetInt("chupitoNivel2")-1);
		if(PlayerPrefs.GetInt("chupitoNivel2") <= 0)
			PlayerPrefs.SetInt("chupitoNivel2",0);
	}

}
