using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    [SerializeField] private TMP_Text _inputField;
    [SerializeField] private CalkButton _calculateButton;
    [SerializeField] private CalkButton _multipleButton;

    private void Awake()
    {
        ButtonOperations.Init(_inputField, _calculateButton);
    }

    public void PrintText(CalkButton button)
    {
        if (_inputField.text == "0" || _inputField.text == string.Empty)
        {
            _inputField.text = button.Text;
        }
        else
        {
            _inputField.text += button.Text;
        }
    }

    public void Multiple()
    {
        DoOperation(ButtonOperations.Multiple);
    }

    public void Summa()
    {
        DoOperation(ButtonOperations.Summa);
    }

    public void Division()
    {
        DoOperation(ButtonOperations.Division);
    }

    public void Subtraction()
    {
        DoOperation(ButtonOperations.Substraction);
    }

    private void DoOperation(UnityAction action)
    {
        if (TryGetFirstNumber(out float firstNumber))
        {
            ButtonOperations.SetFirstNumber(firstNumber);
            _inputField.text = "0";
            _calculateButton.Button.onClick.AddListener(action);
        }
    }

    private bool TryGetFirstNumber(out float number)
    {
        number = 0;
        if (_inputField.text == string.Empty)
            return false;

        if (float.TryParse(_inputField.text, out float firstNumber))
        {
            number = firstNumber;
            return true;
        }

        return false;
    }

    public void CleanInputField()
    {
        _inputField.text = "0";
        _calculateButton.Button.onClick.RemoveAllListeners();
    }
}
