﻿using PatientsFomsRepository.Infrastructure;
using PatientsFomsRepository.Models;
using Prism.Commands;
using Prism.Regions;

namespace PatientsFomsRepository.ViewModels
{
    public class PatientsFileSettingsViewModel : DomainObject, IRegionMemberLifetime
    {
        #region Поля
        private Settings settings;
        private readonly IFileDialogService fileDialogService;
        #endregion

        #region Свойства
        public IActiveViewModel ActiveViewModel { get; set; }
        public bool KeepAlive { get => false; }
        public Settings Settings { get => settings; set => SetProperty(ref settings, value); }
        public DelegateCommand SaveCommand { get; }
        public DelegateCommand LoadCommand { get; }
        public DelegateCommand SetDefaultCommand { get; }
        public DelegateCommand<ColumnProperty> MoveUpCommand { get; }
        public DelegateCommand<ColumnProperty> MoveDownCommand { get; }
        public DelegateCommand ShowFileDialogCommand { get; }
        #endregion

        #region Конструкторы
        public PatientsFileSettingsViewModel(IActiveViewModel activeViewModel, IFileDialogService fileDialogService)
        {
            this.fileDialogService = fileDialogService;
            ActiveViewModel = activeViewModel;

            ActiveViewModel.Header = "Настройки файла пациентов";            
            Settings = Settings.Instance;
            SaveCommand = new DelegateCommand(SaveExecute);
            LoadCommand = new DelegateCommand(LoadExecute);
            SetDefaultCommand = new DelegateCommand(SetDefaultExecute);
            MoveUpCommand = new DelegateCommand<ColumnProperty>(x => Settings.MoveUpColumnProperty(x as ColumnProperty));
            MoveDownCommand = new DelegateCommand<ColumnProperty>(x => Settings.MoveDownColumnProperty(x as ColumnProperty));
            ShowFileDialogCommand = new DelegateCommand(ShowFileDialogExecute);
        }
        #endregion

        #region Методы
        private void ShowFileDialogExecute()
        {
            fileDialogService.DialogType = settings.DownloadNewPatientsFile ? DialogType.Save : DialogType.Open;
            fileDialogService.FullPath = settings.PatientsFilePath;
            fileDialogService.Filter = "Excel files (*.xslx)|*.xlsx";

            if (fileDialogService.ShowDialog() == true)
                settings.PatientsFilePath = fileDialogService.FullPath;
        }
        private void SaveExecute()
        {
            Settings.Save();
            ActiveViewModel.Status = "Настройки сохранены.";
        }
        private void LoadExecute()
        {
            Settings = Settings.Load();
            ActiveViewModel.Status = "Изменения настроек отменены.";
        }
        private void SetDefaultExecute()
        {
            Settings.SetDefaultPatiensFile();
            ActiveViewModel.Status = "Настройки установлены по умолчанию.";
        }
        #endregion
    }
}