using System;
using System.Linq;
using System.Web.DynamicData;
using System.Web.Routing;

namespace Islamic_Dreams
{
    public class Global : System.Web.HttpApplication
    {
	    protected void Application_Start(object sender, EventArgs e)
	    {
		    RegisterRoutes(RouteTable.Routes);
	    }

	    static void RegisterRoutes(RouteCollection routes)
	    {
		    routes.DefaultIfEmpty(new DynamicDataRoute("English"));
			routes.MapPageRoute("Default", "Default", "~/English/Default.aspx");
			routes.MapPageRoute("English", "English", "~/English/Default.aspx");
			routes.MapPageRoute("Urdu", "Urdu", "~/Default.aspx");
			routes.MapPageRoute("English/Search", "English/Search", "~/English/Search.aspx");

			routes.MapPageRoute("English/Home", "English/Home", "~/English/Default.aspx");
			routes.MapPageRoute("English/About-us", "English/About-us", "~/English/About.aspx");
			routes.MapPageRoute("English/Types-of-Dreams", "English/Types-of-Dreams", "~/TypeOfDreams.aspx");
			routes.MapPageRoute("English/Dream-Interpretation", "English/Dream-Interpretation", "~/English/DreamsInterpretation.aspx");


			routes.MapPageRoute("About-us", "About-us", "~/English/About.aspx");
			routes.MapPageRoute("Types-of-Dreams", "Types-of-Dreams", "~/TypeOfDreams.aspx");
			routes.MapPageRoute("Dream-Interpretation", "Dream-Interpretation", "~/English/DreamsInterpretation.aspx");






			routes.MapPageRoute("Home", "Home", "~/English/Default.aspx");
			routes.MapPageRoute("Urdu/Home", "Urdu/Home", "~/Default.aspx");
			routes.MapPageRoute("Dashboard", "Dashboard", "~/Dashboard.aspx");
		    routes.MapPageRoute("Login", "Login", "~/Login.aspx");
		    routes.MapPageRoute("Lock", "Lock", "~/Lock.aspx");
		    routes.MapPageRoute("Catalogue", "Catalogue", "~/Catalogue.aspx");
		    routes.MapPageRoute("KeyWords", "KeyWords", "~/KeyWords.aspx");
		    routes.MapPageRoute("Books", "Books", "~/Books.aspx");
		    routes.MapPageRoute("Urdu/About-Us", "Urdu/About-Us", "~/About-Us.aspx");
		    routes.MapPageRoute("Search-Keyword", "Search-Keyword", "~/English/Search.aspx");
			routes.MapPageRoute("Search", "Search", "~/Search.aspx");
			routes.MapPageRoute("Urdu/Seeing-Allah-in-Dream", "Urdu/Seeing-Allah-in-Dream", "~/ToSeeAlmightyAllah.aspx");
		    routes.MapPageRoute("Urdu/Seeing-Angels-in-Dream", "Urdu/Seeing-Angels-in-Dream", "~/ToSeeAngels.aspx");
		    routes.MapPageRoute("Urdu/Seeing-Prophets-in-Dream", "Urdu/Seeing-Prophets-in-Dream", "~/SeeingTheProphets.aspx");
		    routes.MapPageRoute("Urdu/Seeing-Khulefa-in-Dreams", "Urdu/Seeing-Khulefa-in-Dreams", "~/ToDreamOfTheRighteousCaliphs.aspx");
		    routes.MapPageRoute("Urdu/Dream-Interpretation", "Urdu/Dream-Interpretation", "~/DreamsInterpretation.aspx");
		    routes.MapPageRoute("Urdu/Types-of-Dreams", "Urdu/Types-of-Dreams", "~/TypeOfDreams.aspx");
		    routes.MapPageRoute("Imam", "Imam", "~/Imam.aspx");
		    routes.MapPageRoute("SearchIndex", "SearchIndex", "~/SearchIndex.aspx");


			

		}

		void Application_End(object sender, EventArgs e)
	    {
		    //  Code that runs on application shutdown  

	    }

	    void Application_Error(object sender, EventArgs e)
	    {
		    // Code that runs when an unhandled error occurs  

	    }

	    void Session_Start(object sender, EventArgs e)
	    {
		    // Code that runs when a new session is started  

	    }

	    void Session_End(object sender, EventArgs e)
	    {
		    // Code that runs when a session ends.   
		    // Note: The Session_End event is raised only when the sessionstate mode  
		    // is set to InProc in the Web.config file. If session mode is set to StateServer   
		    // or SQLServer, the event is not raised.  

	    }
    }
}