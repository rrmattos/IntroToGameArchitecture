using UnityEngine;

public class BicicletaCore
{
    public float Velocidade { get; set; } = 8;
    public bool PodeAndar { get; set; } = true;

    public void InteragirComObjeto(GameObject _objeto)
    {
        if (_objeto.CompareTag("Obstaculo"))
        {
            Debug.Log("Bateu no obstáculo!");
            PodeAndar = false;
        }
        else if (_objeto.CompareTag("Moeda"))
        {
            PodeAndar = true;
            _objeto.SetActive(false);
            MonoBehaviour.Destroy(_objeto);
        }
    }
}
