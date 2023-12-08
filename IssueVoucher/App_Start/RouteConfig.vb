Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Optimization
Imports System.Web.Routing

Public Class RouteConfig
    Public Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        ' MapRoute takes the following parameters, in order:
        ' (1) Route name
        ' (2) URL with parameters
        ' (3) Parameter defaults
        'routes.MapRoute( _
        '    "Default", _
        '    "{controller}/{action}/{id}", _
        '    New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional} _
        ')
        routes.MapRoute( _
            "Default", _
            "{controller}/{action}/{id}", _
            New With {.controller = "Login", .action = "Login", .id = UrlParameter.Optional} _
        )
    End Sub
End Class
