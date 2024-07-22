using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Category 
{ 
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary,
    Mythic
}

[CreateAssetMenu(fileName = "New FishData", menuName = "Fish Data", order = 51)]
public class FishData : ScriptableObject
{
    public Category rarity;
    public Sprite icon;
    public int multiplier;
    public Color color;
}
