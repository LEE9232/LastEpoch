using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class sound
{
    public string soundName;
    public AudioClip clip;
}



public class SoundManeger : MonoBehaviour
{
    public static SoundManeger instance;


    [Header("ȿ���� ���")] 
    [SerializeField] sound[] sfxSound;

    [Header("ȿ���� �÷��̾�")] 
    [SerializeField] AudioSource[] sfxPlayer;

    void Start()
    {
        instance = this;
    }

    
    void Update()
    {
        
    }

    public void PlaySE(string _soundName)
    {
        for(int i = 0; i < sfxSound.Length; i++)
        {
            if(_soundName == sfxSound[i].soundName)
            {
                for(int x =0; x < sfxPlayer.Length; x++)
                {
                    if(!sfxPlayer[x].isPlaying)
                    {
                        sfxPlayer[x].clip = sfxSound[i].clip;
                        sfxPlayer[x].Play();

                        return;
                    }
                }
                Debug.Log(" ��� ����� ");
                return;
            }
        }
        Debug.Log(" ȿ���� ���� ");
    }
}
*/