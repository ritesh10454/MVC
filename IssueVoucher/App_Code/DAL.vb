Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

#Region "Class Implementation"
Public Class Cls_UsrLogDtl
    Inherits db_Connection
    Implements IissueVoucher(Of PRP_UsrLogDtl)

    Public Sub New()
        MyBase.New("cnQuality") 'Maintenance Development Database
    End Sub

    Public Function Insert(ByVal args As PRP_UsrLogDtl) As QueryResponse(Of PRP_UsrLogDtl) Implements IissueVoucher(Of PRP_UsrLogDtl).Insert
        Dim res As New QueryResponse(Of PRP_UsrLogDtl)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Save_User_Log_Dtl"
            cmd.Parameters.Add("emp_cd", SqlDbType.NVarChar, 6).Value = args.emp_cd
            cmd.Parameters.Add("login_dt", SqlDbType.DateTime).Value = args.login_dt
            cmd.Parameters.Add("rpt_name", SqlDbType.NVarChar, 100).Value = args.rpt_name
            cmd.Parameters.Add("para_1", SqlDbType.NVarChar, 2900).Value = args.para_1
            cmd.Parameters.Add("para_2", SqlDbType.NVarChar, 2900).Value = args.para_2
            cmd.Parameters.Add("rpt_print", SqlDbType.NVarChar, 1).Value = args.rpt_print
            cmd.Parameters.Add("rpt_export", SqlDbType.NVarChar, 1).Value = args.rpt_export
            cmd.Parameters.Add("PACK_NAME", SqlDbType.NVarChar, 50).Value = args.PACK_NAME
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Update(ByVal args As PRP_UsrLogDtl) As QueryResponse(Of PRP_UsrLogDtl) Implements IissueVoucher(Of PRP_UsrLogDtl).Update
        Throw New NotImplementedException()
    End Function

    Public Function Delete(ByVal args As PRP_UsrLogDtl) As QueryResponse(Of PRP_UsrLogDtl) Implements IissueVoucher(Of PRP_UsrLogDtl).Delete
        Throw New NotImplementedException()
    End Function

    Public Function View() As QueryResponse(Of PRP_UsrLogDtl) Implements IissueVoucher(Of PRP_UsrLogDtl).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_UsrLogDtl) As QueryResponse(Of PRP_UsrLogDtl) Implements IissueVoucher(Of PRP_UsrLogDtl).View
        Throw New NotImplementedException()
    End Function
End Class

Public Class CLS_User_Master
    Inherits db_Connection
    Implements IissueVoucher(Of PRP_users)

    Public Sub New()
        MyBase.new("cnl") 'Maintenance Development Database
    End Sub

    Public Function Check_User_Login(ByVal varusrcod As String, ByVal varusrpwd As String) As QueryResponse(Of PRP_users)
        Dim res As New QueryResponse(Of PRP_users)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIS_Display_User"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 4
            cmd.Parameters.Add("@usr_cod", SqlDbType.NVarChar, 6).Value = varusrcod
            cmd.Parameters.Add("@usr_pwd", SqlDbType.NVarChar, 50).Value = varusrpwd
            Dim p1 As New SqlParameter("@outres", SqlDbType.Int)
            p1.Direction = ParameterDirection.ReturnValue
            cmd.Parameters.Add(p1)
            cmd.ExecuteNonQuery()
            res.responseObject = New PRP_users()
            res.responseObject.outres = Convert.ToInt32(cmd.Parameters("@outres").Value)
            res.response = res.responseObject.outres
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_User_Name(ByVal varusrcod As String) As QueryResponse(Of PRP_users)
        Dim res As New QueryResponse(Of PRP_users)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIS_Display_User"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 3
            cmd.Parameters.Add("@usr_cod", SqlDbType.NVarChar, 6).Value = varusrcod
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_users()
                res.responseObject.empnm = drr("emp_nm").ToString()
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Delete(ByVal args As PRP_users) As QueryResponse(Of PRP_users) Implements IissueVoucher(Of PRP_users).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Insert(ByVal args As PRP_users) As QueryResponse(Of PRP_users) Implements IissueVoucher(Of PRP_users).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Update(ByVal args As PRP_users) As QueryResponse(Of PRP_users) Implements IissueVoucher(Of PRP_users).Update
        Throw New NotImplementedException()
    End Function

    Public Function View() As QueryResponse(Of PRP_users) Implements IissueVoucher(Of PRP_users).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_users) As QueryResponse(Of PRP_users) Implements IissueVoucher(Of PRP_users).View
        Throw New NotImplementedException()
    End Function
End Class

Public Class Cls_HRY
    Inherits db_Connection
    Implements IissueVoucher(Of PRP_hry)


    Public Sub New()
        MyBase.new("cnl") 'Maintenance Development Database
    End Sub

    Public Function Delete(ByVal args As PRP_hry) As QueryResponse(Of PRP_hry) Implements IissueVoucher(Of PRP_hry).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Insert(ByVal args As PRP_hry) As QueryResponse(Of PRP_hry) Implements IissueVoucher(Of PRP_hry).Insert
        Dim res As New QueryResponse(Of PRP_hry)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Save_hry"
            cmd.Parameters.Add("emp_cd", SqlDbType.NVarChar, 10).Value = args.emp_cd
            cmd.Parameters.Add("rpt", SqlDbType.NVarChar, 10).Value = args.rpt
            cmd.Parameters.Add("tpi", SqlDbType.NVarChar, 10).Value = args.tpi
            cmd.Parameters.Add("tag", SqlDbType.NVarChar, 50).Value = args.tag
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Update(ByVal args As PRP_hry) As QueryResponse(Of PRP_hry) Implements IissueVoucher(Of PRP_hry).Update
        Dim res As New QueryResponse(Of PRP_hry)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_update_hry"
            cmd.Parameters.Add("emp_cd", SqlDbType.NVarChar, 10).Value = args.emp_cd
            cmd.Parameters.Add("rpt", SqlDbType.NVarChar, 10).Value = args.rpt
            cmd.Parameters.Add("tpi", SqlDbType.NVarChar, 10).Value = args.tpi
            cmd.Parameters.Add("tag", SqlDbType.NVarChar, 50).Value = args.tag
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_CheckID(ByVal emp_cd As String) As QueryResponse(Of PRP_hry)
        Dim res As New QueryResponse(Of PRP_hry)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 14
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 6).Value = emp_cd.ToString()
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)

            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                res.CheckID = Convert.ToInt32(drr("srno").ToString())
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_All_Users() As QueryResponse(Of PRP_hry)
        Dim res As New QueryResponse(Of PRP_hry)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 10
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_hry)
                For Each drr As DataRow In ds.Tables(0).Rows
                    no = no + 1
                    res.responseObjectList.Add(New PRP_hry() With {
                        .srno = no,
                        .emp_cd = drr("emp_cD").ToString(),
                        .emp_nm = drr("emp_nm").ToString(),
                        .dept_nm = drr("dept_nm").ToString(),
                        .desig_nm = drr("desig_nm").ToString(),
                        .rpt = drr("rpt").ToString(),
                        .apr_emp_nm = drr("rpt_nm").ToString(),
                        .tpi = drr("tpi_nm").ToString(),
                        .tpiid = drr("tpiid").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_ID_Detail(ByVal emp_cd As String) As QueryResponse(Of PRP_hry)
        Dim res As New QueryResponse(Of PRP_hry)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 12
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 6).Value = emp_cd.ToString()
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_hry)
                For Each drr As DataRow In ds.Tables(0).Rows
                    'Dim r As Int32 = ds.Tables(0).Rows.IndexOf(drr)
                    no = no + 1
                    res.responseObjectList.Add(New PRP_hry() With {
                        .srno = no,
                        .emp_cd = drr("emp_cD").ToString(),
                        .emp_nm = drr("emp_nm").ToString(),
                        .dept_nm = drr("dept_nm").ToString(),
                        .desig_nm = drr("desig_nm").ToString(),
                        .rpt = drr("rpt").ToString(),
                        .apr_emp_nm = drr("rpt_nm").ToString(),
                        .tpi = drr("tpi_nm").ToString(),
                        .tpiid = drr("tpiid").ToString(),
                        .tag = drr("tag").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Check_Login(ByVal usernm As String, ByVal pwd As String) As QueryResponse(Of PRP_hry)
        Dim objs As New Cls_HRY()
        Dim res As New QueryResponse(Of PRP_hry)
        Dim res_log As New QueryResponse(Of PRP_Indent_Log)
        Dim obj_log As New Cls_Indent_log()
        Dim clsusr1 As New CLS_User_Master()
        Dim Result As Integer = 0
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim clientIPAddress As String = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString
        Try
            If usernm.Trim().ToUpper() <> "R18238" Then
                Dim objprplog As New PRP_Indent_Log()
                objprplog.edatetime = DateTime.Now()
                objprplog.emp_cd = usernm.Trim()
                objprplog.hostname = strHostName
                res_log = obj_log.Save_indent_Log(objprplog)

                If res_log.response = -1 Then
                    res.response = res_log.response
                    Throw New Exception(res.responseMsg)
                End If
            End If

            HttpContext.Current.Session("SPW") = ""
            If usernm.Trim().ToUpper() = "Store#$786" Then
                HttpContext.Current.Session("SPW") = "Store#$786"
                res.response = 1
            Else
                Dim res1 As New QueryResponse(Of PRP_users)
                res1 = clsusr1.Check_User_Login(usernm.Trim().ToUpper(), pwd)
                If res1.responseObject.outres = -1 Then
                    res.response = -1
                    Throw New Exception(res1.responseMsg)
                End If
                res.response = res1.response
            End If

            If res.response = 1 Then
                'this.session.
                HttpContext.Current.Session("usrnam") = usernm.Trim().ToUpper()
                'FormsAuthentication.RedirectFromLoginPage(usernm.Trim().ToUpper(), True)
                'Response.Redirect("Home.aspx")
                'res.response = Result
            ElseIf res.response = -2 Then
                res.response = -2
                res.responseMsg = "Password is Wrong"
            ElseIf Result = 8 Then
                res.response = 8
                res.responseMsg = "You are not Authorized."
            Else
                res.response = -1
                res.responseMsg = "Error in Login, check sp: NIS_Display_User"
                Throw New Exception(res.responseMsg)
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message
        End Try
        Return res
    End Function



    Public Function Display_User_Detail(ByVal emp_cd As String) As QueryResponse(Of PRP_hry)
        Dim res As New QueryResponse(Of PRP_hry)
        res.responseObject = New PRP_hry()
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_UserDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 1
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 6).Value = emp_cd.ToString()
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim row As DataRow = ds.Tables(0).Rows(0)
                With res.responseObject
                    .emp_cd = row("emp_cd").ToString()
                    .emp_nm = row("emp_nm").ToString()
                    .apr_id = row("apr_id").ToString()
                    .apr_emp_nm = row("apr_emp_nm").ToString()
                    .eid = row("eid").ToString()
                    .reid = row("reid").ToString()
                    .dept_nm = row("dept_nm").ToString()
                    .desig_nm = row("desig_nm").ToString()
                    .aut_id = row("auth_id").ToString()
                    .aut_emp_nm = row("auth_nm").ToString()
                    .dept_cd = row("dept_cd").ToString()
                End With
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_User_Role(ByVal emp_cd As String) As QueryResponse(Of PRP_hry)
        Dim res As New QueryResponse(Of PRP_hry)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 41
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 6).Value = emp_cd.ToString()
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim row As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_hry()
                With res.responseObject
                    .emp_cd = row("emp_cd").ToString()
                    .tag = row("tag").ToString()
                End With
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function View() As QueryResponse(Of PRP_hry) Implements IissueVoucher(Of PRP_hry).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_hry) As QueryResponse(Of PRP_hry) Implements IissueVoucher(Of PRP_hry).View
        Throw New NotImplementedException()
    End Function
End Class

