using System.Collections.Generic;
using UnityEngine;

public class G_PlayerState:MonoBehaviour
{
    [SerializeField] private GameObject G_PlayerObj;
    [SerializeField] private int G_ModifyStrength=1;
    [SerializeField] private int G_MaxModifyStrength=120;
    [SerializeField] private GameObject G_TypeOfWeapon;

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
        for (int i = 0; i < members.Count; i++)
        {
            float spacing = 1.5f;
            Vector3 newPos = new Vector3((i % 5) * spacing, 0, -(i / 5) * spacing); // 橫排5人
            members[i].transform.localPosition = newPos;
        }
    }
}
