using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebServer.Application.Models;
using WebServer.Server.Contracts;

namespace WebServer.Application.Views
{
    public class SearchCakeView : IView
    {
	    public SearchCakeView(string criteria, string productsCount)
	    {
		    this.criteria = criteria;
		    this.productsCount = productsCount;
	    }


	    private string productsCount;

		private string criteria;
	    public string View()
	    {
			//<!--...-->
		    var cakes = string.Empty;
		    var result = File.ReadAllText(@".\Application\Resources\search.html");
		    var productsInCart = productsCount;
		    if (string.IsNullOrEmpty(criteria))
		    {
			    cakes = CakeList.AllCakes();
		    }
		    else
		    {
				cakes = CakeList.Search(criteria);
			}
		   
		    result = result.Replace("<!--...-->", cakes);

		    return result;
		}
    }
}
