using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Configs/Repair", fileName = "Repair")]
public class RepairConfig : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public string Description { get; private set; }

    [field: SerializeField] public List<ItemPack> ItemRequires { get; private set; }


}


public static partial class Configs
{
    public static RepairConfig GetRepairConfig(BuildingType buildingType)
        => Resources.Load<RepairConfig>($"Configs/Repairs/{buildingType}");
}
