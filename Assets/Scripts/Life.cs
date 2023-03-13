using UnityEngine;
using System;

public class Life : MonoBehaviour {
    public int Lives = 3;
    public event Action<int> OnLivesChanged;

    public int DecreaseLives() {
        Lives--;
        OnLivesChanged?.Invoke(Lives);
        return Lives;
    }

    public int IncreaseLives() {
        Lives++;
        OnLivesChanged?.Invoke(Lives);
        return Lives;
    }
}
