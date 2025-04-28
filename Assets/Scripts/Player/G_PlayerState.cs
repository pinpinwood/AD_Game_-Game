using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class G_PlayerState:MonoBehaviour
{
    [SerializeField] private GameObject G_PlayerObj;
    [SerializeField] private int G_ModifyStrength=1;
    [SerializeField] private int G_MaxModifyStrength=120;
    [SerializeField] private GameObject G_TypeOfWeapon;
    public Transform spawnArea;
    private int maxPlayerCount=30;
    [SerializeField] private int playerCount=1;
    private int spacing = 2;

    private void Awake()
    {
        //G_PlayerObj=GetComponent<GameObject>();
    }

    public Transform playerGroup; // 母物件

    private List<GameObject> members = new List<GameObject>();

    public void AddMembers(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newMember = Instantiate(G_PlayerObj, playerGroup);
            members.Add(newMember);
            playerCount = members.Count;
        }
        UpdateFormation();
    }

    public void RemoveMembers(int count)
    {
        int removeCount = Mathf.Min(count, members.Count);
        for (int i = 0; i < removeCount; i++)
        {
            GameObject toRemove = members[members.Count - 1];
            members.RemoveAt(members.Count - 1);
            Destroy(toRemove);
        }
        UpdateFormation();
    }

    void UpdateFormation()
    {
        if (playerCount < maxPlayerCount)
        {
            GameObject newPlayer = Instantiate(G_PlayerObj);

            // 根據目前的玩家數量計算新角色的位置
            Vector3 spawnPosition = spawnArea.position + new Vector3(playerCount * spacing, 0, 0);  // 排列在 x 軸上

            newPlayer.transform.position = spawnPosition;
        }
        else
            playerCount = maxPlayerCount;
    }
}
