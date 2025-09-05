using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomManager : Singleton<CustomManager>
{
    public List<CharacterData> _characterDataList;
    public List<MapData> _mapDataList;

    public override void Awake()
    {
        base.Awake();
        InitCustom();
    }
    private void InitCustom()
    {
        _characterDataList = new List<CharacterData>(Resources.LoadAll<CharacterData>(GameConfig.CHARACTER_DATA_PATH));
        _mapDataList = new List<MapData>(Resources.LoadAll<MapData>(GameConfig.MAP_DATA_PATH));
    }
    public CharacterData GetCharacter(string characterName)
    {
        CharacterData character = _characterDataList.Find(ch => ch.characterName == characterName);
        if (character != null)
        {
            Debug.Log("Found Character: " + character.characterName);
            return character;
        }
        else
        {
            character = ScriptableObject.CreateInstance<CharacterData>();
            character.characterName = characterName;
            _characterDataList.Add(character);
        }
        return character;
    }
    public MapData GetMap(string mapName)
    {
        MapData map = _mapDataList.Find(m => m.mapName == mapName);
        if (map != null)
        {
            Debug.Log("Found Map: " + map.mapName);
            return map;
        }
        else
        {
            map = ScriptableObject.CreateInstance<MapData>();
            map.mapName = mapName;
            _mapDataList.Add(map);
        }
        return map;
    }
}
