using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Entity _actor;
    [SerializeField] private int _iterations;


    private void Start()
    {
        Application.targetFrameRate = 30;
    }

    private void Update()
    {
        

    }



}
