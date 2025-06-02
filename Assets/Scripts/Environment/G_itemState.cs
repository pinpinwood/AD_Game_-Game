using TMPro;
using UnityEngine;

public class G_itemState : MonoBehaviour
{
    [Header("物件設定")]
    public int G_Wallint;

    [Header("牆壁UI(字體）")]
    [SerializeField] private TextMeshProUGUI valueText;

    private float hitCooldown = 0.1f;
    private float lastHitTime = -1f;

    private void Awake()
    {
        // AddWallint();
        lastHitTime = Time.time;
        G_Wallint = Random.Range(1, 4);
        SetValue(G_Wallint);
    }

    public void SetValue(int newValue)
    {
        G_Wallint = newValue;
        UpdateWallText();
    }

    public void AddWallint()
    {
        float currentTime = Time.time;
        if (currentTime - lastHitTime >= hitCooldown)
        {
            lastHitTime = currentTime;
            G_Wallint++;
            UpdateWallText();
        }
    }
    private void UpdateWallText()
    {
        if (G_Wallint >= 0)
        {
            valueText.text = "+" + G_Wallint.ToString();
            G_isNegative = false;
        }
        else
            valueText.text = G_Wallint.ToString();
    }
}
