using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �e�̎ˌ��p�e�X�g�X�N���v�g
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
