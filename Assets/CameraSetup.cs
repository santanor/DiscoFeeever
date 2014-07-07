using UnityEngine;
using System.Collections;

public class CameraSetup : MonoBehaviour {

    public float TARGET_WIDTH = 960;
    public float TARGET_HEIGHT = 640;
    public int PIXELS_TO_UNITS = 1; // 1:1 ratio of pixels to units
 // Use this for initialization
    void Update()
    {
        float desiredRatio = TARGET_WIDTH / TARGET_HEIGHT;
        float currentRatio = (float)Screen.width / (float)Screen.height;

        if (currentRatio >= desiredRatio)
        {
            // Our resolution has plenty of width, so we just need to use the height to determine the camera size
            Camera.main.orthographicSize = TARGET_HEIGHT / 2 / PIXELS_TO_UNITS;
        }
        else
        {
            // Our camera needs to zoom out further than just fitting in the height of the image.
            // Determine how much bigger it needs to be, then apply that to our original algorithm.
            float differenceInSize = desiredRatio / currentRatio;
            Camera.main.orthographicSize = TARGET_HEIGHT / 2 / PIXELS_TO_UNITS * differenceInSize;
        }
    }
}

