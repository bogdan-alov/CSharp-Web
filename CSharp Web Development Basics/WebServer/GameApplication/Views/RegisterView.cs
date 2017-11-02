using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebServer.Server.Contracts;

namespace WebServer.GameApplication.Views
{
    public class RegisterView : IView
    {
	    public RegisterView()
	    {
		    
	    }

	    public RegisterView(bool error)
	    {
		    this.hasError = error;
	    }


	    private bool hasError;


	    public string View()
	    {
		    var result = File.ReadAllText(@".\GameApplication\Resources\register.html");

		    if (hasError)
		    {
			    return result.Replace("<!--error-->",
				    "<div class=\"alert alert-danger\" role=\"alert\"> <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"> <span aria-hidden=\"true\">&times;</span> </button> <strong>Oh snap!</strong> Invalid Password. It should be at least 6 symbols long, containing 1 uppercase letter, 1 lowercase letter and 1 digit. </div>");
			    
		    }

		    return result;

	    }
    }
}
