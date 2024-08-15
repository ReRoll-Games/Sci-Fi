using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public delegate void OnMove(Vector2 direction);
    public static event OnMove onMove;
    public static event Action onAttack;




    private void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        if (Mathf.Approximately(horizontalMove, 0f) == false
            || Mathf.Approximately(verticalMove, 0f) == false)
            onMove?.Invoke(new Vector2(horizontalMove, verticalMove));

        if (Input.GetMouseButtonDown(0)) onAttack?.Invoke();


    }




}
