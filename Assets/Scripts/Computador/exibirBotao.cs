using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class exibirBotao : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Configura��o do bot�o")]
    public Button botao;
    public TextMeshProUGUI textoBotao;
    private GameObject gameObjectBotao;

    [Header("Objeto do jogador")]
    public GameObject player;

    [Header("Tela do comutador para abrir")]
    public GameObject tela;

    private int estadoBotao = 0;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        estadoBotao = 0;
        ResetarBotao();
        Debug.Log("Personagem: " + player);
        gameObjectBotao = botao.gameObject;
        if (collision.gameObject.tag == "Player") {
            gameObjectBotao.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            gameObjectBotao.SetActive(false);
        }
    }

    void ExibirTelaComputador() {
        // Congela rota��o do personagem
        player.GetComponent<Rigidbody2D>().isKinematic = true;
        tela.SetActive(true);
        ResetarBotao();
    }

    void FecharTela() {
        tela.SetActive(false);
        player.GetComponent<Rigidbody2D>().isKinematic = false;
        ResetarBotao();
    }

    void ResetarBotao() {
        botao.onClick.RemoveAllListeners();
        if (estadoBotao == 0) {
            textoBotao.text = "Abrir";
            botao.onClick.AddListener(ExibirTelaComputador);
            estadoBotao = 1;
        } else {
            textoBotao.text = "Fechar";
            botao.onClick.AddListener(FecharTela);
            estadoBotao = 0;
        }
    }


}
