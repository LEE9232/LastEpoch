using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
public class AudioManeger : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource bgmAudioSource;

    private void Awake()
    {
        // ����� �Ŵ����� �ϳ��� �����ؾ� ��
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(AudioClip bgmClip)
    {
        if (bgmAudioSource != null && bgmClip != null)
        {
            bgmAudioSource.clip = bgmClip;
            bgmAudioSource.loop = true;
            bgmAudioSource.Play();
        }
    }

    public void StopBGM()
    {
        if (bgmAudioSource != null)
        {
            bgmAudioSource.Stop();
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // ���� �ε�� ������ BGM�� �ٽ� ���
        // �ʿ信 ���� �� ���� ���� BGM�� �����ϰ� �ش� BGM�� ����� �� ����
        PlayBGM(yourDesiredBGMClip);
    }
}
*/