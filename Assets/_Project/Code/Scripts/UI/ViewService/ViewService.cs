using System.Collections.Generic;
using Project.Scripts.UI.Views;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Scripts.UI
{
    public interface IViewService : IInitializable
    {
        
    }
    
    public class ViewService : IViewService
    {
        private readonly ViewServiceConfig _config;
        private readonly Dictionary<ViewType, BaseView> _viewMap = new ();
        
        private Transform _viewParent;

        [Inject]
        public ViewService(ViewServiceConfig config)
        {
            _config = config;
        }

        public void Initialize()
        {
            _viewParent = Object.Instantiate(_config.ViewParentPrefab, null);
            
            foreach (var data in _config.DefaultViews)
            {
                var view = Object.Instantiate(data.ViewPrefab, _viewParent);
                _viewMap.Add(data.Type, view);
            }
        }
    }
}