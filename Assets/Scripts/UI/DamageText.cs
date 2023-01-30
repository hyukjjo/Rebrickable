using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _damageText;
    [SerializeField]
    private Animator _animator;

    public void ShowText(float dam, Transform target)
    {
        _damageText.text = dam.ToString();
        transform.position = target.position;
        _animator.SetTrigger("Hit");
    }

    private void Update()
    {
        if(_animator.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            HideText();
        }
    }

    public void HideText()
    {
        ObjectPoolManager.Instance.Despawn(GetComponent<PoolObject>());
    }
}
