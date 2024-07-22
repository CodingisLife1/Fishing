using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New UpgradeData", menuName = "Upgrade Data", order = 52)]
public class UpgradeData : ScriptableObject
{
    public int currentLevel;
    public int nextLevel;
    public float cost;
    public float incomePerSecond;

    
}