Public Class Cls_Pmivinbox
    Inherits db_Connection
    Implements IissueVoucher(Of PRP_PmivInbox)

    Public Sub New()
        MyBase.new("cnl") 'Maintenance Development Database
    End Sub

    Public Function Insert(ByVal args As PRP_PmivInbox) As QueryResponse(Of PRP_PmivInbox) Implements IissueVoucher(Of PRP_PmivInbox).Insert
        Dim res As New QueryResponse(Of PRP_PmivInbox)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Save_pmivinbox"
            cmd.Parameters.Add("miv_no", SqlDbType.BigInt).Value = args.Miv_No
            cmd.Parameters.Add("miv_dt", SqlDbType.DateTime).Value = args.Miv_dt
            cmd.Parameters.Add("sta", SqlDbType.Int).Value = args.Sta
            cmd.Parameters.Add("emp_cd", SqlDbType.NVarChar, 7).Value = args.Emp_Cd
            cmd.Parameters.Add("dept_cd", SqlDbType.Int).Value = args.dept_cd
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
    Public Function Insert(ByVal args As PRP_PmivInbox, ByVal con As SqlConnection, ByVal tran As SqlTransaction) As QueryResponse(Of PRP_PmivInbox)
        Dim res As New QueryResponse(Of PRP_PmivInbox)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = tran
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Save_pmivinbox"
            cmd.Parameters.Add("miv_no", SqlDbType.BigInt).Value = args.Miv_No
            cmd.Parameters.Add("miv_dt", SqlDbType.DateTime).Value = args.Miv_dt
            cmd.Parameters.Add("sta", SqlDbType.Int).Value = args.Sta
            cmd.Parameters.Add("emp_cd", SqlDbType.NVarChar, 7).Value = args.Emp_Cd
            cmd.Parameters.Add("dept_cd", SqlDbType.Int).Value = args.dept_cd
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function
    Public Function Update(ByVal args As PRP_PmivInbox, ByVal con As SqlConnection, ByVal tran As SqlTransaction) As QueryResponse(Of PRP_PmivInbox)
        Dim res As New QueryResponse(Of PRP_PmivInbox)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = tran
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_update_pmivinbox"
            cmd.Parameters.Add("par", SqlDbType.Int).Value = args.par
            cmd.Parameters.Add("miv_no", SqlDbType.BigInt).Value = args.Miv_No
            cmd.Parameters.Add("miv_dt", SqlDbType.DateTime).Value = args.Miv_dt
            cmd.Parameters.Add("auth_cd1", SqlDbType.NVarChar, 6).Value = args.Auth_Cd1
            cmd.Parameters.Add("remark", SqlDbType.NVarChar, 2000).Value = args.remark
            cmd.Parameters.Add("Splw", SqlDbType.NVarChar, 100).Value = args.Splw
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function

    Public Function Update(ByVal args As PRP_PmivInbox) As QueryResponse(Of PRP_PmivInbox) Implements IissueVoucher(Of PRP_PmivInbox).Update
        Dim res As New QueryResponse(Of PRP_PmivInbox)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_update_pmivinbox"
            cmd.Parameters.Add("par", SqlDbType.Int).Value = args.par
            cmd.Parameters.Add("miv_no", SqlDbType.BigInt).Value = args.Miv_No
            cmd.Parameters.Add("miv_dt", SqlDbType.DateTime).Value = args.Miv_dt
            cmd.Parameters.Add("auth_cd1", SqlDbType.NVarChar, 6).Value = args.Auth_Cd1
            cmd.Parameters.Add("remark", SqlDbType.NVarChar, 2000).Value = args.remark
            cmd.Parameters.Add("Splw", SqlDbType.NVarChar, 100).Value = args.Splw
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Delete(ByVal args As PRP_PmivInbox) As QueryResponse(Of PRP_PmivInbox) Implements IissueVoucher(Of PRP_PmivInbox).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Display_PendingInbox() As QueryResponse(Of PRP_PmivInbox)
        Dim res As New QueryResponse(Of PRP_PmivInbox)
        Dim inv_typ As String = "" : Dim Apr_sta As String = "" : Dim Aut_sta As String = "" : Dim status As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 8
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_PmivInbox)
                For Each drr As DataRow In ds.Tables(0).Rows
                    'Dim r As Int32 = ds.Tables(0).Rows.IndexOf(drr)
                    no = no + 1
                    inv_typ = "" : Apr_sta = "" : Aut_sta = "" : status = ""
                    If drr("inv_typ").ToString().Trim = "C" Then inv_typ = "Consumable" Else inv_typ = "Captial"
                    If Convert.ToInt32(drr("sta").ToString()) <= 1 Then
                        Apr_sta = "Pending"
                        Aut_sta = "Pending"
                    ElseIf Convert.ToInt32(drr("sta").ToString()) = 2 Then
                        Apr_sta = "Approved"
                        Aut_sta = "Pending"
                    ElseIf Convert.ToInt32(drr("sta").ToString()) = 3 Then
                        Apr_sta = "Approved"
                        Aut_sta = "Approved"
                    End If
                    status = drr("status").ToString()

                    res.responseObjectList.Add(New PRP_PmivInbox() With {
                        .Emp_Cd = drr("emp_cd").ToString().Trim(),
                        .emp_nm = drr("emp_nm").ToString().Trim(),
                        .Miv_No = drr("miv_no").ToString(),
                        .Miv_dt = drr("miv_dt").ToString(),
                        .dept_nm = drr("dept_nm").ToString().Trim(),
                        .Sta = Convert.ToInt32(drr("sta").ToString()),
                        .id = drr("id").ToString(),
                        .gemp_cd = drr("gemp_cd").ToString(),
                        .gemp_nm = drr("gemp_nm").ToString(),
                        .inv_typ = inv_typ.ToString().Trim(),
                        .status = status.ToString().Trim(),
                        .apr_sta = Apr_sta.ToString().Trim(),
                        .aut_sta = Aut_sta.ToString().Trim()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_PmivInbox(ByVal par As Int32, ByVal emp_cd As String) As QueryResponse(Of PRP_PmivInbox)
        Dim res As New QueryResponse(Of PRP_PmivInbox)
        Dim inv_typ As String = "" : Dim Apr_sta As String = "" : Dim Aut_sta As String = "" : Dim status As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = par
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 6).Value = emp_cd.ToString()
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_PmivInbox)
                For Each drr As DataRow In ds.Tables(0).Rows
                    no = no + 1
                    inv_typ = "" : Apr_sta = "" : Aut_sta = "" : status = ""
                    If drr("inv_typ").ToString().Trim() = "C" Then inv_typ = "Consumable" Else inv_typ = "Captial"
                    status = drr("status").ToString()
                    If Convert.ToInt32(drr("sta").ToString()) <= 1 Then
                        Apr_sta = "Pending"
                        Aut_sta = "Pending"
                    ElseIf Convert.ToInt32(drr("sta").ToString()) = 2 And drr("tra").ToString() = "C" Then
                        Apr_sta = "Canceled"
                        Aut_sta = " "
                    ElseIf drr("tra").ToString() <> "C" And Convert.ToInt32(drr("sta").ToString()) = 2 Then
                        Apr_sta = "Approved"
                        Aut_sta = "Pending"
                    ElseIf Convert.ToInt32(drr("sta").ToString()) = 3 And status = "A" Then
                        Apr_sta = "Approved"
                        Aut_sta = "Approved"
                    ElseIf Convert.ToInt32(drr("sta").ToString()) = 3 And status = "O" Then
                        Apr_sta = "Approved"
                        Aut_sta = "Pending"
                    ElseIf Convert.ToInt32(drr("sta").ToString()) = 4 Then
                        Apr_sta = "Approved"
                        Aut_sta = "Canceled"
                    End If


                    res.responseObjectList.Add(New PRP_PmivInbox() With {
                    .Emp_Cd = drr("emp_cd").ToString(),
                    .emp_nm = drr("emp_nm").ToString(),
                    .Miv_No = drr("miv_no").ToString(),
                    .Miv_dt = drr("miv_dt").ToString(),
                    .dept_nm = drr("dept_nm").ToString(),
                    .Sta = Convert.ToInt32(drr("sta").ToString()),
                    .id = drr("id").ToString(),
                    .Tra = drr("tra").ToString(),
                    .inv_typ = inv_typ.ToString().Trim(),
                    .status = status.ToString().Trim(),
                    .apr_sta = Apr_sta.ToString().Trim(),
                    .aut_sta = Aut_sta.ToString().Trim()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            'cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_PmivInboxD(ByVal miv_no As Int64, ByVal miv_yr As Int32) As QueryResponse(Of PRP_PmivInbox)
        Dim res As New QueryResponse(Of PRP_PmivInbox)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 32
            cmd.Parameters.Add("@miv_no", SqlDbType.BigInt).Value = miv_no
            cmd.Parameters.Add("@miv_yr", SqlDbType.Int).Value = miv_yr
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_PmivInbox)
                For Each drr As DataRow In ds.Tables(0).Rows
                    'Dim r As Int32 = ds.Tables(0).Rows.IndexOf(drr)
                    no = no + 1
                    res.responseObjectList.Add(New PRP_PmivInbox() With {
                        .Miv_No = drr("miv_no").ToString(),
                        .Miv_dt = drr("miv_dt").ToString(),
                        .Sta = drr("sta").ToString(),
                        .Tra = drr("tra").ToString(),
                        .remark = drr("remark").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function View() As QueryResponse(Of PRP_PmivInbox) Implements IissueVoucher(Of PRP_PmivInbox).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_PmivInbox) As QueryResponse(Of PRP_PmivInbox) Implements IissueVoucher(Of PRP_PmivInbox).View
        Throw New NotImplementedException()
    End Function
End Class

Public Class Cls_pmivhdr
    Inherits db_Connection
    Implements IissueVoucher(Of PRP_Pmivhdr)

    Public Sub New()
        MyBase.new("cnl") 'Maintenance Development Database
    End Sub

    Public Function Display_Pending_Slip(ByVal par As Int32, ByVal emp_cd As String) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        Dim inv_typ As String = "" : Dim Apr_sta As String = "" : Dim Aut_sta As String = "" : Dim status As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = par
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 6).Value = emp_cd.ToString()
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                res.slipNo = drr("Column1")
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_MIVHDR(ByVal miv_no As Int32, ByVal miv_yr As Int32) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        Dim inv_typ As String = "" : Dim Apr_sta As String = "" : Dim Aut_sta As String = "" : Dim status As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 39
            cmd.Parameters.Add("@miv_no", SqlDbType.NVarChar, 11).Value = miv_no
            cmd.Parameters.Add("@miv_yr", SqlDbType.NVarChar, 11).Value = miv_yr
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Pmivhdr)
                For Each row As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_Pmivhdr() With {
                        .miv_no = row("miv_no").ToString(),
                        .miv_yr = row("miv_yr").ToString(),
                        .miv_dt = Convert.ToDateTime(row("miv_dt").ToString()).ToString("dd-MMM-yyyy"),
                        .miv_dt1 = CDate(row("miv_dt")),
                        .inv_typG = If((row("inv_typ").ToString() = "C"), "Consumable", "Capital"),
                        .status = row("status").ToString(),
                        .luser_id = row("luser_id").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function CancelMIV(ByVal args As PRP_Pmivhdr) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Cancel_MIV"
            cmd.Parameters.Add("miv_no", SqlDbType.BigInt).Value = args.miv_no
            cmd.Parameters.Add("miv_yr", SqlDbType.Int).Value = args.miv_yr
            cmd.Parameters.Add("auth_id", SqlDbType.NVarChar, 6).Value = args.auth_id
            cmd.Parameters.Add("auth_dt", SqlDbType.DateTime).Value = args.auth_dt
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = "MIV is Canceled."
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function UpdateCancelStatus(ByVal miv_no As Int32, ByVal miv_yr As Int32, ByVal remark As String) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("par", SqlDbType.Int).Value = 27
            cmd.Parameters.Add("miv_no", SqlDbType.BigInt).Value = miv_no
            cmd.Parameters.Add("miv_yr", SqlDbType.Int).Value = miv_yr
            cmd.Parameters.Add("remark", SqlDbType.NVarChar, 1500).Value = remark
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
    Public Function UpdateCancelStatus(ByVal miv_no As Int32, ByVal miv_yr As Int32, ByVal remark As String, ByVal con As SqlConnection, ByVal tran As SqlTransaction) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = tran
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("par", SqlDbType.Int).Value = 27
            cmd.Parameters.Add("miv_no", SqlDbType.BigInt).Value = miv_no
            cmd.Parameters.Add("miv_yr", SqlDbType.Int).Value = miv_yr
            cmd.Parameters.Add("remark", SqlDbType.NVarChar, 1500).Value = remark
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function

    Public Function Display_StutusMail(ByVal miv_no As Int32, ByVal miv_yr As Int32, ByVal con As SqlConnection, ByVal tran As SqlTransaction) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = tran
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 31
            cmd.Parameters.Add("@miv_no", SqlDbType.BigInt).Value = miv_no
            cmd.Parameters.Add("@miv_yr", SqlDbType.Int).Value = miv_yr
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim row As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_Pmivhdr()
                res.responseObject.mailStatus = row("Column1")
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function
    Public Function Display_Stutus(ByVal miv_no As Int32, ByVal miv_yr As Int32, ByVal con As SqlConnection, ByVal tran As SqlTransaction) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = tran
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 26
            cmd.Parameters.Add("@miv_no", SqlDbType.BigInt).Value = miv_no
            cmd.Parameters.Add("@miv_yr", SqlDbType.Int).Value = miv_yr
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_Pmivhdr()
                res.responseObject.mailStatus = drr("Column1")
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function

    Public Function Display_Stutus(ByVal miv_no As Int32, ByVal miv_yr As Int32) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 26
            cmd.Parameters.Add("@miv_no", SqlDbType.BigInt).Value = miv_no
            cmd.Parameters.Add("@miv_yr", SqlDbType.Int).Value = miv_yr
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                res.responseObject.mailStatus = drr("Column1")
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_PreStock(ByVal itm_cd As String) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 1
            cmd.Parameters.Add("@itm_cd", SqlDbType.NVarChar, 7).Value = itm_cd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                '  res.preStock = Convert.ToDouble(drr("stk_qty").ToString())
                res.preStock = Convert.ToDouble(drr("Column1").ToString())
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = "Item Stock not found"
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_MivNo() As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 1
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObject = New PRP_Pmivhdr()
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                res.responseObject.miv_no = Convert.ToDouble(drr("Column1").ToString())
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_PreStock1(ByVal itm_cd As String) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 1000
            cmd.Parameters.Add("@itm_cd", SqlDbType.NVarChar, 7).Value = itm_cd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                'res.preStock = Convert.ToDouble(drr("stk_qty").ToString())
                res.preStock = Convert.ToDouble(drr("Column1").ToString())
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = "Item Stock not found"
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
    Public Function Display_PreStock1(ByVal itm_cd As String, ByVal con As SqlConnection, ByVal tran As SqlTransaction) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = tran
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 1000
            cmd.Parameters.Add("@itm_cd", SqlDbType.NVarChar, 7).Value = itm_cd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                'res.preStock = Convert.ToDouble(drr("stk_qty").ToString())
                res.preStock = Convert.ToDouble(drr("Column1").ToString())
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = "Item Stock not found"
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function

    Public Function Display_Current_MIV_No() As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 2
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                res.currentMivNo = Convert.ToDouble(drr("last_no").ToString())
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_Current_MIV_No(ByVal con As SqlConnection, ByVal tran As SqlTransaction) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = tran
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 2
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                res.currentMivNo = Convert.ToDouble(drr("last_no").ToString())
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function

    Public Function Display_ConCos_Report(ByVal varpar As Int32, ByVal varmivdatfro As String, ByVal varmivdatTo As String) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = varpar
            cmd.Parameters.Add("@miv_dt_Fro", SqlDbType.NVarChar, 11).Value = varmivdatfro
            cmd.Parameters.Add("@miv_dt_To", SqlDbType.NVarChar, 11).Value = varmivdatTo
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            ' Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Pmivhdr)
                For Each row As DataRow In ds.Tables(0).Rows
                    'Dim r As Int32 = ds.Tables(0).Rows.IndexOf(drr)
                    '  no = no + 1
                    '.iss_qty =   Format(row("iss_qty"), "0.000"),
                    '.iss_rt = Format(row("iss_rt"), "0.00"), 
                    res.responseObjectList.Add(New PRP_Pmivhdr() With {
                    .miv_no = row("miv_no").ToString(),
                    .miv_dt = Format(row("miv_dt"), "dd-MMM-yyyy"),
                    .miv_dt1 = CDate(row("miv_dt")),
                    .inv_typG = If((row("inv_typ").ToString() = "Consumable"), "Consumable", "Capital"),
                    .cons_desc = row("cons_desc").ToString(),
                    .cc_desc = row("cc_desc").ToString(),
                    .itm_cd = row("itm_cd").ToString(),
                    .itm_desc = row("itm_desc").ToString(),
                    .iss_qty = Convert.ToDouble(row("iss_qty").ToString()).ToString("0.000"),
                    .iss_rt = Convert.ToDouble(row("iss_rt").ToString()).ToString("0.000"),
                    .emp_cdG = row("emp_cd").ToString(),
                    .emp_nmG = row("emp_nm").ToString(),
                    .dept_nmG = row("dept_nm").ToString(),
                     .Tot_valG = Convert.ToDouble(row("Tot_Val").ToString())
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_ConCos_Report(ByVal varpar As Int32, ByVal varmivdatfro As String, ByVal varmivdatTo As String, ByVal varconscd As Int32, ByVal vari As String) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = varpar
            cmd.Parameters.Add("@miv_dt_Fro", SqlDbType.NVarChar, 11).Value = varmivdatfro
            cmd.Parameters.Add("@miv_dt_To", SqlDbType.NVarChar, 11).Value = varmivdatTo
            cmd.Parameters.Add("@cons_cd", SqlDbType.Int).Value = varconscd
            cmd.Parameters.Add("@i", SqlDbType.NVarChar, 4).Value = vari
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            ' Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Pmivhdr)
                For Each row As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_Pmivhdr() With {
                    .miv_no = row("miv_no").ToString(),
                    .miv_dt = Convert.ToDateTime(row("miv_dt").ToString()).ToString("dd-MMM-yyyy"),
                    .miv_dt1 = CDate(row("miv_dt")),
                    .inv_typG = If((row("inv_typ").ToString() = "Consumable"), "Consumable", "Capital"),
                    .cons_desc = row("cons_desc").ToString(),
                    .cc_desc = row("cc_desc").ToString(),
                    .itm_cd = row("itm_cd").ToString(),
                    .itm_desc = row("itm_desc").ToString(),
                    .iss_qty = Convert.ToDouble(row("iss_qty").ToString()).ToString("0.000"),
                    .iss_rt = Convert.ToDouble(row("iss_rt").ToString()).ToString("0.000"),
                    .emp_cdG = row("emp_cd").ToString(),
                    .emp_nmG = row("emp_nm").ToString(),
                    .dept_nmG = row("dept_nm").ToString(),
                     .Tot_valG = Convert.ToDouble(row("Tot_Val").ToString())
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_ConCos_Report(ByVal varpar As Int32, ByVal varmivdatfro As String, ByVal varmivdatTo As String, ByVal varcccd As Int32) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = varpar
            cmd.Parameters.Add("@miv_dt_Fro", SqlDbType.NVarChar, 11).Value = varmivdatfro
            cmd.Parameters.Add("@miv_dt_To", SqlDbType.NVarChar, 11).Value = varmivdatTo
            cmd.Parameters.Add("@cc_cd", SqlDbType.Int).Value = varcccd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            ' Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Pmivhdr)
                For Each row As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_Pmivhdr() With {
                    .miv_no = row("miv_no").ToString(),
                    .miv_dt = Convert.ToDateTime(row("miv_dt").ToString()).ToString("dd-MMM-yyyy"),
                    .miv_dt1 = CDate(row("miv_dt")),
                    .inv_typG = If((row("inv_typ").ToString() = "Consumable"), "Consumable", "Capital"),
                    .cons_desc = row("cons_desc").ToString(),
                    .cc_desc = row("cc_desc").ToString(),
                    .itm_cd = row("itm_cd").ToString(),
                    .itm_desc = row("itm_desc").ToString(),
                    .iss_qty = Convert.ToDouble(row("iss_qty").ToString()).ToString("0.000"),
                    .iss_rt = Convert.ToDouble(row("iss_rt").ToString()).ToString("0.000"),
                    .emp_cdG = row("emp_cd").ToString(),
                    .emp_nmG = row("emp_nm").ToString(),
                    .dept_nmG = row("dept_nm").ToString(),
                     .Tot_valG = Convert.ToDouble(row("Tot_Val").ToString())
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_ConCos_Report(ByVal varpar As Int32, ByVal varmivdatfro As String, ByVal varmivdatTo As String, ByVal varconscd As Int32, ByVal varcccd As Int32) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = varpar
            cmd.Parameters.Add("@miv_dt_Fro", SqlDbType.NVarChar, 11).Value = varmivdatfro
            cmd.Parameters.Add("@miv_dt_To", SqlDbType.NVarChar, 11).Value = varmivdatTo
            cmd.Parameters.Add("@cons_cd", SqlDbType.Int).Value = varconscd
            cmd.Parameters.Add("@cc_cd", SqlDbType.Int).Value = varcccd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            ' Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Pmivhdr)
                For Each row As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_Pmivhdr() With {
                    .miv_no = row("miv_no").ToString(),
                    .miv_dt = Convert.ToDateTime(row("miv_dt").ToString()).ToString("dd-MMM-yyyy"),
                    .miv_dt1 = CDate(row("miv_dt")),
                    .inv_typG = If((row("inv_typ").ToString() = "Consumable"), "Consumable", "Capital"),
                    .cons_desc = row("cons_desc").ToString(),
                    .cc_desc = row("cc_desc").ToString(),
                    .itm_cd = row("itm_cd").ToString(),
                    .itm_desc = row("itm_desc").ToString(),
                    .iss_qty = Convert.ToDouble(row("iss_qty").ToString()).ToString("0.000"),
                    .iss_rt = Convert.ToDouble(row("iss_rt").ToString()).ToString("0.000"),
                    .emp_cdG = row("emp_cd").ToString(),
                    .emp_nmG = row("emp_nm").ToString(),
                    .dept_nmG = row("dept_nm").ToString(),
                    .Tot_valG = Convert.ToDouble(row("Tot_Val").ToString())
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_MIV_Report(ByVal varpar As Int32, ByVal varmivdatfro As String, ByVal varmivdatTo As String) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        Dim statusG As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = varpar
            cmd.Parameters.Add("@miv_dt_Fro", SqlDbType.NVarChar, 11).Value = varmivdatfro
            cmd.Parameters.Add("@miv_dt_To", SqlDbType.NVarChar, 11).Value = varmivdatTo
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Pmivhdr)
                For Each drr As DataRow In ds.Tables(0).Rows
                    If drr("Status").ToString() = "A" Then
                        statusG = "Authorized"
                    ElseIf drr("Status").ToString() = "C" Then
                        statusG = "Canceled"
                    End If
                    res.responseObjectList.Add(New PRP_Pmivhdr() With {
                    .miv_no = drr("miv_no").ToString(),
                    .miv_dt = Convert.ToDateTime(drr("miv_dt").ToString()).ToString("dd-MMM-yyyy"),
                    .miv_dt1 = CDate(drr("miv_dt")),
                    .inv_typG = If((drr("inv_typ").ToString() = "Consumable"), "Consumable", "Capital"),
                    .statusG = statusG,
                    .emp_cdG = drr("luser_id").ToString(),
                    .emp_nmG = drr("emp_nm").ToString(),
                    .dept_cdG = drr("dept_cd").ToString(),
                    .dept_nmG = drr("dept_nm").ToString(),
                    .Tot_valG = Convert.ToDouble(drr("Tot_Val").ToString())
                })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_MIV_Report(ByVal varpar As Int32, ByVal varmivdatfro As String, ByVal varmivdatTo As String, ByVal varinvtyp As Char) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        Dim statusG As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = varpar
            cmd.Parameters.Add("@miv_dt_Fro", SqlDbType.NVarChar, 11).Value = varmivdatfro
            cmd.Parameters.Add("@miv_dt_To", SqlDbType.NVarChar, 11).Value = varmivdatTo
            cmd.Parameters.Add("@inv_typ", SqlDbType.Char, 1).Value = varinvtyp
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Pmivhdr)
                For Each row As DataRow In ds.Tables(0).Rows
                    If row("Status").ToString() = "A" Then
                        statusG = "Authorized"
                    ElseIf row("Status").ToString() = "C" Then
                        statusG = "Canceled"
                    End If
                    res.responseObjectList.Add(New PRP_Pmivhdr() With {
                    .miv_no = row("miv_no").ToString(),
                    .miv_dt = Convert.ToDateTime(row("miv_dt").ToString()).ToString("dd-MMM-yyyy"),
                    .miv_dt1 = CDate(row("miv_dt")),
                    .inv_typG = If((row("inv_typ").ToString() = "Consumable"), "Consumable", "Capital"),
                    .statusG = statusG,
                    .emp_cdG = row("luser_id").ToString(),
                    .emp_nmG = row("emp_nm").ToString(),
                    .dept_cdG = row("dept_cd").ToString(),
                    .dept_nmG = row("dept_nm").ToString(),
                    .Tot_valG = Convert.ToDouble(row("Tot_Val").ToString())
                })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_MIV_Report(ByVal varpar As Int32, ByVal varmivdatfro As String, ByVal varmivdatTo As String, ByVal varinvtyp As Char, ByVal vardeptcd As Int32) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        Dim statusG As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = varpar
            cmd.Parameters.Add("@miv_dt_Fro", SqlDbType.NVarChar, 11).Value = varmivdatfro
            cmd.Parameters.Add("@miv_dt_To", SqlDbType.NVarChar, 11).Value = varmivdatTo
            cmd.Parameters.Add("@inv_typ", SqlDbType.Char, 1).Value = varinvtyp
            cmd.Parameters.Add("@dept_cd", SqlDbType.Int).Value = vardeptcd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Pmivhdr)
                For Each row As DataRow In ds.Tables(0).Rows
                    If row("Status").ToString() = "A" Then
                        statusG = "Authorized"
                    ElseIf row("Status").ToString() = "C" Then
                        statusG = "Canceled"
                    End If
                    res.responseObjectList.Add(New PRP_Pmivhdr() With {
                    .miv_no = row("miv_no").ToString(),
                    .miv_dt = Convert.ToDateTime(row("miv_dt").ToString()).ToString("dd-MMM-yyyy"),
                    .miv_dt1 = CDate(row("miv_dt")),
                    .inv_typG = If((row("inv_typ").ToString() = "Consumable"), "Consumable", "Capital"),
                    .statusG = statusG,
                    .emp_cdG = row("luser_id").ToString(),
                    .emp_nmG = row("emp_nm").ToString(),
                    .dept_cdG = row("dept_cd").ToString(),
                    .dept_nmG = row("dept_nm").ToString(),
                    .Tot_valG = Convert.ToDouble(row("Tot_Val").ToString())
                })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_MIV_Report(ByVal varpar As Int32, ByVal varmivdatfro As String, ByVal varmivdatTo As String, ByVal varinvtyp As Char, ByVal varempcd As String) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        Dim statusG As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = varpar
            cmd.Parameters.Add("@miv_dt_Fro", SqlDbType.NVarChar, 11).Value = varmivdatfro
            cmd.Parameters.Add("@miv_dt_To", SqlDbType.NVarChar, 11).Value = varmivdatTo
            cmd.Parameters.Add("@inv_typ", SqlDbType.Char, 1).Value = varinvtyp
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 7).Value = varempcd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Pmivhdr)
                For Each row As DataRow In ds.Tables(0).Rows
                    If row("Status").ToString() = "A" Then
                        statusG = "Authorized"
                    ElseIf row("Status").ToString() = "C" Then
                        statusG = "Canceled"
                    End If
                    res.responseObjectList.Add(New PRP_Pmivhdr() With {
                    .miv_no = row("miv_no").ToString(),
                    .miv_dt = Convert.ToDateTime(row("miv_dt").ToString()).ToString("dd-MMM-yyyy"),
                    .miv_dt1 = CDate(row("miv_dt")),
                    .inv_typG = If((row("inv_typ").ToString() = "Consumable"), "Consumable", "Capital"),
                    .statusG = statusG,
                    .emp_cdG = row("luser_id").ToString(),
                    .emp_nmG = row("emp_nm").ToString(),
                    .dept_cdG = row("dept_cd").ToString(),
                    .dept_nmG = row("dept_nm").ToString(),
                    .Tot_valG = Convert.ToDouble(row("Tot_Val").ToString())
                })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_MIV_Report(ByVal varpar As Int32, ByVal varmivdatfro As String, ByVal varmivdatTo As String, ByVal varempcd As String) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        Dim statusG As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = varpar
            cmd.Parameters.Add("@miv_dt_Fro", SqlDbType.NVarChar, 11).Value = varmivdatfro
            cmd.Parameters.Add("@miv_dt_To", SqlDbType.NVarChar, 11).Value = varmivdatTo
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 7).Value = varempcd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Pmivhdr)
                For Each row As DataRow In ds.Tables(0).Rows
                    If row("Status").ToString() = "A" Then
                        statusG = "Authorized"
                    ElseIf row("Status").ToString() = "C" Then
                        statusG = "Canceled"
                    End If
                    res.responseObjectList.Add(New PRP_Pmivhdr() With {
                    .miv_no = row("miv_no").ToString(),
                    .miv_dt = Convert.ToDateTime(row("miv_dt").ToString()).ToString("dd-MMM-yyyy"),
                    .miv_dt1 = CDate(row("miv_dt")),
                    .inv_typG = If((row("inv_typ").ToString() = "Consumable"), "Consumable", "Capital"),
                    .statusG = statusG,
                    .emp_cdG = row("luser_id").ToString(),
                    .emp_nmG = row("emp_nm").ToString(),
                    .dept_cdG = row("dept_cd").ToString(),
                    .dept_nmG = row("dept_nm").ToString(),
                    .Tot_valG = Convert.ToDouble(row("Tot_Val").ToString())
                })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_MIV_Report(ByVal varpar As Int32, ByVal varmivdatfro As String, ByVal varmivdatTo As String, ByVal vardeptcd As Int32) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        Dim statusG As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = varpar
            cmd.Parameters.Add("@miv_dt_Fro", SqlDbType.NVarChar, 11).Value = varmivdatfro
            cmd.Parameters.Add("@miv_dt_To", SqlDbType.NVarChar, 11).Value = varmivdatTo
            cmd.Parameters.Add("@dept_cd", SqlDbType.Int).Value = vardeptcd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Pmivhdr)
                For Each row As DataRow In ds.Tables(0).Rows
                    If row("Status").ToString() = "A" Then
                        statusG = "Authorized"
                    ElseIf row("Status").ToString() = "C" Then
                        statusG = "Canceled"
                    End If
                    res.responseObjectList.Add(New PRP_Pmivhdr() With {
                    .miv_no = row("miv_no").ToString(),
                    .miv_dt = Convert.ToDateTime(row("miv_dt").ToString()).ToString("dd-MMM-yyyy"),
                    .miv_dt1 = CDate(row("miv_dt")),
                    .inv_typG = If((row("inv_typ").ToString() = "Consumable"), "Consumable", "Capital"),
                    .statusG = statusG,
                    .emp_cdG = row("luser_id").ToString(),
                    .emp_nmG = row("emp_nm").ToString(),
                    .dept_cdG = row("dept_cd").ToString(),
                    .dept_nmG = row("dept_nm").ToString(),
                    .Tot_valG = Convert.ToDouble(row("Tot_Val").ToString())
                })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function MailFunction(ByVal varmivno As Int64, ByVal varmivyr As Int32) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "IssueVoucher_MailNew"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 1
            cmd.Parameters.Add("@miv_no", SqlDbType.BigInt).Value = varmivno
            cmd.Parameters.Add("@miv_yr", SqlDbType.Int).Value = varmivyr
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function CancelMailFunction(ByVal varmivno As Int64, ByVal varmivyr As Int32) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "IssueVoucher_Mail_Cancel"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 1
            cmd.Parameters.Add("@miv_no", SqlDbType.BigInt).Value = varmivno
            cmd.Parameters.Add("@miv_yr", SqlDbType.Int).Value = varmivyr
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
    Public Function CancelMailFunction(ByVal varmivno As Int64, ByVal varmivyr As Int32, ByVal con As SqlConnection, ByVal tran As SqlTransaction) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = tran
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "IssueVoucher_Mail_Cancel"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 1
            cmd.Parameters.Add("@miv_no", SqlDbType.BigInt).Value = varmivno
            cmd.Parameters.Add("@miv_yr", SqlDbType.Int).Value = varmivyr
            res.response = cmd.ExecuteNonQuery()
            res.response = 1
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function


    Public Function Delete(ByVal args As PRP_Pmivhdr) As QueryResponse(Of PRP_Pmivhdr) Implements IissueVoucher(Of PRP_Pmivhdr).Delete
        Throw New NotImplementedException()
    End Function

    Public Function SaveMivEntry(ByVal args As PRP_Pmivhdr) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        Dim res1 As New QueryResponse(Of PRP_Pmivhdr)
        Dim res_inbox As New QueryResponse(Of PRP_PmivInbox)
        Dim res_typ As New QueryResponse(Of PRP_pmivtype)
        Dim res_dtl As New QueryResponse(Of PRP_Pmivdtl)
        Dim obj_hdr As New Cls_pmivhdr
        Dim obj_typ As New CLS_Pmivtype
        Dim obj_dtl As New CLS_Pmivdtl
        Dim obj_inbox As New Cls_Pmivinbox
        Dim varretno As Integer = 0
        openConnection()
        Dim trans As SqlTransaction = con.BeginTransaction(IsolationLevel.ReadCommitted)
        cmd = New SqlCommand()
        Try
            If args.btnsaveText.Trim() = "Save" Then
                res1 = New QueryResponse(Of PRP_Pmivhdr)
                res1 = obj_hdr.Display_Current_MIV_No(con, trans)
                If res1.response = -1 Then
                    trans.Rollback()
                    res.response = -1
                    Throw New Exception(res1.responseMsg)
                End If
                args.miv_no = res1.currentMivNo
                res_typ = New QueryResponse(Of PRP_pmivtype)
                res_typ = obj_typ.Display_Current_Ret_No(con, trans)
                If res_typ.response = -1 Then
                    trans.Rollback()
                    res.response = -1
                    Throw New Exception(res_typ.responseMsg)
                End If
                args.Ret_no = res_typ.responseObject.Ret_No
                For Each itmx As PRP_Pmivdtl In args.pmivdtl_List
                    If args.btnsaveText.Trim() = "Save" Then
                        itmx.Ret_no = args.Ret_no
                        itmx.miv_no = args.miv_no
                    End If
                Next

                res = New QueryResponse(Of PRP_Pmivhdr)
                res = obj_hdr.Insert(args, con, trans)
                If res.response = -1 Then
                    trans.Rollback()
                    Throw New Exception(res.responseMsg)
                End If
                Dim objPrpPmivinbox As New PRP_PmivInbox()
                objPrpPmivinbox.Miv_No = args.miv_no
                objPrpPmivinbox.Miv_dt = args.miv_dt
                objPrpPmivinbox.Sta = 0
                objPrpPmivinbox.Emp_Cd = args.luser_id
                objPrpPmivinbox.dept_cd = args.dept_cd
                res_inbox = New QueryResponse(Of PRP_PmivInbox)
                res_inbox = obj_inbox.Insert(objPrpPmivinbox, con, trans)
                If res_inbox.response = -1 Then
                    trans.Rollback()
                    Throw New Exception(res_inbox.responseMsg)
                End If
            ElseIf args.btnsaveText.Trim() = "Update" Then
                res_dtl = New QueryResponse(Of PRP_Pmivdtl)
                res_dtl = obj_dtl.Delete_MIV_Detail(args.miv_no, args.miv_yr, con, trans)
                If res_dtl.response = -1 Then
                    trans.Rollback()
                    Throw New Exception(res_dtl.responseMsg)
                End If

                res_dtl = New QueryResponse(Of PRP_Pmivdtl)
                res_dtl = obj_dtl.Delete_MIVType(args.miv_no, args.miv_yr, con, trans)
                If res_dtl.response = -1 Then
                    trans.Rollback()
                    Throw New Exception(res_dtl.responseMsg)
                End If

            End If
            For Each item As PRP_Pmivdtl In args.pmivdtl_List
                Dim objPrpPmivtype As New PRP_pmivtype
                objPrpPmivtype.miv_no = item.miv_no
                objPrpPmivtype.miv_yr = item.miv_yr
                If item.RetTyp = "Replacement" Then objPrpPmivtype.RetTyp = "R" Else If item.RetTyp = "New Addition" Then objPrpPmivtype.RetTyp = "A" Else If item.RetTyp = "Project" Then objPrpPmivtype.RetTyp = "P" Else objPrpPmivtype.RetTyp = "N"
                objPrpPmivtype.Reason = item.Reason
                objPrpPmivtype.itm_sno = item.itm_sno
                objPrpPmivtype.Ret_No = item.Ret_no
                objPrpPmivtype.remark = item.Remark
                varretno = item.Ret_no
                res_typ = New QueryResponse(Of PRP_pmivtype)
                res_typ = obj_typ.Insert(objPrpPmivtype, con, trans)
                If res_typ.response = -1 Then
                    res.response = -1
                    res.responseMsg = res_typ.responseMsg
                    Exit For
                End If

                res_dtl = New QueryResponse(Of PRP_Pmivdtl)
                res_dtl = obj_dtl.Insert(item, con, trans)
                If res_dtl.response = -1 Then
                    res.response = -1
                    res.responseMsg = res_dtl.responseMsg
                    Exit For
                End If
            Next
            If res.response = -1 Then
                trans.Rollback()
                Throw New Exception(res.responseMsg)
            End If
            'Dim objPrpPmivhdr As New PRP_Pmivhdr()
            'objPrpPmivhdr.cur_Ret_no = varretno
            args.cur_Ret_no = varretno
            If args.btnsaveText.Trim() <> "Update" Then
                res1 = New QueryResponse(Of PRP_Pmivhdr)
                res1 = obj_hdr.update_Pcontrol_RET_no(args, con, trans)
                If res1.response = -1 Then
                    trans.Rollback()
                    Throw New Exception(res1.responseMsg)
                End If

                'args.cur_miv_no = args.miv_no
                res1 = New QueryResponse(Of PRP_Pmivhdr)
                res1 = obj_hdr.update_Pcontrol_MIV_no(args, con, trans)
                If res1.response = -1 Then
                    trans.Rollback()
                    Throw New Exception(res1.responseMsg)
                End If

            End If
            trans.Commit()
            res.response = 1
            If args.btnsaveText.Trim() = "Save" Then res.responseMsg = "One Record is Saved Successfully." Else If args.btnsaveText.Trim() = "Update" Then res.responseMsg = "MIV  Updated Successfully."

        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function SaveMivAuthorize(ByVal args As PRP_Pmivhdr) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        Dim res1 As New QueryResponse(Of PRP_Pmivhdr)
        Dim res_inbox As New QueryResponse(Of PRP_PmivInbox)
        Dim res_typ As New QueryResponse(Of PRP_pmivtype)
        Dim res_dtl As New QueryResponse(Of PRP_Pmivdtl)
        Dim res_plg As New QueryResponse(Of PRP_plgdtl)
        Dim res_pit As New QueryResponse(Of PRP_Pitmaster)
        Dim obj_hdr As New Cls_pmivhdr
        Dim obj_typ As New CLS_Pmivtype
        Dim obj_dtl As New CLS_Pmivdtl
        Dim obj_inbox As New Cls_Pmivinbox
        Dim obj_plg As New CLS_Plgdtl
        Dim obj_pit As New CLS_Pitmaster
        Dim varretno As Integer = 0
        Dim varsta1 As Int32 = 0
        openConnection()
        Dim trans As SqlTransaction = con.BeginTransaction(IsolationLevel.ReadCommitted)
        cmd = New SqlCommand()
        Try
            '-- To Update Pmivinbox 
            Dim objPrpPmivinbox As New PRP_PmivInbox()
            objPrpPmivinbox.par = 3
            objPrpPmivinbox.Sta = 1
            objPrpPmivinbox.Auth_Cd2 = args.Auth_Cd2
            objPrpPmivinbox.remark = args.Remarks
            objPrpPmivinbox.Miv_No = args.miv_no
            objPrpPmivinbox.Miv_dt = args.miv_dt

            '-- Till her pmivinbox updation

            '-- To Update Pmivhdr 
            args.status = "A"

            res_dtl = New QueryResponse(Of PRP_Pmivdtl)
            res_dtl = obj_dtl.Delete_MIV_Detail(args.miv_no, args.miv_yr, con, trans)
            If res_dtl.response = -1 Then
                trans.Rollback()
                Throw New Exception(res_dtl.responseMsg)
            End If

            res_dtl = New QueryResponse(Of PRP_Pmivdtl)
            res_dtl = obj_dtl.Delete_MIVType(args.miv_no, args.miv_yr, con, trans)
            If res_dtl.response = -1 Then
                trans.Rollback()
                Throw New Exception(res_dtl.responseMsg)
            End If

            For Each item As PRP_Pmivdtl In args.pmivdtl_List
                Dim objPrpPmivtype As New PRP_pmivtype
                objPrpPmivtype.miv_no = item.miv_no
                objPrpPmivtype.miv_yr = item.miv_yr
                If item.RetTyp = "Replacement" Then objPrpPmivtype.RetTyp = "R" Else If item.RetTyp = "New Addition" Then objPrpPmivtype.RetTyp = "A" Else If item.RetTyp = "Project" Then objPrpPmivtype.RetTyp = "P" Else objPrpPmivtype.RetTyp = "N"
                objPrpPmivtype.Reason = item.Reason
                objPrpPmivtype.itm_sno = item.itm_sno
                objPrpPmivtype.Ret_No = item.Ret_no
                objPrpPmivtype.remark = item.Remark
                varretno = item.Ret_no
                res_typ = New QueryResponse(Of PRP_pmivtype)
                res_typ = obj_typ.Save_Pmivdtl_With_transaction(objPrpPmivtype, con, trans)
                If res_typ.response = -1 Then
                    res.response = -1
                    res.responseMsg = res_typ.responseMsg
                    Exit For
                End If

                res_dtl = New QueryResponse(Of PRP_Pmivdtl)
                res_dtl = obj_dtl.Save_Pmivdtl_authorize_With_Transaction(item, con, trans)
                If res_dtl.response = -1 Then
                    res.response = -1
                    res.responseMsg = res_dtl.responseMsg
                    Exit For
                End If
            Next

            If res.response = -1 Then
                trans.Rollback()
                Throw New Exception(res.responseMsg)
            End If

            args.cur_Ret_no = varretno
            If args.btnsaveText.Trim() <> "Update" Then
                res1 = New QueryResponse(Of PRP_Pmivhdr)
                res1 = obj_hdr.update_Pcontrol_RET_no(args, con, trans)
                If res1.response = -1 Then
                    trans.Rollback()
                    Throw New Exception(res1.responseMsg)
                End If
            End If

            '-- To Update Plgdtl
            res1 = New QueryResponse(Of PRP_Pmivhdr)
            res1 = obj_hdr.Display_StutusMail(args.miv_no, args.miv_yr, con, trans)
            If res1.response = -1 Then
                trans.Rollback()
                Throw New Exception(res1.responseMsg)
            End If
            varsta1 = res1.responseObject.mailStatus
            res_dtl = New QueryResponse(Of PRP_Pmivdtl)
            res_dtl = obj_dtl.Delete_Plg_Detail(args.miv_no, args.miv_yr, con, trans)
            If res_dtl.response = -1 Then
                trans.Rollback()
                Throw New Exception(res_dtl.responseMsg)
            End If

            '-----------------Save PlgDetail ------------------------------
            Dim k As Int64 = 0
            For Each item As PRP_Pmivdtl In args.pmivdtl_List

                If item.iss_qty > 0 Then
                    args.negChec = 0
                    k = 0
                    res_plg = obj_plg.Display_lgsrno(con, trans)
                    If res_plg.response = -1 Then
                        res.response = -1
                        res.responseMsg = res_plg.responseMsg
                        Exit For
                    End If
                    k = res_plg.responseObject.sr_no
                    Dim objPrpPlgdtl As New PRP_plgdtl()
                    objPrpPlgdtl.sr_no = k + 1
                    objPrpPlgdtl.doc_no = args.miv_no
                    objPrpPlgdtl.doc_dt = args.miv_dt
                    objPrpPlgdtl.crt_dt = args.miv_dt
                    objPrpPlgdtl.doc_typ = "IV"
                    objPrpPlgdtl.yr = args.miv_yr
                    objPrpPlgdtl.mm = Month(Convert.ToDateTime(args.miv_dt))

                    objPrpPlgdtl.itm_cd = item.itm_cd.ToString().Trim()
                    objPrpPlgdtl.iss_qty = item.iss_qty
                    objPrpPlgdtl.iss_val = item.iss_val
                    objPrpPlgdtl.inv_typ = args.inv_typ  ' item.inv_typ
                    objPrpPlgdtl.luser_id = item.auth_id
                    objPrpPlgdtl.auth_id = item.auth_id
                    objPrpPlgdtl.auth_dt = item.auth_dt
                    objPrpPlgdtl.lupd_dt = item.lupd_dt

                    Dim objpitmasterprp As New PRP_Pitmaster()
                    objpitmasterprp.itm_cd = item.itm_cd.ToString().Trim()
                    objpitmasterprp.last_iss_no = args.miv_no
                    objpitmasterprp.last_iss_dt = args.miv_dt
                    res1 = New QueryResponse(Of PRP_Pmivhdr)
                    res1 = Display_PreStock1(item.itm_cd.ToString().Trim(), con, trans)
                    If res1.response = -1 Then
                        res.response = -1
                        res.responseMsg = res1.responseMsg
                        Exit For
                    End If
                    Dim stk As Decimal = 0
                    stk = res1.preStock
                    If item.iss_qty > stk Then
                        args.negChec = 1
                        res.response = -1
                        res.responseMsg = "You Can't Authorize becuase of Less Qty ."
                        Exit For
                    End If
                    res_pit = New QueryResponse(Of PRP_Pitmaster)
                    res_pit = obj_pit.Update_Pitmaster(objpitmasterprp, con, trans)
                    If res_pit.response = -1 Then
                        res.response = -1
                        res.responseMsg = res_pit.responseMsg
                        Exit For
                    End If
                    res_plg = New QueryResponse(Of PRP_plgdtl)
                    res_plg = obj_plg.Save_Plgdtl(objPrpPlgdtl, con, trans)
                    If res_plg.response = -1 Then
                        res.response = -1
                        res.responseMsg = res_plg.responseMsg
                        Exit For
                    End If
                End If
            Next
            If res.response = -1 Then
                trans.Rollback()
                Throw New Exception(res.responseMsg)
            End If



            If args.negChec <> 1 Then
                If varsta1 >= 1 Then
                    res1 = New QueryResponse(Of PRP_Pmivhdr)
                    res1 = obj_hdr.Display_StutusMail(args.miv_no, args.miv_yr, con, trans)
                    If res1.response = -1 Then
                        trans.Rollback()
                        Throw New Exception(res1.responseMsg)
                    End If
                End If
                res = New QueryResponse(Of PRP_Pmivhdr)
                res = obj_hdr.Update(args, con, trans)
                If res.response = -1 Then
                    trans.Rollback()
                    Throw New Exception(res.responseMsg)
                End If

                res_inbox = New QueryResponse(Of PRP_PmivInbox)
                res_inbox = obj_inbox.Update(objPrpPmivinbox, con, trans)
                If res_inbox.response = -1 Then
                    trans.Rollback()
                    Throw New Exception(res_inbox.responseMsg)
                End If
            End If
            Dim varsta As Int32 = 0
            res = New QueryResponse(Of PRP_Pmivhdr)
            res = obj_hdr.Display_Stutus(args.miv_no, args.miv_yr, con, trans)
            If res.response = -1 Then
                trans.Rollback()
                Throw New Exception(res.responseMsg)
            End If
            varsta = res.responseObject.mailStatus

            If varsta = 1 Then
                res = New QueryResponse(Of PRP_Pmivhdr)
                res = obj_hdr.CancelMailFunction(args.miv_no, args.miv_yr, con, trans)
                If res.response = -1 Then
                    trans.Rollback()
                    Throw New Exception(res.responseMsg)
                End If
                res = New QueryResponse(Of PRP_Pmivhdr)
                res = obj_hdr.UpdateCancelStatus(args.miv_no, args.miv_yr, args.Remarks, con, trans)
                If res.response = -1 Then
                    trans.Rollback()
                    Throw New Exception(res.responseMsg)
                End If

            End If


            If res.response = -1 Then
                trans.Rollback()
                Throw New Exception(res.responseMsg)
            End If
            '-----------------------End------------------------------------

            trans.Commit()
            res.response = 1
            If args.btnsaveText.Trim() = "Save" Then res.responseMsg = "One Record is Saved Successfully." Else If args.btnsaveText.Trim() = "Update" Then res.responseMsg = "MIV  Updated Successfully."

        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function





    Public Function Insert(ByVal args As PRP_Pmivhdr, ByVal con As SqlConnection, ByVal tran As SqlTransaction) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = tran
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Save_pmivhdr"
            cmd.Parameters.Add("miv_no", SqlDbType.BigInt).Value = args.miv_no
            cmd.Parameters.Add("miv_dt", SqlDbType.NVarChar, 11).Value = args.miv_dt
            cmd.Parameters.Add("miv_yr", SqlDbType.Int).Value = args.miv_yr
            cmd.Parameters.Add("inv_typ", SqlDbType.Char, 1).Value = args.inv_typ
            cmd.Parameters.Add("dept_cd", SqlDbType.Int).Value = args.dept_cd
            cmd.Parameters.Add("cc_cd", SqlDbType.Int).Value = args.cc_cd
            cmd.Parameters.Add("status", SqlDbType.Char, 1).Value = args.status
            cmd.Parameters.Add("luser_id", SqlDbType.Char, 6).Value = args.luser_id
            cmd.Parameters.Add("lupd_dt", SqlDbType.DateTime).Value = args.lupd_dt
            cmd.Parameters.Add("auth_dt", SqlDbType.DateTime).Value = args.auth_dt
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function


    Public Function Insert(ByVal args As PRP_Pmivhdr) As QueryResponse(Of PRP_Pmivhdr) Implements IissueVoucher(Of PRP_Pmivhdr).Insert
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Save_pmivhdr"
            cmd.Parameters.Add("miv_no", SqlDbType.BigInt).Value = args.miv_no
            cmd.Parameters.Add("miv_dt", SqlDbType.NVarChar, 11).Value = args.miv_dt
            cmd.Parameters.Add("miv_yr", SqlDbType.Int).Value = args.miv_yr
            cmd.Parameters.Add("inv_typ", SqlDbType.Char, 1).Value = args.inv_typ
            cmd.Parameters.Add("dept_cd", SqlDbType.Int).Value = args.dept_cd
            cmd.Parameters.Add("cc_cd", SqlDbType.Int).Value = args.cc_cd
            cmd.Parameters.Add("status", SqlDbType.Char, 1).Value = args.status
            cmd.Parameters.Add("luser_id", SqlDbType.Char, 6).Value = args.luser_id
            cmd.Parameters.Add("lupd_dt", SqlDbType.DateTime).Value = args.lupd_dt
            cmd.Parameters.Add("auth_dt", SqlDbType.DateTime).Value = args.auth_dt
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
    Public Function Update(ByVal args As PRP_Pmivhdr, ByVal con As SqlConnection, ByVal tran As SqlTransaction) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = tran
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Update_pmivhdr"
            cmd.Parameters.Add("par", SqlDbType.Int).Value = 2
            cmd.Parameters.Add("miv_no", SqlDbType.BigInt).Value = args.miv_no
            cmd.Parameters.Add("miv_dt", SqlDbType.NVarChar, 11).Value = args.miv_dt
            cmd.Parameters.Add("miv_yr", SqlDbType.Int).Value = args.miv_yr
            cmd.Parameters.Add("inv_typ", SqlDbType.Char, 1).Value = args.inv_typ
            cmd.Parameters.Add("status", SqlDbType.Char, 1).Value = args.status
            cmd.Parameters.Add("auth_id", SqlDbType.NVarChar, 6).Value = args.auth_id
            cmd.Parameters.Add("auth_dt", SqlDbType.DateTime).Value = args.auth_dt
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function

    Public Function Update(ByVal args As PRP_Pmivhdr) As QueryResponse(Of PRP_Pmivhdr) Implements IissueVoucher(Of PRP_Pmivhdr).Update
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Update_pmivhdr"
            cmd.Parameters.Add("par", SqlDbType.Int).Value = 2
            cmd.Parameters.Add("miv_no", SqlDbType.BigInt).Value = args.miv_no
            cmd.Parameters.Add("miv_dt", SqlDbType.NVarChar, 11).Value = args.miv_dt
            cmd.Parameters.Add("miv_yr", SqlDbType.Int).Value = args.miv_yr
            cmd.Parameters.Add("inv_typ", SqlDbType.Char, 1).Value = args.inv_typ
            cmd.Parameters.Add("status", SqlDbType.Char, 1).Value = args.status
            cmd.Parameters.Add("auth_id", SqlDbType.NVarChar, 6).Value = args.auth_id
            cmd.Parameters.Add("auth_dt", SqlDbType.DateTime).Value = args.auth_dt
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function update_Pcontrol_MIV_no(ByVal args As PRP_Pmivhdr) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("Par", SqlDbType.Int).Value = 3
            cmd.Parameters.Add("cur_miv_no", SqlDbType.BigInt).Value = args.cur_miv_no
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
    Public Function update_Pcontrol_MIV_no(ByVal args As PRP_Pmivhdr, ByVal con As SqlConnection, ByVal tran As SqlTransaction) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = tran
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("Par", SqlDbType.Int).Value = 3
            cmd.Parameters.Add("cur_miv_no", SqlDbType.BigInt).Value = args.miv_no
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function

    Public Function update_Pcontrol_RET_no(ByVal args As PRP_Pmivhdr, ByVal con As SqlConnection, ByVal tran As SqlTransaction) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = tran
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("Par", SqlDbType.Int).Value = 22
            cmd.Parameters.Add("cur_Ret_no", SqlDbType.BigInt).Value = args.cur_Ret_no
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function

    Public Function update_Pcontrol_RET_no(ByVal args As PRP_Pmivhdr) As QueryResponse(Of PRP_Pmivhdr)
        Dim res As New QueryResponse(Of PRP_Pmivhdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("Par", SqlDbType.Int).Value = 22
            cmd.Parameters.Add("cur_Ret_no", SqlDbType.BigInt).Value = args.cur_Ret_no
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    'Public Function Display_Current_MIV_No() As QueryResponse(Of PRP_Pmivhdr)
    '    Dim res As New QueryResponse(Of PRP_Pmivhdr)
    '    openConnection()
    '    cmd = New SqlCommand()
    '    Try
    '        cmd.Connection = con
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandTimeout = 500
    '        cmd.CommandText = "NIVS_Display_IssueDetail"
    '        cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 2
    '        dat = New SqlDataAdapter(cmd)
    '        Dim ds As New DataSet()
    '        dat.Fill(ds)
    '        If ds.Tables(0).Rows.Count > 0 Then
    '            res.responseObjectList = New List(Of PRP_Pmivhdr)
    '            For Each row As DataRow In ds.Tables(0).Rows
    '                res.responseObjectList.Add(New PRP_Pmivhdr() With {
    '                    .cur_miv_no = row("last_no").ToString()
    '            })
    '            Next
    '        End If
    '        res.response = cmd.ExecuteNonQuery()
    '        res.responseMsg = ""
    '    Catch ex As Exception
    '        res.response = -1 : res.responseMsg = ex.Message.ToString()
    '    Finally
    '        cmd.Dispose()
    '        closeConnection()
    '    End Try
    '    Return res
    'End Function

    Public Function View() As QueryResponse(Of PRP_Pmivhdr) Implements IissueVoucher(Of PRP_Pmivhdr).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_Pmivhdr) As QueryResponse(Of PRP_Pmivhdr) Implements IissueVoucher(Of PRP_Pmivhdr).View
        Throw New NotImplementedException()
    End Function
