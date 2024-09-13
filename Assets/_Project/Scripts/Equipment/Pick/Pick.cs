using UnityEngine;
using VG;

public class Pick : MonoBehaviour
{
    [SerializeField] private float _miningDistance;
    [SerializeField] private float _extractTime;

    private Body _body;
    private OreSource _targetOreSource;

    private float _extractTimeLeft;


    private void Start()
    {
        _body = GetComponentInParent<Body>();
    }

    private void Update()
    {
        OnFindCicle();
        if (oreSourceIsAvailable) Using();
    }


    private bool oreSourceIsAvailable
    {
        get
        {
            if (_targetOreSource == null) return false;

            float distance = Vector3.Distance(_body.transform.position,
                _targetOreSource.transform.position);
            return distance < _miningDistance;
        }
    }


    private void OnFindCicle()
    {
        if (oreSourceIsAvailable) return;

        foreach (var oreSource in OreSource.all)
        {
            float distance = Vector3.Distance(_body.transform.position,
                oreSource.transform.position);

            if (distance < _miningDistance)
            {
                StartUsing(oreSource);
                return;
            }
        }

        StopUsing();
    }

    private void StartUsing(OreSource oreSource)
    {
        _body.animator.SetBool("LazerCutter", true);
        _targetOreSource = oreSource;
        _extractTimeLeft = _extractTime;
    }

    private void Using()
    {
        Vector3 lookDirection = (_targetOreSource.transform.position -
            _body.transform.position).normalized;
        lookDirection.y = 0f;

        _body.transform.forward = lookDirection;

        _extractTimeLeft -= Time.deltaTime;
        if (_extractTimeLeft < 0f)
        {
            _extractTimeLeft = _extractTime;
            Saves.Int[Key_Save.item_quantity(_targetOreSource.itemType)].Value++;
        }

    }

    private void StopUsing()
    {
        _body.animator.SetBool("LazerCutter", false);
        _targetOreSource = null;
        _body.transform.localRotation = Quaternion.identity;
    }


    




}
