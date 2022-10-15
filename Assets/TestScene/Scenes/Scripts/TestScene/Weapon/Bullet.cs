using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 _current;
    Vector3 _previous;

    float _deleteTime = 5;

    // Update is called once per frame
    void Update()
    {
        if (_current != null)
        {
            _previous = _current;
        }

        _current = transform.position;

        Hit();

        _deleteTime -= Time.deltaTime;

        if(_deleteTime < 0)
        {
            Destroy(this.gameObject);
        }
    }

    void Hit()
    {
        Vector3 rayPosition = _previous;
        var dir = _current - _previous;
        Ray ray = new Ray(rayPosition, dir.normalized);
        Debug.DrawRay(ray.origin, dir.normalized, Color.red, 10, false);

        //“G‚ÉÕ“Ë‚µ‚½‚Æ‚«‚Ìˆ—
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, dir.magnitude))
        {
            if (hit.collider.tag == "Target")
            {
                Debug.Log("Hit");
                hit.collider.GetComponent<Renderer>().material.color = Color.red;

            }

            Debug.Log(hit.collider.tag);
            Destroy(this.gameObject);
        }
    }
}
