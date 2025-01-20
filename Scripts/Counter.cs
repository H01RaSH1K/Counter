using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float _waitTime = 0.5f;
    private WaitForSeconds _wait;
    private Coroutine _countingCoroutine;

    public event Action ValueChanged;
    public int Value { get; private set; } = 0;
    public bool Counting => _countingCoroutine != null;

    private void Start()
    {
        _wait = new WaitForSeconds(_waitTime);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeState();
        }
    }

    private void StartCounting()
    {
        _countingCoroutine = StartCoroutine(Count());
    }

    private void StopCounting()
    {
        StopCoroutine(_countingCoroutine);
        _countingCoroutine = null;
    }

    private IEnumerator Count()
    {
        while (true)
        {
            yield return _wait;
            IncreaseValue();
        }
    }

    private void IncreaseValue()
    {
        Value++;
        ValueChanged?.Invoke();
    }

    public void ChangeState()
    {
        if (Counting)
        {
            StopCounting();
            return;
        }
        StartCounting();
    }
}
