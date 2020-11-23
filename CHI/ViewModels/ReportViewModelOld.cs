﻿using CHI.Infrastructure;
using CHI.Models;
using CHI.Services;
using CHI.Services.Report;
using Microsoft.EntityFrameworkCore;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CHI.ViewModels
{
    class ReportViewModelOld : DomainObject, IRegionMemberLifetime, INavigationAware
    {
        AppDBContext dbContext;
        Settings settings;
        int year = DateTime.Now.Year;
        int month = DateTime.Now.Month;
        bool isGrowing;
        IMainRegionService mainRegionService;
        IFileDialogService fileDialogService;
        OldReportService report;

        public bool KeepAlive { get => false; }
        public int Year { get => year; set => SetProperty(ref year, value); }
        public int Month { get => month; set => SetProperty(ref month, value); }
        public bool IsGrowing { get => isGrowing; set => SetProperty(ref isGrowing, value); }
        public Dictionary<int, string> Months { get; } = Enumerable.Range(1, 12).ToDictionary(x => x, x => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x));
        public OldReportService Report { get => report; set => SetProperty(ref report, value); }

        public DelegateCommand IncreaseYear { get; }
        public DelegateCommand DecreaseYear { get; }
        public DelegateCommandAsync BuildReportCommand { get; }
        public DelegateCommandAsync SaveExcelCommand { get; }
        public DelegateCommandAsync BuildAndSaveExcelCommand { get; }


        public ReportViewModelOld(IMainRegionService mainRegionService, IFileDialogService fileDialogService)
        {
            settings = Settings.Instance;

            this.mainRegionService = mainRegionService;
            this.fileDialogService = fileDialogService;

            mainRegionService.Header = "Отчет по объемам";

            IncreaseYear = new DelegateCommand(() => ++Year);
            DecreaseYear = new DelegateCommand(() => --Year);
            BuildReportCommand = new DelegateCommandAsync(BuildReportExecute);
            SaveExcelCommand = new DelegateCommandAsync(SaveExcelExecute);
            BuildAndSaveExcelCommand = new DelegateCommandAsync(BuildAndSaveExcelExecute, () => !string.IsNullOrEmpty(settings.ServiceAccountingReportPath));
        }


        private void BuildReportExecute()
        {
            mainRegionService.ShowProgressBar("Построение отчета");

            BuilderReportInternal(Report, IsGrowing);

            mainRegionService.HideProgressBar($"Отчет за {Months[Month]} {Year} построен");
        }

        private void BuilderReportInternal(OldReportService report, bool isGrowing)
        {
            var monthBegin = isGrowing ? 1 : Month;

            var registers = dbContext.Registers
                .Where(x => x.Year == Year && monthBegin <= x.Month && x.Month <= Month)
                .Include(x => x.Cases).ThenInclude(x => x.Services).ThenInclude(x => x.ClassifierItem)
                .ToList();

            var plans = dbContext.Plans.Where(x => x.Year == Year && monthBegin <= x.Month && x.Month <= Month).ToList();

            report.Build(registers, plans, Month, Year, isGrowing);
        }

        private void SaveExcelExecute()
        {
            mainRegionService.ShowProgressBar("Выбор пути");

            fileDialogService.DialogType = FileDialogType.Save;
            fileDialogService.FileName = "Отчет по выполнению объемов";
            fileDialogService.Filter = "Excel files (*.xslx)|*.xlsx";

            if (fileDialogService.ShowDialog() != true)
            {
                mainRegionService.HideProgressBar("Отменено");
                return;
            }

            var filePath = fileDialogService.FileName;

            if (Helpers.IsFileLocked(filePath))
            {
                mainRegionService.HideProgressBar("Отменено. Файл занят другим пользователем, поэтому не может быть изменен");
                return;
            }

            mainRegionService.ShowProgressBar("Сохранение файла");

            Report.SaveExcel(filePath);

            mainRegionService.HideProgressBar($"Файл сохранен: {filePath}");
        }

        private void BuildAndSaveExcelExecute()
        {
            mainRegionService.ShowProgressBar("Построение отчета");

            if (!File.Exists(settings.ServiceAccountingReportPath))
            {
                mainRegionService.HideProgressBar("Отменено. Путь к отчету не задан либо файл отсутствует");
                return;
            }

            if (Helpers.IsFileLocked(settings.ServiceAccountingReportPath))
            {
                mainRegionService.HideProgressBar("Отменено. Файл занят другим пользователем, поэтому не может быть изменен");
                return;
            }

            var rootDepartment = dbContext.Departments.Local.First(x => x.IsRoot);
            var rootComponent = dbContext.Components.Local.First(x => x.IsRoot);
            var report = new OldReportService(rootDepartment, rootComponent, false);

            BuilderReportInternal(report, false);
            report.SaveExcel(settings.ServiceAccountingReportPath);

            BuilderReportInternal(report, true);
            report.SaveExcel(settings.ServiceAccountingReportPath);

            mainRegionService.HideProgressBar($"Отчет за месяц и нарастающий успешно построены и сохранены в excel файл");
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            dbContext = new AppDBContext();

            dbContext.Departments.Load();

            var rootDepartment = dbContext.Departments.Local.First(x => x.IsRoot);

            dbContext.Parameters.Load();

            dbContext.Employees
                .Include(x => x.Medic)
                .Include(x => x.Specialty)
                .Load();

            dbContext.Components
                .Include(x => x.Indicators).ThenInclude(x => x.Ratios)
                .Include(x => x.CaseFilters)
                .Load();

            var rootComponent = dbContext.Components.Local.First(x => x.IsRoot);

            Report = new OldReportService(rootDepartment, rootComponent, false);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}