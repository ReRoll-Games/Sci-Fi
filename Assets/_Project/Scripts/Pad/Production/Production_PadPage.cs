using System.Collections.Generic;
using UnityEngine;

public class Production_PadPage : MonoBehaviour
{
    public enum Section { Process, Recipes, Upgrade }


    [SerializeField] private GameObject _process;
    [SerializeField] private GameObject _recipes;
    [SerializeField] private GameObject _upgrade;

    private static Dictionary<Section, GameObject> _sections;



    private void Awake()
    {
        _sections = new Dictionary<Section, GameObject>()
        { 
            { Section.Process, _process },
            { Section.Recipes, _recipes },
            { Section.Upgrade, _upgrade }
        };
    }

    public static void SelectSection(Section section)
    {
        foreach (var item in _sections)
            item.Value.SetActive(item.Key == section);
    }



}
