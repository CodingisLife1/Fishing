using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boosts : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SilverPerSecondMultiplier()
    {
        Init.Instance.playerData.silverPerSecond *= 4;

        yield return new WaitForSeconds(60);

        Init.Instance.playerData.silverPerSecond /= 4;
    }

    // ������ ����
    public void StartCor_SilverPerSecondMultiplier()
    {
        StartCoroutine(SilverPerSecondMultiplier());
    }

    // ������ ����
    public void BirdSilverBonus()
    {
        Init.Instance.playerData.silverAmount += Init.Instance.playerData.fishCost * 64;
    }

    public void ChestSilverBonus()
    {
        Init.Instance.playerData.silverAmount += Init.Instance.playerData.fishCost * 64;
    }

    public void BirdRandomBoost()
    {
        int r = Random.Range(1, 3);

        switch (r)
        {
            case 1:
                StartCor_SilverPerSecondMultiplier();
                Debug.Log("�4 ����� � �������");
                break;

            case 2:
                BirdSilverBonus();
                Debug.Log("����� � ������");
                break;

            default:
                break;
        }
    }
}
