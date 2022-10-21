using System;
using System.Collections;
using System.Collections.Generic;
using Character.Actions;
using Character.Command;
using UnityEngine;

public class ThumbnailManager : MonoBehaviour
{
    [SerializeField] private AttackThumbnail _thumbnail;

    [SerializeField] private List<Attack> attacks;

    private void Start()
    {
        GenerateThumbnails();
    }

    private void GenerateThumbnails()
    {
        foreach (Attack attack in attacks)
        {
            AttackThumbnail thumbnail = Instantiate(_thumbnail, transform);
            thumbnail.SetAttack(attack);
        }
    }
}
