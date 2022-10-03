using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    [Serializable]
    public class TowerLevelSettings
    {
        [SerializeField]
        private ConstructionSettings _constructionSettings;
        public ConstructionSettings ConstructionSettings => _constructionSettings;
        [SerializeField]
        private int _ammunition = 3;
        public int Ammonition => _ammunition;
        [SerializeField]
        private float _distance = 5;
        public float Distance => _distance;
    }
}
