using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    [SerializeField] private Transform[] _transformImages;
    [SerializeField] private RotatingScript[] _rotatingScripts;

    [SerializeField] private float _rotationSpeed;

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

    public void Update()
    {
        _transformImages[0].rotation = Quaternion.Euler(0, 0, _transformImages[0].rotation.eulerAngles.z+_rotationSpeed*Time.deltaTime*(int)_rotatingScripts[0].RotateDirection);
        _transformImages[1].rotation = Quaternion.Euler(0, 0, _transformImages[1].rotation.eulerAngles.z+_rotationSpeed*Time.deltaTime*(int)_rotatingScripts[1].RotateDirection);
        _transformImages[2].rotation = Quaternion.Euler(0, 0, _transformImages[2].rotation.eulerAngles.z+_rotationSpeed*Time.deltaTime*(int)_rotatingScripts[2].RotateDirection);
    }

    public void ChangeRotationButton(int id)
    {
        if (id == 2)
        {
            _rotatingScripts[3].ChangeRotate();
        }
        _rotatingScripts[id].ChangeRotate();
    }
}