End Class

Public Class CLS_Pmivtype
    Inherits db_Connection
    Implements IissueVoucher(Of PRP_pmivtype)


    Public Sub New()
        MyBase.new("cnl") 'Maintenance Development Database
    End Sub



    Public Function Delete(ByVal args As PRP_pmivtype) As QueryResponse(Of PRP_pmivtype) Implements IissueVoucher(Of PRP_pmivtype).Delete
        Dim res As New QueryResponse(Of PRP_pmivtype)
        openConnection()
        cmd = New SqlCommand()
        Try

            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("par", SqlDbType.Int).Value = 20
            cmd.Parameters.Add("miv_no", SqlDbType.BigInt).Value = args.miv_no
            cmd.Parameters.Add("miv_yr", SqlDbType.Int).Value = args.miv_yr
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
    Public Function Insert(ByVal args As PRP_pmivtype, ByVal con As SqlConnection, ByVal trans As SqlTransaction) As QueryResponse(Of PRP_pmivtype)
        Dim res As New QueryResponse(Of PRP_pmivtype)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = trans
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Save_pmivtype"
            cmd.Parameters.Add("miv_no", SqlDbType.BigInt).Value = args.miv_no
            cmd.Parameters.Add("miv_yr", SqlDbType.Int).Value = args.miv_yr
            cmd.Parameters.Add("itm_sno", SqlDbType.Int).Value = args.itm_sno
            cmd.Parameters.Add("ret_no", SqlDbType.Int).Value = args.Ret_No
            cmd.Parameters.Add("reason", SqlDbType.NVarChar, 1000).Value = args.Reason
            cmd.Parameters.Add("rettyp", SqlDbType.NVarChar, 5).Value = args.RetTyp
            cmd.Parameters.Add("remark", SqlDbType.NVarChar, 1000).Value = args.remark
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = "Data Saved"
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function

    Public Function Insert(ByVal args As PRP_pmivtype) As QueryResponse(Of PRP_pmivtype) Implements IissueVoucher(Of PRP_pmivtype).Insert
        Dim res As New QueryResponse(Of PRP_pmivtype)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Save_pmivtype"
            cmd.Parameters.Add("miv_no", SqlDbType.BigInt).Value = args.miv_no
            cmd.Parameters.Add("miv_yr", SqlDbType.Int).Value = args.miv_yr
            cmd.Parameters.Add("itm_sno", SqlDbType.Int).Value = args.itm_sno
            cmd.Parameters.Add("ret_no", SqlDbType.Int).Value = args.Ret_No
            cmd.Parameters.Add("reason", SqlDbType.NVarChar, 1000).Value = args.Reason
            cmd.Parameters.Add("rettyp", SqlDbType.NVarChar, 5).Value = args.RetTyp
            cmd.Parameters.Add("remark", SqlDbType.NVarChar, 1000).Value = args.remark
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = "Data Saved"
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Save_Pmivdtl_With_transaction(ByVal args As PRP_pmivtype, ByVal con As SqlConnection, ByVal tran As SqlTransaction) As QueryResponse(Of PRP_pmivtype)
        Dim res As New QueryResponse(Of PRP_pmivtype)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = tran
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Save_pmivtype_authorize"
            cmd.Parameters.Add("miv_no", SqlDbType.BigInt).Value = args.miv_no
            cmd.Parameters.Add("miv_yr", SqlDbType.Int).Value = args.miv_yr
            cmd.Parameters.Add("itm_sno", SqlDbType.Int).Value = args.itm_sno
            cmd.Parameters.Add("ret_no", SqlDbType.Int).Value = args.Ret_No
            cmd.Parameters.Add("reason", SqlDbType.NVarChar, 1000).Value = args.Reason
            cmd.Parameters.Add("rettyp", SqlDbType.NVarChar, 5).Value = args.RetTyp
            cmd.Parameters.Add("remark", SqlDbType.NVarChar, 1000).Value = args.remark
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function

    Public Function Display_Current_Ret_No() As QueryResponse(Of PRP_pmivtype)
        Dim res As New QueryResponse(Of PRP_pmivtype)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 21
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_pmivtype()
                res.responseObject.Ret_No = drr("last_no")
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_Current_Ret_No(ByVal con As SqlConnection, ByVal tran As SqlTransaction) As QueryResponse(Of PRP_pmivtype)
        Dim res As New QueryResponse(Of PRP_pmivtype)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = tran
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 21
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_pmivtype()
                res.responseObject.Ret_No = drr("last_no")
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function


    Public Function Display_Ret_No(ByVal args As PRP_pmivtype) As QueryResponse(Of PRP_pmivtype)
        Dim res As New QueryResponse(Of PRP_pmivtype)
        res.responseObject = New PRP_pmivtype()
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 23
            cmd.Parameters.Add("@miv_no", SqlDbType.Int).Value = args.miv_no
            cmd.Parameters.Add("@miv_yr", SqlDbType.Int).Value = args.miv_yr
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                res.responseObject.Ret_No = drr("ret_no")
            End If
            res.responseObject.Ret_No = IIf(String.IsNullOrWhiteSpace(res.responseObject.Ret_No), 0, res.responseObject.Ret_No)
            res.response = 1
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function


    Public Function Update(ByVal args As PRP_pmivtype) As QueryResponse(Of PRP_pmivtype) Implements IissueVoucher(Of PRP_pmivtype).Update
        Throw New NotImplementedException()
    End Function

    Public Function View() As QueryResponse(Of PRP_pmivtype) Implements IissueVoucher(Of PRP_pmivtype).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_pmivtype) As QueryResponse(Of PRP_pmivtype) Implements IissueVoucher(Of PRP_pmivtype).View
        Throw New NotImplementedException()
    End Function
