using UnityEngine;
using UnityEngine.Events;

public class DoEveryX : MonoBehaviour
{
    [SerializeField]
    private float intervalInSeconds = 1f; // Serialized float to specify the interval

    public UnityEvent repeatedEvent; // UnityEvent to be invoked repeatedly

    private void Start()
    {
        InvokeRepeating("InvokeRepeatedEvent", 0f, intervalInSeconds);
    }

    private void InvokeRepeatedEvent()
    {
        repeatedEvent.Invoke();
    }
}
