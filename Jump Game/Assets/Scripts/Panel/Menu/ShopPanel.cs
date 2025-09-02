using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : Panel
{
    [SerializeField] private GameObject _characterCustom;
    [SerializeField] private GameObject _backgroundCustom;
    [SerializeField] private Button _characterTab;
    [SerializeField] private Button _backgroundTab;
    private Color activeRed = new Color(0.9f, 0.2f, 0.2f, 1f);
    private Color inactiveRed = new Color(0.5f, 0.1f, 0.1f, 1f);

    public void Start()
    {
        ShowCharacterPanel();
    }
    public void ShowCharacterPanel()
    {
        SoundManager.Instance.PlayClickSound();
        _characterCustom.SetActive(true);
        _backgroundCustom.SetActive(false);
        SetTabColors(_characterTab, _backgroundTab);
    }
    public void ShowBackgroundPanel()
    {
        SoundManager.Instance.PlayClickSound();
        _characterCustom.SetActive(false);
        _backgroundCustom.SetActive(true);
        SetTabColors(_backgroundTab, _characterTab);
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
