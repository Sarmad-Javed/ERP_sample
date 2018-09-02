Imports System.Web.Mvc

Public Class DashboardController
    Inherits Controller

    ' GET: /Dashboard
    Function Index() As ActionResult
        Return View()
    End Function
End Class