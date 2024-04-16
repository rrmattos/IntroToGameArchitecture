using UnityEngine;

public class BicicletaModel2 : MonoBehaviour
{
    public float Velocidade = 8;
    public bool PodeAndar = true;

    public void Mover(float _movimentoHorizontal)
    {
        if (PodeAndar)
        {
            transform.Translate(Vector3.right * _movimentoHorizontal * Velocidade * Time.deltaTime);
        }
    }

    public void InteragirComObjetos(Collider _other)
    {
        if (_other.gameObject.CompareTag("Obstaculo"))
        {
            Debug.Log("Bateu no obstáculo!");
            Velocidade = 0;
            PodeAndar = false;
        }
        else if (_other.gameObject.CompareTag("Moeda"))
        {
            PodeAndar = true;
            Destroy(_other.gameObject);
        }
    }
}
