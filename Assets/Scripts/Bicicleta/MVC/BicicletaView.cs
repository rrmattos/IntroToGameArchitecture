using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BicicletaView : MonoBehaviour
{
    public TextMeshProUGUI PontuacaoTexto;
    [HideInInspector] public SpriteRenderer SRenderer;

    private void Start()
    {
        if(SRenderer == null) SRenderer = GetComponent<SpriteRenderer>();
    }

    public void AtualizarPontuacao(int _pontuacao)
    {
        PontuacaoTexto.text = "Score: " + _pontuacao.ToString();
    }
}
