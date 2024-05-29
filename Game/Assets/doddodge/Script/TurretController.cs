using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurretController : MonoBehaviour
{
    public float rotationSpeed = 5f; // 회전 속도
    public float detectionRange = 10f; // 타겟 감지 범위
    public LayerMask targetLayer; // 타겟 레이어 (플레이어 레이어)

    private Transform target; // 현재 타겟

    void Update()
    {
        DetectTarget();

        if (target != null)
        {
            RotateTowardsTarget();
        }
    }

    // 타겟을 감지하는 함수
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

    // 타겟을 향해 회전하는 함수
    void RotateTowardsTarget()
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0; // y축 회전을 제한하여 수평 회전만 하도록 설정
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    // 감지 범위를 시각화하는 함수 (디버깅용)
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
