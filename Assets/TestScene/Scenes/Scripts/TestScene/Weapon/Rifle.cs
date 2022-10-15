using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 銃の射撃用テストスクリプト
/// </summary>
public class Rifle : MonoBehaviour
{
    [SerializeField] GameObject _bullet;

    [SerializeField] float _speed;

    [SerializeField] GameObject _muzzle;

    [SerializeField] float _angle;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            var bulletRb = Instantiate(_bullet, _muzzle.transform.position, _muzzle.transform.rotation).GetComponent<Rigidbody>();

            bulletRb.AddForce(this.gameObject.transform.forward * _speed, ForceMode.Impulse);
        }
    }
}
