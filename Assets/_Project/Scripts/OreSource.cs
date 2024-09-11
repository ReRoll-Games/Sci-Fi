using System.Collections.Generic;
using UnityEngine;

public class OreSource : MonoBehaviour
{
    public static List<OreSource> all = new List<OreSource>();

    [field: SerializeField] public ItemType itemType { get; private set; }

    private void OnEnable()
    {
        all.Add(this);
    }

    private void OnDisable()
    {
        all.Remove(this);
    }




}
