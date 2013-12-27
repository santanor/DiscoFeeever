using UnityEngine;

public class ScreenExtension
{
    public static float GetPercentHeight(float percent)
    {
        return (Screen.height * percent) / 100;
    }

    public static float GetPercentWidth(float percent)
    {
        return (Screen.width * percent) / 100;
    }
}