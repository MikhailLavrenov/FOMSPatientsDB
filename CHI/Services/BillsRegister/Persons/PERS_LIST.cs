﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace CHI.Services.BillsRegister
{
    /// <summary>
    /// Представляет информацию о пациентах реестра-счетов.
    /// </summary>
    [XmlRoot(ElementName = "PERS_LIST")]
    public class PERS_LIST
    {
        /// <summary>
        /// Список сведений о пациентах
        /// </summary>
        [XmlElement(ElementName = "PERS")]
        public List<PERS> PERS { get; set; }
    }
}
