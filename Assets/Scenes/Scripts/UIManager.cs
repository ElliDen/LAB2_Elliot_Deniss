using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtAccrochages = default;
    [SerializeField] private TMP_Text _txtTemps = default;
    [SerializeField] private GameObject _menuPause = default;

    private GestionJeu _gestionJeu;
    private bool _enPause = false;

    private void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
        _txtAccrochages.text = "Accrochages : " + _gestionJeu.Pointage.ToString();
        Time.timeScale = 1;
        _enPause = false;
    }

    private void Update()
    {
        float temps = Time.time - _gestionJeu.TempsDepart;
        _txtTemps.text = "Temps :" + temps.ToString("f2");
        GestionPause();
    }

    private void GestionPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_enPause)
        {
            _menuPause.SetActive(true);
            Time.timeScale = 0;
            _enPause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _enPause)
        {
            EnleverPause();
        }
    }
    
    public void ChangerPointage(int nouveauPointage)
    {
        _txtAccrochages.text = "Accrochages : " + nouveauPointage;
    }

    public void EnleverPause()
    {
        _menuPause.SetActive(false);
        Time.timeScale = 1;
        _enPause = false;
    }
}
