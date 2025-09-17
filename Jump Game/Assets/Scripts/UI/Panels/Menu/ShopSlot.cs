using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    // [SerializeField] private Button _slotButton;
    [SerializeField] private Image _selectIcon;
    [SerializeField] private Image _icon;
    private string _itemName;
    private bool _isCharacter = true;
    public Sprite GetIcon()
    {
        return _icon.sprite;
    }
    public void SetIcon(Sprite icon, string itemName, bool isCharacter)
    {
        _icon.sprite = icon;
        _itemName = itemName;
        _isCharacter = isCharacter;
    }
    public string GetItemName()
    {
        return _itemName;
    }
    public void SetSelect(bool value)
    {
        Debug.Log($"{_itemName} -> {(value ? "SELECTED" : "UNSELECTED")}");
        _selectIcon.gameObject.SetActive(value);
    }
    public bool IsCharacter()
    {
        return _isCharacter;
    }
}
