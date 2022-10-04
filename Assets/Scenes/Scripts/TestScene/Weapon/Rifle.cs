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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var bulletRb = Instantiate(_bullet, _muzzle.transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            bulletRb.AddForce(Camera.main.transform.forward * _speed, ForceMode.Impulse);
        }
    }
}
