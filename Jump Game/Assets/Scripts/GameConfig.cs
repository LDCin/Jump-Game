using System.Collections.Generic;
using UnityEngine;

public static class GameConfig
{
    // Scene
    public static string GAME_SCENE = "Game";
    // Tag
    public static string PLAYER_TAG = "Player";
    public static string WALL_TAG = "Wall";
    public static string OBSTACLE_TAG = "Obstacle";
    public static string DEAD_ZONE_TAG = "DeadZone";


    // Camera
    public static Camera cam => Camera.main;
    public static Vector3 startCamPosition => cam.transform.position;
    public static Vector3 camPosition => cam.transform.position;
    public static float halfHeight => cam.orthographicSize;
    public static float halfWidth => cam.aspect * halfHeight;
    public static float leftCam => camPosition.x - halfWidth;
    public static float rightCam => camPosition.x + halfWidth;
    public static float topCam => camPosition.y + halfHeight;
    public static float botCam => camPosition.y - halfHeight;
    public static float camPositionMovement;

    // Score
    public static int HIGH_SCORE = PlayerPrefs.GetInt("HighScore", 0);
    public static int SCORE = PlayerPrefs.GetInt("Score", 0);

    // PATH
    public static string PANEL_PATH = "Prefabs/UI/";
    public static string GAME_PANEL_PATH = "Game/";
    public static string SCORE_PANEL = "Game/Panel-Score";
    public static string GAME_OVER_PANEL = "Game/Panel-GameOver";
    public static string PAUSE_PANEL = "Game/Panel-PauseGame";
    public static string MENU_PANEL_PATH = "Menu/";
    public static string MENU_PANEL = "Menu/Panel-Menu";
    public static string SHOP_PANEL = "Menu/Panel-Shop";
    public static string NOADS_PANEL = "Menu/Panel-NoAds";
    public static string SETTING_PANEL = "Menu/Panel-Setting";
}