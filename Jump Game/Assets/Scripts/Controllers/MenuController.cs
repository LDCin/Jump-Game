using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    private Panel _currentPanel;
    private void Start()
    {
        PanelManager._instance.CloseAllPanel();
        string menuPanelPath = GameConfig.MENU_PANEL;
        PanelManager._instance.OpenPanel(menuPanelPath);
        _currentPanel = PanelManager._instance.GetPanel(menuPanelPath);
    }
    
}