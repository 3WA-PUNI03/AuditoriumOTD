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
        // On r�cup�re si le bouton gauche est press� ou pas
        bool isButtonPressed;
// A vous de faire

        Debug.Log(isButtonPressed);

        // On r�cup�re les coordonn�es de la souris
        Vector2 mousePosition;
// A vous de faire


        Debug.Log(mousePosition);

    }
}
