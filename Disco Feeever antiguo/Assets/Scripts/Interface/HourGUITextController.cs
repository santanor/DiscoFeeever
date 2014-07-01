using UnityEngine;
using System.Collections;

public class HourGUITextController : MonoBehaviour {

	int hour;
	float currentMinutes;

	public void SetHour(string hour)
	{
		this.hour = int.Parse (hour.Split (':') [0]);
	}

	public void IncrementateMinutes(float minutes)
	{
		this.currentMinutes = currentMinutes += minutes;
		string currentHour = "" + hour + ":" + (this.currentMinutes + minutes).ToString ();
		this.guiText.text = currentHour;
	}

}
