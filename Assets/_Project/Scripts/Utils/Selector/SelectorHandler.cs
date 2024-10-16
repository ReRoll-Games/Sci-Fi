using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public abstract class SelectorHandler : MonoBehaviour
{
    private Button _button;

    public Button Button 
    {  
        get
        {
            _button ??= GetComponent<Button>();
            return _button;
        }
    }

    public abstract void Select();

}