using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.Rendering.DebugUI;

public class G_WallState : MonoBehaviour
{
    [Header("牆壁設定")]
    [SerializeField] private bool G_isNegative;
    public int G_Wallint;

    [Header("牆壁UI(字體）")]
    [SerializeField] private TextMeshProUGUI valueText;

    private void Awake()
    {
        AddWallint();
    }

    public void SetValue(int newValue)
    {
        G_Wallint = newValue;
        AddWallint();
    }

    public void AddWallint()
    {
        G_Wallint++;
        if (G_Wallint > 0)
            valueText.text = "+" + G_Wallint.ToString();
        else
            valueText.text = G_Wallint.ToString(); // 負數自帶 -
    }
}
