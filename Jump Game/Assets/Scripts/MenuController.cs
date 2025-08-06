using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _menuCanvas;
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private GameObject _noAdsPanel;
    private void Start()
    {
        _menuCanvas.SetActive(true);
        BackToMenu();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void Shop()
    {
        _mainMenuPanel.SetActive(false);
        _shopPanel.SetActive(true);
    }
    public void Setting()
    {
        _mainMenuPanel.SetActive(false);
        _settingPanel.SetActive(true);
    }
    public void NoAds()
    {
        _mainMenuPanel.SetActive(false);
        _noAdsPanel.SetActive(true);
    }
    public void BackToMenu()
    {
        _mainMenuPanel.SetActive(true);
        _shopPanel.SetActive(false);
        _settingPanel.SetActive(false);
        _noAdsPanel.SetActive(false);
    }
}