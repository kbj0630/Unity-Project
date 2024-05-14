using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    public Material collisionMaterial; // 충돌 시 적용할 임시 머테리얼
    public float collisionDuration = 2f; // 충돌 지속 시간

    private Material originalMaterial; // 원래의 머테리얼

    void Start()
    {
        // 초기화
        originalMaterial = GetComponent<Renderer>().material;
    }

    void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트가 자식 오브젝트인지 확인
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.otherCollider.transform.IsChildOf(transform))
            {
                // 충돌한 자식 오브젝트의 렌더러 컴포넌트를 가져와 머테리얼 변경
                Renderer childRenderer = contact.otherCollider.GetComponent<Renderer>();
                if (childRenderer != null)
                {
                    childRenderer.material = collisionMaterial;
                    Invoke("RestoreOriginalMaterial", collisionDuration);
                }
                break; // 충돌한 첫 번째 자식 오브젝트만 처리
            }
        }
    }

    // 원래의 머테리얼로 복구
    void RestoreOriginalMaterial()
    {
        Renderer[] childRenderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in childRenderers)
        {
            renderer.material = originalMaterial;
        }
    }
}