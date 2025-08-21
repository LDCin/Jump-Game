// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;

// // public class PanelManager : MonoBehaviour
// // {
// //     public static PanelManager _instance;

// //     Dictionary<string, Panel> _panelList;
// //     [SerializeField] private GameObject _gameOverPanel;

// //     private void Start()
// //     {
// //         _instance = this;
// //         InitPanelList();
// //         // Open(GetPanel())
// //     }
// //     private void InitPanelList()
// //     {
// //         Panel[] _panelLookUp = Resources.LoadAll<Panel>(GameConfig.PANEL_PATH);
// //         for (int i = 0; i < _panelLookUp.Length; i++)
// //         {
// //             _panelList[_panelLookUp[i].name] = _panelLookUp[i];
// //             _panelList[_panelLookUp[i].name].gameObject.SetActive(false);
// //         }
// //     }
// //     public Panel GetPanel(string panelName)
// //     {
// //         Panel panel = _panelList[panelName];
// //         if (panel != null)
// //         {
// //             return panel;
// //         }
// //         Panel newPanel = new Panel();
// //         _panelList["New Panel" + Random.Range(0, 100000)] = newPanel;
// //         return newPanel;
// //     }
// //     public void Open(string panelName)
// //     {
// //         _panelList[panelName].OpenPanel();
// //     }
// //     public void Close(string panelName)
// //     {
// //         _panelList[panelName].ClosePanel();
// //     }
    
// // }

// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PanelManager : Singleton<PanelManager>
// {
//     public Dictionary<string, Panel> panels = new();

//     private void Start()
//     {
//         var list = GetComponentsInChildren<Panel>();
//         foreach(var panel in list)
//         {
//             panels[panel.name] = panel;
//         }
//     }

//     public Panel GetPanel(string name)
//     {
//         if (IsExisted(name))
//         {
//             return panels[name];
//         }
//         //Load panel len tu resources
//         Panel panel = Resources.Load<Panel>("Panels/" + name);
//         //Debug.Log("Load thành công Panel: " + (transform == null) + " " + (panel == null));
//         //Sinh ra mot ban sao
//         Panel newPanel = Instantiate(panel, transform);
//         newPanel.transform.SetAsLastSibling();
//         newPanel.name = name;
//         newPanel.gameObject.SetActive(false);

//         //luu lai vao trong map
//         panels[name] = newPanel;
//         return newPanel;
//     }

//     public void RemovePanel(string name)
//     {
//         if (IsExisted(name))
//         {
//             panels.Remove(name);
//         }
//     }

//     public void OpenPanel(string name)
//     {
//         Panel panel = GetPanel(name);
//         panel.Open();
//     }

//     public void ClosePanel(string name)
//     {
//         Panel panel = GetPanel(name);
//         panel.Close();
//     }

//     public void CloseAll()
//     {
//         foreach (var panel in panels.Values)
//         {
//             panel.Close();
//         }
//     }

//     private bool IsExisted(string name)
//     {
//         return panels.ContainsKey(name);
//     }

// }