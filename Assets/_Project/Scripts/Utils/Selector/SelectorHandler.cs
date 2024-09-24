using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public abstract class SelectorHandler : MonoBehaviour
{
    public Button Button { get; private set; }


    protected virtual void Awake()
    {
        Button = GetComponent<Button>();
    }


    public abstract void Select();

}