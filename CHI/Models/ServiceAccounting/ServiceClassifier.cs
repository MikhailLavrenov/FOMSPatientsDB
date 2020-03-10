﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CHI.Models.ServiceAccounting
{
    public class ServiceClassifier
    {
        public int Id { get; set; }
        public int Code { get; set; }
        /// <summary>
        /// Условная единица труда (УЕТ)
        /// </summary>
        public double LaborCost { get; set; }

        public ServiceClassifier()
        {
        }

        public ServiceClassifier(int code, double laborCost)
        {
            Code = code;
            LaborCost = laborCost;
        }
    }
}
