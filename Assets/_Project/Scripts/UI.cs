using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static Transform main {  get; private set; }

    private static Dictionary<PanelType, GameObject> openedPanels;


    private void Awake()
    {
        openedPanels = new Dictionary<PanelType, GameObject>();
        main = transform;
    }


    public static void OpenPanel(PanelType panelType)
    {
        openedPanels.Add(panelType, Instantiate(GameResources.GetPanel(panelType), main));
    }

    public static void ClosePanel(PanelType panelType)
    {
        var panel = openedPanels[panelType];
        openedPanels.Remove(panelType);
        Destroy(panel);
    }



}
