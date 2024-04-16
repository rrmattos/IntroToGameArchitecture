using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bicicleta : MonoBehaviour
{
    public float Velocidade;
    public bool EstaAndando;
    public AudioSource AudioSource;

    public TextMeshProUGUI PontuacaoTexto;
    private int pontuacao;

    private void Start()
    {
        pontuacao = 0;
        PontuacaoTexto.text = "Score: " + pontuacao.ToString();
    }

    private void Update()
    {
        Mover();
    }

    private void Mover()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * movimentoHorizontal * Velocidade * Time.deltaTime);
        if(movimentoHorizontal < 0) transform.GetComponent<SpriteRenderer>().flipX = false;
        else if (movimentoHorizontal > 0) transform.GetComponent<SpriteRenderer>().flipX = true;
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.CompareTag("Obstaculo"))
        {
            Debug.Log("Bateu no obstáculo!");
            Velocidade = 0;
            EstaAndando = false;
        }
        else if (_other.gameObject.CompareTag("Moeda"))
        {
            AudioSource.Play();
            AumentarPontuacao(10);
            Destroy(_other.gameObject);
        }
    }

    private void AumentarPontuacao(int _valor)
    {
        pontuacao += _valor;
        PontuacaoTexto.text = "Score: " + pontuacao.ToString();
    }
}
