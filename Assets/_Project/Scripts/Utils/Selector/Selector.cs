using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    [SerializeField] private Color _nonSelectionColor;
    [SerializeField] private Color _selectionColor;
    [SerializeField] private List<SelectorHandler> _handlers;


    private void Start()
    {
        for (int i = 0; i < _handlers.Count; i++)
        {
            _handlers[i].Button.onClick.AddListener(() =>
            {
                int index = i;
                Highlight(index);
                _handlers[i].Select();
            });
        }
    }

    public void Highlight(int handlerIndex)
    {
        for (int i = 0; i < _handlers.Count; i++)
        {
            bool highlight = i == handlerIndex;

            _handlers[i].Button.image.color = highlight ? _selectionColor : _nonSelectionColor;
            _handlers[i].Button.interactable = !highlight;
        }
    }


}
