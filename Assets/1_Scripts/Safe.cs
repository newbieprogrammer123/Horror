using UnityEngine;

public class Safe : MonoBehaviour
{
    [SerializeField] private int[] code;

    private GameObject battery;
    private bool isOpen;

    public int[] GetCode 
    { 
        get
        {
            return code;
        } 
    }

    private void Start()
    {
        battery = transform.GetChild(0).gameObject;
    }

    public void Interacte()
    {
        if (!isOpen)
        {
            SafeWindow.Instance.OpenWindow(this);
        }
    }

    public void CancelInteracte()
    {
        SafeWindow.Instance.CloseWindow();
    }

    public void Open()
    {
        isOpen = true;

        battery.SetActive(true);

        Screamer.Instance.Show();
    }
}
