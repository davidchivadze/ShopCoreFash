using System;
using System.Collections.Generic;
using System.Text;

namespace Models.AdminPanel.ViewModels.Shared
{
    public class JsonView
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}
