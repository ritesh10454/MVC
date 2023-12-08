Namespace IssueVoucher
    Public Class ActionController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /Action

        Function Inbox() As ActionResult
            Return View()
        End Function

        Function Outbox() As ActionResult
            Return View()
        End Function


#Region "Inbox JsonResult Functions"
        Public Function getInboxData(ByVal par As Integer, ByVal emp_cd As String) As JsonResult
            Dim res As New QueryResponse(Of PRP_PmivInbox)
            Dim p As New List(Of PRP_PmivInbox)
            Dim objs As New Cls_Pmivinbox()
            res = objs.Display_PmivInbox(par, emp_cd)
            Return Json(res, JsonRequestBehavior.AllowGet)

        End Function

#End Region

#Region "Outbox JsonResult Functions"
        Public Function getPmivInbox(ByVal par As Int32, ByVal emp_cd As String) As JsonResult
            Dim objs As New Cls_Pmivinbox()
            Dim res As New QueryResponse(Of PRP_PmivInbox)
            res = objs.Display_PmivInbox(par, emp_cd)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function getPmivReport(ByVal varmivno As Int64, ByVal varmivyr As Int32) As JsonResult
            Dim objs As New Cls_Pmivdtl_report()
            Dim res As New QueryResponse(Of PRP_Pmivdtl_report)
            res = objs.NIVS_Display_MIV_Report(varmivno, varmivyr)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

#End Region


    End Class
End Namespace