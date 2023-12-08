Namespace IssueVoucher
    Public Class MainController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /Main

        Function MIVEntry() As ActionResult
            Return View()
        End Function

        Function Password() As ActionResult
            Return View()
        End Function


        '   //JsonResult
#Region "MIVEntry JsonResult Functions"

        Public Function BindGrid(ByVal miv_no As Int64, ByVal miv_yr As Int32, ByVal loginID As String) As JsonResult
            Dim objs As New CLS_Pmivdtl()
            Dim res As New QueryResponse(Of PRP_Pmivdtl_stock)
            Dim pre_stk As Decimal = 0
            Dim p As New PRP_Pmivdtl()
            Dim x As New PRP_Pmivdtl_stock()
            Try
                p.miv_no = miv_no
                p.miv_yr = miv_yr
                p.par = 48
                p.LoginID = loginID
                res = objs.View1(p)
                If res.response = -1 Then
                    Throw New Exception(res.responseMsg)
                End If
            Catch ex As Exception
                res.response = -1 : res.responseMsg = ex.Message
            End Try
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function getItemList() As JsonResult
            Dim objs As New CLS_Pitmaster()
            Dim res As New QueryResponse(Of PRP_Pitmaster)
            res = objs.Display_Item()
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function getMINList(ByVal p As List(Of PRP_Pmivdtl)) As JsonResult
            Dim objs As New CLS_Pmivdtl()
            For Each item As PRP_Pmivdtl In p
                Dim x As New QueryResponse(Of PRP_MinList)
                x = objs.Display_Fill_Dropdown_MIN(2, item.itm_cd.ToString().Trim())
                item.MinList = x.responseObjectList
            Next
            Return Json(p, JsonRequestBehavior.AllowGet)
        End Function

        Public Function getPending_Slip(ByVal varPar As Int32, ByVal varEmpCod As String) As JsonResult
            Dim objs As New Cls_pmivhdr()
            Dim res As New QueryResponse(Of PRP_Pmivhdr)
            res = objs.Display_Pending_Slip(varPar, varEmpCod)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function get_Current_MIV_No() As JsonResult
            Dim objs As New Cls_pmivhdr()
            Dim res As New QueryResponse(Of PRP_Pmivhdr)
            res = objs.Display_Current_MIV_No()
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function get_Current_Ret_No() As JsonResult
            Dim objs As New CLS_Pmivtype()
            Dim res As New QueryResponse(Of PRP_pmivtype)
            res = objs.Display_Current_Ret_No()
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function SaveMivEntry(ByVal p As PRP_Pmivhdr) As JsonResult
            Dim objs As New Cls_pmivhdr()
            Dim obj As New CLS_Pitmaster()
            Dim resp As New QueryResponse(Of PRP_Pitmaster)
            Dim res As New QueryResponse(Of PRP_Pmivhdr)
            Dim res1 As New QueryResponse(Of PRP_Pmivhdr)
            Dim res2 As New QueryResponse(Of PRP_pmivtype)
            Dim srch As New List(Of PRP_Pmivdtl)
            Dim retno As Int64 = 0
            Try
                If p.btnsaveText.Trim() = "Save" Then
                    res1 = objs.Display_Pending_Slip(46, p.luser_id)   ' getPending_Slip(46, p.luser_id)
                    If res1.response = -1 Then
                        res.response = -1
                        res.responseMsg = res1.responseMsg
                        Throw New Exception(res.responseMsg)
                    End If
                    If res1.slipNo > 0 Then
                        res.response = -1
                        res.responseMsg = "Check your inbox, you have not forwarded some of voucher."
                        Throw New Exception(res.responseMsg)
                    End If

                    res1 = New QueryResponse(Of PRP_Pmivhdr)
                    res1 = objs.Display_Pending_Slip(44, p.luser_id)   '  getPending_Slip(44, p.luser_id)
                    If res1.response = -1 Then
                        res.response = -1
                        res.responseMsg = res1.responseMsg
                        Throw New Exception(res.responseMsg)
                    End If
                    If res1.slipNo > 0 Then
                        res.response = -1
                        res.responseMsg = "You Can't create voucher because some of vouchers are lying pendinbg for authorization."
                        Throw New Exception(res.responseMsg)
                    End If
                End If
                For Each item As PRP_Pmivdtl In p.pmivdtl_List
                    res = objs.Display_PreStock1(item.itm_cd.ToString().Trim()) ' getPreStock1(item.itm_cd.ToString().Trim())
                    If res.response = -1 Then
                        Throw New Exception(res.responseMsg)
                    End If
                    Dim stk As Decimal = 0
                    stk = res.preStock
                    p.negChec = 0
                    If item.iss_qty > stk Then
                        p.negChec = 1
                        res.response = -1
                        res.responseMsg = String.Format("You Can't Authorize Because of Less Qty for Item Code : {0}", item.itm_cd)
                        Exit For
                    End If
                    '-----------Add new code for check the stock-----------
                    Dim iss_tot As Decimal = 0
                    srch.Add(New PRP_Pmivdtl() With {
                        .itm_cd = item.itm_cd,
                        .iss_qty = item.iss_qty
                    })

                    Dim sameitm_stk As Decimal = 0
                    For Each col As PRP_Pmivdtl In srch
                        If col.itm_cd = item.itm_cd Then
                            iss_tot += col.iss_qty
                        End If
                    Next
                    sameitm_stk = stk - iss_tot
                    If sameitm_stk < 0 Then
                        p.negChec = 1
                        res.response = -1
                        res.responseMsg = String.Format("You Can't Authorize Because of Less Qty for Item Code : {0}", item.itm_cd)
                        Exit For
                    End If
                    '---------------------------end-------------------------

                    resp = New QueryResponse(Of PRP_Pitmaster)
                    resp = obj.Display_ItemDetail(item.itm_cd.ToString().Trim())
                    If resp.response = -1 Then
                        Throw New Exception(resp.responseMsg)
                    End If
                    item.str_cd = resp.responseObject.str_cd
                    item.SUB_STR_CD = resp.responseObject.str_typ
                Next
                If res.response = -1 Then
                    Throw New Exception(res.responseMsg)
                End If
                res = objs.SaveMivEntry(p)
                If res.response = -1 Then
                    Throw New Exception(res.responseMsg)
                End If
                res.responseObject = p
            Catch ex As Exception
                res.response = -1 : res.responseMsg = ex.Message
            End Try
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function SaveMivAuthorize(ByVal p As PRP_Pmivhdr) As JsonResult
            Dim objs As New Cls_pmivhdr()
            Dim obj As New CLS_Pitmaster()
            Dim resp As New QueryResponse(Of PRP_Pitmaster)
            Dim res As New QueryResponse(Of PRP_Pmivhdr)
            Dim srch As New List(Of PRP_Pmivdtl)
            Try
                For Each item As PRP_Pmivdtl In p.pmivdtl_List
                    res = objs.Display_PreStock1(item.itm_cd.ToString().Trim()) ' getPreStock1(item.itm_cd.ToString().Trim())
                    If res.response = -1 Then
                        Throw New Exception(res.responseMsg)
                    End If
                    Dim stk As Decimal = 0
                    stk = res.preStock
                    p.negChec = 0
                    If item.iss_qty > stk Then
                        p.negChec = 1
                        res.response = -1
                        res.responseMsg = String.Format("You Can't Authorize Because of Less Qty for Item Code : {0}", item.itm_cd)
                        Exit For
                    End If
                    '-----------Code to prevent the stock become negative if the same item comes again-----------
                    Dim iss_tot As Decimal = 0
                    srch.Add(New PRP_Pmivdtl() With {
                        .itm_cd = item.itm_cd,
                        .iss_qty = item.iss_qty
                    })

                    Dim sameitm_stk As Decimal = 0
                    For Each col As PRP_Pmivdtl In srch
                        If col.itm_cd = item.itm_cd Then
                            iss_tot += col.iss_qty
                        End If
                    Next
                    sameitm_stk = stk - iss_tot
                    If sameitm_stk < 0 Then
                        p.negChec = 1
                        res.response = -1
                        res.responseMsg = String.Format("You Can't Authorize Because of Less Qty for Item Code : {0}", item.itm_cd)
                        Exit For
                    End If
                    '---------------------------end-------------------------

                    resp = New QueryResponse(Of PRP_Pitmaster)
                    resp = obj.Display_ItemDetail(item.itm_cd.ToString().Trim())
                    If resp.response = -1 Then
                        Throw New Exception(resp.responseMsg)
                    End If
                    item.str_cd = resp.responseObject.str_cd
                    item.SUB_STR_CD = resp.responseObject.str_typ
                Next
                If res.response = -1 Then
                    Throw New Exception(res.responseMsg)
                End If
                res = objs.SaveMivAuthorize(p)
                If res.response = -1 Then
                    Throw New Exception(res.responseMsg)
                End If
            Catch ex As Exception
                res.response = -1 : res.responseMsg = ex.Message
            End Try
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function CancelMIV(ByVal p As PRP_Pmivhdr) As JsonResult
            Dim objs As New Cls_pmivhdr()
            Dim res As New QueryResponse(Of PRP_Pmivhdr)

            Try
                res = objs.CancelMailFunction(p.miv_no, p.miv_yr)
                If res.response = -1 Then
                    Throw New Exception(res.responseMsg)
                End If
                res = New QueryResponse(Of PRP_Pmivhdr)
                res = objs.CancelMIV(p)
                If res.response = -1 Then
                    Throw New Exception(res.responseMsg)
                End If
            Catch ex As Exception
                res.response = -1 : res.responseMsg = ex.Message
            End Try
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function CancelMailFunction(ByVal varmivno As Int64, ByVal varmivyr As Int32) As JsonResult
            Dim objs As New Cls_pmivhdr()
            Dim res As New QueryResponse(Of PRP_Pmivhdr)
            res = objs.CancelMailFunction(varmivno, varmivyr)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function MailFunction(ByVal varmivno As Int64, ByVal varmivyr As Int32) As JsonResult
            Dim objs As New Cls_pmivhdr()
            Dim res As New QueryResponse(Of PRP_Pmivhdr)
            res = objs.MailFunction(varmivno, varmivyr)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function Update_Pmivinbox(ByVal p As PRP_PmivInbox) As JsonResult
            Dim objs As New Cls_Pmivinbox()
            Dim res As New QueryResponse(Of PRP_PmivInbox)
            res = objs.Update(p)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function getPreStock1(ByVal varitmcd As String) As JsonResult
            Dim objs As New Cls_pmivhdr()
            Dim res As New QueryResponse(Of PRP_Pmivhdr)
            res = objs.Display_PreStock1(varitmcd)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function getItems(ByVal varitmcd As String) As JsonResult
            Dim objs As New CLS_Pitmaster()
            Dim res As New QueryResponse(Of PRP_Pitmaster)
            res = objs.Display_Items(varitmcd)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function getItemRate(ByVal varitmcd As String) As JsonResult
            Dim objs As New CLS_Pitmaster()
            Dim res As New QueryResponse(Of PRP_Pitmaster)
            res = objs.Display_rate(varitmcd)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function getPreStock(ByVal varitmcd As String) As JsonResult
            Dim objs As New Cls_pmivhdr()
            Dim res As New QueryResponse(Of PRP_Pmivhdr)
            res = objs.Display_PreStock(varitmcd)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function getItemDetail(ByVal varitmcd As String) As JsonResult
            Dim objs As New CLS_Pitmaster()
            Dim res As New QueryResponse(Of PRP_Pitmaster)
            Dim res_hdr As New QueryResponse(Of PRP_Pmivhdr)
            Dim obj_hdr As New Cls_pmivhdr()
            Try
                res = objs.Display_ItemDetail(varitmcd)
                If res.response = -1 Then
                    Throw New Exception(res.responseMsg)
                End If
                res_hdr = obj_hdr.Display_PreStock(varitmcd)
                If res_hdr.response = -1 Then
                    res.response = -1
                    Throw New Exception(res_hdr.responseMsg)

                End If
                res.responseObject.stk_qty = res_hdr.preStock
            Catch ex As Exception
                res.response = -1 : res.responseMsg = ex.Message
            End Try
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function getItemDetail1(ByVal varitmcd As String) As JsonResult
            Dim objs As New CLS_Pitmaster()
            Dim res As New QueryResponse(Of PRP_Pitmaster)
            Dim res_rate As New QueryResponse(Of PRP_Pitmaster)
            Dim res_hdr As New QueryResponse(Of PRP_Pmivhdr)
            Dim obj_hdr As New Cls_pmivhdr()
            res = objs.Display_ItemDetail(varitmcd)

            If res.response = -1 Then
                Throw New Exception(res.responseMsg)
            End If
            res_hdr = obj_hdr.Display_PreStock(varitmcd)
            If res_hdr.response = -1 Then
                res.response = -1
                Throw New Exception(res_hdr.responseMsg)
            End If
            res.responseObject.stk_qty = res_hdr.preStock

            res_rate = objs.Display_rate(varitmcd)
            If res_rate.response = -1 Then
                res.response = -1
                Throw New Exception(res_rate.responseMsg)
            End If
            res.responseObject.rate = res_rate.responseObject.rate
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function getMINDetail(ByVal varpar As Int32, ByVal varItmCod As String) As JsonResult
            Dim res As New QueryResponse(Of PRP_Pmivdtl)
            Dim objs As New CLS_Pmivdtl()
            res = objs.Display_MINDetail(varpar, varItmCod)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function GetmivInboxD(ByVal miv_no As Int64, ByVal miv_yr As Int32) As JsonResult
            Dim objs As New Cls_Pmivinbox()
            Dim res As New QueryResponse(Of PRP_PmivInbox)
            Dim emp_cd As String = System.Web.HttpContext.Current.Session("usrnam").ToString()
            res = objs.Display_PmivInboxD(miv_no, miv_yr)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function getAllList() As ActionResult
            Dim res As New QueryResponse(Of PRP_Lists)
            Dim res_cons As New QueryResponse(Of PRP_ConsumptionCentre)
            Dim res_cost As New QueryResponse(Of PRP_CostCentre)
            Dim res_users As New QueryResponse(Of PRP_hry)
            Dim res_items As New QueryResponse(Of PRP_Pitmaster)
            Dim objs_cons As New cls_ConsumptionCentre()
            Dim objs_cost As New cls_CostCentre()
            Dim objs_users As New Cls_HRY()
            Dim objs_items As New CLS_Pitmaster()
            Try
                res.responseObject = New PRP_Lists()

                res_cons = objs_cons.View()  'getConsumptionCentre()
                If res_cons.response = -1 Then
                    res.response = -1
                    Throw New Exception(res_cons.responseMsg)
                End If
                res.responseObject.ConsumptionCentre = res_cons.responseObjectList

                res_cost = objs_cost.View()   'getCostCentre()
                If res_cost.response = -1 Then
                    res.response = -1
                    Throw New Exception(res_cost.responseMsg)
                End If
                res.responseObject.CostCentre = res_cost.responseObjectList

                Dim emp_cd As String = System.Web.HttpContext.Current.Session("usrnam").ToString()
                res_users = objs_users.Display_User_Role(emp_cd)     ' GetUserRole()
                If res_users.response = -1 Then
                    res.response = -1
                    Throw New Exception(res_users.responseMsg)
                End If
                res.responseObject.UserRole = res_users.responseObject

                res_items = objs_items.Display_Item()    'getItemList()
                If res_items.response = -1 Then
                    res.response = -1
                    Throw New Exception(res_items.responseMsg)
                End If
                res.responseObject.ItemList = res_items.responseObjectList
                res.response = 1 : res.responseMsg = ""
            Catch ex As Exception
                res.response = -1 : res.responseMsg = ex.Message
            End Try

            ' Return Json(res, JsonRequestBehavior.AllowGet)

            'Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
            'serializer.MaxJsonLength = Int32.MaxValue
            'Return serializer.Serialize(res)

            'Dim jsonResult As System.Web.Mvc.JsonResult = Json(res, JsonRequestBehavior.AllowGet)
            'jsonResult.MaxJsonLength = Int32.MaxValue
            'Return jsonResult

            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer() With {.MaxJsonLength = Int32.MaxValue}
            Dim result As New ContentResult() With {.Content = serializer.Serialize(res), .ContentType = "application/json"}
            Return result

        End Function

        Public Function GetReturnNo(ByVal p As PRP_pmivtype) As JsonResult
            Dim objs As New CLS_Pmivtype()
            Dim res As New QueryResponse(Of PRP_pmivtype)
            res = objs.Display_Ret_No(p)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

#End Region

#Region "Password JsonResult Functions"
        Public Function UpdatePassword(ByVal varempcd As String, ByVal varseccd As String) As JsonResult
            Dim objs As New cls_Lv_emp_Sec()
            Dim k As New PRP_lv_emp_sec()
            k.emp_cd = varempcd.ToString().Trim()
            k.sec_cd = varseccd.ToString().Trim()
            Dim res As New QueryResponse(Of PRP_lv_emp_sec)
            res = objs.Update(k)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

        Public Function checkPassword(ByVal varempcd As String, ByVal varoldpwd As String) As JsonResult
            Dim objs As New cls_Lv_emp_Sec()
            Dim res As New QueryResponse(Of PRP_lv_emp_sec)
            res = objs.Check_Password(varempcd, varoldpwd)
            Return Json(res, JsonRequestBehavior.AllowGet)
        End Function

#End Region
    End Class

End Namespace