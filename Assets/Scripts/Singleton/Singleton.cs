using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton {

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
     public static T Instance;


    // minha instancia é igual ao script
    private void Awake() {
        if(Instance == null)
            Instance = GetComponent<T>();
        else
            Destroy(gameObject);
    }
}

}
