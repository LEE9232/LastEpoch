using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleObject : MonoBehaviour
{
    public ObjectPool pool; // 오브젝트 풀을 참조

    private void OnParticleSystemStopped()
    {
        gameObject.SetActive(false);
        if (pool != null)
        {
            pool.ReturnObject(gameObject); // 풀로 반환
        }
    }
}
