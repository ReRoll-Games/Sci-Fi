using System;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public static List<Entity> everybody = new List<Entity>();



    [SerializeField] private List<EntityComponent> _components;

    private Dictionary<Type, EntityComponent> _componentsDictionary;


    private void Awake()
    {
        _componentsDictionary = new Dictionary<Type, EntityComponent>();

        foreach (var component in _components)
            _componentsDictionary.Add(component.GetType(), component);
    }

    private void OnEnable() => everybody.Add(this);

    private void OnDisable() => everybody.Remove(this);


    public bool Has<T>() where T : EntityComponent => _componentsDictionary.ContainsKey(typeof(T));
    public T Get<T>() where T : EntityComponent => (T)_componentsDictionary[typeof(T)];



    



}
