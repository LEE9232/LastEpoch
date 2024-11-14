using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaFinishDamage : MonoBehaviour
{
    public NovafinlshSkill NovaDam;
    public int Damamge;
    void Start()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Skill"));
        Damamge = NovaDam.NovaEndDamage;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            MonsterStat monsterStat = collision.gameObject.GetComponent<MonsterStat>();
            if (monsterStat != null)
            {               
                monsterStat.TakeDamage(Damamge);
            }
        }
    }
}