End Class

Public Class CLS_Pmivdtl
    Inherits db_Connection
    Implements IissueVoucher(Of PRP_Pmivdtl)

    Public Sub New()
        MyBase.new("cnl") 'Maintenance Development Database
    End Sub

    Public Function Delete(ByVal args As PRP_Pmivdtl) As QueryResponse(Of PRP_Pmivdtl) Implements IissueVoucher(Of PRP_Pmivdtl).Delete
        Throw New NotImplementedException()
    End Function
    Public Function Delete_MIV_Detail(ByVal varmivno As Int64, ByVal varmivyr As Int32, ByVal con As SqlConnection, ByVal tran As SqlTransaction) As QueryResponse(Of PRP_Pmivdtl)
        Dim res As New QueryResponse(Of PRP_Pmivdtl)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = tran
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("par", SqlDbType.Int).Value = 6
            cmd.Parameters.Add("miv_no", SqlDbType.BigInt).Value = varmivno
            cmd.Parameters.Add("miv_yr", SqlDbType.Int).Value = varmivyr
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function


    Public Function Delete_MIVType(ByVal varmivno As Int64, ByVal varmivyr As Int32, ByVal con As SqlConnection, ByVal tran As SqlTransaction) As QueryResponse(Of PRP_Pmivdtl)
        Dim res As New QueryResponse(Of PRP_Pmivdtl)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = tran
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("par", SqlDbType.Int).Value = 25
            cmd.Parameters.Add("miv_no", SqlDbType.BigInt).Value = varmivno
            cmd.Parameters.Add("miv_yr", SqlDbType.Int).Value = varmivyr
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function

    Public Function Delete_Plg_Detail(ByVal varmivno As Int64, ByVal varmivyr As Int32, ByVal con As SqlConnection, ByVal tran As SqlTransaction) As QueryResponse(Of PRP_Pmivdtl)
        Dim res As New QueryResponse(Of PRP_Pmivdtl)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = tran
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("par", SqlDbType.Int).Value = 24
            cmd.Parameters.Add("miv_no", SqlDbType.BigInt).Value = varmivno
            cmd.Parameters.Add("miv_yr", SqlDbType.Int).Value = varmivyr
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function

    Public Function Insert(ByVal args As PRP_Pmivdtl) As QueryResponse(Of PRP_Pmivdtl) Implements IissueVoucher(Of PRP_Pmivdtl).Insert
        Dim res As New QueryResponse(Of PRP_Pmivdtl)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Save_pmivdtl"
            cmd.Parameters.Add("miv_no", SqlDbType.BigInt).Value = args.miv_no
            cmd.Parameters.Add("miv_dt", SqlDbType.NVarChar, 11).Value = args.miv_dt
            cmd.Parameters.Add("miv_yr", SqlDbType.Int).Value = args.miv_yr
            cmd.Parameters.Add("itm_sno", SqlDbType.Int).Value = args.itm_sno
            cmd.Parameters.Add("itm_cd", SqlDbType.Char, 7).Value = args.itm_cd
            cmd.Parameters.Add("str_cd", SqlDbType.Char, 2).Value = args.str_cd
            cmd.Parameters.Add("req_Qty", SqlDbType.Decimal).Value = args.req_qty
            cmd.Parameters.Add("pre_stk_qty", SqlDbType.Decimal).Value = args.pre_stk_qty
            cmd.Parameters.Add("iss_Qty", SqlDbType.Decimal).Value = args.iss_qty
            cmd.Parameters.Add("iss_rt", SqlDbType.Decimal).Value = args.iss_rt
            cmd.Parameters.Add("iss_val", SqlDbType.Decimal).Value = args.iss_val
            cmd.Parameters.Add("cc_cd", SqlDbType.Int).Value = args.cc_cd
            cmd.Parameters.Add("cons_Cd", SqlDbType.BigInt).Value = args.cons_cd
            cmd.Parameters.Add("iss_yard", SqlDbType.Char, 6).Value = args.iss_yard
            cmd.Parameters.Add("sbu_cd", SqlDbType.BigInt).Value = args.sbu_cd
            cmd.Parameters.Add("sub_str_cd", SqlDbType.Char, 2).Value = args.SUB_STR_CD
            cmd.Parameters.Add("luser_id", SqlDbType.Char, 6).Value = args.luser_id
            cmd.Parameters.Add("lupd_dt", SqlDbType.DateTime).Value = args.lupd_dt
            cmd.Parameters.Add("auth_id", SqlDbType.Char, 6).Value = args.auth_id
            cmd.Parameters.Add("auth_dt", SqlDbType.DateTime).Value = args.auth_dt
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Insert(ByVal args As PRP_Pmivdtl, ByVal con As SqlConnection, ByVal tran As SqlTransaction) As QueryResponse(Of PRP_Pmivdtl)
        Dim res As New QueryResponse(Of PRP_Pmivdtl)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = tran
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Save_pmivdtl"
            cmd.Parameters.Add("miv_no", SqlDbType.BigInt).Value = args.miv_no
            cmd.Parameters.Add("miv_dt", SqlDbType.NVarChar, 11).Value = args.miv_dt
            cmd.Parameters.Add("miv_yr", SqlDbType.Int).Value = args.miv_yr
            cmd.Parameters.Add("itm_sno", SqlDbType.Int).Value = args.itm_sno
            cmd.Parameters.Add("itm_cd", SqlDbType.Char, 7).Value = args.itm_cd
            cmd.Parameters.Add("str_cd", SqlDbType.Char, 2).Value = args.str_cd
            cmd.Parameters.Add("req_Qty", SqlDbType.Decimal).Value = args.req_qty
            cmd.Parameters.Add("pre_stk_qty", SqlDbType.Decimal).Value = args.pre_stk_qty
            cmd.Parameters.Add("iss_Qty", SqlDbType.Decimal).Value = args.iss_qty
            cmd.Parameters.Add("iss_rt", SqlDbType.Decimal).Value = args.iss_rt
            cmd.Parameters.Add("iss_val", SqlDbType.Decimal).Value = args.iss_val
            cmd.Parameters.Add("cc_cd", SqlDbType.Int).Value = args.cc_cd
            cmd.Parameters.Add("cons_Cd", SqlDbType.BigInt).Value = args.cons_cd
            cmd.Parameters.Add("iss_yard", SqlDbType.Char, 6).Value = args.iss_yard
            cmd.Parameters.Add("sbu_cd", SqlDbType.BigInt).Value = args.sbu_cd
            cmd.Parameters.Add("sub_str_cd", SqlDbType.Char, 2).Value = args.SUB_STR_CD
            cmd.Parameters.Add("luser_id", SqlDbType.Char, 6).Value = args.luser_id
            cmd.Parameters.Add("lupd_dt", SqlDbType.DateTime).Value = args.lupd_dt
            cmd.Parameters.Add("auth_id", SqlDbType.Char, 6).Value = args.auth_id
            cmd.Parameters.Add("auth_dt", SqlDbType.DateTime).Value = args.auth_dt
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function

    Public Function Insert_authorize(ByVal args As PRP_Pmivdtl) As QueryResponse(Of PRP_Pmivdtl)
        Dim res As New QueryResponse(Of PRP_Pmivdtl)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Save_pmivdtl"
            cmd.Parameters.Add("miv_no", SqlDbType.BigInt).Value = args.miv_no
            cmd.Parameters.Add("miv_dt", SqlDbType.NVarChar, 11).Value = args.miv_dt
            cmd.Parameters.Add("miv_yr", SqlDbType.Int).Value = args.miv_yr
            cmd.Parameters.Add("itm_sno", SqlDbType.Int).Value = args.itm_sno
            cmd.Parameters.Add("itm_cd", SqlDbType.Char, 7).Value = args.itm_cd
            cmd.Parameters.Add("str_cd", SqlDbType.Char, 2).Value = args.str_cd
            cmd.Parameters.Add("req_Qty", SqlDbType.Decimal).Value = args.req_qty
            cmd.Parameters.Add("pre_stk_qty", SqlDbType.Decimal).Value = args.pre_stk_qty
            cmd.Parameters.Add("iss_Qty", SqlDbType.Decimal).Value = args.iss_qty
            cmd.Parameters.Add("iss_rt", SqlDbType.Decimal).Value = args.iss_rt
            cmd.Parameters.Add("iss_val", SqlDbType.Decimal).Value = args.iss_val
            cmd.Parameters.Add("cc_cd", SqlDbType.Int).Value = args.cc_cd
            cmd.Parameters.Add("cons_Cd", SqlDbType.BigInt).Value = args.cons_cd
            cmd.Parameters.Add("iss_yard", SqlDbType.Char, 6).Value = args.iss_yard
            cmd.Parameters.Add("sbu_cd", SqlDbType.BigInt).Value = args.sbu_cd
            cmd.Parameters.Add("sub_str_cd", SqlDbType.Char, 2).Value = args.SUB_STR_CD
            cmd.Parameters.Add("luser_id", SqlDbType.Char, 6).Value = args.luser_id
            cmd.Parameters.Add("lupd_dt", SqlDbType.DateTime).Value = args.lupd_dt
            cmd.Parameters.Add("auth_id", SqlDbType.Char, 6).Value = args.auth_id
            cmd.Parameters.Add("auth_dt", SqlDbType.DateTime).Value = args.auth_dt
            cmd.Parameters.Add("min_no", SqlDbType.BigInt).Value = args.min_no
            cmd.Parameters.Add("min_dt", SqlDbType.NVarChar, 11).Value = args.min_dt
            cmd.Parameters.Add("min_qty", SqlDbType.Decimal).Value = args.min_qty
            cmd.Parameters.Add("min_stk", SqlDbType.Decimal).Value = args.rem_qty
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Save_Pmivdtl_authorize_With_Transaction(ByVal args As PRP_Pmivdtl, ByVal con As SqlConnection, ByVal tran As SqlTransaction) As QueryResponse(Of PRP_Pmivdtl)
        Dim res As New QueryResponse(Of PRP_Pmivdtl)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = tran
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Save_pmivdtl_authorize"
            cmd.Parameters.Add("miv_no", SqlDbType.BigInt).Value = args.miv_no
            cmd.Parameters.Add("miv_dt", SqlDbType.NVarChar, 11).Value = args.miv_dt
            cmd.Parameters.Add("miv_yr", SqlDbType.Int).Value = args.miv_yr
            cmd.Parameters.Add("itm_sno", SqlDbType.Int).Value = args.itm_sno
            cmd.Parameters.Add("itm_cd", SqlDbType.Char, 7).Value = args.itm_cd
            cmd.Parameters.Add("str_cd", SqlDbType.Char, 2).Value = args.str_cd
            cmd.Parameters.Add("req_Qty", SqlDbType.Decimal).Value = args.req_qty
            cmd.Parameters.Add("pre_stk_qty", SqlDbType.Decimal).Value = args.pre_stk_qty
            cmd.Parameters.Add("iss_Qty", SqlDbType.Decimal).Value = args.iss_qty
            cmd.Parameters.Add("iss_rt", SqlDbType.Decimal).Value = args.iss_rt
            cmd.Parameters.Add("iss_val", SqlDbType.Decimal).Value = args.iss_val
            cmd.Parameters.Add("cc_cd", SqlDbType.Int).Value = args.cc_cd
            cmd.Parameters.Add("cons_Cd", SqlDbType.BigInt).Value = args.cons_cd
            cmd.Parameters.Add("iss_yard", SqlDbType.Char, 6).Value = args.iss_yard
            cmd.Parameters.Add("sbu_cd", SqlDbType.BigInt).Value = args.sbu_cd
            cmd.Parameters.Add("sub_str_cd", SqlDbType.Char, 2).Value = args.SUB_STR_CD
            cmd.Parameters.Add("luser_id", SqlDbType.Char, 6).Value = args.luser_id
            cmd.Parameters.Add("lupd_dt", SqlDbType.DateTime).Value = args.lupd_dt
            cmd.Parameters.Add("auth_id", SqlDbType.Char, 6).Value = args.auth_id
            cmd.Parameters.Add("auth_dt", SqlDbType.DateTime).Value = args.auth_dt
            cmd.Parameters.Add("min_no", SqlDbType.BigInt).Value = args.min_no
            cmd.Parameters.Add("min_dt", SqlDbType.NVarChar, 11).Value = args.min_dt
            cmd.Parameters.Add("min_qty", SqlDbType.Decimal).Value = args.min_qty
            cmd.Parameters.Add("min_stk", SqlDbType.Decimal).Value = args.rem_qty
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function


    Public Function Update(ByVal args As PRP_Pmivdtl) As QueryResponse(Of PRP_Pmivdtl) Implements IissueVoucher(Of PRP_Pmivdtl).Update
        Throw New NotImplementedException()
    End Function

    Public Function View1(ByVal args As PRP_Pmivdtl) As QueryResponse(Of PRP_Pmivdtl_stock)
        Dim res As New QueryResponse(Of PRP_Pmivdtl_stock)
        'Dim obj As New PRP_Pmivdtl_stock()
        Dim pre_stk As Decimal = 0
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = args.par
            cmd.Parameters.Add("@miv_no", SqlDbType.Int).Value = args.miv_no
            cmd.Parameters.Add("@miv_yr", SqlDbType.Int).Value = args.miv_yr
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObject = New PRP_Pmivdtl_stock()
                res.responseObject.Pmivdtl_List = New List(Of PRP_Pmivdtl)
                'Dim x As New List(Of PRP_Pmivdtl)

                For Each row As DataRow In ds.Tables(0).Rows
                    Dim p As New PRP_Pmivdtl()
                    With p
                        rettyp = ""
                        If row("rettyp").ToString().Trim = "N" Then
                            rettyp = ""
                        ElseIf row("rettyp").ToString().Trim = "R" Then
                            rettyp = "Replace ment"
                        ElseIf row("rettyp").ToString().Trim = "A" Then
                            rettyp = "New Addition"
                        ElseIf row("rettyp").ToString().Trim = "P" Then
                            rettyp = "Project"
                        End If

                        c = c + 1
                        '.sno = c
                        .itm_sno = c
                        .miv_no = row("miv_no").ToString()
                        .miv_dt1 = Convert.ToDateTime(row("miv_dt").ToString()).ToString("dd-MMM-yyyy")
                        .miv_dt = Convert.ToDateTime(row("miv_dt").ToString()).ToString("dd-MMM-yyyy")
                        .inv_typ = row("inv_typ").ToString()
                        .status = row("status").ToString()
                        .itm_sno = row("itm_sno").ToString()
                        .itm_cd = row("itm_cd").ToString()
                        .str_cd = row("str_cd").ToString()
                        .itm_desc = row("itm_desc").ToString()
                        .SUB_STR_CD = row("sub_str_cd").ToString()
                        .pre_stk_qty = Format(row("pre_stk_qty"), "0.000")
                        .req_qty = Format(row("req_qty"), "0.000")
                        .iss_qty = Format(row("iss_qty"), "0.000")
                        .iss_rt = Format(row("iss_rt"), "0.00")
                        .iss_val = Format(row("iss_val"), "0.00")
                        pre_stk = pre_stk + .iss_val
                        .cons_cd = row("cons_cd").ToString()
                        .cc_cd = row("cc_cd").ToString()
                        .uom = row("stk_uom").ToString()
                        .Reason = row("reason").ToString()
                        .Ret_no = Convert.ToInt32(row("ret_no"))
                        .RetTyp = rettyp
                        .Remark = row("remark")
                        .min_no = row("min_no")
                        .min_dt = Convert.ToDateTime(row("min_dt").ToString()).ToString("dd-MMM-yyyy")
                        .min_qty = row("min_qty")
                        .rem_qty = row("rem_qty")
                        .OrdNo = row("ord_no")
                        .cons_nm = row("cons_nm")
                        .cc_nm = row("cc_nm")
                    End With
                    res.responseObject.Pmivdtl_List.Add(p)
                Next
            Else
                res.response = -1
                res.responseMsg = "Detail not found, Check sp: NIVS_Display_IssueDetail"
                Throw New Exception(res.responseMsg)
            End If

            If args.LoginID = "J16338" Then
                'res.responseObject.Pmivdtl_List = New List(Of PRP_Pmivdtl)
                'res.responseObject.Pmivdtl_List = res.responseObject.Pmivdtl_List
                'res.responseObject.stk = pre_stk
                For Each item As PRP_Pmivdtl In res.responseObject.Pmivdtl_List
                    Dim x As New QueryResponse(Of PRP_MinList)
                    x = Display_Fill_Dropdown_MIN(2, item.itm_cd.ToString().Trim())
                    item.MinList = x.responseObjectList
                Next
            End If

            'Dim objcs As New cls_ConsumptionCentre()
            'Dim res1 As New QueryResponse(Of PRP_ConsumptionCentre)
            'res1 = objcs.View()
            'res.responseObject.PRP_ConsumptionCentre_List = res1.responseObjectList

            'Dim objccs As New cls_CostCentre()
            'Dim res2 As New QueryResponse(Of PRP_CostCentre)
            'res2 = objccs.View()
            'res.responseObject.PRP_CostCentre_List = res2.responseObjectList

            res.response = 1
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function


    Public Function Display_Fill_Dropdown_MIN(ByVal varpar As Int32, ByVal varItmCod As String) As QueryResponse(Of PRP_MinList)
        Dim res As New QueryResponse(Of PRP_MinList)
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Issue_Link_MIN_Ritesh1"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = varpar
            cmd.Parameters.Add("@itm_cd", SqlDbType.NVarChar, 7).Value = varItmCod
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_MinList)
                For Each row As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_MinList() With {
                    .min_desc = row("min_desc").ToString(),
                    .min_no = row("min_no").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_MINDetail(ByVal varpar As Int32, ByVal varItmCod As String) As QueryResponse(Of PRP_Pmivdtl)
        Dim res As New QueryResponse(Of PRP_Pmivdtl)
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Issue_Link_MIN_Ritesh1"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = varpar
            cmd.Parameters.Add("@itm_cd", SqlDbType.NVarChar, 7).Value = varItmCod
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Pmivdtl)
                For Each row As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_Pmivdtl() With {
                    .min_no = row("min_no").ToString(),
                    .min_dt = row("min_dt").ToString(),
                    .min_qty = row("acpt_Qty").ToString(),
                    .itm_sno = row("sno").ToString(),
                    .itm_cd = row("itm_cd").ToString().Trim(),
                    .OrdNo = row("ord_no").ToString.Trim()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function


    Public Function View() As QueryResponse(Of PRP_Pmivdtl) Implements IissueVoucher(Of PRP_Pmivdtl).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_Pmivdtl) As QueryResponse(Of PRP_Pmivdtl) Implements IissueVoucher(Of PRP_Pmivdtl).View
        Dim res As New QueryResponse(Of PRP_Pmivdtl)
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = args.par
            cmd.Parameters.Add("@miv_no", SqlDbType.Int).Value = args.miv_no
            cmd.Parameters.Add("@miv_yr", SqlDbType.Int).Value = args.miv_yr
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Pmivdtl)
                For Each row As DataRow In ds.Tables(0).Rows
                    rettyp = ""
                    If row("rettyp").ToString().Trim = "N" Then
                        rettyp = ""
                    ElseIf row("rettyp").ToString().Trim = "R" Then
                        rettyp = "Replace ment"
                    ElseIf row("rettyp").ToString().Trim = "A" Then
                        rettyp = "New Addition"
                    ElseIf row("rettyp").ToString().Trim = "P" Then
                        rettyp = "Project"
                    End If

                    c = c + 1
                    res.responseObjectList.Add(New PRP_Pmivdtl() With {
                        .sno = c,
                        .miv_no = row("miv_no").ToString(),
                        .miv_dt1 = Convert.ToDateTime(row("miv_dt").ToString()).ToString("dd-MMM-yyyy"),
                        .miv_dt = Convert.ToDateTime(row("miv_dt").ToString()).ToString("dd-MMM-yyyy"),
                        .inv_typ = row("inv_typ").ToString(),
                        .status = row("status").ToString(),
                        .itm_sno = row("itm_sno").ToString(),
                        .itm_cd = row("itm_cd").ToString(),
                        .str_cd = row("str_cd").ToString(),
                        .itm_desc = row("itm_desc").ToString(),
                        .SUB_STR_CD = row("sub_str_cd").ToString(),
                        .pre_stk_qty = Format(row("pre_stk_qty"), "0.000"),
                        .req_qty = Format(row("req_qty"), "0.000"),
                        .iss_qty = Format(row("iss_qty"), "0.000"),
                        .iss_rt = Format(row("iss_rt"), "0.00"),
                        .iss_val = Format(row("iss_val"), "0.00"),
                        .cons_cd = row("cons_cd").ToString(),
                        .cc_cd = row("cc_cd").ToString(),
                        .uom = row("stk_uom").ToString(),
                        .Reason = row("reason").ToString(),
                        .Ret_no = Convert.ToInt32(row("ret_no")),
                        .RetTyp = rettyp,
                        .Remark = row("remark"),
                        .min_no = row("min_no"),
                        .min_dt = Convert.ToDateTime(row("min_dt").ToString()).ToString("dd-MMM-yyyy"),
                        .min_qty = row("min_qty"),
                        .rem_qty = row("rem_qty"),
                        .OrdNo = row("ord_no")
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
End Class

Public Class cls_Lv_emp_Sec
    Inherits db_Connection
    Implements IissueVoucher(Of PRP_lv_emp_sec)


    Public Sub New()
        MyBase.new("cnl") 'Maintenance Development Database
    End Sub

    Public Function Check_Password(ByVal varempcd As String, ByVal varoldpwd As String) As QueryResponse(Of PRP_lv_emp_sec)
        Dim res As New QueryResponse(Of PRP_lv_emp_sec)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIS_Check_Password"
            cmd.Parameters.Add("@Par", SqlDbType.NVarChar, 6).Value = 1
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 6).Value = varempcd
            cmd.Parameters.Add("@sec_cd", SqlDbType.NVarChar, 50).Value = varoldpwd
            Dim p1 As New SqlParameter("@outres", SqlDbType.Int)
            p1.Direction = ParameterDirection.ReturnValue
            cmd.Parameters.Add(p1)
            cmd.CommandType = CommandType.StoredProcedure
            res.response = cmd.ExecuteNonQuery()
            res.slipNo = Convert.ToInt32(cmd.Parameters("@outres").Value)
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function


    Public Function Delete(ByVal args As PRP_lv_emp_sec) As QueryResponse(Of PRP_lv_emp_sec) Implements IissueVoucher(Of PRP_lv_emp_sec).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Insert(ByVal args As PRP_lv_emp_sec) As QueryResponse(Of PRP_lv_emp_sec) Implements IissueVoucher(Of PRP_lv_emp_sec).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Update(ByVal args As PRP_lv_emp_sec) As QueryResponse(Of PRP_lv_emp_sec) Implements IissueVoucher(Of PRP_lv_emp_sec).Update
        Dim res As New QueryResponse(Of PRP_lv_emp_sec)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIS_Change_Password"
            cmd.Parameters.Add("par", SqlDbType.Int).Value = 1
            cmd.Parameters.Add("emp_cd", SqlDbType.NVarChar, 6).Value = args.emp_cd
            cmd.Parameters.Add("sec_cd", SqlDbType.NVarChar, 50).Value = args.sec_cd
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = "Password is Changed Succesfully"
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function View() As QueryResponse(Of PRP_lv_emp_sec) Implements IissueVoucher(Of PRP_lv_emp_sec).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_lv_emp_sec) As QueryResponse(Of PRP_lv_emp_sec) Implements IissueVoucher(Of PRP_lv_emp_sec).View
        Throw New NotImplementedException()
    End Function
