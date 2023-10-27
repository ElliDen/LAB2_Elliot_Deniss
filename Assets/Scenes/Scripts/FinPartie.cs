using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinPartie : MonoBehaviour
{
    // ***** Attributs *****
    
    private bool _finPartie = false;  // bool�en qui d�termine si la partie est termin�e
    private GestionJeu _gestionJeu; // attribut qui contient un objet de type GestionJeu
    private Player _player;  // attribut qui contient un objet de type Player

    // ***** M�thode priv�es  *****
    
    private void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();  // r�cup�re sur la sc�ne le gameObject de type GestionJeu
        _player = FindObjectOfType<Player>();  // r�cup�re sur la sc�ne le gameObject de type Player
    }

    /*
     * M�thode qui se produit quand il y a collision avec le gameObject de fin
     */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !_finPartie)  // Si la collision est produite avec le joueur et la partie n'est pas termin�e
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;  // on change la couleur du mat�riel � vert
            int noScene = SceneManager.GetActiveScene().buildIndex; // R�cup�re l'index de la sc�ne en cours
            if (noScene == (SceneManager.sceneCountInBuildSettings - 2))  // Si nous somme sur la derni�re sc�ne
            {
                _gestionJeu.SetTempsFinal(Time.time);
            }
            SceneManager.LoadScene(noScene + 1);
        }
    }
}
