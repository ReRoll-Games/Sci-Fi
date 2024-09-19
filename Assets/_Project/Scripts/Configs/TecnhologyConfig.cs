using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Project/Configs/Tecnhologies", fileName = "Tecnhologies")]
public class TecnhologyConfig : ScriptableObject
{
    [field: SerializeField] public TechnologyType technologyType { get; private set; }
    [SerializeField] private List<ItemPack> _requiredItems;
    [SerializeField] private Sprite _iconSprite;
    [SerializeField] private string _title;
    [SerializeField] private string _description;
    


    public List<ItemPack> GetRequiredItems(int level) => _requiredItems;

    public string GetDescription(int level) => _description;

    public string GetTitle(int level) => _title;

    public Sprite GetIconSprite(int level) => _iconSprite;


}
