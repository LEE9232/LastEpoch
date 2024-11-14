using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraSkill : MonoBehaviour
{

    public Playerstats player;

    public ParticleSystem AuraPrefab; // 스프린트 파티클 시스템

   
    private bool isAurating = false; // 스프린트 중인지 여부
    private float auraTimer = 10.0f; // 스프린트 타이머

    private ParticleSystem AuraInstance;

    void Update()
    {
        // Q 키를 누르면 스프린트 시작
        if (Input.GetKeyDown(KeyCode.E) && !isAurating)
        {
            AuraMode();
        }
    }
    void AuraMode()
    {
        if (isAurating == false)
        {
            StartCoroutine(ResetSpeed());
            //파티클 시스템 재생
            if (AuraPrefab != null)
            {
                if (AuraInstance == null)
                { 
                    AuraInstance = Instantiate(AuraPrefab, transform.position, Quaternion.identity);
                    AuraInstance.transform.SetParent(transform); // 파티클 시스템을 플레이어의 자식으로 설정
                }
                AuraInstance.Play();                
            }
        }
    }
    
    IEnumerator ResetSpeed()
    {
        isAurating = true;
        yield return new WaitForSeconds(auraTimer);
        isAurating = false;
       
        
        if (AuraInstance != null)
        {
            AuraInstance.Stop();
            StartCoroutine(DestroyParticleAfterDelay(AuraInstance, 10f));
        }
        
    }
    
    IEnumerator DestroyParticleAfterDelay(ParticleSystem particleSystem, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (particleSystem != null)
        {
            Destroy(particleSystem.gameObject);
        }
    }  
}
