using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/*
Class : Drones
Description : A class to define my drones
*/
public class Drones : MonoBehaviour
{
    private int ID;
    //Mask for detect Walls
    [SerializeField] private LayerMask _layer_mask;
    [SerializeField] private LayerMask layer_mask_car;
    private Ray ray0;
    public float maxVelocity = 5.0f;
    public Vector3 velocity;
    private float _rayDistance = 15.0f;
    private float _stoppingDistance = 1.5f;
    private Vector3 _destination;
    private Vector3 _direction;
    private Quaternion _desireRotation;
    private Cars _target;
    private DroneState _currentState;
    public bool get_target = false;
    public bool is_moving_to_target = false;
    private float _time_to_change = 5.0f;
    private RaycastHit hit;
    public float radius = 100.0f;
    private Drones[] drones;
    private GameObject car_object;
    private Cars car; 
    public string object_to_find = "Cube";

    private Console console;
    public static List<Cars> normal_cars = new List<Cars>();

    public static List<Cars> critical_cars = new List<Cars>();
     
    private float min_distance_following = 20;

    private SphereCollider sc;

    

    void Awake()
    {
        sc = GetComponent<SphereCollider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _layer_mask = LayerMask.GetMask("Wall");  
        drones = FindObjectsOfType<Drones>();
        for (int i = 0; i < drones.Length; i++)
        {
            if(drones[i] == this)
            {
                ID = i;
            }
        }
        layer_mask_car = LayerMask.GetMask("Car"); 
        console = GameObject.Find("Console").GetComponent<Console>();
    }

    // Update is called once per frame
    void Update()
    {
        //Change object to follow
        switch(PauseMenu.m_DropDown_Value)
        {
            case 0:
                if(object_to_find != "Cube")
                {
                    object_to_find = "Cube";
                    critical_cars = new List<Cars>();
                    normal_cars = new List<Cars>();
                    _target = null;
                }
                break;
            case 1:
                if(object_to_find != "Sphere")
                {
                    object_to_find = "Sphere";
                    critical_cars = new List<Cars>();
                    normal_cars = new List<Cars>();
                    _target = null;
                }
                break;
            case 2:
                if(object_to_find != "Cylinder")
                {
                    object_to_find = "Cylinder";
                    critical_cars = new List<Cars>();
                    normal_cars = new List<Cars>();
                    _target = null;
                }
                break;
            case 3:
                if(object_to_find != "Capsule")
                {
                    object_to_find = "Capsule";
                    critical_cars = new List<Cars>();
                    normal_cars = new List<Cars>();
                    _target = null;
                }
                break;
        }
        //Check the drone state
        switch(_currentState) {
            case DroneState.Wander :
            {
                _time_to_change -= Time.deltaTime;
                detectCar();
                if (_time_to_change < 0)
                {
                    GetDestination();
                    _time_to_change = 5.0f;
                }
                if (NeedsDestination())
                {
                    GetDestination();
                }
                transform.rotation = _desireRotation;
                transform.Translate(Vector3.forward * Time.deltaTime * 5f);
                
                var rayColor = IsPathBlocked() ? Color.red : Color.green;
                Debug.DrawRay(transform.position, _direction * _rayDistance, rayColor);
                while (IsPathBlocked())
                {
                    GetDestination();
                }

                break;
            }
            case DroneState.Chase :
            {
                if (_target == null)
                {
                    _currentState = DroneState.Wander;
                    return;
                }
                
                FollowTarget();

                LostTarget();

                break;
            }


        }
        
    }
    //Get a random destination
    private void GetDestination()
    {
        
        Vector3 testPosition = (transform.position + (transform.forward * 4f)) + new Vector3(Random.Range(-4.5f, 4.5f), 0f, Random.Range(-4.5f,4.5f));
        _destination = new Vector3(testPosition.x, 1f, testPosition.z);
        _direction = Vector3.Normalize(_destination - transform.position);
        _direction = new Vector3(_direction.x, 0f, _direction.z);
        _desireRotation = Quaternion.LookRotation(_direction);
    }
    
