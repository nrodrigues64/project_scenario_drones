using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/*
Class : SpawnerCars
Description : A class to make spawn my cars
*/
public class SpawnerCars : MonoBehaviour
{
    //Static value to access them from everywhere
    public static int nbCubeCar;
    public static int nbSphereCar;
    public static int nbCylinderCar;
    public static int nbCapsuleCar;
    public GameObject prefabCubeCar;
    public GameObject prefabSphereCar;
    public GameObject prefabCylinderCar;
    public GameObject prefabCapsuleCar;
    // Start is called before the first frame update
    void Start()
    {
        int nbCubeCar_tmp = nbCubeCar;
        int nbCapsuleCar_tmp = nbCapsuleCar;
        int nbSphereCar_tmp = nbSphereCar;
        int nbCylinderCar_tmp = nbCylinderCar;
        for (int i = 0; i < nbCubeCar_tmp; i++)
        {
            Vector3 pos = GeneratePos();
            while(SetDestination(pos) == false)
            {
                pos = GeneratePos();
            }
            Instantiate(prefabCubeCar, pos, Quaternion.identity);
            nbCubeCar--;
        }
        for (int i = 0; i < nbCapsuleCar_tmp; i++)
        {
            Vector3 pos = GeneratePos();
            while(SetDestination(pos) == false)
            {
                pos = GeneratePos();
            }
            Instantiate(prefabCapsuleCar, pos, Quaternion.identity);
            nbCapsuleCar--;
        }
        for (int i = 0; i < nbSphereCar_tmp; i++)
        {
            Vector3 pos = GeneratePos();
            while(SetDestination(pos) == false)
            {
                pos = GeneratePos();
            }
            Instantiate(prefabSphereCar, pos, Quaternion.identity);
            nbSphereCar--;
        }
        for (int i = 0; i < nbCylinderCar_tmp; i++)
        {
            Vector3 pos = GeneratePos();
            while(SetDestination(pos) == false)
            {
                pos = GeneratePos();
            }
            Instantiate(prefabCylinderCar, pos, Quaternion.identity);
            nbCylinderCar--;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        while (nbCylinderCar > 0)
        {
            Vector3 pos = GeneratePos();
            while(SetDestination(pos) == false)
            {
                pos = GeneratePos();
            }
            Instantiate(prefabCylinderCar, pos, Quaternion.identity);
            nbCylinderCar--;
        }
        while (nbCubeCar > 0)
        {
            Vector3 pos = GeneratePos();
            while(SetDestination(pos) == false)
            {
                pos = GeneratePos();
            }
            Instantiate(prefabCubeCar, pos, Quaternion.identity);
            nbCubeCar--;
        }
        while (nbSphereCar > 0)
        {
            Vector3 pos = GeneratePos();
            while(SetDestination(pos) == false)
            {
                pos = GeneratePos();
            }
            Instantiate(prefabSphereCar, pos, Quaternion.identity);
            nbSphereCar--;
        }
        while (nbCapsuleCar > 0)
        {
            Vector3 pos = GeneratePos();
            while(SetDestination(pos) == false)
            {
                pos = GeneratePos();
            }
            Instantiate(prefabCapsuleCar, pos, Quaternion.identity);
            nbCapsuleCar--;
        }
    }
    private bool SetDestination(Vector3 targetDestination)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(targetDestination, out hit, 1f, NavMesh.AllAreas))
        {
            return true;
        }
        return false;
    }

    private Vector3 GeneratePos()
    {
        return new Vector3(Random.Range(0,300), 0, Random.Range(0,300));
    }
}
