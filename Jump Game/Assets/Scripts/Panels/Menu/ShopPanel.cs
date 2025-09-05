using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : Panel
{
    [SerializeField] private Button _characterTab;
    [SerializeField] private Button _mapTab;

    [SerializeField] private Image _selectedItemImage;
    [SerializeField] private TextMeshProUGUI _selectedItemName;

    [SerializeField] private GameObject _characterCustom;
    [SerializeField] private GameObject _mapCustom;

    [Header("Character UI")]
    [SerializeField] private Transform _characterScrollContent;
    [SerializeField] private Transform _mapScrollContent;
    [SerializeField] private GameObject _slotPrefab;

    private Color activeRed = new Color(0.9f, 0.2f, 0.2f, 1f);
    private Color inactiveRed = new Color(0.5f, 0.1f, 0.1f, 1f);

    [Header("Logic")]
    private bool _isInitCharacter = false;
    private bool _isInitMap = false;

    private void Start()
    {
        ShowCharacterView();
        SelectCharacter(GameConfig.DEFAULT_CHARACTER_NAME);
        SelectMap(GameConfig.DEFAULT_MAP_NAME);
    }
    private void SelectCharacter(string characterName)
    {
        OnCharacterSelected(CustomManager.Instance.GetCharacter(characterName));
    }
    private void SelectMap(string mapName)
    {
        OnMapSelected(CustomManager.Instance.GetMap(mapName));
    }
    private void OnCharacterSelected(CharacterData character)
    {
        _selectedItemImage.sprite = character.sprite;
        _selectedItemName.text = character.characterName;

        PlayerPrefs.SetString("CurrentCharacter", character.characterName);
        PlayerPrefs.Save();
    }
    private void OnMapSelected(MapData map)
    {
        _selectedItemImage.sprite = map.icon;
        _selectedItemName.text = map.mapName;

        PlayerPrefs.SetString("CurrentMap", map.mapName);
        PlayerPrefs.Save();
    }
    private void CreateCharacterSlots(List<CharacterData> characterList)
    {
        foreach (var character in characterList)
        {
            GameObject slot = Instantiate(_slotPrefab, _characterScrollContent);

            Transform iconTransform = slot.transform.Find("Image - Icon");
            if (iconTransform != null)
            {
                Debug.Log("Found Image");
                Image iconImage = iconTransform.GetComponent<Image>();
                if (iconImage != null)
                    iconImage.sprite = character.icon;
            }

            Button btn = slot.GetComponent<Button>();
            if (btn != null)
            {
                btn.onClick.AddListener(() => OnCharacterSelected(character));
            }
        }
    }

    private void CreateMapSlots(List<MapData> mapList)
    {
        foreach (var map in mapList)
        {
            GameObject slot = Instantiate(_slotPrefab, _mapScrollContent);

            Transform iconTransform = slot.transform.Find("Image - Icon");
            if (iconTransform != null)
            {
                Image iconImage = iconTransform.GetComponent<Image>();
                if (iconImage != null)
                    iconImage.sprite = map.icon;
            }

            Button btn = slot.GetComponent<Button>();
            if (btn != null)
            {
                btn.onClick.AddListener(() => OnMapSelected(map));
            }
            Debug.Log($"Creating slot for {map.name}, iconTransform: {iconTransform}");

        }
    }
    public void ShowCharacterView()
    {
        if (!_isInitCharacter)
        {
            CreateCharacterSlots(CustomManager.Instance._characterDataList);
            _isInitCharacter = true;
        }
        SoundManager.Instance.PlayClickSound();
        _characterCustom.SetActive(true);
        _mapCustom.SetActive(false);
        SetTabColors(_characterTab, _mapTab);
    }
    public void ShowBackgroundView()
    {
        if (!_isInitMap)
        {
            CreateMapSlots(CustomManager.Instance._mapDataList);
            _isInitMap = true;
        }
        SoundManager.Instance.PlayClickSound();
        _characterCustom.SetActive(false);
        _mapCustom.SetActive(true);
        SetTabColors(_mapTab, _characterTab);
    }
    private void SetTabColors(Button active, Button inactive)
    {
        active.image.color = activeRed;
        inactive.image.color = inactiveRed;
    }
    public void BackToMenu()
    {
        SoundManager.Instance.PlayClickSound();
        Close();
    }
}
