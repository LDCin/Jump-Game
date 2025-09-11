using System.Collections.Generic;
using UnityEngine;

public static class GameConfig
{
    // SCENE
    public static string GAME_SCENE = "Game";
    public static string MENU_SCENE = "Menu";

    // TAG
    public static string PLAYER_TAG = "Player";
    public static string WALL_TAG = "Wall";
    public static string OBSTACLE_TAG = "Obstacle";
    public static string DEAD_ZONE_TAG = "DeadZone";
    public static string SCORE_ZONE_TAG = "ScoreZone";

    //MAP
    public static Vector2 WALL_SIZE = new Vector2(0.2f, HALF_HEIGHT * 2);

    // CAMERA
    public static Camera CAM => Camera.main;
    public static Vector3 START_CAM_POSITION => CAM.transform.position;
    public static Vector3 CAM_POSITION => CAM.transform.position;
    public static float HALF_HEIGHT => CAM.orthographicSize;
    public static float HALF_WIDTH => CAM.aspect * HALF_HEIGHT;
    public static float LEFT_CAM => CAM_POSITION.x - HALF_WIDTH;
    public static float RIGHT_CAM => CAM_POSITION.x + HALF_WIDTH;
    public static float TOP_CAM => CAM_POSITION.y + HALF_HEIGHT;
    public static float BOT_CAM => CAM_POSITION.y - HALF_HEIGHT;
    public static float CAM_POSITION_MOVEMENT;

    // SCORE
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
    public static int BGM_STATE => PlayerPrefs.GetInt("BGMState", 1);
    public static int SFX_STATE => PlayerPrefs.GetInt("SFXState", 1);

    // CREDIT URL
    public static string CREDIT_URL = "https://github.com/LDCin";

    // CUSTOM
    public static string DEFAULT_CHARACTER_NAME = "Dog";
    public static string DEFAULT_MAP_NAME = "City";
    public static string CURRENT_CHARACTER_NAME => PlayerPrefs.GetString("CurrentCharacter", DEFAULT_CHARACTER_NAME);
    public static string CURRENT_MAP_NAME => PlayerPrefs.GetString("CurrentMap", DEFAULT_MAP_NAME);
    public static string CHARACTER_DATA_PATH = "ScriptableObjects/CharacterDatas/";
    public static string MAP_DATA_PATH = "ScriptableObjects/MapDatas/";
    public static CharacterData CURRENT_CHARACTER_DATA => CustomManager.Instance.GetCharacter(CURRENT_CHARACTER_NAME);
    public static MapData CURRENT_MAP_DATA => CustomManager.Instance.GetMap(CURRENT_MAP_NAME);
}