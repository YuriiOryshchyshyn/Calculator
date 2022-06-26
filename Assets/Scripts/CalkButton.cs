using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalkButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _button;

    public Button Button => _button;
    public string Text => _text.text;
}
