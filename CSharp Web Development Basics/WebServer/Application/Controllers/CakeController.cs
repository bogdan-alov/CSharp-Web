using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Application.Models;
using WebServer.Application.Views;
using WebServer.Server.Enums;
using WebServer.Server.HTTP.Contracts;
using WebServer.Server.HTTP.Response;

namespace WebServer.Application.Controllers
{
    public class CakeController
    {

	    private CartService cartService;

	    public IHttpResponse AddCakeGet(IHttpRequest request)
	    {
		    var ss = string.Empty;

			if (!request.Cookies.ContainsKey("UserId"))
			{
				this.cartService = new CartService();
				return new RedirectResponse("/login");
			}



			return new ViewResponse(HttpStatusCode.OK, new AddCakeView());
	    }

	    public IHttpResponse AddCakePost(string name, string price)
	    {
		    
		    if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(price))
		    {
				var castPriceToDecimal = decimal.Parse(price);
			    var cake = new Cake(name, castPriceToDecimal);
			    CakeList.Add(cake);
			}
			
		    return new RedirectResponse("/add");
	    }

	    public IHttpResponse SearchGet(IHttpRequest req, IDictionary<string, string> queryParams)
	    {

		    var cake = string.Empty;
		    var productsCount = string.Empty;

		    if (!req.Cookies.ContainsKey("UserId"))
		    {
			    return new RedirectResponse("/login");
		    }



			if (queryParams.ContainsKey("criteria"))
		    {
			    cake = queryParams["criteria"];
		    }
			return new ViewResponse(HttpStatusCode.OK, new SearchCakeView(cake, productsCount));
	    }


	    public IHttpResponse CartGet()
	    {
			return new ViewResponse(HttpStatusCode.OK, new CartView());
	    }
	}
}
