using UnityEngine;


[CreateAssetMenu(menuName = "Project/Configs/Tecnhologies", fileName = "Tecnhologies")]
public class TecnhologyConfig : ScriptableObject
{
    [field: SerializeField] public TechnologyType technologyType { get; private set; }
    [field: SerializeField] public TechnologyType unlockTechnology { get; private set; }
    [field: SerializeField] public int price { get; private set; }

}
