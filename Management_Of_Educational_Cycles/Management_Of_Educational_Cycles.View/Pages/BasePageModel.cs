using Management_Of_Educational_Cycles.Logic.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.View.Pages
{
    public abstract class BasePageModel:PageModel
    {
        protected IRequestSender _requestSender { get; set; }
        public BasePageModel(IRequestSender requestSender)
        {
            _requestSender = requestSender;
        }
    }
}
