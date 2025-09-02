using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : Singleton<PanelManager>
{
    private Dictionary<string, Panel> panelList = new Dictionary<string, Panel>();
    public override void Awake()
    {
        // Time.timeScale = 0;
        base.Awake();
        var existPanels = GetComponentsInChildren<Panel>();
        foreach (var panel in existPanels)
        {
            panelList[panel.name] = panel;
        }
    }
    public void Start()
    {
        CloseAllPanel();
        OpenPanel(GameConfig.MENU_PANEL);
    }
    private bool IsAvailable(string namePanel)
    {
        return panelList.ContainsKey(namePanel);
    }
    public Panel GetPanel(string namePanel)
    {
        if (IsAvailable(namePanel))
        {
            Debug.Log(namePanel + " is available");
            return panelList[namePanel];
        }

        Panel panel;
        panel = Resources.Load<Panel>(GameConfig.PANEL_PATH + GameConfig.MENU_PANEL_PATH + namePanel);
        if (panel == null)
        {
            panel = Resources.Load<Panel>(GameConfig.PANEL_PATH + GameConfig.GAME_PANEL_PATH + namePanel);
        }

        if (panel == null)
        {
            Debug.Log("Not Found: " + namePanel);
        }
        Panel newPanel = Instantiate(panel, transform);
        newPanel.transform.SetAsLastSibling();
        newPanel.gameObject.SetActive(false);
        
        newPanel.SetPanelName(namePanel);

        panelList[namePanel] = newPanel;
        foreach (String panel_ in panelList.Keys)
        {
            Debug.Log(panel_);
        }
        return newPanel;
    }
    public void OpenPanel(string namePanel)
    {
        Panel panel = GetPanel(namePanel);
        panel.Open();
    }
    public void ClosePanel(string namePanel)
    {
        Panel panel = GetPanel(namePanel);
        panel.Close();
    }
    public void CloseAllPanel()
    {
        foreach (var panel in panelList.Values)
        {
            panel.Close();
        }
    }
    public void RemovePanel(string namePanel)
    {
        if (IsAvailable(namePanel))
        {
            panelList.Remove(namePanel);
        }
    }
}
