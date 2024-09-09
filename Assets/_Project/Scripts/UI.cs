using UnityEngine;

public class UI : MonoBehaviour
{
    public static Transform container {  get; private set; }

    private void Awake()
    {
        container = transform;
    }

}
