using TMPro;
using UnityEngine;

public class CoinAmountScript : MonoBehaviour
{
    [SerializeField] private TMP_Text coinAmountText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinAmountText.text = "Coins: " + Globals.Coins.ToString();
    }
}
