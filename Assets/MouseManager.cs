using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{
    [SerializeField] Camera _camera;

    [SerializeField] InputActionReference _mousePos;
    [SerializeField] InputActionReference _mouseClick;

    [SerializeField] Texture2D _resizeIcon;
    [SerializeField] Texture2D _moveIcon;

    GameObject _currentMoveCircle;
    GameObject _currentResizeCircle;


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
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.green);
        
    // On �crit le nom du collider que l'on vient de toucher
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);

            if(hit.collider.gameObject.CompareTag("Resize"))
            {
                Cursor.SetCursor(_resizeIcon, Vector2.zero, CursorMode.ForceSoftware);

                // Ici le curseur est au dessus du cercle violet + le joueur a cliqu�
                if (isButtonPressed)
                {
                    _currentResizeCircle = hit.collider.gameObject;
                }
                else
                {
                    _currentResizeCircle = null;
                }

            }
            else if(hit.collider.gameObject.CompareTag("Move"))
            { 
                Cursor.SetCursor(_moveIcon, Vector2.zero, CursorMode.ForceSoftware);

                // Ici le curseur est au dessus du cercle violet + le joueur a cliqu�
                if(isButtonPressed)
                {
                    _currentMoveCircle = hit.collider.gameObject;
                }
                else
                {
                    _currentMoveCircle = null;
                }

            }
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
            Debug.Log("rien touch�");
        }


        // On met � jour nos cercles
        if(_currentMoveCircle != null)
        {
            // Pour bouger l'effector on doit d�placer l'objet par rapport � la position du curseur.
            // Pour �a on demande � la camera de nous fournir la position du monde pour notre coordonn�e de souris
            Vector3 pos = _camera.ScreenToWorldPoint(mousePosition);
            Debug.Log(pos);
            // Le ScreenToWorldPoint nous donne un Z=-10 qui est pas top pour notre jeu, on retravail donc ce Z avant de le claquer dans la nouvelle position de notre objet
            pos.z = 0;
            // 
            _currentMoveCircle.transform.parent.parent.position = pos;
        }


        if(_currentResizeCircle !=null)
        {
            // R�cup�re la position du curseur dans le monde

            
            // On calcule distance entre le cercle et le curseur, on obtient le radius


            // On choppe le composant CircleShape et on lui change son radius

        }

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
