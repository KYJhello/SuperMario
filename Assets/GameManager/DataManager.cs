using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    // 코인 갱신
    [SerializeField] private int coinCount;

    public UnityAction<int> OnCoinChanged;

    public void AddCoinCount(int count)
    {
        coinCount += count;
        OnCoinChanged?.Invoke(coinCount);
    }

    // 스코어 갱신
    [SerializeField] private int scoreCount;

    public UnityAction<int> OnScoreChanged;

    public void AddScoreCount(int count)
    {
        scoreCount += count;
        OnScoreChanged?.Invoke(scoreCount);
    }
}
