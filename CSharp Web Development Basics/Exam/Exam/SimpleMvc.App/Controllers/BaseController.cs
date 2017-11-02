using System;
using System.Collections.Generic;
using System.Text;
using SimpleMvc.Framework.Controllers;

namespace SimpleMvc.App.Controllers
{
    public class BaseController : Controller
    {
	    protected BaseController()
	    {
			this.ViewModel["anonymousDisplay"] = "flex";
		    this.ViewModel["userDisplay"] = "none";
		    this.ViewModel["adminDisplay"] = "none";
		    this.ViewModel["show-error"] = "none";
		}
    }
}
