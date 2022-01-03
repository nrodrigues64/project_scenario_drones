using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/*
Class : Cars
Description : A class to define my in-game cars
*/
public class Cars : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 _destination;
    private Vector3 _direction;
    private Quaternion _desireRotation;
    [SerializeField] private LayerMask _layer_mask;
    private float _rayDistance = 10.0f;
    private float timeLeft = 5;
    private void RandomVector() {
        Vector3 testPosition = (transform.position + (transform.forward * 4f)) + new Vector3(Random.Range(-4.5f, 4.5f), 0f, Random.Range(-4.5f,4.5f));
        _destination = new Vector3(testPosition.x, 1f, testPosition.z);
        _direction = Vector3.Normalize(_destination - transform.position);
        _direction = new Vector3(_direction.x, 0f, _direction.z);
        _desireRotation = Quaternion.LookRotation(_direction);
    }

    void Awake()
    {
        RandomVector();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _layer_mask = LayerMask.GetMask("Wall");
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = _desireRotation;
        transform.Translate(Vector3.forward * Time.deltaTime * 5f);
        timeLeft -= Time.deltaTime;
        if (IsPathBlocked())
        {
            RandomVector();
        }
        if ( timeLeft < 0)
        {
            timeLeft = Random.Range(2f,5f);
            RandomVector();
        }
        

    }

    void OnTriggerEnter (Collider col) {
        if(col.gameObject.layer == LayerMask.GetMask("Car"))
        {
            RandomVector();
        }
    }

     private bool IsPathBlocked()
    {
        Ray ray = new Ray(transform.position, _direction);
        Debug.DrawRay(transform.position, _direction * _rayDistance, Color.green);
        return (Physics.Raycast(ray,_rayDistance, _layer_mask) || Physics.Raycast(ray, _rayDistance, LayerMask.GetMask("Car")));
    }
}
