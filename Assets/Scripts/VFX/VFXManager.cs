using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class VFXManager : Singleton<VFXManager>
{
    public enum VFXType
    {
        WALK,
        JUMP,
        COIN
    }

    public List<VFXManagerSetup> vfxSetup;

    public void PlayVFXByType(VFXType vfxType, Vector3 position)
    {
        foreach(var i in vfxSetup)
        {
            if(i.vfxType == vfxType)
            {
                var item = Instantiate(i.prefab);
                item.transform.position = position;
                break;
            }
        }
    }
}

[System.Serializable]

public class VFXManagerSetup
{
    public VFXManager.VFXType vfxType;
    public GameObject prefab;
}
