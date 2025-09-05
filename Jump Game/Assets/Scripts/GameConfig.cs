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
    public static string HIGH_SCORE = "HighScore";
    public static string SCORE = "Score";

    public static int GET_HIGH_SCORE => PlayerPrefs.GetInt(HIGH_SCORE, 0);
    public static int GET_SCORE => PlayerPrefs.GetInt(SCORE, 0);

    // PATH
    // - PREFABS
    public static string PREFABS_PATH = "Prefabs/";
    public static string GAME_MANAGER = "GameManager";
    // - PANEL
    public static string PANEL_PATH = "Prefabs/UI/Panels/";
    public static string GAME_PANEL_PATH = "Game/";
    public static string SCORE_PANEL = "Panel-ScoreGame";
    public static string GAME_OVER_PANEL = "Panel-GameOver";
    public static string PAUSE_PANEL = "Panel-PauseGame";
    public static string DEFAULT_PANEL = "Panel-DefaultGame";
    public static string MENU_PANEL_PATH = "Menu/";
    public static string MENU_PANEL = "Panel-Menu";
    public static string SHOP_PANEL = "Panel-Shop";
    public static string NOADS_PANEL = "Panel-NoAds";
    public static string SETTING_PANEL = "Panel-Setting";

    // - OBSTACLE
    public static string OBSTACLE_PATH = "Prefabs/Obstacle/";
    public static string OBSTACLE_SPAWNER = "ObstacleSpawner";
    public static string OBSTACLE_POOL = "ObstaclePool";
    public static string OBSTACLE = "Obstacle";

    // SOUND
    public static string AUDIO_PATH = "Sounds/";
    public static string BGM_PATH = "BGM";
    public static string CLICK_SOUND = "ClickSound";
    public static AudioClip[] audioClipList = Resources.LoadAll<AudioClip>(AUDIO_PATH);
    public static AudioClip BGM_SOUND = Resources.Load<AudioClip>(AUDIO_PATH + BGM_PATH);

    // CREDIT URL
    public static string CREDIT_URL = "https://github.com/LDCin";

    // CUSTOM
    public static string DEFAULT_CHARACTER_NAME = "Dog";
    public static string DEFAULT_MAP_NAME = "City";
    public static string CURRENT_CHARACTER_NAME => PlayerPrefs.GetString("CurrentCharacter", DEFAULT_CHARACTER_NAME);
    public static string CURRENT_MAP_NAME => PlayerPrefs.GetString("CurrentMap", DEFAULT_MAP_NAME);
    public static string CHARACTER_DATA_PATH = "ScriptableObjects/CharacterDatas/";
    public static string MAP_DATA_PATH = "ScriptableObjects/MapDatas/";
}