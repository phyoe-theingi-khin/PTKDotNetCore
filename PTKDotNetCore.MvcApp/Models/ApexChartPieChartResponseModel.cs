﻿using Newtonsoft.Json;

namespace PTKDotNetCore.MvcApp.Models
{
    public class ApexChartPieChartResponseModel
    {
        public List<int> Series { get; set; }
        public List<string> Lables { get; set; }
    }
}
