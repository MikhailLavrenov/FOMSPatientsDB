﻿using System;
using System.Xml.Serialization;

namespace CHI.Services.BillsRegister
{
    /// <summary>
    /// Представляет информацию о пациенте
    /// </summary>
    [XmlRoot(ElementName = "PACIENT")]
    public class PACIENT
    {
        /// <summary>
        /// Guid пациента
        /// </summary>
        [XmlElement(ElementName = "ID_PAC")]
        public Guid ID_PAC { get; set; }
        /// <summary>
        /// Серия полиса ОМС
        /// </summary>
        [XmlElement(ElementName = "SPOLIS")]
        public string SPOLIS { get; set; }
        /// <summary>
        /// Номер полиса ОМС
        /// </summary>
        [XmlElement(ElementName = "NPOLIS")]
        public string NPOLIS { get; set; }
    }
}