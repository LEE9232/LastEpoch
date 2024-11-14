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


    [Header("효과음 등록")] 
    [SerializeField] sound[] sfxSound;

    [Header("효과음 플레이어")] 
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
                Debug.Log(" 모두 사용중 ");
                return;
            }
        }
        Debug.Log(" 효과음 없음 ");
    }
}
*/