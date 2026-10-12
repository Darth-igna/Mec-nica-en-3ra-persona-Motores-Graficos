using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI itemsText;   
    public GameObject victoryPanel;     

    private int collected = 0;
    private int totalItems = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        totalItems = GameObject.FindGameObjectsWithTag("Dito").Length;

        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false);
        }

        UpdateText();
    }
    public void AddItem()
    {
        collected++;
        UpdateText();

        if (collected >= totalItems)
        {
            if (itemsText != null)
            {
                itemsText.gameObject.SetActive(false);   
            }

            if (victoryPanel != null)
            {
                victoryPanel.SetActive(true);           
            }

            Time.timeScale = 0f; 
        }
    }

    void UpdateText()
    {
        if (itemsText != null)
        {
            itemsText.text = "Items: " + collected + " / " + totalItems;
        }
    }
}