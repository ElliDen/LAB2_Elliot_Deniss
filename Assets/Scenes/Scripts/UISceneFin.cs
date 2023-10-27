using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UISceneFin : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtTempsTotal = default;
    [SerializeField] private TMP_Text _txtAccrochagesTotal = default;
    [SerializeField] private TMP_Text _txtPointageTotal = default;

    private GestionJeu _gestionJeu;

    private void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();

        _txtTempsTotal.text = "Temps Total : " + _gestionJeu.TempsFinal.ToString("f2") + " sec.";
        _txtAccrochagesTotal.text = "Collision : " + _gestionJeu.Pointage.ToString();
        float pointageFinal = _gestionJeu.TempsFinal + _gestionJeu.Pointage;
        _txtPointageTotal.text = "Pointage final : " + pointageFinal.ToString("f2") + " sec.";
    }
}
