using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{

    [SerializeField] InputActionReference _mousePos;
    [SerializeField] InputActionReference _mouseClick;


    void Update()
    {
        // On récupère si le bouton gauche est pressé ou pas
        bool isButtonPressed;
// A vous de faire

        Debug.Log(isButtonPressed);

        // On récupère les coordonnées de la souris
        Vector2 mousePosition;
// A vous de faire


        Debug.Log(mousePosition);

    }
}
