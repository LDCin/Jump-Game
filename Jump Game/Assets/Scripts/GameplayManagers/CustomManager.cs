using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomManager : Singleton<CustomManager>
{
    private List<CharacterData> _characterDataList;
    private List<MapData> _mapDataList;

    public override void Awake()
    {
        base.Awake();
        InitCustom();

    }
    private void InitCustom()
    {
        _characterDataList = new List<CharacterData>(Resources.LoadAll<CharacterData>(GameConfig.CHARACTER_DATA_PATH));
        _characterDataList = new List<CharacterData>(Resources.LoadAll<CharacterData>(GameConfig.MAP_DATA_PATH));
        PlayerPrefs.SetString("CurrentCharacter", GameConfig.DEFAULT_CHARACTER_NAME);
        PlayerPrefs.SetString("CurrrentMap", GameConfig.DEFAULT_MAP_NAME);
    }
}
