using System;
using TMPro;
using UnityEngine;

public class PontuacaoRefObserver : MonoBehaviour 
{
    public static event Action<TextMeshProUGUI> OnGetReference;
    private static TextMeshProUGUI textMesh;

    private PontuacaoRefObserver() { }
    
    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    public static void SetReference()
    {
        OnGetReference?.Invoke(textMesh);
    }
}
