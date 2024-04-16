using TMPro;
using UnityEngine;

public class PontuacaoService : IPontuacaoService
{
    private int pontuacao;
    private TextMeshProUGUI textMeshPontuacao;

    public void AumentarPontuacao(int _valor)
    {
        pontuacao += _valor;

        if (textMeshPontuacao == null)
            textMeshPontuacao = GameObject.FindGameObjectWithTag("Pontuacao").GetComponent<TextMeshProUGUI>();

        textMeshPontuacao.text = "Score: " + pontuacao;
    }
}


public interface IPontuacaoService
{
    void AumentarPontuacao(int _valor);
}