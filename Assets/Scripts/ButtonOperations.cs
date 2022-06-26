using System;
using TMPro;
using UnityEngine;

public static class ButtonOperations
{
    private static TMP_Text _inputField;
    private static CalkButton _calculateButton;
    private static float _firstNumber;

    public static void Init(TMP_Text inputField, CalkButton calkulateButton)
    {
        _inputField = inputField;
        _calculateButton = calkulateButton;
    }

    public static void SetFirstNumber(float number)
    {
        _firstNumber = number;
    }

    public static void Multiple()
    {
        DoCalkulateOperation((float firstNumber, float secondNumber) => firstNumber * secondNumber);
    }

    public static void Division()
    {
        DoCalkulateOperation((float firstNumber, float secondNumber) => firstNumber / secondNumber);
    }

    public static void Substraction()
    {
        DoCalkulateOperation((float firstNumber, float secondNumber) => firstNumber - secondNumber);
    }

    public static void Summa()
    {
        DoCalkulateOperation((float firstNumber, float secondNumber) => firstNumber + secondNumber);
    }

    private static void DoCalkulateOperation(Func<float, float, float> operation)
    {
        if (TryGetSecondNumber(out float secondNumber))
        {
            float result = operation.Invoke(_firstNumber, secondNumber);
            _inputField.text = result.ToString();
            _calculateButton.Button.onClick.RemoveAllListeners();
        }
    }

    private static bool TryGetSecondNumber(out float num)
    {
        num = 0;
        if (_inputField.text == string.Empty)
            return false;

        string number = _inputField.text;
        if (float.TryParse(number, out float secondNumber))
        {
            num = secondNumber;
            return true;
        }

        return false;
    }
}