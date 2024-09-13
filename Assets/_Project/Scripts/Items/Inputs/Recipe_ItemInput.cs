using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VG;

public class Recipe_ItemInput : ItemInput
{
    [SerializeField] private Building _building;

    private ItemType _itemForDrop;
    private RecipeProcess _currentRecipe;

    protected override bool inputAvailable
    {
        get
        {
            _currentRecipe = Saves.GetRecipeProcess(_building.index);
            for (int i = 0; i < _currentRecipe.inputItems.Count; i++)
                if (Inventory.HasItem(_currentRecipe.inputItems[i].itemType))
                {
                    _itemForDrop = _currentRecipe.inputItems[i].itemType;
                    return true;
                }

            return false;
        }
    }

    protected override ItemType dropItemType => _itemForDrop;

    protected override void OnItemDropped(ItemType itemType)
    {
        for (int i = 0; i < _currentRecipe.inputItems.Count; i++)
            if (_currentRecipe.inputItems[i].itemType == itemType)
            {
                var itemFullness = _currentRecipe.inputItems[i];
                itemFullness.quantity++;
                _currentRecipe.inputItems[i] = itemFullness;
                break;
            }

        Saves.SetRecipeProcess(_building.index, _currentRecipe);
    }


}
