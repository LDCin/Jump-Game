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

    [Header("UI")]
    [SerializeField] private Transform _characterScrollContent;
    [SerializeField] private Transform _mapScrollContent;
    [SerializeField] private ShopSlot _slotPrefab;

    private Color activeRed = new Color(0.9f, 0.2f, 0.2f, 1f);
    private Color inactiveRed = new Color(0.5f, 0.1f, 0.1f, 1f);

    [Header("Logic")]
    private Animator _animator;
    private bool _isInitCharacter = false;
    private bool _isInitMap = false;
    private List<ShopSlot> _characterSlots = new List<ShopSlot>();
    private List<ShopSlot> _mapSlots = new List<ShopSlot>();
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        // _animator.SetTrigger("Start");
        ShowCharacterView();
    }
    public void OnCharacterSlotClicked(ShopSlot slot)
    {
        Debug.Log("Click on: " + slot.GetItemName());
        SelectCharacter(slot.GetItemName());
    }

    public void OnMapSlotClicked(ShopSlot slot)
    {
        Debug.Log("Click on: " + slot.GetItemName());
        SelectMap(slot.GetItemName());
    }
    public void OnSlotClicked(ShopSlot slot)
    {
        if (slot.IsCharacter())
        {
            OnCharacterSlotClicked(slot);
        }
        else
        {
            OnMapSlotClicked(slot);
        }
    }
    private void SelectCharacter(string characterName)
    {
        CharacterData character = CustomManager.Instance.GetCharacter(characterName);

        foreach (var slot in _characterSlots)
        {
            slot.SetSelect(slot.GetItemName() == character.characterName);
        }

        _selectedItemImage.sprite = character.sprite;
        _selectedItemName.text = character.characterName;

        PlayerPrefs.SetString("CurrentCharacter", character.characterName);
        PlayerPrefs.Save();
    }

    private void SelectMap(string mapName)
    {
        MapData map = CustomManager.Instance.GetMap(mapName);

        foreach (var slot in _mapSlots)
        {
            slot.SetSelect(slot.GetItemName() == map.mapName);
        }

        _selectedItemImage.sprite = map.icon;
        _selectedItemName.text = map.mapName;

        PlayerPrefs.SetString("CurrentMap", map.mapName);
        PlayerPrefs.Save();
    }
    private void CreateCharacterSlots(List<CharacterData> characterList)
    {
        foreach (var character in characterList)
        {
            ShopSlot slot = Instantiate(_slotPrefab, _characterScrollContent);
            slot.SetIcon(character.icon, character.characterName, true);
            slot.GetComponent<Button>().onClick.AddListener(() => OnSlotClicked(slot));
            _characterSlots.Add(slot);
        }
    }
    private void CreateMapSlots(List<MapData> mapList)
    {
        foreach (var map in mapList)
        {
            ShopSlot slot = Instantiate(_slotPrefab, _mapScrollContent);
            slot.SetIcon(map.icon, map.mapName, false);
            slot.GetComponent<Button>().onClick.AddListener(() => OnSlotClicked(slot));
            _mapSlots.Add(slot);
        }
    }
    public void ShowCharacterView()
    {
        if (!_isInitCharacter)
        {
            CreateCharacterSlots(CustomManager.Instance._characterDataList);
            _isInitCharacter = true;
        }
        SelectCharacter(GameConfig.CURRENT_CHARACTER_NAME);
        SoundManager.Instance.PlayClickSound();
        _characterCustom.SetActive(true);
        _mapCustom.SetActive(false);
        SetTabColors(_characterTab, _mapTab);
    }
    public void ShowBackgroundView()
    {
        // _animator.enabled = false;
        if (!_isInitMap)
        {
            CreateMapSlots(CustomManager.Instance._mapDataList);
            _isInitMap = true;
        }
        SelectMap(GameConfig.CURRENT_MAP_NAME);
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
        // _animator.enabled = true;
        SoundManager.Instance.PlayClickSound();
        Close();
    }
}
