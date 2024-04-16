using UnityEngine;

public class BicicletaAdapter : MonoBehaviour
{
    private BicicletaCore bicicleta;
    private SpriteRenderer spriteRenderer;

    private IPontuacaoService pontuacaoService;
    private IAudioService audioService;

    private void Start()
    {
        bicicleta = new BicicletaCore();
        pontuacaoService = new LocalPontuacaoService();
        audioService = new AudioService();
        spriteRenderer = transform.parent.GetComponentInChildren<SpriteRenderer>();
    }

    public void Mover(float _movimentoHorizontal)
    {
        if (bicicleta.PodeAndar)
        {
            transform.parent.Translate(Vector3.right * _movimentoHorizontal * bicicleta.Velocidade * Time.deltaTime);
            if (_movimentoHorizontal < 0 && spriteRenderer.flipX) spriteRenderer.flipX = false;
            else if (_movimentoHorizontal > 0 && !spriteRenderer.flipX) spriteRenderer.flipX = true;
        }
    }

    private void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        Mover(movimentoHorizontal);
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Moeda"))
        {
            pontuacaoService.AumentarPontuacao(10);
            AudioClip audio = _other.GetComponent<Moeda>().Audio;
            audioService.TocarSom(audio);
        }

        bicicleta.InteragirComObjeto(_other.gameObject);
    }
}
