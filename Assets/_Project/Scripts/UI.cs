using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static Transform main {  get; private set; }

    private static Dictionary<PadPageType, GameObject> openedPanels;


    private void Awake()
    {
        openedPanels = new Dictionary<PadPageType, GameObject>();
        main = transform;
    }


    public static void OpenPanel(PadPageType panelType)
    {
        openedPanels.Add(panelType, Instantiate(GameResources.GetPanel(panelType), main));
    }

    public static void ClosePanel(PadPageType panelType)
    {
        var panel = openedPanels[panelType];
        openedPanels.Remove(panelType);
        Destroy(panel);
    }



}
