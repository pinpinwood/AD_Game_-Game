using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.Rendering.DebugUI;
using System.Collections.Generic;

public class G_WallState : MonoBehaviour
{
    [Header("Àð¾À³]©w")]
    [SerializeField] private bool G_isNegative;
    public int G_Wallint;

    [Header("Àð¾ÀUI(¦rÅé¡^")]
    [SerializeField] private TextMeshProUGUI valueText;

    private float hitCooldown = 0.2f;
    private float lastHitTime = -1f;

    private void Awake()
    {
       // AddWallint();
        lastHitTime = Time.time;
        G_Wallint = Random.Range(-4, 4);
        SetValue(G_Wallint);
    }

    public void SetValue(int newValue)
    {
        G_Wallint = newValue;
        if (G_Wallint < 0)
            G_isNegative = true;
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
