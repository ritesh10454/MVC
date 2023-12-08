Namespace IssueVoucher
    Public Class ReportController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /Report

        Function PendingDetail() As ActionResult
            Return View()
        End Function

        Function ReportMIVDetail() As ActionResult
            Return View()
        End Function

        Function ReportConsCos() As ActionResult
            Return View()
        End Function

        Function CHECKMIV() As ActionResult
            Return View()
        End Function

#Region "PendingDetail JsonResult Functions"
        Public Function getPendingInbox() As JsonResult
            Dim objs As New Cls_Pmivinbox()
            Dim res As New QueryResponse(Of PRP_PmivInbox)
            res = objs.Display_PendingInbox()
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function
#End Region

#Region "ReportMIVDetail JsonResult Functions"

        Public Function getMIVReport(ByVal varpar As Int32, ByVal varmivdatfro As String, ByVal varmivdatTo As String, ByVal varinvtyp As String, ByVal varempcd As String, ByVal vardeptcd As String) As JsonResult
            Dim objs As New Cls_pmivhdr()
            Dim res As New QueryResponse(Of PRP_Pmivhdr)
            If varinvtyp = "L" And vardeptcd = "L" And varempcd = "L" Then
                res = objs.Display_MIV_Report(varpar, varmivdatfro, varmivdatTo)
            ElseIf varinvtyp <> "L" And vardeptcd = "L" And varempcd = "L" Then
                res = objs.Display_MIV_Report(varpar, varmivdatfro, varmivdatTo, Convert.ToChar(varinvtyp))
            ElseIf varinvtyp = "L" And vardeptcd = "L" And varempcd <> "L" Then
                res = objs.Display_MIV_Report(varpar, varmivdatfro, varmivdatTo, varempcd)
            ElseIf varinvtyp <> "L" And vardeptcd = "L" And varempcd <> "L" Then
                res = objs.Display_MIV_Report(varpar, varmivdatfro, varmivdatTo, Convert.ToChar(varinvtyp), varempcd)
            ElseIf varinvtyp = "L" And vardeptcd <> "L" And varempcd = "L" Then
                res = objs.Display_MIV_Report(varpar, varmivdatfro, varmivdatTo, Convert.ToInt32(vardeptcd))
            ElseIf varinvtyp = "L" And vardeptcd <> "L" And varempcd <> "L" Then
                res = objs.Display_MIV_Report(varpar, varmivdatfro, varmivdatTo, Convert.ToChar(varinvtyp), Convert.ToInt32(vardeptcd))
            End If
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

#End Region

#Region "ReportConCos JsonResult Functions"

        Public Function getConCosReport(ByVal varpar As Int32, ByVal varmivdatfro As String, ByVal varmivdatTo As String, ByVal varconscd As String, ByVal varcccd As String, ByVal varvari As String) As JsonResult
            Dim objs As New Cls_pmivhdr()
            Dim res As New QueryResponse(Of PRP_Pmivhdr)
            If varconscd = "L" And varcccd = "L" Then
                res = objs.Display_ConCos_Report(varpar, varmivdatfro, varmivdatTo)
            ElseIf varconscd <> "L" And varcccd <> "L" Then
                res = objs.Display_ConCos_Report(varpar, varmivdatfro, varmivdatTo, Convert.ToInt32(varconscd), Convert.ToInt32(varcccd))
            ElseIf varconscd <> "L" And varcccd = "L" Then
                res = objs.Display_ConCos_Report(varpar, varmivdatfro, varmivdatTo, Convert.ToInt32(varconscd), varvari)
            ElseIf varconscd = "L" And varcccd <> "L" Then
                res = objs.Display_ConCos_Report(varpar, varmivdatfro, varmivdatTo, Convert.ToInt32(varcccd))
            End If
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function
#End Region

#Region "CHECKMIV JsonResult Functions"
        Public Function getMIVHDR(ByVal varmivno As Int32, ByVal varmivyr As Int32) As JsonResult
            Dim res As New QueryResponse(Of PRP_Pmivhdr)
            Dim objs As New Cls_pmivhdr()
            res = objs.Display_MIVHDR(varmivno, varmivyr)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function
#End Region

    End Class
End Namespace