using TMPro;
using UnityEngine;

public class BicicletaView2 : MonoBehaviour
{
    private TextMeshProUGUI pontuacaoTexto;
    [HideInInspector] public SpriteRenderer SRenderer;

    private void Start()
    {
        if (SRenderer == null) SRenderer = GetComponent<SpriteRenderer>();

        PontuacaoRefObserver.OnGetReference += GetPontuacaoReference;
        try { PontuacaoRefObserver.SetReference(); }
        finally { PontuacaoRefObserver.OnGetReference -= GetPontuacaoReference; }
    }

    private void GetPontuacaoReference(TextMeshProUGUI _ref)
    {
        pontuacaoTexto = _ref;
    }

    public void AtualizarPontuacao(int _novaPontuacao)
    {
        pontuacaoTexto.text = "Score: " + _novaPontuacao.ToString();
    }
}
