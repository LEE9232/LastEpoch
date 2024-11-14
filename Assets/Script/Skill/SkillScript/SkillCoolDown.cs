using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCoolDown : MonoBehaviour
{
    // �� ��ų�� ���� ��ٿ��� �����ϴ� ����ü
    [System.Serializable] // �� Ư���� ����ϸ� Unity �����Ϳ��� ����ü�� ������ �� �ֽ��ϴ�.
    public struct Skill
    {
        public Slider cooldownSlider; // ��ų�� ��ٿ��� ǥ���ϴ� �����̴�
        public GameObject cooldownImageObject; // ��Ÿ�� ���� ǥ���� �̹��� ������Ʈ
        public float cooldownTime; // ��ų�� ��ٿ� �ð�
        [HideInInspector] public float currentTime; // ���� ��ٿ� �ð��� �󸶳� ���Ҵ���
        [HideInInspector] public bool isCooldown; // ���� ��ٿ� ������ ����
        // ��ٿ� ������Ʈ �޼���
        public void UpdateCooldown()
        {
            if (isCooldown) // ���� ��ٿ� ���̶��
            {
                currentTime -= Time.deltaTime; // ��ٿ� �ð��� ���ҽ�ŵ�ϴ�.
                cooldownSlider.value = 1 - (currentTime / cooldownTime); // �����̴� ���� ������Ʈ�մϴ�.

                if (currentTime <= 0) // ��ٿ��� �����ٸ�
                {
                    isCooldown = false; // ��ٿ� ���¸� �����մϴ�.
                    currentTime = 0; // ���� �ð��� 0���� �����մϴ�.
                    cooldownImageObject.SetActive(false); // ��Ÿ�� �̹����� ��Ȱ��ȭ�մϴ�.
                }
            }
        }

        // ��ٿ� ���� �޼���
        public void StartCooldown()
        {
            currentTime = cooldownTime; // ���� �ð��� ��ٿ� �ð����� �����մϴ�.
            isCooldown = true; // ��ٿ� ���·� �����մϴ�.
            cooldownImageObject.SetActive(true); // ��Ÿ�� �̹����� Ȱ��ȭ�մϴ�.
        }
    }

    public Skill skill1; // ù ��° ��ų�� ���� ��ٿ� ����
    public Skill skill2; // �� ��° ��ų�� ���� ��ٿ� ����
    public Skill skill3; // �� ��° ��ų�� ���� ��ٿ� ����
    public Skill Heal1; // �� ��° ��ų�� ���� ��ٿ� ����

    void Update()
    {
        // �� ��ų�� ��ٿ��� ������Ʈ�մϴ�.
        skill1.UpdateCooldown();
        skill2.UpdateCooldown();
        skill3.UpdateCooldown();
        Heal1.UpdateCooldown();
    }

    // ��ų ��� �޼��� (��: UI ��ư�̳� Ű���� �Է¿� ����)
    public void UseSkill1()
    {
        if (!skill1.isCooldown) // ��ų�� ��ٿ� ���� �ƴ϶��
        {
            // ��ų ��� ���� �߰� (��: ������, ����Ʈ ��)
            skill1.StartCooldown(); // ��ų�� ��ٿ��� �����մϴ�.
        }
    }
    public void UseSkill2()
    {
        if (!skill2.isCooldown) // ��ų�� ��ٿ� ���� �ƴ϶��
        {
            // ��ų ��� ���� �߰� (��: ������, ����Ʈ ��)
            skill2.StartCooldown(); // ��ų�� ��ٿ��� �����մϴ�.
        }
    }
    public void UseSkill3()
    {
        if (!skill3.isCooldown) // ��ų�� ��ٿ� ���� �ƴ϶��
        {
            // ��ų ��� ���� �߰� (��: ������, ����Ʈ ��)
            skill3.StartCooldown(); // ��ų�� ��ٿ��� �����մϴ�.
        }
    }
    public void Heal()
    {
        if (!Heal1.isCooldown) // ��ų�� ��ٿ� ���� �ƴ϶��
        {
            // ��ų ��� ���� �߰� (��: ������, ����Ʈ ��)
            Heal1.StartCooldown(); // ��ų�� ��ٿ��� �����մϴ�.
        }
    }
}