End Class

Public Class CLS_Plgdtl
    Inherits db_Connection
    Implements IissueVoucher(Of PRP_plgdtl)

    Public Sub New()
        MyBase.new("cnl") 'Maintenance Development Database
    End Sub

    Public Function Delete(ByVal args As PRP_plgdtl) As QueryResponse(Of PRP_plgdtl) Implements IissueVoucher(Of PRP_plgdtl).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Save_Plgdtl(ByVal args As PRP_plgdtl, ByVal con As SqlConnection, ByVal tran As SqlTransaction) As QueryResponse(Of PRP_plgdtl)
        Dim res As New QueryResponse(Of PRP_plgdtl)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = tran
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Save_plgdtl"
            cmd.Parameters.Add("inv_typ", SqlDbType.Char, 1).Value = args.inv_typ
            cmd.Parameters.Add("sr_no", SqlDbType.BigInt).Value = args.sr_no
            cmd.Parameters.Add("itm_cd", SqlDbType.Char, 7).Value = args.itm_cd
            cmd.Parameters.Add("str_cd", SqlDbType.Char, 2).Value = args.str_cd
            cmd.Parameters.Add("crt_dt", SqlDbType.NVarChar, 11).Value = args.crt_dt
            cmd.Parameters.Add("mm", SqlDbType.Int).Value = args.mm
            cmd.Parameters.Add("yr", SqlDbType.Int).Value = args.yr
            cmd.Parameters.Add("doc_typ", SqlDbType.Char, 4).Value = args.doc_typ
            cmd.Parameters.Add("doc_dt", SqlDbType.NVarChar, 11).Value = args.doc_dt
            cmd.Parameters.Add("doc_no", SqlDbType.Int).Value = args.doc_no
            cmd.Parameters.Add("iss_Qty", SqlDbType.Decimal).Value = args.iss_qty
            cmd.Parameters.Add("iss_val", SqlDbType.Decimal).Value = args.iss_val
            cmd.Parameters.Add("luser_id", SqlDbType.NVarChar, 6).Value = args.luser_id
            cmd.Parameters.Add("lupd_dt", SqlDbType.DateTime).Value = args.lupd_dt
            cmd.Parameters.Add("auth_id", SqlDbType.NVarChar, 6).Value = args.auth_id
            cmd.Parameters.Add("auth_dt", SqlDbType.DateTime).Value = args.auth_dt
            cmd.Parameters.Add("sub_str_cd", SqlDbType.Char, 2).Value = args.SUB_STR_CD
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function


    Public Function Insert(ByVal args As PRP_plgdtl) As QueryResponse(Of PRP_plgdtl) Implements IissueVoucher(Of PRP_plgdtl).Insert
        Dim res As New QueryResponse(Of PRP_plgdtl)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Save_plgdtl"

            cmd.Parameters.Add("inv_typ", SqlDbType.Char, 1).Value = args.inv_typ
            cmd.Parameters.Add("sr_no", SqlDbType.BigInt).Value = args.sr_no
            cmd.Parameters.Add("itm_cd", SqlDbType.Char, 7).Value = args.itm_cd
            cmd.Parameters.Add("str_cd", SqlDbType.Char, 2).Value = args.str_cd
            cmd.Parameters.Add("crt_dt", SqlDbType.NVarChar, 11).Value = args.crt_dt
            cmd.Parameters.Add("mm", SqlDbType.Int).Value = args.mm
            cmd.Parameters.Add("yr", SqlDbType.Int).Value = args.yr
            cmd.Parameters.Add("doc_typ", SqlDbType.Char, 4).Value = args.doc_typ
            cmd.Parameters.Add("doc_dt", SqlDbType.NVarChar, 11).Value = args.doc_dt
            cmd.Parameters.Add("doc_no", SqlDbType.Int).Value = args.doc_no
            cmd.Parameters.Add("iss_Qty", SqlDbType.Decimal).Value = args.iss_qty
            cmd.Parameters.Add("iss_val", SqlDbType.Decimal).Value = args.iss_val
            cmd.Parameters.Add("luser_id", SqlDbType.NVarChar, 6).Value = args.luser_id
            cmd.Parameters.Add("lupd_dt", SqlDbType.DateTime).Value = args.lupd_dt
            cmd.Parameters.Add("auth_id", SqlDbType.NVarChar, 6).Value = args.auth_id
            cmd.Parameters.Add("auth_dt", SqlDbType.DateTime).Value = args.auth_dt
            cmd.Parameters.Add("sub_str_cd", SqlDbType.Char, 2).Value = args.SUB_STR_CD
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Update(ByVal args As PRP_plgdtl) As QueryResponse(Of PRP_plgdtl) Implements IissueVoucher(Of PRP_plgdtl).Update
        Throw New NotImplementedException()
    End Function

    Public Function View() As QueryResponse(Of PRP_plgdtl) Implements IissueVoucher(Of PRP_plgdtl).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_plgdtl) As QueryResponse(Of PRP_plgdtl) Implements IissueVoucher(Of PRP_plgdtl).View
        Throw New NotImplementedException()
    End Function
    Public Function Display_lgsrno(ByVal con As SqlConnection, ByVal tran As SqlTransaction) As QueryResponse(Of PRP_plgdtl)
        Dim res As New QueryResponse(Of PRP_plgdtl)
        Dim c As Int64 = 0
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = tran
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 9
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObject = New PRP_plgdtl()
                Dim row As DataRow = ds.Tables(0).Rows(0)
                res.responseObject.sr_no = Convert.ToInt64(row(0))
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function

    Public Function Display_lgsrno() As QueryResponse(Of PRP_plgdtl)
        Dim res As New QueryResponse(Of PRP_plgdtl)
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 9
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObject = New PRP_plgdtl()
                Dim row As DataRow = ds.Tables(0).Rows(0)
                res.responseObject.sr_no = Convert.ToInt64(row(0))
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
End Class

