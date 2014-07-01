using UnityEngine;

public class ScreenExt
{
    public static float Height(float percent)
    {
        return (Screen.height * percent) / 100;
    }

    public static float Width(float percent)
    {
        return (Screen.width * percent) / 100;
    }
}