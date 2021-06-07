using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image _autoButton;
    private GameObject _settingsMenu;
    private FlipperController _flippers;

    private void Awake()
    {
        _settingsMenu = this.transform.GetChild(0).gameObject;    
    }

    private void Start()
    {
        _flippers = FlipperController.Instance;
    }

    public void ChangeAuto()
    {
        _flippers.AutoFlippers = !_flippers.AutoFlippers;
        _autoButton.sprite = (_flippers.AutoFlippers) ? _sprites[0] : _sprites[1];
        
    }

    public void ChangeState(bool State)
    {
        _settingsMenu.SetActive(State);
        _autoButton.sprite = (_flippers.AutoFlippers) ? _sprites[0] : _sprites[1];
    }
}
