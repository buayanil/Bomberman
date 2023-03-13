using System;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Image heartPrefab; // The heart image
    public float heartSpacing = 20f; // The distance between each heart image
    public Life life;
    private int currentLives;
    private Image[] hearts;

    void Start()
    {
        // Set the starting number of lives
        currentLives = life.Lives;

        // Create an array of heart images
        hearts = new Image[currentLives];
        for (int i = 0; i < currentLives; i++)
        {
            Image heartObj = Instantiate(heartPrefab, transform);
            heartObj.rectTransform.localPosition = new Vector3(i * heartSpacing, 0, 0);
            hearts[i] = heartObj;
        }

        // Subscribe to the OnLivesChanged event of the Life component
        life.OnLivesChanged += UpdateLivesUI;
    }

    void UpdateLivesUI(int newLives)
{
    // Update the current number of lives
    currentLives = newLives;

    // Resize the hearts array if necessary
    if (currentLives > hearts.Length)
    {
        Array.Resize(ref hearts, currentLives);
        for (int i = hearts.Length - 1; i >= currentLives; i--)
        {
            Destroy(hearts[i].gameObject);
        }
    }

    // Update the heart images based on the number of lives
    for (int i = 0; i < hearts.Length; i++)
    {
        if (i < currentLives)
        {
            if (hearts[i] == null)
            {
                hearts[i] = Instantiate(heartPrefab, transform);
                hearts[i].rectTransform.localPosition = new Vector3(i * heartSpacing, 0, 0);
            }
            hearts[i].enabled = true;
        }
        else
        {
            if (hearts[i] != null)
            {
                Destroy(hearts[i].gameObject);
            }
        }
    }
}

public void LoseLife()
{
    // Subtract one from the current lives
    currentLives--;

    // Update the heart images based on the number of lives
    for (int i = 0; i < hearts.Length; i++)
    {
        if (i < currentLives)
        {
            if (hearts[i] == null)
            {
                hearts[i] = Instantiate(heartPrefab, transform);
                hearts[i].rectTransform.localPosition = new Vector3(i * heartSpacing, 0, 0);
            }
            hearts[i].enabled = true;
        }
        else
        {
            if (hearts[i] != null)
            {
                Destroy(hearts[i].gameObject);
            }
        }
    }
}

}

