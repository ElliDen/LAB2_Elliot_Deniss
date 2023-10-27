using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GestionJeu : MonoBehaviour
{
    // ***** Attributs *****
    private int _pointage = 0;  // Attribut qui conserve le nombre d'accrochages
    public int Pointage => _pointage;

    private float _tempsDepart = 0.0f;
    public float TempsDepart => _tempsDepart;

    private float _tempsFinal = 0.0f;
    public float TempsFinal => _tempsFinal;

    // ***** Méthodes privées *****
    private void Awake()
    {
        // Vérifie si un gameObject GestionJeu est déjà présent sur la scène si oui
        // on détruit celui qui vient d'être ajouté. Sinon on le conserve pour le 
        // scène suivante.
        int nbGestionJeu = FindObjectsOfType<GestionJeu>().Length;
        if (nbGestionJeu > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        _tempsDepart = Time.time;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(gameObject);
        }
    }

    // ***** Méthodes publiques ******

    /*
     * Méthode publique qui permet d'augmenter le pointage de 1
     */
    public void AugmenterPointage()
    {
        _pointage++;
        UIManager uiManager = FindObjectOfType<UIManager>();
        uiManager.ChangerPointage(_pointage);
    }

    // Méthode qui reçoit les valeurs pour le niveau 1 et qui modifie les attributs respectifs
    public void SetTempsFinal(float p_tempsFinal)
    {
        _tempsFinal = p_tempsFinal - _tempsDepart;
    }
}
