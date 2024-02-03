using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;
    public Transform positionProjectile;
    public float timeBetweenShoot = .3f;
    public Transform sideRef;

    [Header("Audio")]
    public AudioRamdonAudioPlay randomShoot;


    private Coroutine _currentCoroutine;

    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            //Debug.Log("Pressed left-click.");
            _currentCoroutine = StartCoroutine(StartShoot());
        }
        else if(Input.GetMouseButtonUp(0)){
            if(_currentCoroutine != null) StopCoroutine(_currentCoroutine);
        }
    }
    
    IEnumerator StartShoot() {
        while(true){
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public void Shoot(){

        if (randomShoot != null) randomShoot.PlayRandom();

        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionProjectile.position;
        projectile.side = sideRef.transform.localScale.x;
    }


}
