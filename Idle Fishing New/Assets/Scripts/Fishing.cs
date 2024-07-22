using System;
using System.Collections;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    [SerializeField] private bool fishOnHook;
    [SerializeField] private int[] weights;
    [SerializeField] private GameObject[] fishes;
    [SerializeField] private int totalWeight;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private GameObject fishHistoryElement;
    [SerializeField] private Transform elementParent;
    private string[] chars = { "", "K", "M", "B", "T" };

    void Start()
    {
        StartCoroutine(IEIncomePerSecond());
        CalculateTotalWeight();
        StartCoroutine(FindFish());
    }

    // Ожидание рыбы
    IEnumerator FindFish()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(0.3f, Init.Instance.playerData.fishBiteSpeed));
        Debug.Log("Рыба на крючке!");
        StartCoroutine(TakeFish());  
    }


    // Ловля рыбы
    IEnumerator TakeFish()
    {
        for (int i = 0; i < Init.Instance.playerData.takeFishOut; i++)
        {
            Debug.Log($"Осталось {Init.Instance.playerData.takeFishOut - i} секунд");
            yield return new WaitForSeconds(1);
        }
        GenerateRandomDrop();

        yield return new WaitForSeconds(0.5f);

        StartCoroutine(FindFish());

    }


    // Вычисление суммарного "веса"
    public void CalculateTotalWeight()
    {
        foreach (var item in weights)
        {
            totalWeight += item;
        }
    }

    // Генерация случайного числа и определение дропа
    public void GenerateRandomDrop()
    {
        int r = UnityEngine.Random.Range(0, totalWeight);


        for (int i = 0; i < weights.Length; i++)
        {
            if (r <= weights[i])
            {
                Instantiate(fishes[i], spawnPos.position, Quaternion.identity);
                Fish f = fishes[i].GetComponent<Fish>();
                Init.Instance.playerData.silverAmount += f.data.multiplier * Init.Instance.playerData.fishCost;
                Init.Instance.uiManager.silverAmount_txt.text = ShortScaleString.parseFloat(Init.Instance.playerData.silverAmount, 2, 1000, true);
                Init.Instance.playerData.goldAmount += f.data.multiplier * Init.Instance.playerData.fishGoldCost;
                Init.Instance.uiManager.goldAmount_txt.text = Init.Instance.playerData.goldAmount.ToString();


                GameObject e = Instantiate(fishHistoryElement, elementParent);
                e.GetComponent<ElementOfHistory>().FillElement(f.data);
                break;
            }
            else
            {
                r -= weights[i];
            }
        }
    }

    IEnumerator IEIncomePerSecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Init.Instance.playerData.silverAmount += Init.Instance.playerData.silverPerSecond;
            Init.Instance.uiManager.silverAmount_txt.text = ShortScaleString.parseFloat(Init.Instance.playerData.silverAmount, 2, 1000, true);
        }
    }

    /*public string FormatMoney(decimal digit)
    {
        int n = 0;
        while (n + 1 < chars.Length && digit >= 1000m)
        {
            digit /= 1000m;
            n++;
        }
        string s = digit.ToString("0.00") + chars[n];
        return s;
    }*/
}
