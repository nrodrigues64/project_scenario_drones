using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
Class : StartMenu
Description : A class to control the game at the start
*/
public class StartMenu : MonoBehaviour
{
    [SerializeField] private Slider sliderCube;
    [SerializeField] private Slider sliderSphere;
    [SerializeField] private Slider sliderCapsule;
    [SerializeField] private Slider sliderCylinder;

    [SerializeField] private Text txtCube;
    [SerializeField] private Text txtSphere;
    [SerializeField] private Text txtCapsule;
    [SerializeField] private Text txtCylinder;

    [SerializeField] private Button startButton;
    // Start is called before the first frame update
    void Start()
    {
        sliderCube.onValueChanged.AddListener (delegate {OnValueChangedCube ();});
        sliderSphere.onValueChanged.AddListener (delegate {OnValueChangedSphere ();});
        sliderCylinder.onValueChanged.AddListener (delegate {OnValueChangedCylinder ();});
        sliderCapsule.onValueChanged.AddListener (delegate {OnValueChangedCapsule ();});
        startButton.onClick.AddListener (delegate {StartSimulation ();});
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnValueChangedCube() {
        txtCube.text = sliderCube.value.ToString();
    }
    void OnValueChangedSphere() {
        txtSphere.text = sliderSphere.value.ToString();
    }
    void OnValueChangedCapsule() {
        txtCapsule.text = sliderCapsule.value.ToString();
    }
    void OnValueChangedCylinder() {
        txtCylinder.text = sliderCylinder.value.ToString();
    }

    void StartSimulation() {
        SpawnerCars.nbCapsuleCar = (int)sliderCapsule.value;
        SpawnerCars.nbCubeCar = (int)sliderCube.value;
        SpawnerCars.nbCylinderCar = (int)sliderCylinder.value;
        SpawnerCars.nbSphereCar = (int)sliderSphere.value;
        SceneManager.LoadScene("SampleScene");

    }
}
