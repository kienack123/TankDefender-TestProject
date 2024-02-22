using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawnPoint;

    private IController controller;

    [SerializeField] private BulletController bulletController;


    private void Start()
    {
        controller = GetComponentInParent<IController>();
    }


    public void TankFire(IController _Icontroller = null)
    {
        if (controller == null) return;
        SpawnBullet(_Icontroller);
    }


    private void SpawnBullet(IController _IController)
    {
        GameObject bullet = PoolingStore.Instance.GetPooledObject(); 
        if (bullet != null) 
        {
            bullet.transform.position = bulletSpawnPoint.position;
            bullet.SetActive(true);
        }

    
        BulletController _bulletController = bullet.GetComponent<BulletController>();

        if (!_bulletController) return;
        _bulletController.controller = _IController;
        
        if(_bulletController.TryGetComponent(out Rigidbody bulletRb))
        {
            bulletRb.AddForce(bulletSpawnPoint.forward * controller.Force, ForceMode.Impulse);
            
        }
    }
    
}
