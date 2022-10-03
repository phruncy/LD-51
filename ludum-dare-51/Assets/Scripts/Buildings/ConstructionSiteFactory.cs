using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class ConstructionSiteFactory : MonoBehaviour
    {
        [SerializeField]
        private ConstructionSite _constructionSitePrefab;

        public void Create(NodeSlot slot,
            Action onComplete, ConstructionSettings settings, NodeColorSettings colorSettings)
		{
            ConstructionSite site = Instantiate(_constructionSitePrefab);
            site.Init(slot.Node, onComplete, settings, colorSettings);
            slot.SetContent(site);
        }
    }
}
