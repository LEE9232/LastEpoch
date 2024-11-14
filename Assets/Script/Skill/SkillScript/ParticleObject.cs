using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleObject : MonoBehaviour
{
    public ObjectPool pool; // ������Ʈ Ǯ�� ����

    private void OnParticleSystemStopped()
    {
        gameObject.SetActive(false);
        if (pool != null)
        {
            pool.ReturnObject(gameObject); // Ǯ�� ��ȯ
        }
    }
}
