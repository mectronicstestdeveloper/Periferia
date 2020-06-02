using System;

namespace WebAppDevExpress.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class ErrorModel
    {
        public string Title { set; get; }
        public string Error { set; get; }

        public string TagHelper { get; set; }
    }
}