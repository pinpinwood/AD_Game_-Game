using UnityEngine;

public class G_EnimyState:MonoBehaviour
{
    [SerializeField] private int G_EnimyHP;
    [SerializeField] private float speed;
    private void Update()
    {
        Vector3 newPos = transform.position + transform.forward * -speed * Time.deltaTime;
        this.transform.position = newPos;
    }
}
