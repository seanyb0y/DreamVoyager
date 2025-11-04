using UnityEngine;
using TMPro;

public class CollectibleManager : MonoBehaviour
{
    public int totalCollectibles = 10;
    private int collectedCount = 0;

    public TextMeshProUGUI collectibleText;

    void Start()
    {
        UpdateUI();
    }

    public void Collect()
    {
        collectedCount++;
        UpdateUI();
    }

    void UpdateUI()
    {
        collectibleText.text = collectedCount + " / " + totalCollectibles;
    }
}