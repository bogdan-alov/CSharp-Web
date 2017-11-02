using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebServer.Server.Contracts;

namespace WebServer.GameApplication.Views
{
    public class LoginView : IView
    {
	    public LoginView()
	    {

	    }

	    public LoginView(string error)
	    {
		    this.Error = error;
	    }

	    public string Error { get; set; }
	    public string View()
	    {
			var result = File.ReadAllText(@".\GameApplication\Resources\login.html");

			if (!string.IsNullOrEmpty(Error))
			{
				result = result.Replace("<!--error-->",
					$"<div class=\"alert alert-danger\" role=\"alert\"> <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"> <span aria-hidden=\"true\">&times;</span> </button> <strong>Oh snap!</strong> {Error} </div>");
			}

		    return result;
	    }
    }
}
