using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Project/Configs/Tecnhology", fileName = "Tecnhology")]
public class TecnhologyConfig : ScriptableObject
{
    [field: SerializeField] public List<ItemPack> RequiredItems { get; private set; }
    [field: SerializeField] public Sprite IconSprite { get; private set; }

    [SerializeField] private string _title;
    [SerializeField] private string _description;


    public string Title => _title;
    public string Description => _description;


}
