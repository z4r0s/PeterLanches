using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CtrlHUD : MonoBehaviour
{

    public int moedas;
    public Text texto;
    public GameObject HudGameOver;
    public GameObject TelaConfiguracoes;
    public GameObject btOpt;
    public AudioSource abatido;
    public AudioSource pwrUp;
    public GameObject BT_Opcoes;
    public float km;
    public int entregas;
    public Text KmText;
    public Text EntregasText;

    public void Start()
    {
        moedas = 0;
        entregas = 0;
        km = 0;
        texto.text = moedas.ToString();
    }

    public void Update()
    {
        texto.text = moedas.ToString();
        km += Time.deltaTime * 10f;
        KmText.text = Mathf.Round(km).ToString() + "m";
        EntregasText.text = entregas.ToString();
    }

    public void AttEntregas()
    {
        entregas += 1;
    }

    public void AttMoedas()
    {
        moedas += 10;
    }

    public void LoadFase(string cena)
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        HudGameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public void Bt_Sair()
    {
        Application.Quit();
        Debug.Log("Saiu");
    }

    public void SomAbatido()
    {
        abatido.Play();
    }

    public void SomPwrUp()
    {
        pwrUp.Play();
    }

    public void AbrirTela(GameObject tela)
    {
        tela.SetActive(true);
        BT_Opcoes.SetActive(false);
        Time.timeScale = 0;
    }

    public void BT_Cancel(GameObject tela)
    {
        tela.SetActive(false);
        BT_Opcoes.SetActive(true);
        Time.timeScale = 1;
    }
}


