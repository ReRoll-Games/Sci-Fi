using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public delegate void OnMove(Vector2 direction);
    public static event OnMove onMove;




    private void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        if (Mathf.Approximately(horizontalMove, 0f) == false
            || Mathf.Approximately(verticalMove, 0f) == false)
            onMove?.Invoke(new Vector2(horizontalMove, verticalMove));
    }


}
