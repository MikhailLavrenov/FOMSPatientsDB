﻿using CHI.Application.Infrastructure;
using Prism.Commands;
using Prism.Regions;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CHI.Application.ViewModels
{
    class AboutViewModel : DomainObject, IRegionMemberLifetime, INavigationAware
    {
        #region Поля
        private readonly string manualPath;
        #endregion

        #region Свойства
        public IMainRegionService MainRegionService { get; set; }
        public bool KeepAlive { get => true; }
        public string Name { get; }
        public string Version { get; }
        public string Copyright { get; }
        public string Author { get; }
        public string Email { get; }
        public string Phone { get; }
        public string License { get; }
        public DelegateCommand OpenManualCommand { get; }
        #endregion

        #region Конструкторы
        public AboutViewModel(IMainRegionService mainRegionService, ILicenseManager licenseManager)
        {
            MainRegionService = mainRegionService;
            var assembly = Assembly.GetExecutingAssembly();

            manualPath = "Инструкция.docx";
            Name = ((AssemblyTitleAttribute)assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false).First()).Title;
            Version = assembly.GetName().Version.ToString();
            Copyright = @"©  2019";
            Author = "Лавренов Михаил Владимирович";
            Email = "mvlavrenov@mail.ru";
            Phone = "8-924-213-79-11";
            License = licenseManager.GetActiveLicenseInfo();

            OpenManualCommand = new DelegateCommand( ()=>Process.Start(manualPath), ()=> File.Exists(manualPath));
        }
        #endregion

        #region Методы
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            MainRegionService.Header = "О программе";
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }        
        #endregion

    }
}