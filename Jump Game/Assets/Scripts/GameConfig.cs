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

    // Camera
    public static Camera cam = Camera.main;
    public static Vector3 camPosition = cam.transform.position;
    public static float halfHeight = cam.orthographicSize;
    public static float halfWidth = cam.aspect * halfHeight;
    public static float leftCam = camPosition.x - halfWidth;
    public static float rightCam = camPosition.x + halfWidth;
    public static float topCam = camPosition.x + halfHeight;
    public static float botCam = camPosition.x - halfHeight;

    // Spawner
    public static List<Vector2> spawnList;


}