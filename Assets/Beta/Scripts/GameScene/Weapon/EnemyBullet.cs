using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        _current = transform.position;
        Hit();
        _previous = _current;

        DeleteTimer();
    }

    void Hit()
    {
        Vector3 rayPosition = _previous;
        var dir = _current - _previous;
        Ray ray = new Ray(rayPosition, dir.normalized);
        Debug.DrawRay(ray.origin, dir.normalized, Color.red, 10, false);

        //ìGÇ…è’ìÀÇµÇΩÇ∆Ç´ÇÃèàóù
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, dir.magnitude))
        {
            hit.collider.GetComponentInParent<PlayerManager>()?.Hit(_damage);
            //Destroy(this.gameObject);
        }
    }
}
