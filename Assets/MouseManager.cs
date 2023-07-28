using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{
    [SerializeField] Camera _camera;

    [SerializeField] InputActionReference _mousePos;
    [SerializeField] InputActionReference _mouseClick;

    [SerializeField] Texture2D _resizeIcon;
    [SerializeField] Texture2D _moveIcon;

    void Update()
    {
    // On r�cup�re si le bouton gauche est press� ou pas
        bool isButtonPressed;
        isButtonPressed = _mouseClick.action.IsPressed();
        //Debug.Log($"Left button : {isButtonPressed}");

    // On r�cup�re les coordonn�es de la souris
        Vector2 mousePosition;
        mousePosition = _mousePos.action.ReadValue<Vector2>();
        //Debug.Log($"Mouse Pos : {mousePosition}");


    // On r�cup�re un rayon de la part de la camera par rapport � la position du curseur du jeu
        Ray ray = _camera.ScreenPointToRay(mousePosition);
    // On demande au moteur physique de produire le raycast pour detecter un collider sur le chemin
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        
        // On �crit le nom du collider que l'on vient de toucher
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);

            if(hit.collider.gameObject.CompareTag("Resize"))
            {
                Cursor.SetCursor(_resizeIcon, Vector2.zero, CursorMode.ForceSoftware);
            }
            else if(hit.collider.gameObject.CompareTag("Move"))
            { 
                Cursor.SetCursor(_moveIcon, Vector2.zero, CursorMode.ForceSoftware);
            }
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
            Debug.Log("rien touch�");
        }


        Debug.DrawRay(ray.origin, ray.direction * 10, Color.green);
        

        #region 
        // Explication de base du raycast
        Vector3 origin = new Vector3(1, 1, 0);
        Vector3 dir = Vector3.right * 2;
        if(    Physics2D.Raycast(origin, dir, 2f)     )
        {
            Debug.DrawRay(origin, dir, Color.green);
        }
        else
        {
            Debug.DrawRay(origin, dir, Color.red);
        }
        #endregion


    }
}
