using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraSkill : MonoBehaviour
{

    public Playerstats player;

    public ParticleSystem AuraPrefab; // ������Ʈ ��ƼŬ �ý���

   
    private bool isAurating = false; // ������Ʈ ������ ����
    private float auraTimer = 10.0f; // ������Ʈ Ÿ�̸�

    private ParticleSystem AuraInstance;

    void Update()
    {
        // Q Ű�� ������ ������Ʈ ����
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
            //��ƼŬ �ý��� ���
            if (AuraPrefab != null)
            {
                if (AuraInstance == null)
                { 
                    AuraInstance = Instantiate(AuraPrefab, transform.position, Quaternion.identity);
                    AuraInstance.transform.SetParent(transform); // ��ƼŬ �ý����� �÷��̾��� �ڽ����� ����
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