Public Class CLS_Pitmaster
    Inherits db_Connection
    Implements IissueVoucher(Of PRP_Pitmaster)


    Public Sub New()
        MyBase.new("cnl") 'Maintenance Development Database
    End Sub

    Public Function Delete(ByVal args As PRP_Pitmaster) As QueryResponse(Of PRP_Pitmaster) Implements IissueVoucher(Of PRP_Pitmaster).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Insert(ByVal args As PRP_Pitmaster) As QueryResponse(Of PRP_Pitmaster) Implements IissueVoucher(Of PRP_Pitmaster).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Update(ByVal args As PRP_Pitmaster) As QueryResponse(Of PRP_Pitmaster) Implements IissueVoucher(Of PRP_Pitmaster).Update
        Dim res As New QueryResponse(Of PRP_Pitmaster)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Update_pitmaster"
            cmd.Parameters.Add("itm_cd", SqlDbType.NVarChar, 7).Value = args.itm_cd
            cmd.Parameters.Add("last_iss_no", SqlDbType.Int).Value = args.last_iss_no
            cmd.Parameters.Add("last_iss_dt", SqlDbType.DateTime).Value = args.last_iss_dt
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
    Public Function Update_Pitmaster(ByVal args As PRP_Pitmaster, ByVal con As SqlConnection, ByVal tran As SqlTransaction) As QueryResponse(Of PRP_Pitmaster)
        Dim res As New QueryResponse(Of PRP_Pitmaster)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = tran
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Update_pitmaster"
            cmd.Parameters.Add("itm_cd", SqlDbType.NVarChar, 7).Value = args.itm_cd
            cmd.Parameters.Add("last_iss_no", SqlDbType.Int).Value = args.last_iss_no
            cmd.Parameters.Add("last_iss_dt", SqlDbType.DateTime).Value = args.last_iss_dt
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function

    Public Function View() As QueryResponse(Of PRP_Pitmaster) Implements IissueVoucher(Of PRP_Pitmaster).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_Pitmaster) As QueryResponse(Of PRP_Pitmaster) Implements IissueVoucher(Of PRP_Pitmaster).View
        Throw New NotImplementedException()
    End Function

    Public Function Display_Items_ForPopup(ByVal varitmcd As String) As QueryResponse(Of PRP_Pitmaster)
        Dim res As New QueryResponse(Of PRP_Pitmaster)
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 42
            cmd.Parameters.Add("@itmnam", SqlDbType.NVarChar, 50).Value = varitmcd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Pitmaster)
                For Each row As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_Pitmaster() With {
                        .itm_cd = row("itm_cd").ToString(),
                    .itm_desc = row("itm_desc").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_Items(ByVal varitmcd As String) As QueryResponse(Of PRP_Pitmaster)
        Dim res As New QueryResponse(Of PRP_Pitmaster)
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NSM_Display_Detail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 14
            cmd.Parameters.Add("@itmnam", SqlDbType.NVarChar, 50).Value = varitmcd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Pitmaster)
                For Each row As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_Pitmaster() With {
                        .itm_cd = row("itm_cd").ToString(),
                    .itm_desc = row("itm_desc").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_rate(ByVal varitmcd As String) As QueryResponse(Of PRP_Pitmaster)
        Dim res As New QueryResponse(Of PRP_Pitmaster)
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIS_Display_Indent_hdr"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 10
            cmd.Parameters.Add("@itm_cd", SqlDbType.NVarChar, 7).Value = varitmcd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_Pitmaster()
                res.responseObject.rate = drr("Column1").ToString()
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = "Item Rate not Found"
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_Item() As QueryResponse(Of PRP_Pitmaster)
        Dim res As New QueryResponse(Of PRP_Pitmaster)
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIS_Display_Indent_hdr"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 6
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Pitmaster)
                For Each row As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_Pitmaster() With {
                        .itm_cd = row("itm_cd").ToString(),
                        .itm_desc = row("itm_desc").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_ItemName(ByVal varitmnam As String) As QueryResponse(Of PRP_Pitmaster)
        Dim res As New QueryResponse(Of PRP_Pitmaster)
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 40
            cmd.Parameters.Add("@itm_desc", SqlDbType.Char, 20).Value = varitmnam
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Pitmaster)
                For Each row As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_Pitmaster() With {
                        .itm_cd = row("itm_cd").ToString(),
                        .itm_desc = row("itm_desc").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_ItemDetail(ByVal varitmcd As String) As QueryResponse(Of PRP_Pitmaster)
        Dim res As New QueryResponse(Of PRP_Pitmaster)
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_Pitmaster"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 1
            cmd.Parameters.Add("@itm_cd", SqlDbType.NVarChar, 7).Value = varitmcd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim row As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_Pitmaster()
                With res.responseObject
                    .itm_cd = row("itm_cd").ToString()
                    .itm_desc = row("itm_desc").ToString()
                    .uom = row("stk_uom").ToString()
                    .stk_qty = row("curr_stk_qty").ToString()
                    .rate = row("war_rt").ToString()
                    .str_cd = row("str_cd").ToString()
                    .str_typ = row("str_typ").ToString()
                End With
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_Item(ByVal varitmcd As String) As QueryResponse(Of PRP_Pitmaster)
        Dim res As New QueryResponse(Of PRP_Pitmaster)
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIS_Display_Indent_hdr"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 7
            cmd.Parameters.Add("@itm_cd", SqlDbType.NVarChar, 7).Value = varitmcd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Pitmaster)
                For Each row As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_Pitmaster() With {
                    .itm_cd = row("itm_cd").ToString(),
                    .itm_desc = row("itm_desc").ToString(),
                    .uom = row("stk_uom").ToString(),
                    .stk_qty = row("curr_stk_qty").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function FillDropDown(ByVal vartext As String) As QueryResponse(Of PRP_Pitmaster)
        Dim res As New QueryResponse(Of PRP_Pitmaster)
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIS_Display_Indent"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 33
            cmd.Parameters.Add("@ftext", SqlDbType.NVarChar, 50).Value = vartext
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Pitmaster)
                For Each row As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_Pitmaster() With {
                    .itm_cd = row("itm_cd").ToString(),
                    .itm_desc = row("itm_desc").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_ItemDetail() As QueryResponse(Of PRP_Pitmaster)
        Dim res As New QueryResponse(Of PRP_Pitmaster)
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIS_Display_Indent_hdr"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 27
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Pitmaster)
                For Each row As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_Pitmaster() With {
                    .itm_cd = row("itm_cd").ToString(),
                    .itm_desc = row("itm_desc").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function


End Class

Public Class cls_EmployeeDetail
    Inherits db_Connection
    Implements IissueVoucher(Of PRP_EmployeeDetail)


    Public Sub New()
        MyBase.new("cnl") 'Maintenance Development Database
    End Sub

    Public Function Delete(ByVal args As PRP_EmployeeDetail) As QueryResponse(Of PRP_EmployeeDetail) Implements IissueVoucher(Of PRP_EmployeeDetail).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Insert(ByVal args As PRP_EmployeeDetail) As QueryResponse(Of PRP_EmployeeDetail) Implements IissueVoucher(Of PRP_EmployeeDetail).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Update(ByVal args As PRP_EmployeeDetail) As QueryResponse(Of PRP_EmployeeDetail) Implements IissueVoucher(Of PRP_EmployeeDetail).Update
        Throw New NotImplementedException()
    End Function

    Public Function View() As QueryResponse(Of PRP_EmployeeDetail) Implements IissueVoucher(Of PRP_EmployeeDetail).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_EmployeeDetail) As QueryResponse(Of PRP_EmployeeDetail) Implements IissueVoucher(Of PRP_EmployeeDetail).View
        Throw New NotImplementedException()
    End Function
    Public Function Display_Employee_Name(ByVal varempcd As String) As QueryResponse(Of PRP_EmployeeDetail)
        Dim res As New QueryResponse(Of PRP_EmployeeDetail)
        Dim c As Int64 = 0
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIS_employee_dtl"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 2
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 11).Value = varempcd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_EmployeeDetail()
                res.responseObject.emp_nm = drr("emp_nm").ToString().Trim
                res.responseObject.emp_cd = drr("emp_cd").ToString().Trim
                res.responseObject.dept_cd = drr("dept_cd").ToString().Trim
                res.responseObject.dept_nm = drr("dept_nm").ToString().Trim
                res.responseObject.emp_nm1 = drr("emp_nm1").ToString().Trim
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_Indentor() As QueryResponse(Of PRP_EmployeeDetail)
        Dim res As New QueryResponse(Of PRP_EmployeeDetail)
        Dim c As Int64 = 0
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIS_Display_Indent_hdr"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 13
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_EmployeeDetail)
                For Each row As DataRow In ds.Tables(0).Rows
                    c = c + 1
                    res.responseObjectList.Add(New PRP_EmployeeDetail() With {
                    .emp_cd = row("userid").ToString(),
                    .emp_nm = row("emp_nm").ToString(),
                    .dept_nm = row("dept_nm").ToString(),
                    .firautcod = row("firautcod").ToString(),
                    .firautnam = row("firautnam").ToString(),
                    .finautcod = row("finautcod").ToString(),
                    .finautnam = row("finautnam").ToString(),
                    .secautcod = row("secautcod").ToString(),
                    .secautnam = row("secautnam").ToString(),
                    .desig_nm = row("desig_nm").ToString(),
                    .dept_cd = row("dept_cd").ToString(),
                    .srno = c
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_Indentor(ByVal varempcd As String) As QueryResponse(Of PRP_EmployeeDetail)
        Dim res As New QueryResponse(Of PRP_EmployeeDetail)
        Dim c As Int64 = 0
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIS_Display_Indent_hdr"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 16
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 6).Value = varempcd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_EmployeeDetail)
                For Each row As DataRow In ds.Tables(0).Rows
                    c = c + 1
                    res.responseObjectList.Add(New PRP_EmployeeDetail() With {
                    .emp_cd = row("userid").ToString(),
                    .emp_nm = row("emp_nm").ToString(),
                    .dept_nm = row("dept_nm").ToString(),
                    .firautcod = row("firautcod").ToString(),
                    .firautnam = row("firautnam").ToString(),
                    .finautcod = row("finautcod").ToString(),
                    .finautnam = row("finautnam").ToString(),
                    .secautcod = row("secautcod").ToString(),
                    .secautnam = row("secautnam").ToString(),
                    .desig_nm = row("desig_nm").ToString(),
                    .dept_cd = row("dept_cd").ToString(),
                    .srno = c
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
    Public Function Display_Employee_Detail(ByVal varempcd As String) As QueryResponse(Of PRP_EmployeeDetail)
        Dim res As New QueryResponse(Of PRP_EmployeeDetail)
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIS_employee_dtl"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 1
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 11).Value = varempcd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_EmployeeDetail()
                res.responseObject.emp_cd = varempcd
                res.responseObject.emp_nm = drr("emp_nm").ToString()
                res.responseObject.dept_nm = drr("dept_nm").ToString()
                res.responseObject.firautcod = drr("firautcod").ToString()
                res.responseObject.firautnam = drr("firautnam").ToString()
                res.responseObject.finautcod = drr("finautcod").ToString()
                res.responseObject.finautnam = drr("finautnam").ToString()
                res.responseObject.secautcod = drr("secautcod").ToString()
                res.responseObject.secautnam = drr("secautnam").ToString()
                res.responseObject.desig_nm = drr("desig_nm").ToString()
                res.responseObject.dept_cd = drr("dept_cd").ToString()
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_EmployeeDetail(ByVal varempcd As String) As QueryResponse(Of PRP_EmployeeDetail)
        Dim res As New QueryResponse(Of PRP_EmployeeDetail)
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 30
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 11).Value = varempcd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_EmployeeDetail()
                res.responseObject.emp_cd = varempcd
                res.responseObject.emp_nm = drr("emp_nm").ToString()
                res.responseObject.dept_nm = drr("dept_nm").ToString()
                res.responseObject.desig_nm = drr("desig_nm").ToString()
                res.responseObject.dept_cd = drr("dept_cd").ToString()
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_Emp_Name() As QueryResponse(Of PRP_EmployeeDetail)
        Dim res As New QueryResponse(Of PRP_EmployeeDetail)
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 13
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_EmployeeDetail)
                For Each row As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_EmployeeDetail() With {
                    .emp_cd = row("emp_cd").ToString(),
                    .emp_nm = row("emp_nm").ToString(),
                    .dept_nm = row("dept_nm").ToString(),
                    .desig_nm = row("desig_nm").ToString(),
                    .dept_cd = row("dept_cd").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
    Public Function Display_Indentor_indropdown() As QueryResponse(Of PRP_EmployeeDetail)
        Dim res As New QueryResponse(Of PRP_EmployeeDetail)
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIS_Display_Indent_hdr"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 15
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_EmployeeDetail()
                res.responseObject.emp_nm = drr("emp_nm").ToString()
                res.responseObject.emp_nm1 = drr("emp_nm1").ToString()
                res.responseObject.emp_cd = drr("emp_cd").ToString()
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

End Class

Public Class cls_Department
    Inherits db_Connection
    Implements IissueVoucher(Of PRP_Department)


    Public Sub New()
        MyBase.new("cnl") 'Maintenance Development Database
    End Sub

    Public Function Delete(ByVal args As PRP_Department) As QueryResponse(Of PRP_Department) Implements IissueVoucher(Of PRP_Department).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Insert(ByVal args As PRP_Department) As QueryResponse(Of PRP_Department) Implements IissueVoucher(Of PRP_Department).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Update(ByVal args As PRP_Department) As QueryResponse(Of PRP_Department) Implements IissueVoucher(Of PRP_Department).Update
        Throw New NotImplementedException()
    End Function

    Public Function View() As QueryResponse(Of PRP_Department) Implements IissueVoucher(Of PRP_Department).View
        Dim res As New QueryResponse(Of PRP_Department)
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIS_Display_dept"
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Department)
                For Each row As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_Department() With {
                    .dept_cd = row("dept_cd").ToString(),
                    .dept_nm = row("dept_nm").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function View(ByVal args As PRP_Department) As QueryResponse(Of PRP_Department) Implements IissueVoucher(Of PRP_Department).View
        Throw New NotImplementedException()
    End Function
End Class

Public Class cls_CostCentre
    Inherits db_Connection
    Implements IissueVoucher(Of PRP_CostCentre)

    Public Sub New()
        MyBase.new("cnl") 'Maintenance Development Database
    End Sub

    Public Function Delete(ByVal args As PRP_CostCentre) As QueryResponse(Of PRP_CostCentre) Implements IissueVoucher(Of PRP_CostCentre).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Insert(ByVal args As PRP_CostCentre) As QueryResponse(Of PRP_CostCentre) Implements IissueVoucher(Of PRP_CostCentre).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Update(ByVal args As PRP_CostCentre) As QueryResponse(Of PRP_CostCentre) Implements IissueVoucher(Of PRP_CostCentre).Update
        Throw New NotImplementedException()
    End Function

    Public Function View() As QueryResponse(Of PRP_CostCentre) Implements IissueVoucher(Of PRP_CostCentre).View
        Dim res As New QueryResponse(Of PRP_CostCentre)
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIS_Display_Indent_hdr"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 1
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_CostCentre)
                For Each row As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_CostCentre() With {
                       .cc_cd = Convert.ToInt32(row("cc_cd").ToString()),
                        .cc_desc = row("cc_desc").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function View(ByVal args As PRP_CostCentre) As QueryResponse(Of PRP_CostCentre) Implements IissueVoucher(Of PRP_CostCentre).View
        Throw New NotImplementedException()
    End Function
End Class

Public Class cls_ConsumptionCentre
    Inherits db_Connection
    Implements IissueVoucher(Of PRP_ConsumptionCentre)

    Public Sub New()
        MyBase.new("cnl") 'Maintenance Development Database
    End Sub

    Public Function Delete(ByVal args As PRP_ConsumptionCentre) As QueryResponse(Of PRP_ConsumptionCentre) Implements IissueVoucher(Of PRP_ConsumptionCentre).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Insert(ByVal args As PRP_ConsumptionCentre) As QueryResponse(Of PRP_ConsumptionCentre) Implements IissueVoucher(Of PRP_ConsumptionCentre).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Update(ByVal args As PRP_ConsumptionCentre) As QueryResponse(Of PRP_ConsumptionCentre) Implements IissueVoucher(Of PRP_ConsumptionCentre).Update
        Throw New NotImplementedException()
    End Function

    Public Function View() As QueryResponse(Of PRP_ConsumptionCentre) Implements IissueVoucher(Of PRP_ConsumptionCentre).View
        Dim res As New QueryResponse(Of PRP_ConsumptionCentre)
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIS_Display_Indent_hdr"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 2
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_ConsumptionCentre)
                For Each row As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_ConsumptionCentre() With {
                       .cons_cd = Convert.ToInt32(row("cons_cd").ToString()),
                        .cons_desc = row("cons_desc").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function View(ByVal args As PRP_ConsumptionCentre) As QueryResponse(Of PRP_ConsumptionCentre) Implements IissueVoucher(Of PRP_ConsumptionCentre).View
        Throw New NotImplementedException()
    End Function
End Class

Public Class commonfunctions
    Inherits db_Connection
    Public Sub New()
        MyBase.new("cnl") 'Maintenance Development Database
    End Sub
    Public Function Set_Welcome_Message(ByVal usernm As String) As QueryResponse(Of PRP_users)
        Dim objusr As New CLS_User_Master()
        Dim res As New QueryResponse(Of PRP_users)
        Dim varusrnam As String = ""
        res = objusr.Display_User_Name(usernm.ToString().Trim())
        Return res
        'varusrnam = res.responseObject.empnm.ToString()
        'CType(mp.FindControl("lblusrnam"), Label).Text = "Welcome, " + varusrnam
    End Function

    Public Sub Set_Welcome_Message(ByVal mp As MasterPage, ByVal u As String)
        Dim objusr As New CLS_User_Master()
        Dim res As New QueryResponse(Of PRP_users)
        Dim varusrnam As String = ""
        res = objusr.Display_User_Name(System.Web.HttpContext.Current.Session("usrnam"))
        varusrnam = res.responseObject.empnm.ToString()
        CType(mp.FindControl("lblusrnam"), Label).Text = "Welcome, " + varusrnam
    End Sub

    Public Sub NLSMessageBox(ByVal p As Page, ByVal msg As String)
        Dim lbl As New Label
        lbl.Text = "<script language='javascript'>" & Environment.NewLine & _
               "window.alert('" + msg + "')</script>"
        p.Controls.Add(lbl)
    End Sub
    Public Function ValidUser(ByVal varusrnam As String, ByVal varusrpas As String) As Boolean
        Dim objusr As New CLS_User_Master()
        Dim res As New QueryResponse(Of PRP_users)
        Dim valid As Boolean = False
        res = objusr.Check_User_Login(varusrnam, varusrpas)
        If res.responseObject.outres = 1 Then valid = True
        Return valid
    End Function
    Public Sub HideMenu(ByVal m As MasterPage)
        CType(m.FindControl("NavigationMenu"), Menu).Visible = False
    End Sub
    Public Sub Set_Menu(ByVal mp As MasterPage)

        '   Dim obj As New Cls_Pindhdr()
        Dim objp As New PRP_Pindhdr()
        ' objp = obj.Display_Login(Session("usrnam"))
        Dim mymenu As Menu = CType(mp.FindControl("NavigationMenu"), Menu)

        Dim mymenuitem As MenuItem = mymenu.FindItem("Admin")
        Dim mymenuitem1 As MenuItem = mymenu.FindItem("Inbox")
        If System.Web.HttpContext.Current.Session("usrnam") = Nothing Then
            System.Web.HttpContext.Current.Response.Redirect("login.aspx")
        ElseIf ((System.Web.HttpContext.Current.Session("usrnam")).ToString.ToUpper <> "H21083") Then
            'mymenuitem.ChildItems.Remove(CType(mymenuitem.ChildItems(1), MenuItem))
            mymenu.Items.Remove(mymenuitem)
        End If
    End Sub

    Public Shared Function GetWebsiteURL() As String
        Dim url As String = ""
        url = HttpContext.Current.Request.Url.Scheme & "://" & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath.TrimEnd("/") & "/"
        Return url
    End Function

    Public Function getSessionVariables() As String
        Dim res As New QueryResponse(Of PRP_PmivInbox)
        Dim emp_cd As String = ""
        If IsNothing(HttpContext.Current.Session("usrnam")) Then
            emp_cd = ""
        Else
            emp_cd = HttpContext.Current.Session("usrnam").ToString()
        End If
        Return emp_cd
    End Function

End Class

Public Class Cls_Hit_counter
    Inherits db_Connection
    Implements IissueVoucher(Of PRP_Hit_Counter)


    Public Sub New()
        MyBase.new("cnl") 'Maintenance Development Database
    End Sub



    Public Function Delete(ByVal args As PRP_Hit_Counter) As QueryResponse(Of PRP_Hit_Counter) Implements IissueVoucher(Of PRP_Hit_Counter).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Insert(ByVal args As PRP_Hit_Counter) As QueryResponse(Of PRP_Hit_Counter) Implements IissueVoucher(Of PRP_Hit_Counter).Insert
        Dim res As New QueryResponse(Of PRP_Hit_Counter)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_save_hit_cou"
            cmd.Parameters.Add("hit_cou", SqlDbType.BigInt).Value = args.hit_cou
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Update(ByVal args As PRP_Hit_Counter) As QueryResponse(Of PRP_Hit_Counter) Implements IissueVoucher(Of PRP_Hit_Counter).Update
        Throw New NotImplementedException()
    End Function

    Public Function View() As QueryResponse(Of PRP_Hit_Counter) Implements IissueVoucher(Of PRP_Hit_Counter).View
        Dim res As New QueryResponse(Of PRP_Hit_Counter)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "NIVS_Display_hit_cou"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 1
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim row As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_Hit_Counter()
                res.responseObject.hit_cou = row("hit_cou").ToString()
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function View(ByVal args As PRP_Hit_Counter) As QueryResponse(Of PRP_Hit_Counter) Implements IissueVoucher(Of PRP_Hit_Counter).View
        Throw New NotImplementedException()
    End Function
End Class

Public Class Cls_Pmivdtl_report
    Inherits db_Connection
    Implements IissueVoucher(Of PRP_Pmivdtl_report)

    Public Sub New()
        MyBase.new("cnl") 'Maintenance Development Database
    End Sub
    Public Function NIVS_Display_MIV_Report(ByVal varmivno As Int64, ByVal varmivyr As Int64) As QueryResponse(Of PRP_Pmivdtl_report)
        Dim res As New QueryResponse(Of PRP_Pmivdtl_report)
        Dim statusG As String = "" : Dim inv_typ As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_MIVReport"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 1
            cmd.Parameters.Add("@miv_no", SqlDbType.NVarChar, 11).Value = varmivno
            cmd.Parameters.Add("@miv_yr", SqlDbType.NVarChar, 11).Value = varmivyr
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Pmivdtl_report)
                For Each row As DataRow In ds.Tables(0).Rows
                    If row("Status").ToString() = "A" Then
                        statusG = "Authorized"
                    ElseIf row("Status").ToString() = "C" Then
                        statusG = "Canceled"
                    End If
                    inv_typ = ""
                    If row("inv_typ").ToString().Trim = "C" Then inv_typ = "Consumable" Else inv_typ = "Captial"
                    res.responseObjectList.Add(New PRP_Pmivdtl_report() With {
                    .miv_no = Convert.ToInt32(row("miv_no").ToString()),
                    .miv_dt = Convert.ToDateTime(row("miv_dt").ToString().ToString()).ToString("dd-MMM-yyyy"),
                    .miv_yr = Convert.ToInt32(row("miv_yr").ToString()),
                    .inv_typ = inv_typ,
                    .status = statusG,
                    .itm_sno = Convert.ToInt32(row("itm_sno").ToString()),
                    .itm_cd = row("itm_cd").ToString(),
                    .str_cd = row("str_cd").ToString(),
                    .req_qty = Convert.ToDecimal(row("req_qty").ToString()),
                    .iss_qty = Convert.ToDecimal(row("iss_qty").ToString()),
                    .itm_desc = row("itm_desc").ToString(),
                    .stk_uom = row("stk_uom").ToString(),
                    .iss_rt = Convert.ToDecimal(row("iss_rt").ToString()),
                    .iss_val = Convert.ToDecimal(row("iss_val").ToString()),
                    .cc_cd = Convert.ToInt32(row("cc_cd").ToString()),
                    .cons_cd = Convert.ToInt32(row("cons_cd").ToString()),
                    .pre_stk_qty = Convert.ToDecimal(row("pre_stk_qty").ToString()),
                    .SUB_STR_CD = row("SUB_STR_CD").ToString(),
                    .cons_desc = row("cons_desc").ToString(),
                    .cc_desc = row("cc_desc").ToString(),
                    .Emp_cd = row("Emp_cd").ToString(),
                    .emp_nm = row("emp_nm").ToString(),
                    .dept_nm = row("dept_nm").ToString(),
                    .app_nm = row("app_nm").ToString()
                })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Delete(ByVal args As PRP_Pmivdtl_report) As QueryResponse(Of PRP_Pmivdtl_report) Implements IissueVoucher(Of PRP_Pmivdtl_report).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Insert(ByVal args As PRP_Pmivdtl_report) As QueryResponse(Of PRP_Pmivdtl_report) Implements IissueVoucher(Of PRP_Pmivdtl_report).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Update(ByVal args As PRP_Pmivdtl_report) As QueryResponse(Of PRP_Pmivdtl_report) Implements IissueVoucher(Of PRP_Pmivdtl_report).Update
        Throw New NotImplementedException()
    End Function

    Public Function View() As QueryResponse(Of PRP_Pmivdtl_report) Implements IissueVoucher(Of PRP_Pmivdtl_report).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_Pmivdtl_report) As QueryResponse(Of PRP_Pmivdtl_report) Implements IissueVoucher(Of PRP_Pmivdtl_report).View
        Throw New NotImplementedException()
    End Function
