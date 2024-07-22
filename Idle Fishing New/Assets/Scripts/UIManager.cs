using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI silverAmount_txt;
    public TextMeshProUGUI silverPerSecond_txt;
    public TextMeshProUGUI goldAmount_txt;

    [SerializeField] private GameObject[] shopSections;
    [SerializeField] private Button buildingUpgrades_button;
    [SerializeField] private Button restartUpgrades_button;

    private void Start()
    {
        buildingUpgrades_button.onClick.AddListener(() => OpenSection(0));
        restartUpgrades_button.onClick.AddListener(() => OpenSection(1));

        //StartCoroutine(UpdateSilver());
    }

    private void Update()
    {
        //silverAmount_txt.text = ShortScaleString.parseFloat(Init.Instance.playerData.silverAmount, 2, 1000, true);
    }

    void OpenSection(int id)
    {
        foreach (var item in shopSections)
        {
            item.SetActive(false);
        }

        shopSections[id].SetActive(true);
    }
   

    
}
