using UnityEngine;
using System.IO;

public class LocalPontuacaoService : IPontuacaoService
{
    private int pontuacao;
    private readonly string fileName = "pontuacao.txt";

    public LocalPontuacaoService()
    {
        if (File.Exists(Application.persistentDataPath + fileName))
        {
            string data = File.ReadAllText(Application.persistentDataPath + fileName);
            int.TryParse(data, out pontuacao);
        }
    }

    public void AumentarPontuacao(int valor)
    {
        pontuacao += valor;
        SalvarPontuacao();
    }

    private void SalvarPontuacao()
    {
        File.WriteAllText(Application.persistentDataPath + fileName, pontuacao.ToString());
        Debug.Log($"Pontuação salva em {Application.persistentDataPath + fileName}");
    }
}