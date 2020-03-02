﻿using System;

namespace CHI.Services.MedicalExaminations
{
    /// <summary>
    /// Представляет информацию о прохождении пациентом профилактического осмотра в определенном году.
    /// </summary>
    public class PatientExaminations : IPatient
    {
        /// <summary>
        /// Серия и/или номер полиса ОМС
        /// </summary>
        public string InsuranceNumber { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthdate { get; set; }
        /// <summary>
        /// 1й этап профилактического осмотра
        /// </summary>
        public Examination Stage1 { get; set; }
        /// <summary>
        /// 2й этап профилактического осмотра
        /// </summary>
        public Examination Stage2 { get; set; }
        /// <summary>
        /// Год прохождения профилактического осмотра
        /// </summary>
        public int Year { get; private set; }
        /// <summary>
        /// Вид профилактического осмотра
        /// </summary>
        public ExaminationKind Kind { get; private set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="insuranceNumber">Серия и/или номер полиса ОМС</param>
        /// <param name="year">Год прохождения профилактического осмотра</param>
        /// <param name="examinationKind">Вид профилактического осмотра</param>
        public PatientExaminations(string insuranceNumber, int year, ExaminationKind examinationKind)
        {
            InsuranceNumber = insuranceNumber;
            Year = year;
            Kind = examinationKind;
        }
    }
}
