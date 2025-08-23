using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public static PanelManager _instance;
    private Dictionary<string, Panel> panelList = new Dictionary<string, Panel>();

    private void Awake()
    {
        _instance = this;
        var existPanels = GetComponentsInChildren<Panel>();
        foreach (var panel in existPanels)
        {
            panelList[panel.name] = panel;
        }
    }
    private bool IsAvailable(string namePanel)
    {
        return panelList.ContainsKey(namePanel);
    }
    public Panel GetPanel(string namePanel)
    {
        if (IsAvailable(namePanel))
        {
            return panelList[namePanel];
        }

        Panel panel = Resources.Load<Panel>(GameConfig.PANEL_PATH + namePanel);

        Panel newPanel = Instantiate(panel, transform);
        newPanel.transform.SetAsLastSibling();
        newPanel.gameObject.SetActive(false);

        panelList[namePanel] = newPanel;
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
