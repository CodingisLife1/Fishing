using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    public PlayerData playerData;
    public static Init Instance;
    public UIManager uiManager;
    public GameManager gameManager;
    public Boosts boosts;

    // Start is called before the first frame update
    protected void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
