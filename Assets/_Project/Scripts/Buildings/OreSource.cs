using System.Collections.Generic;
using UnityEngine;

public class OreSource : MonoBehaviour
{
    public static List<OreSource> all = new List<OreSource>();



    private void OnEnable()
    {
        all.Add(this);
    }

    private void OnDisable()
    {
        all.Remove(this);
    }




}
