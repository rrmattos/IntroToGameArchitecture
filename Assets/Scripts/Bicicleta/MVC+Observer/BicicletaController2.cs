using UnityEngine;

public class BicicletaController2 : MonoBehaviour
{
    private BicicletaModel2 model;
    private BicicletaView2 view;
    private AudioSource audioController;

    private void Start()
    {
        model = GetComponentInParent<BicicletaModel2>();
        view = transform.parent.Find("Visuals").GetComponent<BicicletaView2>();

        AudioRefObserver.OnGetReference += GetAudioControllerRef;
        try { AudioRefObserver.SetReference(); }
        finally { AudioRefObserver.OnGetReference -= GetAudioControllerRef; }
    }

    private void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        HandleMovement(movimentoHorizontal);
    }

    private void HandleMovement(float _direcao)
    {
        model.Mover(_direcao);
        if (_direcao < 0 && view.SRenderer.flipX) view.SRenderer.flipX = false;
        else if (_direcao > 0 && !view.SRenderer.flipX) view.SRenderer.flipX = true;
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.CompareTag("Moeda"))
        {
            view.AtualizarPontuacao(10);
            audioController.clip = _other.GetComponent<Moeda>().Audio;
            audioController.Play();
        }

        model.InteragirComObjetos(_other);
    }

    private void GetAudioControllerRef(AudioSource _audioController)
    {
        audioController = _audioController;
    }
}
