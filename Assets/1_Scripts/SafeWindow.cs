using UnityEngine;
using UnityEngine.UI;

public class SafeWindow : Singletone<SafeWindow>
{
    [SerializeField] private Text[] numberTexts;
    [SerializeField] private Text messageText;
    [SerializeField] private GameObject substarate;

    private int[] currentNumbers = new int[4] { 1, 2, 3, 4 };
    private int[] needNumbers;

    private Safe currentSafe;

    public void OpenWindow(Safe safe)
    {
        currentSafe = safe;

        needNumbers = safe.GetCode;
        UpdateTexts();

        substarate.SetActive(true);
    }

    public void IncrementNumber(int number)
    {
        if (currentNumbers[number] == 9)
        {
            currentNumbers[number] = 0;
        }
        else
        {
            currentNumbers[number]++;
        }

        UpdateTexts();
    }

    public void DecrementNumber(int number)
    {
        if (currentNumbers[number] == 0)
        {
            currentNumbers[number] = 9;
        }
        else
        {
            currentNumbers[number]--;
        }

        UpdateTexts();
    }

    private void UpdateTexts()
    {
        for (int i = 0; i < currentNumbers.Length; i++)
        {
            numberTexts[i].text = currentNumbers[i].ToString();
        }
    }

    public void TryOpenSafe()
    {
        bool isOpen = true;

        for (int i = 0; i < currentNumbers.Length; i++)
        {
            if(currentNumbers[i] != needNumbers[i])
            {
                isOpen = false;
            }
        }

        if(isOpen)
        {
            currentSafe.Open();
            substarate.SetActive(false);
        }
        else
        {
            messageText.text = "Не угадал!";
            Invoke("ClearMessageText", 1.5f);
        }
    }

    private void ClearMessageText()
    {
        messageText.text = "";
    }

    public void CloseWindow()
    {
        substarate.SetActive(false);
    }
}
