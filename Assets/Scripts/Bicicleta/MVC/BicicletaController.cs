using System;
using System.Collections;
using UnityEngine;

public class BicicletaController : MonoBehaviour
{
    private BicicletaModel model;
    private BicicletaView view;

    private void Start()
    {
        model = GetComponentInParent<BicicletaModel>();
        view = transform.parent.Find("Visuals").GetComponent<BicicletaView>();
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
            if (_other.TryGetComponent(out AudioSource audioSource) && !audioSource.isPlaying)
            {
                _other.GetComponent<SpriteRenderer>().enabled = false;
                audioSource.Play();
                StartCoroutine(PlayAudioBeforeDelete(audioSource, _other));
            }
        }

        model.InteragirComObjetos(_other);
    }

    IEnumerator PlayAudioBeforeDelete(AudioSource _audioSource, Collider _other)
    {
        while (_audioSource.isPlaying)
        {
            yield return null;
        }
        Destroy(_other.gameObject);
    }
}
