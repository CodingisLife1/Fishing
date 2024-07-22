using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradableElement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI level_txt;
    [SerializeField] private TextMeshProUGUI cost_txt;
    [SerializeField] private TextMeshProUGUI incomePerSecond_txt;
    [SerializeField] private UpgradeData data;


    void Start()
    {
        UpdateData();
    }

    public void BuyUpgrade()
    {
        if (Init.Instance.playerData.silverAmount >= data.cost)
        {
            Init.Instance.playerData.silverAmount -= data.cost;
            Init.Instance.uiManager.silverAmount_txt.text = ShortScaleString.parseFloat(Init.Instance.playerData.silverAmount, 2, 1000, true);

            Init.Instance.playerData.silverPerSecond += data.incomePerSecond;
            Init.Instance.uiManager.silverPerSecond_txt.text = ShortScaleString.parseFloat(Init.Instance.playerData.silverPerSecond, 2, 1000, true);

            Init.Instance.playerData.fishCost += data.incomePerSecond * 0.1f;

            data.currentLevel++;

            if (data.currentLevel == 10)
            {
                data.nextLevel = 25;
            }
            else if (data.currentLevel == 25)
            {
                data.nextLevel = 50;
            }
            else if (data.currentLevel >= 50 && data.currentLevel % 50 == 0)
            {
                data.nextLevel += 50;
            }

            data.cost *= Mathf.Pow(1.2f, data.currentLevel + 1);

            data.incomePerSecond *= Mathf.Pow(1.14f, data.currentLevel + 1);

            UpdateData();
        }

        
    }

    public void UpdateData()
    {
        level_txt.text = $"{Math.Round(Convert.ToDouble(data.currentLevel), 2)}/{data.nextLevel}";
        cost_txt.text = ShortScaleString.parseFloat(data.cost, 2, 1000, true);
        incomePerSecond_txt.text = ShortScaleString.parseFloat(data.incomePerSecond, 2, 1000, true);
    }
}
