using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public static List<Unit> all { get; private set; } = new List<Unit>();


    [field: SerializeField] public Team Team { get; private set; }
    [field: SerializeField] public Health Health { get; private set; }
    [field: SerializeField] public Move Move { get; private set; }
    [field: SerializeField] public Weapon Weapon { get; private set; }
    [SerializeField] private Transform _pivot; public Vector3 Pivot => _pivot.position;

    public Vector2 Position2D => new Vector2(transform.position.x, transform.position.z);
    public Vector3 Position3D => transform.position;


    private void OnEnable() => all.Add(this);

    private void OnDisable() => all.Remove(this);





}
