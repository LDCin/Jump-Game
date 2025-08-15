using System.Collections.Generic;
using UnityEngine;

public static class GameConfig
{
    // Scene
    public static string GAME_SCENE = "Game";
    public static string MENU_SCENE = "Menu";

    // Tag
    public static string PLAYER_TAG = "Player";
    public static string WALL_TAG = "Wall";
    public static string OBSTACLE_TAG = "Obstacle";
    public static string DEAD_ZONE_TAG = "DeadZone";


    // Camera
    public static Camera cam = Camera.main;
    public static Vector3 camPosition = cam.transform.position;
    public static float halfHeight = cam.orthographicSize;
    public static float halfWidth = cam.aspect * halfHeight;
    public static float leftCam = camPosition.x - halfWidth;
    public static float rightCam = camPosition.x + halfWidth;
    public static float topCam = camPosition.y + halfHeight;
    public static float botCam = camPosition.y - halfHeight;

    // Score
    public static int HIGH_SCORE = PlayerPrefs.GetInt("HighScore", 0);


}