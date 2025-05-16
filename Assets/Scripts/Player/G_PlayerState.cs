using System.Collections.Generic;
using UnityEngine;

public class G_PlayerState : MonoBehaviour
{
    [Header("角色設定")]
    [SerializeField] private GameObject G_PlayerObj;
    [SerializeField] private int G_ModifyStrength = 1;
    [SerializeField] private int G_MaxModifyStrength = 120;
    [SerializeField] private GameObject G_TypeOfWeapon;

    [Header("生成設定")]
    public Transform spawnArea;
    public Transform playerGroup;

    private int G_MaxPlayerCount = 30;
    private List<GameObject> G_Members = new List<GameObject>();

    [Header("排列參數")]
    [SerializeField] private int G_MaxPerRow = 5;
    [SerializeField] private float G_Spacing = 1.5f;
    [SerializeField] private float G_UniformScale = 0.7f;

    void Start()
    {
        // 假設一開始就有一個角色
        if (G_Members.Count == 0 && G_PlayerObj != null)
        {
            GameObject startPlayer = Instantiate(G_PlayerObj, playerGroup);
            G_Members.Add(startPlayer);
            UpdateFormation();
        }
    }

    public void AddMembers(int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (G_Members.Count >= G_MaxPlayerCount) break;

            GameObject newPlayer = Instantiate(G_PlayerObj, playerGroup);
            G_Members.Add(newPlayer);
        }

        UpdateFormation();
    }

    public void RemoveMembers(int count)
    {
        int removeCount = G_Members.Count + count;
        for (int i = 0; i < count; i++)
        {
            if (G_Members.Count == 1) break;

            GameObject toRemove = G_Members[G_Members.Count - 1];
            G_Members.RemoveAt(G_Members.Count - 1);
            Destroy(toRemove);
        }

        UpdateFormation();
    }

    void UpdateFormation()
    {
        for (int i = 0; i < G_Members.Count; i++)
        {
            int row = i / G_MaxPerRow;
            int col = i % G_MaxPerRow;

            int countInRow = Mathf.Min(G_MaxPerRow, G_Members.Count - row * G_MaxPerRow);
            float rowWidth = (countInRow - 1) * G_Spacing;
            float xOffset = col * G_Spacing - rowWidth / 2f;
            float zOffset = row * G_Spacing;  

            Vector3 spawnPos = spawnArea.position + new Vector3(xOffset, 0f, zOffset);
            GameObject player = G_Members[i];
            player.transform.position = spawnPos;
            player.transform.localScale = Vector3.one * G_UniformScale;           
        }
        if (G_Members.Count <= 3)
            GetComponentInParent<G_PlayerMove>().largeMax();
        else
            GetComponentInParent<G_PlayerMove>().MinMax();

    }
}