using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIHelper : MonoBehaviour
{
    public static UIHelper Instance;
    private void Awake()
    {
        Instance = this;
    }
    public bool IsPointerOverUI()
    {

        EventSystem eventSystem = EventSystem.current;

        PointerEventData eventData = new PointerEventData(eventSystem);
        eventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();

        eventSystem.RaycastAll(eventData, results);

        return results.Count > 0;
    }
}
