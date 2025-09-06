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
    [SerializeField] private GameObject _slotPrefab;

    private Color activeRed = new Color(0.9f, 0.2f, 0.2f, 1f);
    private Color inactiveRed = new Color(0.5f, 0.1f, 0.1f, 1f);

    [Header("Logic")]
    private Animator _animator;
    private bool _isInitCharacter = false;
    private bool _isInitMap = false;
    private List<GameObject> _characterSlots = new List<GameObject>();
    private List<GameObject> _mapSlots = new List<GameObject>();
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        // _animator.SetTrigger("Start");
        ShowCharacterView();
    }
    private void SelectCharacter(string characterName)
    {
        CharacterData character = CustomManager.Instance.GetCharacter(characterName);

        foreach (var slot in _characterSlots)
        {
            var icon = slot.transform.Find("Image - Icon")?.GetComponent<Image>();
            if (icon != null && icon.sprite == character.icon)
            {
                OnCharacterSelected(character, slot);
                break;
            }
        }
    }
    private void SelectMap(string mapName)
    {
        MapData map = CustomManager.Instance.GetMap(mapName);

        foreach (var slot in _mapSlots)
        {
            var icon = slot.transform.Find("Image - Icon")?.GetComponent<Image>();
            if (icon != null && icon.sprite == map.icon)
            {
                OnMapSelected(map, slot);
                break;
            }
        }
    }
    private void OnCharacterSelected(CharacterData character, GameObject selectedSlot)
    {
        _selectedItemImage.sprite = character.sprite;
        _selectedItemName.text = character.characterName;

        foreach (var slot in _characterSlots)
        {
            var icon = slot.transform.Find("Image - SelectedIcon");
            icon.gameObject.SetActive(false);
        }

        var selectedIcon = selectedSlot.transform.Find("Image - SelectedIcon");
        selectedIcon.gameObject.SetActive(true);
        PlayerPrefs.SetString("CurrentCharacter", character.characterName);
        PlayerPrefs.Save();
    }
    private void OnMapSelected(MapData map, GameObject selectedSlot)
    {
        _selectedItemImage.sprite = map.icon;
        _selectedItemName.text = map.mapName;

        foreach (var slot in _mapSlots)
        {
            var icon = slot.transform.Find("Image - SelectedIcon");
            icon.gameObject.SetActive(false);
        }

        var selectedIcon = selectedSlot.transform.Find("Image - SelectedIcon");
        selectedIcon.gameObject.SetActive(true);
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
            Transform selectedIconTransform = slot.transform.Find("Image - SelectedIcon");
            if (selectedIconTransform != null)
            {
                Debug.Log("Found Image");
                selectedIconTransform.gameObject.SetActive(false);
            }
            
            Button btn = slot.GetComponent<Button>();
            if (btn != null)
            {
                btn.onClick.AddListener(() => OnCharacterSelected(character, slot));
            }
            _characterSlots.Add(slot);
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
            Transform selectedIconTransform = slot.transform.Find("Image - SelectedIcon");
            if (selectedIconTransform != null)
            {
                Debug.Log("Found Image");
                selectedIconTransform.gameObject.SetActive(false);
            }

            Button btn = slot.GetComponent<Button>();
            if (btn != null)
            {
                btn.onClick.AddListener(() => OnMapSelected(map, slot));
            }
            Debug.Log($"Creating slot for {map.name}, iconTransform: {iconTransform}");
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
