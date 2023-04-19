using UnityEngine;

public static class LayoutMng
{
    public static Vector2 btnPosition1 = new Vector2(Screen.width* 0.25f, Screen.height / 2);
    public static Vector2 btnPosition2 = new Vector2(Screen.width * 0.75f, Screen.height / 2);
    public static Vector2 btnPosition3 = new Vector2(Screen.width * 0.5f, Screen.height * 0.2f);

    public static Vector2 topMiddle = new Vector2(Screen.width * 0.5f, Screen.height * 0.9f);
    public static Vector2 topMiddleLeft = new Vector2(Screen.width * 0.38f, Screen.height * 0.9f);
    public static Vector2 topMiddleRight = new Vector2(Screen.width * 0.62f, Screen.height * 0.9f);
    public static Vector2 verticalLine = new Vector2(Screen.width * 0.015f, Screen.height);

    public static void refreshCoordinates()
    {
        btnPosition1 = new Vector2(Screen.width * 0.25f, Screen.height / 2);
        btnPosition2 = new Vector2(Screen.width * 0.75f, Screen.height / 2);
        btnPosition3 = new Vector2(Screen.width * 0.5f, Screen.height * 0.2f);

        topMiddle = new Vector2(Screen.width * 0.5f, Screen.height * 0.9f);
        topMiddleLeft = new Vector2(Screen.width * 0.38f, Screen.height * 0.9f);
        topMiddleRight = new Vector2(Screen.width * 0.62f, Screen.height * 0.9f);
    }
}
