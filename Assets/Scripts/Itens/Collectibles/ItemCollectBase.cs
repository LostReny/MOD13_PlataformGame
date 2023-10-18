using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectBase : MonoBehaviour
{
    //override - usado para escrever em cima de uma classe pai(virtual), dando função diferente para classe filha(override)

    public string compareTag = "Player";

    public void OnTriggerEnter2D(Collider2D collision) {

        if(collision.transform.CompareTag(compareTag)){
            Collect();
        }
        
    }


    //o que vai acontecer quando coletar ??
    // quando coletar ele destroi e chama a ação ao coletar 
    protected virtual void Collect(){
        Destroy(gameObject);
        OnCollect();
    }


    //quando coletar que ação será realizada ?
    protected virtual void OnCollect()
{
    
}

}
