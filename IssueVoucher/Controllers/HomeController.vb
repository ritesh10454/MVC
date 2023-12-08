Imports System.Web.Script.Serialization



Namespace IssueVoucher
    Public Class HomeController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /Home

        Function Index() As ActionResult
            ViewBag.Message = "Welcome to ASP.NET MVC!"
            Return View()
        End Function

        Function Home() As ActionResult
            'ViewBag.UserName = System.Web.HttpContext.Current.Session("usrnam")
            Return View()
        End Function

#Region "JsonResult Functions"

        Function getSessionVariables() As JsonResult
            Dim cls As New commonfunctions()
            Dim emp_cd As String = cls.getSessionVariables()
            Return Json(emp_cd, JsonRequestBehavior.AllowGet)
        End Function

        Function Set_Welcome_Message(ByVal usercd As String) As JsonResult
            Dim objs As New CLS_User_Master()
            Dim res As New QueryResponse(Of PRP_users)
            res = objs.Display_User_Name(usercd.ToString().Trim())
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function clearSession() As JsonResult
            Dim res As New QueryResponse(Of PRP_PmivInbox)
            Dim result As String = ""
            If Not IsNothing(System.Web.HttpContext.Current.Session("usrnam")) Then
                Session.Clear()
                Session.Abandon()
                result = "OK"
            End If
            Return Json(result, JsonRequestBehavior.AllowGet)
        End Function

        Public Function getEmployeeDetail(ByVal varempcd As String) As JsonResult
            Dim objs As New cls_EmployeeDetail()
            Dim res As New QueryResponse(Of PRP_EmployeeDetail)
            res = objs.Display_EmployeeDetail(varempcd)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function getConsumptionCentre() As JsonResult
            Dim res As New QueryResponse(Of PRP_ConsumptionCentre)
            Dim objs As New cls_ConsumptionCentre()
            res = objs.View()
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function getCostCentre() As JsonResult
            Dim res As New QueryResponse(Of PRP_CostCentre)
            Dim objs As New cls_CostCentre()
            res = objs.View()
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function Save_UsrLogDtl(ByVal p As PRP_UsrLogDtl) As JsonResult
            Dim objs As New Cls_UsrLogDtl()
            Dim res As New QueryResponse(Of PRP_UsrLogDtl)
            res = objs.Insert(p)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function getDepartment() As JsonResult
            Dim res As New QueryResponse(Of PRP_Department)
            Dim objs As New cls_Department()
            res = objs.View()
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function getAllUsers() As JsonResult
            Dim res As New QueryResponse(Of PRP_hry)
            Dim objs As New Cls_HRY()
            res = objs.Display_All_Users()
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function GetUserDetail(ByVal usercd As String) As JsonResult
            Dim objs As New Cls_HRY()
            Dim res As New QueryResponse(Of PRP_hry)
            res = objs.Display_User_Detail(usercd)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function GetUserRole() As JsonResult
            Dim objs As New Cls_HRY()
            Dim res As New QueryResponse(Of PRP_hry)
            Dim emp_cd As String = System.Web.HttpContext.Current.Session("usrnam").ToString()
            res = objs.Display_User_Role(emp_cd)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function



        '   Public Function GetReallyBigJsonResult(ByVal data As Object, ByVal requestBehavior As JsonRequestBehavior) As JsonResult
        '       Return New JsonResult() With {
        '           .ContentEncoding = System.Text.Encoding.[Default],
        '           .ContentType = "application/json",
        '           .Data = data,
        '           .JsonRequestBehavior = requestBehavior,
        '           .MaxJsonLength = Integer.MaxValue
        '       }
        '   End Function

        '   var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
        'var result = new ContentResult
        '{
        '    Content = serializer.Serialize(myBigData),
        '    ContentType = "application/json"
        '};
        'return result;




#End Region

    End Class


End Namespace