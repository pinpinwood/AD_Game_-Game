using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_PlayerMove : MonoBehaviour
{
    [Header("���Ⲿ�ʰѼ�")]
    [SerializeField] private float _acceleration = 5f;
    [SerializeField] private float _deceleration = 5f;
    [SerializeField] private float _maxspeed = 20f;
    [SerializeField] private float minX = -4.9f;
    [SerializeField] private float maxX = 4.9f;

    private Rigidbody _rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // �ưʩ���L���k��
        Vector3 newPos = transform.position + new Vector3(horizontal * _maxspeed * Time.deltaTime, 0, 0);

        // �i�[�J Clamp ����ʽd��
        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);

        transform.position = newPos;
    }
    public void largeMax()
    {
        minX = -4.9f;
        maxX = 4.9f;
    }
    public void MinMax()
    {
        minX = -3.2f;
        maxX = 3.2f;
    }
}
