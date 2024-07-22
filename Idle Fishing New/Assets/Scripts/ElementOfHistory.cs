using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ElementOfHistory : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI silverAmount_txt;
    [SerializeField] private TextMeshProUGUI goldAmount_txt;
    [SerializeField] private Image fishIcon;
    [SerializeField] private Image background;

    private void Start()
    {
        StartCoroutine(LifeTime());
    }

    public void FillElement(FishData data)
    {
        fishIcon.sprite = data.icon;
        silverAmount_txt.text = $"+ {ShortScaleString.parseDouble(Init.Instance.playerData.fishCost * data.multiplier, 2, 1000, true)}";
        goldAmount_txt.text = (Init.Instance.playerData.fishGoldCost * data.multiplier).ToString();
        background.color = data.color;
    }

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    }
}
