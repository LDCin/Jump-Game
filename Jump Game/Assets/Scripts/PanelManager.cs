using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    Dictionary<string, Panel> _panelList;

    private void Start()
    {
        InitPanelList();
        // Open(GetPanel())
    }
    private void InitPanelList()
    {
        Panel[] _panelLookUp = Resources.LoadAll<Panel>(GameConfig.PANEL_PATH);
        for (int i = 0; i < _panelLookUp.Length; i++)
        {
            _panelList[_panelLookUp[i].name] = _panelLookUp[i];
            _panelList[_panelLookUp[i].name].gameObject.SetActive(false);
        }
    }
    public Panel GetPanel(string panelName)
    {
        Panel panel = _panelList[panelName];
        if (panel != null)
        {
            return panel;
        }
        Panel newPanel = new Panel();
        _panelList["New Panel" + Random.Range(0, 100000)] = newPanel;
        return newPanel;
    }
    public void Open(string panelName)
    {
        _panelList[panelName].OpenPanel();
    }
    public void Close(string panelName)
    {
        _panelList[panelName].ClosePanel();
    }
}
