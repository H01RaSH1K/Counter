using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _counterText;

    private void OnEnable()
    {
        _counter.ValueChanged += ChangeCounterText;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= ChangeCounterText;
    }

    private void ChangeCounterText()
    {
        _counterText.text = _counter.Value.ToString();
    }
}
