using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EFieldItemType
{
    MonsterKill = 0,
    SpeedUpgrade,
    MagnetUpgrade,
    None
}

[System.Serializable]
public class FieldItemData
{
    public EFieldItemType FieldItemType = EFieldItemType.None;
    public Sprite Sprite;
}

public class FieldItem : MonoBehaviour
{
    private Image _image;

    public FieldItemData CurrentData;

    public List<FieldItemData> FieldItemDataList = new List<FieldItemData>();

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponentInChildren<Image>();

        if(FieldItemDataList.Count > 0)
        {
            CurrentData = FieldItemDataList[Random.Range(0, FieldItemDataList.Count + 1)];
        }

        if(CurrentData != null)
        {
            switch (CurrentData.FieldItemType)
            {
                case EFieldItemType.MonsterKill:
                    GameManager.Instance.KillAllMonstersInField();
                    break;
                case EFieldItemType.SpeedUpgrade:
                    GameManager.Instance.PlayerSpeedUp();
                    break;
                case EFieldItemType.MagnetUpgrade:
                    GameManager.Instance.PlayerMagnetUp();
                    break;
                case EFieldItemType.None:
                    Destroy(gameObject);
                    break;
                default:
                    break;
            }
        }
    }
}