Namespace IssueVoucher
    Public Class AdministratorController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /Administrator

        Function NewIssueId() As ActionResult
            Return View()
        End Function

        Function UserDetail() As ActionResult
            Return View()
        End Function

#Region "NewIssueId JsonResult Functions"
        Public Function getID_Detail(ByVal emp_cd As String) As JsonResult
            Dim res As New QueryResponse(Of PRP_hry)
            Dim objs As New Cls_HRY()
            res = objs.Display_ID_Detail(emp_cd)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function getCheckID(ByVal emp_cd As String) As JsonResult
            Dim res As New QueryResponse(Of PRP_hry)
            Dim objs As New Cls_HRY()
            res = objs.Display_CheckID(emp_cd)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function getEmployeeNames() As JsonResult
            Dim objs As New cls_EmployeeDetail()
            Dim res As New QueryResponse(Of PRP_EmployeeDetail)
            res = objs.Display_Emp_Name()
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function getIndentory_indropdown() As JsonResult
            Dim res As New QueryResponse(Of PRP_EmployeeDetail)
            Dim objs As New cls_EmployeeDetail()
            res = objs.Display_Indentor_indropdown()
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function getEmployee_Name(ByVal emp_cd As String) As JsonResult
            Dim res As New QueryResponse(Of PRP_EmployeeDetail)
            Dim objs As New cls_EmployeeDetail()
            res = objs.Display_Employee_Name(emp_cd)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function Save_HRY(ByVal p As PRP_hry) As JsonResult
            Dim objs As New Cls_HRY()
            Dim res As New QueryResponse(Of PRP_hry)
            res = objs.Insert(p)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function Update_HRY(ByVal p As PRP_hry) As JsonResult
            Dim objs As New Cls_HRY()
            Dim res As New QueryResponse(Of PRP_hry)
            res = objs.Update(p)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function
#End Region
    End Class
End Namespace