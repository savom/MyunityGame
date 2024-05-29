using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurretController : MonoBehaviour
{
    public float rotationSpeed = 5f; // ȸ�� �ӵ�
    public float detectionRange = 10f; // Ÿ�� ���� ����
    public LayerMask targetLayer; // Ÿ�� ���̾� (�÷��̾� ���̾�)

    private Transform target; // ���� Ÿ��

    void Update()
    {
        DetectTarget();

        if (target != null)
        {
            RotateTowardsTarget();
        }
    }

    // Ÿ���� �����ϴ� �Լ�
    void DetectTarget()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRange, targetLayer);
        if (hitColliders.Length > 0)
        {
            target = hitColliders[0].transform;
        }
        else
        {
            target = null;
        }
    }

    // Ÿ���� ���� ȸ���ϴ� �Լ�
    void RotateTowardsTarget()
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0; // y�� ȸ���� �����Ͽ� ���� ȸ���� �ϵ��� ����
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    // ���� ������ �ð�ȭ�ϴ� �Լ� (������)
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
