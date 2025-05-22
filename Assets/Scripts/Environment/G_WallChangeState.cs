using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class G_WallChangeState : MonoBehaviour
{
    [SerializeField] G_WallState G_State;
    [SerializeField] int speed=8;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        G_State = GetComponent<G_WallState>();
    }
    private void Update()
    {
        Vector3 newPos = transform.position + transform.forward *-speed * Time.deltaTime;
        this.transform.position = newPos;   
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            G_PlayerState g_Player = other.GetComponentInParent<G_PlayerState>();
            if(G_State.G_Wallint>=0)
                g_Player.AddMembers(G_State.G_Wallint);
            else
                g_Player.RemoveMembers(G_State.G_Wallint); 
            Destroy(this.gameObject);
        }
        if(other.tag =="Finish")
        {
            Destroy(this.gameObject);
        }
    }
}