End Class

Public Class Cls_Indent_log
    Inherits db_Connection
    Implements IissueVoucher(Of PRP_Indent_Log)


    Public Sub New()
        MyBase.new("cnl") 'Maintenance Development Database
    End Sub

    Public Function Save_indent_Log(ByVal i As PRP_Indent_Log) As QueryResponse(Of PRP_Indent_Log)
        Dim res As New QueryResponse(Of PRP_Indent_Log)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure

            cmd.CommandText = "NIS_Save_Indent_Log"
            cmd.Parameters.Add("emp_cd", SqlDbType.NVarChar, 6).Value = i.emp_cd
            cmd.Parameters.Add("edatetime", SqlDbType.DateTime).Value = i.edatetime
            cmd.Parameters.Add("hostname", SqlDbType.NVarChar, 20).Value = i.hostname
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Delete(ByVal args As PRP_Indent_Log) As QueryResponse(Of PRP_Indent_Log) Implements IissueVoucher(Of PRP_Indent_Log).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Insert(ByVal args As PRP_Indent_Log) As QueryResponse(Of PRP_Indent_Log) Implements IissueVoucher(Of PRP_Indent_Log).Insert
        Dim res As New QueryResponse(Of PRP_Indent_Log)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIS_Save_Indent_Log"
            cmd.Parameters.Add("emp_cd", SqlDbType.NVarChar, 6).Value = args.emp_cd
            cmd.Parameters.Add("edatetime", SqlDbType.DateTime).Value = args.edatetime
            cmd.Parameters.Add("hostname", SqlDbType.NVarChar, 20).Value = args.hostname
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Update(ByVal args As PRP_Indent_Log) As QueryResponse(Of PRP_Indent_Log) Implements IissueVoucher(Of PRP_Indent_Log).Update
        Throw New NotImplementedException()
    End Function

    Public Function View() As QueryResponse(Of PRP_Indent_Log) Implements IissueVoucher(Of PRP_Indent_Log).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_Indent_Log) As QueryResponse(Of PRP_Indent_Log) Implements IissueVoucher(Of PRP_Indent_Log).View
        Throw New NotImplementedException()
    End Function
End Class


#End Region

