using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager;


    private FMOD.Studio.EventInstance instance;
    public FMODUnity.EventReference fmodEvent;


    public FMODUnity.EventReference VermeFireRef;
    public FMODUnity.EventReference CaveiraFireRef;
    public FMODUnity.EventReference MoscaFireRef;
    public FMODUnity.EventReference DemonioFireRef;
    public FMODUnity.EventReference KillEnemyRef;

    public FMODUnity.EventReference PlayerFireRef;
    public FMODUnity.EventReference PlayerHitRef;
    public FMODUnity.EventReference PlayerKillRef;
    public FMODUnity.EventReference PlayerLoseBodyRef;
    public FMODUnity.EventReference PlayerGetBodyRef;



    [SerializeField]
    [Range(0f, 1f)]
    public float CombateType, InCombat;


    public void HitEnemy()
    {
        int num = Random.Range(1, 4);
        RuntimeManager.PlayOneShot("event:/SFX/Hits/HE" + num.ToString());
    }
    public void HitMisc()
    {
        int num = Random.Range(1, 3);
        RuntimeManager.PlayOneShot("event:/SFX/Hits/HA" + num.ToString());
    }

    
    public void PlayerFire()
    {
        RuntimeManager.PlayOneShot(PlayerFireRef);
    }
    public void PlayerHit()
    {
        RuntimeManager.PlayOneShot(PlayerHitRef);
    }
    public void PlayerKill()
    {
        RuntimeManager.PlayOneShot(PlayerKillRef);
    }
    public void PlayerLoseBody()
    {
        RuntimeManager.PlayOneShot(PlayerLoseBodyRef);
    }
    public void PlayerGetBody()
    {
        RuntimeManager.PlayOneShot(PlayerGetBodyRef);
    }
    public void VermeFire()
    {
        RuntimeManager.PlayOneShot(VermeFireRef);
    }
    public void CaveiraFire()
    {
        FMODUnity.RuntimeManager.PlayOneShot(CaveiraFireRef);
    }
    public void MoscaFire()
    {
        RuntimeManager.PlayOneShot(MoscaFireRef);
    }
    public void DemonioFire()
    {
        RuntimeManager.PlayOneShot(DemonioFireRef);
    }
    public void KillEnemy()
    {
        RuntimeManager.PlayOneShot(KillEnemyRef);
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if(audioManager != null && audioManager != this)
        {
            Destroy(gameObject);
        }
        else
        {
            audioManager = this;
            instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
            instance.start();
        }
    }
    void Update()
    {
        instance.setParameterByName("CombateType", CombateType);
        instance.setParameterByName("InCombat", InCombat);
    }
}