    public void MoveTowards(Vector3 pos)
    {
        _destination = new Vector3(pos.x, 1f, pos.z);
        _direction = Vector3.Normalize(_destination - transform.position);
        _direction = new Vector3(_direction.x, 0f, _direction.z);
        _desireRotation = Quaternion.LookRotation(_direction);
    }
    //Call when a drone loose a target
    private void LostTarget() 
    {
        if (Vector3.Distance(transform.position, _direction) >= min_distance_following)
        {
            console.AddMessageToConsole("Drone n°" + ID + " lost car around " + _target.transform.position);
            
            _destination = Vector3.zero;
            _currentState = DroneState.Wander;
            Vector3 last_pos = _target.transform.position;
            for (int i = 0; i < drones.Length; i++)
            {
                if(drones[i] != this)
                {
                    var diff = drones[i].transform.position - this.transform.position;
                    if(drones[i].get_target == false && diff.magnitude < radius )
                    {
                        Vector3 testPosition = (drones[i].transform.position + (transform.forward * 4f)) + new Vector3(Random.Range(drones[i].transform.position.x, last_pos.x), 0f, Random.Range(drones[i].transform.position.z, last_pos.z));
                        drones[i].MoveTowards(testPosition);
                        console.AddMessageToConsole("Drones n°" + drones[i].GetID() + " moving around the lost target.");
                    }
                }
                
            }
            if(critical_cars.Exists(x => x.Equals(_target)))
            {
                critical_cars.Remove(_target);
            }
            _target = null;        
        }
    }
    private void FollowTarget()
    {
        _direction = _target.transform.position;
        //setting always the same Y position
        _direction.y = this.transform.position.y;
        transform.rotation = _target.transform.rotation; 
        transform.position = Vector3.MoveTowards(this.transform.position, _direction, 5f * Time.deltaTime);
    }
    private bool NeedsDestination()
    {
        if (_destination == Vector3.zero)
            return true;

        var distance = Vector3.Distance(transform.position, _destination);
        if (distance <= _stoppingDistance)
        {
            return true;
        }

        return false;
    }

    private bool IsPathBlocked()
    {
        Ray ray = new Ray(transform.position, _direction);
        var hitSomething = Physics.RaycastAll(ray, _rayDistance, _layer_mask);
        return hitSomething.Any();
    }
    private void detectCar()
    {
        Debug.DrawRay(transform.position, new Vector3(_direction.x,-1,_direction.z) * _rayDistance, Color.magenta);
        ray0 = new Ray(transform.position, new Vector3(_direction.x,-1,_direction.z));
        if(Physics.Raycast(ray0, out hit, Mathf.Infinity, layer_mask_car))
        {
            car_object = hit.transform.gameObject;   
            car = car_object.GetComponentInParent<Cars>();
            var child = car_object.transform.GetChild(0);
            if(child.name == object_to_find)
            {
                if(critical_cars.Exists(x => x.Equals(car)) == false)
                {
                    _target = car;
                    get_target = true;
                    _currentState = DroneState.Chase;
                    console.AddMessageToConsole("Drone n°" + ID + " find a critical car"); 
                    critical_cars.Add(_target);
                }
            } else {
                if(normal_cars.Exists(x => x.Equals(car)) == false)
                {
                    console.AddMessageToConsole("Drone n°" + ID + " find a normal car");
                    normal_cars.Add(car);
                }
                
            }
                
        } else {
            if (get_target == true)
                get_target = false;
        }
    }

    public Cars GetCars() {
        return _target;
    }
    
    public int GetID()
    {
        return ID;
    }

    void OnTriggerEnter (Collider col)
    {
        console.AddMessageToConsole("Safety Zone triggered");
    }
}

public enum DroneState {
    Wander,
    Chase,
}
