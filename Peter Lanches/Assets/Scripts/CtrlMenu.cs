using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CtrlMenu : MonoBehaviour
{
    public GameObject TelaMenu;
    public GameObject TelaComoJogar;
    public GameObject TelaCreditos;
    public GameObject TelaConfiguracoes;
    public GameObject BT_Opcoes;

    public void BT_Options()
    {
        BT_Opcoes.SetActive(false);
        TelaMenu.SetActive(false);
        TelaConfiguracoes.SetActive(true);
    }

    public void BT_Cancel(GameObject tela)
    {
        BT_Opcoes.SetActive(true);
        tela.SetActive(false);
        TelaMenu.SetActive(true); 
    }

    public void BT_Voltar(GameObject tela)
    {
        tela.SetActive(false);
        TelaMenu.SetActive(true);
    }

    public void AbrirTela(GameObject tela)
    {
        TelaMenu.SetActive(false);
        tela.SetActive(true);
    }

    public void LoadFase(string cena)
    {
        SceneManager.LoadScene("Fase1");
    }

    public void QuitGame()
    {
        Debug.Log("Saiu");
        Application.Quit();
    }
}
