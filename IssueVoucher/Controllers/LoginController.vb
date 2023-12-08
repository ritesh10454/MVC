Imports System.Web  

Namespace IssueVoucher
    Public Class LoginController
        Inherits System.Web.Mvc.Controller        '
        ' GET: /Login

        Function Login() As ActionResult
            Return View()
        End Function

        Function getHit_Counter() As JsonResult
            Dim objs As New Cls_Hit_counter()
            Dim res As New QueryResponse(Of PRP_Hit_Counter)
            res = objs.View()
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Function save_LV_Emp_Detail(ByVal p As PRP_Hit_Counter) As JsonResult
            Dim objs As New Cls_Hit_counter()
            Dim res As New QueryResponse(Of PRP_Hit_Counter)
            res = objs.Insert(p)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Function Check_Login(ByVal usernm As String, ByVal pwd As String) As JsonResult
            Dim objs As New Cls_HRY()
            Dim res As New QueryResponse(Of PRP_hry)
            res = objs.Check_Login(usernm, pwd)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

    End Class

End Namespace