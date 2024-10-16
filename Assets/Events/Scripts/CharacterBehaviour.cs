using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class CharacterBehaviour : MonoBehaviour
{
    [SerializeField] private HealthPoints _healthPoints;
    [SerializeField, Range(0, 3)] private int _health;
    private int value;

    private void Awake()
    {
        Health = 3;
    }

    private void Start()
    {
        _healthPoints.LoseHealthEvent += DebugLog;
        _healthPoints.LoseHealthEvent += LoseHealth;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _healthPoints.LoseHealthEvent?.Invoke();
        }
    }

    public int Health
    {
        get => _health;
        set
        {
            _health = Mathf.Clamp(value, 0, 3);
        }
    }

    private void DebugLog()
    {
        Debug.Log(Health);
    }

    public void LoseHealth()
    {
        Health -= 1;
    }

    private void OnDisable()
    {
        _healthPoints.LoseHealthEvent -= DebugLog;
        _healthPoints.LoseHealthEvent -= LoseHealth;
    }
}
