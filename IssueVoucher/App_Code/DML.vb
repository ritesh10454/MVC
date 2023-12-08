#Region "Properties"
Public Class PRP_Lists

    Private var_CostCentre As List(Of PRP_CostCentre)
    Public Property CostCentre() As List(Of PRP_CostCentre)
        Get
            Return var_CostCentre
        End Get
        Set(ByVal value As List(Of PRP_CostCentre))
            var_CostCentre = value
        End Set
    End Property

    Private var_ConsumptionCentre As List(Of PRP_ConsumptionCentre)
    Public Property ConsumptionCentre() As List(Of PRP_ConsumptionCentre)
        Get
            Return var_ConsumptionCentre
        End Get
        Set(ByVal value As List(Of PRP_ConsumptionCentre))
            var_ConsumptionCentre = value
        End Set
    End Property

    Private var_UserRole As PRP_hry
    Public Property UserRole() As PRP_hry
        Get
            Return var_UserRole
        End Get
        Set(ByVal value As PRP_hry)
            var_UserRole = value
        End Set
    End Property

    Private var_ItemList As List(Of PRP_Pitmaster)
    Public Property ItemList() As List(Of PRP_Pitmaster)
        Get
            Return var_ItemList
        End Get
        Set(ByVal value As List(Of PRP_Pitmaster))
            var_ItemList = value
        End Set
    End Property
End Class


Public Class PRP_Pmivdtl_stock


    Private var_prp_CostCentre_List As List(Of PRP_CostCentre)
    Public Property PRP_CostCentre_List() As List(Of PRP_CostCentre)
        Get
            Return var_prp_CostCentre_List
        End Get
        Set(ByVal value As List(Of PRP_CostCentre))
            var_prp_CostCentre_List = value
        End Set
    End Property

    Private var_PRP_ConsumptionCentre_List As List(Of PRP_ConsumptionCentre)
    Public Property PRP_ConsumptionCentre_List() As List(Of PRP_ConsumptionCentre)
        Get
            Return var_PRP_ConsumptionCentre_List
        End Get
        Set(ByVal value As List(Of PRP_ConsumptionCentre))
            var_PRP_ConsumptionCentre_List = value
        End Set
    End Property

    Private var_PRP_Pmivdtl_List As List(Of PRP_Pmivdtl)
    Public Property Pmivdtl_List() As List(Of PRP_Pmivdtl)
        Get
            Return var_PRP_Pmivdtl_List
        End Get
        Set(ByVal value As List(Of PRP_Pmivdtl))
            var_PRP_Pmivdtl_List = value
        End Set
    End Property

    Private var_stk As Decimal
    Public Property stk() As Decimal
        Get
            Return var_stk
        End Get
        Set(ByVal value As Decimal)
            var_stk = value
        End Set
    End Property


    Private var_itm_code As String
    Public Property itm_code() As String
        Get
            Return var_itm_code
        End Get
        Set(ByVal value As String)
            var_itm_code = value
        End Set
    End Property
End Class
Public Class PRP_UsrLogDtl
    Private var_emp_cd As String
    Private var_login_dt As DateTime
    Private var_rpt_name As String
    Private var_para_1 As String
    Private var_para_2 As String
    Private var_rpt_print As Char
    Private var_rpt_export As Char
    Private var_PACK_NAME As String
    Public Property emp_cd As String
        Get
            Return var_emp_cd
        End Get
        Set(ByVal value As String)
            var_emp_cd = value
        End Set
    End Property

    Public Property login_dt As Date
        Get
            Return var_login_dt
        End Get
        Set(ByVal value As Date)
            var_login_dt = value
        End Set
    End Property

    Public Property PACK_NAME As String
        Get
            Return var_PACK_NAME
        End Get
        Set(ByVal value As String)
            var_PACK_NAME = value
        End Set
    End Property

    Public Property para_1 As String
        Get
            Return var_para_1
        End Get
        Set(ByVal value As String)
            var_para_1 = value
        End Set
    End Property

    Public Property para_2 As String
        Get
            Return var_para_2
        End Get
        Set(ByVal value As String)
            var_para_2 = value
        End Set
    End Property

    Public Property rpt_export As Char
        Get
            Return var_rpt_export
        End Get
        Set(ByVal value As Char)
            var_rpt_export = value
        End Set
    End Property

    Public Property rpt_name As String
        Get
            Return var_rpt_name
        End Get
        Set(ByVal value As String)
            var_rpt_name = value
        End Set
    End Property

    Public Property rpt_print As Char
        Get
            Return var_rpt_print
        End Get
        Set(ByVal value As Char)
            var_rpt_print = value
        End Set
    End Property
End Class
Public Class PRP_PmivInbox
    Private var_Miv_No As Int64
    Private var_Miv_dt As DateTime
    Private var_Emp_Cd As String
    Private var_Auth_Cd1 As String
    Private var_Auth_dt1 As DateTime
    Private var_Auth_Cd2 As String
    Private var_Auth_dt2 As DateTime
    Private var_Sta As Int32
    Private var_Tra As Char
    Private var_Id As Int64

    Private var_emp_nm As String
    Private var_dept_nm As String
    Private var_Apr_sta As String
    Private var_Aut_sta As String
    Private var_status As Char
    Private var_inv_typ As String
    Private var_par As Int32

    Private var_apr_status As String
    Private var_aut_status As String

    Private var_gemp_cd As String
    Private var_gemp_nm As String
    Private var_dept_Cd As Int32
    Private var_remark As String
    Private var_SplW As String



    Private var_sno As String
    Public Property sno() As String
        Get
            Return var_sno
        End Get
        Set(ByVal value As String)
            var_sno = value
        End Set
    End Property



    Public Property Splw As String
        Get
            Return var_SplW
        End Get
        Set(ByVal value As String)
            var_SplW = value
        End Set
    End Property


    Public Property remark As String
        Get
            Return var_remark
        End Get
        Set(ByVal value As String)
            var_remark = value
        End Set
    End Property
    Public Property dept_cd As Int32
        Get
            Return var_dept_Cd
        End Get
        Set(ByVal value As Int32)
            var_dept_Cd = value
        End Set
    End Property

    Public Property gemp_nm As String
        Get
            Return var_gemp_nm
        End Get
        Set(ByVal value As String)
            var_gemp_nm = value
        End Set
    End Property
    Public Property gemp_cd As String
        Get
            Return var_gemp_cd
        End Get
        Set(ByVal value As String)
            var_gemp_cd = value
        End Set
    End Property
    Public Property aut_status As String
        Get
            Return var_aut_status
        End Get
        Set(ByVal value As String)
            var_aut_status = value
        End Set
    End Property
    Public Property apr_status As String
        Get
            Return var_apr_status
        End Get
        Set(ByVal value As String)
            var_apr_status = value
        End Set
    End Property
    Public Property par As Int32
        Get
            Return var_par
        End Get
        Set(ByVal value As Int32)
            var_par = value
        End Set
    End Property
    Public Property status As Char
        Get
            Return var_status
        End Get
        Set(ByVal value As Char)
            var_status = value
        End Set
    End Property
    Public Property inv_typ As String
        Get
            Return var_inv_typ
        End Get
        Set(ByVal value As String)
            var_inv_typ = value
        End Set
    End Property
    Public Property id As Int64
        Get
            Return var_Id
        End Get
        Set(ByVal value As Int64)
            var_Id = value
        End Set
    End Property
    Public Property aut_sta As String
        Get
            Return var_Aut_sta
        End Get
        Set(ByVal value As String)
            var_Aut_sta = value
        End Set
    End Property
    Public Property apr_sta As String
        Get
            Return var_Apr_sta
        End Get
        Set(ByVal value As String)
            var_Apr_sta = value
        End Set
    End Property
    Public Property dept_nm As String
        Get
            Return var_dept_nm
        End Get
        Set(ByVal value As String)
            var_dept_nm = value
        End Set
    End Property
    Public Property emp_nm As String
        Get
            Return var_emp_nm
        End Get
        Set(ByVal value As String)
            var_emp_nm = value
        End Set
    End Property

    Public Property Auth_Cd1 As String
        Get
            Return var_Auth_Cd1
        End Get
        Set(ByVal value As String)
            var_Auth_Cd1 = value
        End Set
    End Property

    Public Property Auth_Cd2 As String
        Get
            Return var_Auth_Cd2
        End Get
        Set(ByVal value As String)
            var_Auth_Cd2 = value
        End Set
    End Property

    Public Property Auth_dt1 As Date
        Get
            Return var_Auth_dt1
        End Get
        Set(ByVal value As Date)
            var_Auth_dt1 = value
        End Set
    End Property

    Public Property Auth_dt2 As Date
        Get
            Return var_Auth_dt2
        End Get
        Set(ByVal value As Date)
            var_Auth_dt2 = value
        End Set
    End Property

    Public Property Emp_Cd As String
        Get
            Return var_Emp_Cd
        End Get
        Set(ByVal value As String)
            var_Emp_Cd = value
        End Set
    End Property

    Public Property Miv_dt As Date
        Get
            Return var_Miv_dt
        End Get
        Set(ByVal value As Date)
            var_Miv_dt = value
        End Set
    End Property

    Public Property Miv_No As Long
        Get
            Return var_Miv_No
        End Get
        Set(ByVal value As Long)
            var_Miv_No = value
        End Set
    End Property

    Public Property Sta As Integer
        Get
            Return var_Sta
        End Get
        Set(ByVal value As Integer)
            var_Sta = value
        End Set
    End Property

    Public Property Tra As Char
        Get
            Return var_Tra
        End Get
        Set(ByVal value As Char)
            var_Tra = value
        End Set
    End Property
End Class
Public Class PRP_pmivtype
    Private var_Ret_No As Int32
    Private var_RetTyp As String
    Private var_Reason As String
    Private var_miv_no As Int64
    Private var_miv_yr As Int32
    Private var_itm_sno As Int32
    Private var_remark As String
    Public Property remark As String
        Get
            Return var_remark
        End Get
        Set(ByVal value As String)
            var_remark = value
        End Set
    End Property

    Public Property itm_sno As Integer
        Get
            Return var_itm_sno
        End Get
        Set(ByVal value As Integer)
            var_itm_sno = value
        End Set
    End Property

    Public Property miv_no As Long
        Get
            Return var_miv_no
        End Get
        Set(ByVal value As Long)
            var_miv_no = value
        End Set
    End Property

    Public Property miv_yr As Integer
        Get
            Return var_miv_yr
        End Get
        Set(ByVal value As Integer)
            var_miv_yr = value
        End Set
    End Property

    Public Property Reason As String
        Get
            Return var_Reason
        End Get
        Set(ByVal value As String)
            var_Reason = value
        End Set
    End Property

    Public Property Ret_No As Integer
        Get
            Return var_Ret_No
        End Get
        Set(ByVal value As Integer)
            var_Ret_No = value
        End Set
    End Property

    Public Property RetTyp As String
        Get
            Return var_RetTyp
        End Get
        Set(ByVal value As String)
            var_RetTyp = value
        End Set
    End Property
End Class

Public Class PRP_Pmivhdr
    Private var_comp_cd As Int32
    Private var_locn_cd As Int32
    Private var_miv_no As Int64

    Private var_miv_yr As Int32
    Private var_inv_typ As Char
    Private var_dept_cd As Int32
    Private var_cc_cd As Int32
    Private var_used_for As String
    Private var_status As Char
    Private var_luser_id As String
    Private var_lupd_dt As String
    Private var_auth_id As String
    Private var_auth_dt As String
    Private var_unit_cd As Int32
    Private var_cur_miv_no As Int32
    Private var_cur_Ret_no As Int32

    Private var_miv_dt As String
    Private var_miv_dt1 As String

    Private var_inv_TypG As String
    Private var_StatusG As String
    Private var_emp_cdG As String
    Private var_emp_nmG As String
    Private var_dept_cdG As Int32
    Private var_dept_nmG As String
    Private var_Tot_ValG As Double
    Private var_Cons_desc As String
    Private var_CC_Desc As String

    Private var_itm_cd As String
    Private var_itm_desc As String
    Private var_iss_qty As Double
    Private var_iss_rt As Double
    Private var_uom As String
    Private var_Ret_no As Int32
    Public Property Ret_no As Int32
        Get
            Return var_Ret_no
        End Get
        Set(ByVal value As Int32)
            var_Ret_no = value
        End Set
    End Property


    Public Property uom As String
        Get
            Return var_uom
        End Get
        Set(ByVal value As String)
            var_uom = value
        End Set
    End Property
    Public Property iss_rt As Double
        Get
            Return var_iss_rt
        End Get
        Set(ByVal value As Double)
            var_iss_rt = value
        End Set
    End Property

    Public Property iss_qty As Double
        Get
            Return var_iss_qty
        End Get
        Set(ByVal value As Double)
            var_iss_qty = value
        End Set
    End Property

    Public Property itm_desc As String
        Get
            Return var_itm_desc
        End Get
        Set(ByVal value As String)
            var_itm_desc = value
        End Set
    End Property

    Public Property itm_cd As String
        Get
            Return var_itm_cd
        End Get
        Set(ByVal value As String)
            var_itm_cd = value
        End Set
    End Property

    Public Property cons_desc As String
        Get
            Return var_Cons_desc
        End Get
        Set(ByVal value As String)
            var_Cons_desc = value
        End Set
    End Property
    Public Property cc_desc As String
        Get
            Return var_CC_Desc
        End Get
        Set(ByVal value As String)
            var_CC_Desc = value
        End Set
    End Property
    Public Property Tot_valG As Double
        Get
            Return var_Tot_ValG
        End Get
        Set(ByVal value As Double)
            var_Tot_ValG = value
        End Set
    End Property
    Public Property dept_cdG As Int32
        Get
            Return var_dept_cdG
        End Get
        Set(ByVal value As Int32)
            var_dept_cdG = value
        End Set
    End Property
    Public Property dept_nmG As String
        Get
            Return var_dept_nmG
        End Get
        Set(ByVal value As String)
            var_dept_nmG = value
        End Set
    End Property
    Public Property emp_nmG As String
        Get
            Return var_emp_nmG
        End Get
        Set(ByVal value As String)
            var_emp_nmG = value
        End Set
    End Property
    Public Property statusG As String
        Get
            Return var_StatusG
        End Get
        Set(ByVal value As String)
            var_StatusG = value
        End Set
    End Property
    Public Property inv_typG As String
        Get
            Return var_inv_TypG
        End Get
        Set(ByVal value As String)
            var_inv_TypG = value
        End Set
    End Property
    Public Property emp_cdG As String
        Get
            Return var_emp_cdG
        End Get
        Set(ByVal value As String)
            var_emp_cdG = value
        End Set
    End Property
    Public Property miv_dt As String
        Get
            Return var_miv_dt
        End Get
        Set(ByVal value As String)
            var_miv_dt = value
        End Set
    End Property

    Public Property cur_miv_no As Integer
        Get
            Return var_cur_miv_no
        End Get
        Set(ByVal value As Integer)
            var_cur_miv_no = value
        End Set
    End Property
    Public Property cur_Ret_no As Integer
        Get
            Return var_cur_Ret_no
        End Get
        Set(ByVal value As Integer)
            var_cur_Ret_no = value
        End Set
    End Property
    Public Property auth_dt As String
        Get
            Return var_auth_dt
        End Get
        Set(ByVal value As String)
            var_auth_dt = value
        End Set
    End Property

    Public Property auth_id As String
        Get
            Return var_auth_id
        End Get
        Set(ByVal value As String)
            var_auth_id = value
        End Set
    End Property

    Public Property cc_cd As Integer
        Get
            Return var_cc_cd
        End Get
        Set(ByVal value As Integer)
            var_cc_cd = value
        End Set
    End Property

    Public Property comp_cd As Integer
        Get
            Return var_comp_cd
        End Get
        Set(ByVal value As Integer)
            var_comp_cd = value
        End Set
    End Property

    Public Property dept_cd As Integer
        Get
            Return var_dept_cd
        End Get
        Set(ByVal value As Integer)
            var_dept_cd = value
        End Set
    End Property

    Public Property inv_typ As Char
        Get
            Return var_inv_typ
        End Get
        Set(ByVal value As Char)
            var_inv_typ = value
        End Set
    End Property

    Public Property locn_cd As Integer
        Get
            Return var_locn_cd
        End Get
        Set(ByVal value As Integer)
            var_locn_cd = value
        End Set
    End Property

    Public Property lupd_dt As String
        Get
            Return var_lupd_dt
        End Get
        Set(ByVal value As String)
            var_lupd_dt = value
        End Set
    End Property

    Public Property luser_id As String
        Get
            Return var_luser_id
        End Get
        Set(ByVal value As String)
            var_luser_id = value
        End Set
    End Property

    Public Property miv_dt1 As String
        Get
            Return var_miv_dt1
        End Get
        Set(ByVal value As String)
            var_miv_dt1 = value
        End Set
    End Property

    Public Property miv_no As Long
        Get
            Return var_miv_no
        End Get
        Set(ByVal value As Long)
            var_miv_no = value
        End Set
    End Property

    Public Property miv_yr As Integer
        Get
            Return var_miv_yr
        End Get
        Set(ByVal value As Integer)
            var_miv_yr = value
        End Set
    End Property

    Public Property status As Char
        Get
            Return var_status
        End Get
        Set(ByVal value As Char)
            var_status = value
        End Set
    End Property

    Public Property unit_cd As Integer
        Get
            Return var_unit_cd
        End Get
        Set(ByVal value As Integer)
            var_unit_cd = value
        End Set
    End Property

    Public Property used_for As String
        Get
            Return var_used_for
        End Get
        Set(ByVal value As String)
            var_used_for = value
        End Set
    End Property


    Private var_mailStatus As Int64
    Public Property mailStatus() As Int64
        Get
            Return var_mailStatus
        End Get
        Set(ByVal value As Int64)
            var_mailStatus = value
        End Set
    End Property



    Private var_PRP_pmivdtl_List As List(Of PRP_Pmivdtl)
    Public Property pmivdtl_List() As List(Of PRP_Pmivdtl)
        Get
            Return var_PRP_pmivdtl_List
        End Get
        Set(ByVal value As List(Of PRP_Pmivdtl))
            var_PRP_pmivdtl_List = value
        End Set
    End Property

    Private var_btnsaveText As String
    Public Property btnsaveText() As String
        Get
            Return var_btnsaveText
        End Get
        Set(ByVal value As String)
            var_btnsaveText = value
        End Set
    End Property

    Private var_Auth_Cd2 As String
    Public Property Auth_Cd2() As String
        Get
            Return var_Auth_Cd2
        End Get
        Set(ByVal value As String)
            var_Auth_Cd2 = value
        End Set
    End Property

    Private var_Remarks As String
    Public Property Remarks() As String
        Get
            Return var_Remarks
        End Get
        Set(ByVal value As String)
            var_Remarks = value
        End Set
    End Property

    Private var_negChec As Int64
    Public Property negChec() As Int64
        Get
            Return var_negChec
        End Get
        Set(ByVal value As Int64)
            var_negChec = value
        End Set
    End Property



End Class
Public Class PRP_Pmivdtl
    Private var_comp_cd As Int32
    Private var_locn_cd As Int32
    Private var_miv_no As Int64
    Private var_miv_yr As Int32
    Private var_itm_sno As Int32
    Private var_itm_cd As String
    Private var_str_cd As String
    Private var_req_qty As Decimal
    Private var_iss_qty As Decimal
    Private var_iss_rt As Decimal
    Private var_iss_val As Decimal
    Private var_rtn_qty As Decimal
    Private var_cc_cd As Int64
    Private var_cons_cd As Int32
    Private var_iss_yard As String
    Private var_pre_stk_qty As Decimal
    Private var_luser_id As String
    Private var_lupd_dt As String
    Private var_auth_id As String
    Private var_auth_dt As String
    Private var_SUB_STR_CD As String
    Private var_unit_cd As Int32
    Private var_sbu_cd As Int64
    Private var_sale_no As Int64
    Private var_sale_yr As Int32
    Private var_bom As String
    Private var_miv_dt As String
    Private var_miv_dt1 As String
    Private var_inv_typ As Char
    Private var_status As Char
    Private var_itm_desc As String
    Private var_uom As String

    Private var_Ret_no As Int32
    Private var_RetTyp As String
    Private var_Reason As String
    Private var_Remark As String

    Private var_min_no As Int64
    Private var_min_dt As String
    Private var_min_dt1 As String
    Private var_min_qty As Decimal
    Private var_rem_qty As Decimal
    Private var_ordNo As Int64
    Private var_par As Int64
    Private var_sno As Int64

    Private var_cons_nm As String
    Public Property cons_nm() As String
        Get
            Return var_cons_nm
        End Get
        Set(ByVal value As String)
            var_cons_nm = value
        End Set
    End Property

    Private var_cc_nm As String
    Public Property cc_nm() As String
        Get
            Return var_cc_nm
        End Get
        Set(ByVal value As String)
            var_cc_nm = value
        End Set
    End Property



    Public Property sno() As Int64
        Get
            Return var_sno
        End Get
        Set(ByVal value As Int64)
            var_sno = value
        End Set
    End Property
    Public Property par() As Int64
        Get
            Return var_par
        End Get
        Set(ByVal value As Int64)
            var_par = value
        End Set
    End Property
    Public Property OrdNo As Int64
        Get
            Return var_ordNo
        End Get
        Set(ByVal value As Int64)
            var_ordNo = value
        End Set
    End Property
    Public Property rem_qty As Decimal
        Get
            Return var_rem_qty
        End Get
        Set(ByVal value As Decimal)
            var_rem_qty = value
        End Set
    End Property
    Public Property min_qty As Decimal
        Get
            Return var_min_qty
        End Get
        Set(ByVal value As Decimal)
            var_min_qty = value
        End Set
    End Property
    Public Property min_no As Int64
        Get
            Return var_min_no
        End Get
        Set(ByVal value As Int64)
            var_min_no = value
        End Set
    End Property
    Public Property min_dt1 As String
        Get
            Return var_min_dt1
        End Get
        Set(ByVal value As String)
            var_min_dt1 = value
        End Set
    End Property
    Public Property min_dt As String
        Get
            Return var_min_dt
        End Get
        Set(ByVal value As String)
            var_min_dt = value
        End Set
    End Property
    Public Property Remark As String
        Get
            Return var_Remark
        End Get
        Set(ByVal value As String)
            var_Remark = value
        End Set
    End Property

    Public Property Ret_no As Int32
        Get
            Return var_Ret_no
        End Get
        Set(ByVal value As Int32)
            var_Ret_no = value
        End Set
    End Property
    Public Property RetTyp As String
        Get
            Return var_RetTyp
        End Get
        Set(ByVal value As String)
            var_RetTyp = value
        End Set
    End Property
    Public Property Reason As String
        Get
            Return var_Reason
        End Get
        Set(ByVal value As String)
            var_Reason = value
        End Set
    End Property
    Public Property uom As String
        Get
            Return var_uom
        End Get
        Set(ByVal value As String)
            var_uom = value
        End Set
    End Property
    Public Property itm_desc As String
        Get
            Return var_itm_desc
        End Get
        Set(ByVal value As String)
            var_itm_desc = value
        End Set
    End Property
    Public Property status As Char
        Get
            Return var_status
        End Get
        Set(ByVal value As Char)
            var_status = value
        End Set
    End Property
    Public Property inv_typ As Char
        Get
            Return var_inv_typ
        End Get
        Set(ByVal value As Char)
            var_inv_typ = value
        End Set
    End Property
    Public Property miv_dt As String
        Get
            Return var_miv_dt
        End Get
        Set(ByVal value As String)
            var_miv_dt = value
        End Set
    End Property

    Public Property auth_dt As String
        Get
            Return var_auth_dt
        End Get
        Set(ByVal value As String)
            var_auth_dt = value
        End Set
    End Property

    Public Property auth_id As String
        Get
            Return var_auth_id
        End Get
        Set(ByVal value As String)
            var_auth_id = value
        End Set
    End Property

    Public Property bom As String
        Get
            Return var_bom
        End Get
        Set(ByVal value As String)
            var_bom = value
        End Set
    End Property

    Public Property cc_cd As Long
        Get
            Return var_cc_cd
        End Get
        Set(ByVal value As Long)
            var_cc_cd = value
        End Set
    End Property

    Public Property comp_cd As Integer
        Get
            Return var_comp_cd
        End Get
        Set(ByVal value As Integer)
            var_comp_cd = value
        End Set
    End Property

    Public Property cons_cd As Integer
        Get
            Return var_cons_cd
        End Get
        Set(ByVal value As Integer)
            var_cons_cd = value
        End Set
    End Property

    Public Property iss_qty As Decimal
        Get
            Return var_iss_qty
        End Get
        Set(ByVal value As Decimal)
            var_iss_qty = value
        End Set
    End Property

    Public Property iss_rt As Decimal
        Get
            Return var_iss_rt
        End Get
        Set(ByVal value As Decimal)
            var_iss_rt = value
        End Set
    End Property

    Public Property iss_val As Decimal
        Get
            Return var_iss_val
        End Get
        Set(ByVal value As Decimal)
            var_iss_val = value
        End Set
    End Property

    Public Property iss_yard As String
        Get
            Return var_iss_yard
        End Get
        Set(ByVal value As String)
            var_iss_yard = value
        End Set
    End Property

    Public Property itm_cd As String
        Get
            Return var_itm_cd
        End Get
        Set(ByVal value As String)
            var_itm_cd = value
        End Set
    End Property

    Public Property itm_sno As Integer
        Get
            Return var_itm_sno
        End Get
        Set(ByVal value As Integer)
            var_itm_sno = value
        End Set
    End Property

    Public Property locn_cd As Integer
        Get
            Return var_locn_cd
        End Get
        Set(ByVal value As Integer)
            var_locn_cd = value
        End Set
    End Property

    Public Property lupd_dt As String
        Get
            Return var_lupd_dt
        End Get
        Set(ByVal value As String)
            var_lupd_dt = value
        End Set
    End Property

    Public Property luser_id As String
        Get
            Return var_luser_id
        End Get
        Set(ByVal value As String)
            var_luser_id = value
        End Set
    End Property

    Public Property miv_dt1 As String
        Get
            Return var_miv_dt1
        End Get
        Set(ByVal value As String)
            var_miv_dt1 = value
        End Set
    End Property

    Public Property miv_no As Long
        Get
            Return var_miv_no
        End Get
        Set(ByVal value As Long)
            var_miv_no = value
        End Set
    End Property

    Public Property miv_yr As Integer
        Get
            Return var_miv_yr
        End Get
        Set(ByVal value As Integer)
            var_miv_yr = value
        End Set
    End Property

    Public Property pre_stk_qty As Decimal
        Get
            Return var_pre_stk_qty
        End Get
        Set(ByVal value As Decimal)
            var_pre_stk_qty = value
        End Set
    End Property

    Public Property req_qty As Decimal
        Get
            Return var_req_qty
        End Get
        Set(ByVal value As Decimal)
            var_req_qty = value
        End Set
    End Property

    Public Property rtn_qty As Decimal
        Get
            Return var_rtn_qty
        End Get
        Set(ByVal value As Decimal)
            var_rtn_qty = value
        End Set
    End Property

    Public Property sale_no As Long
        Get
            Return var_sale_no
        End Get
        Set(ByVal value As Long)
            var_sale_no = value
        End Set
    End Property

    Public Property sale_yr As Integer
        Get
            Return var_sale_yr
        End Get
        Set(ByVal value As Integer)
            var_sale_yr = value
        End Set
    End Property

    Public Property sbu_cd As Long
        Get
            Return var_sbu_cd
        End Get
        Set(ByVal value As Long)
            var_sbu_cd = value
        End Set
    End Property

    Public Property str_cd As String
        Get
            Return var_str_cd
        End Get
        Set(ByVal value As String)
            var_str_cd = value
        End Set
    End Property

    Public Property SUB_STR_CD As String
        Get
            Return var_SUB_STR_CD
        End Get
        Set(ByVal value As String)
            var_SUB_STR_CD = value
        End Set
    End Property

    Public Property unit_cd As Integer
        Get
            Return var_unit_cd
        End Get
        Set(ByVal value As Integer)
            var_unit_cd = value
        End Set
    End Property


    Private var_stk As Decimal
    Public Property stk() As Decimal
        Get
            Return var_stk
        End Get
        Set(ByVal value As Decimal)
            var_stk = value
        End Set
    End Property

    Private var_LoginID As String
    Public Property LoginID() As String
        Get
            Return var_LoginID
        End Get
        Set(ByVal value As String)
            var_LoginID = value
        End Set
    End Property


    Private var_prp_pmivtypeList As List(Of PRP_pmivtype)
    Public Property PRP_pmivtypeList() As List(Of PRP_pmivtype)
        Get
            Return var_prp_pmivtypeList
        End Get
        Set(ByVal value As List(Of PRP_pmivtype))
            var_prp_pmivtypeList = value
        End Set
    End Property


    Private var_MinList As List(Of PRP_MinList)
    Public Property MinList() As List(Of PRP_MinList)
        Get
            Return var_MinList
        End Get
        Set(ByVal value As List(Of PRP_MinList))
            var_MinList = value
        End Set
    End Property

End Class
Public Class PRP_Pmivdtl_report
    Private var_comp_cd As Int32
    Private var_locn_cd As Int32
    Private var_miv_no As Int64
    Private var_miv_yr As Int32
    Private var_itm_sno As Int32
    Private var_itm_cd As String
    Private var_str_cd As String
    Private var_req_qty As Decimal
    Private var_iss_qty As Decimal
    Private var_iss_rt As Decimal
    Private var_iss_val As Decimal
    Private var_rtn_qty As Decimal
    Private var_cc_cd As Int64
    Private var_cons_cd As Int32
    Private var_iss_yard As String
    Private var_pre_stk_qty As Decimal
    Private var_luser_id As String
    Private var_lupd_dt As String
    Private var_auth_id As String
    Private var_auth_dt As String
    Private var_SUB_STR_CD As String
    Private var_unit_cd As Int32
    Private var_sbu_cd As Int64
    Private var_sale_no As Int64
    Private var_sale_yr As Int32
    Private var_bom As String
    Private var_miv_dt As String
    Private var_miv_dt1 As String
    Private var_inv_typ As String
    Private var_status As Char
    Private var_itm_desc As String
    Private var_uom As String

    Private var_Ret_no As Int32
    Private var_RetTyp As String
    Private var_Reason As String
    Private var_Remark As String

    Private var_min_no As Int64
    Private var_min_dt As String
    Private var_min_dt1 As String
    Private var_min_qty As Decimal
    Private var_rem_qty As Decimal
    Private var_ordNo As Int64
    Private var_par As Int64
    Private var_sno As Int64

    Private varstk_uom As String
    Public Property stk_uom() As String
        Get
            Return varstk_uom
        End Get
        Set(ByVal value As String)
            varstk_uom = value
        End Set
    End Property


    Private varcons_desc As String
    Public Property cons_desc() As String
        Get
            Return varcons_desc
        End Get
        Set(ByVal value As String)
            varcons_desc = value
        End Set
    End Property

    Private varcc_desc As String
    Public Property cc_desc() As String
        Get
            Return varcc_desc
        End Get
        Set(ByVal value As String)
            varcc_desc = value
        End Set
    End Property

    Private varEmp_cd As String
    Public Property Emp_cd() As String
        Get
            Return varEmp_cd
        End Get
        Set(ByVal value As String)
            varEmp_cd = value
        End Set
    End Property

    Private varemp_nm As String
    Public Property emp_nm() As String
        Get
            Return varemp_nm
        End Get
        Set(ByVal value As String)
            varemp_nm = value
        End Set
    End Property

    Private vardept_nm As String
    Public Property dept_nm() As String
        Get
            Return vardept_nm
        End Get
        Set(ByVal value As String)
            vardept_nm = value
        End Set
    End Property

    Private varapp_nm As String
    Public Property app_nm() As String
        Get
            Return varapp_nm
        End Get
        Set(ByVal value As String)
            varapp_nm = value
        End Set
    End Property
    Public Property sno() As Int64
        Get
            Return var_sno
        End Get
        Set(ByVal value As Int64)
            var_sno = value
        End Set
    End Property
    Public Property par() As Int64
        Get
            Return var_par
        End Get
        Set(ByVal value As Int64)
            var_par = value
        End Set
    End Property
    Public Property OrdNo As Int64
        Get
            Return var_ordNo
        End Get
        Set(ByVal value As Int64)
            var_ordNo = value
        End Set
    End Property
    Public Property rem_qty As Decimal
        Get
            Return var_rem_qty
        End Get
        Set(ByVal value As Decimal)
            var_rem_qty = value
        End Set
    End Property
    Public Property min_qty As Decimal
        Get
            Return var_min_qty
        End Get
        Set(ByVal value As Decimal)
            var_min_qty = value
        End Set
    End Property
    Public Property min_no As Int64
        Get
            Return var_min_no
        End Get
        Set(ByVal value As Int64)
            var_min_no = value
        End Set
    End Property
    Public Property min_dt1 As String
        Get
            Return var_min_dt1
        End Get
        Set(ByVal value As String)
            var_min_dt1 = value
        End Set
    End Property
    Public Property min_dt As String
        Get
            Return var_min_dt
        End Get
        Set(ByVal value As String)
            var_min_dt = value
        End Set
    End Property
    Public Property Remark As String
        Get
            Return var_Remark
        End Get
        Set(ByVal value As String)
            var_Remark = value
        End Set
    End Property

    Public Property Ret_no As Int32
        Get
            Return var_Ret_no
        End Get
        Set(ByVal value As Int32)
            var_Ret_no = value
        End Set
    End Property
    Public Property RetTyp As String
        Get
            Return var_RetTyp
        End Get
        Set(ByVal value As String)
            var_RetTyp = value
        End Set
    End Property
    Public Property Reason As String
        Get
            Return var_Reason
        End Get
        Set(ByVal value As String)
            var_Reason = value
        End Set
    End Property
    Public Property uom As String
        Get
            Return var_uom
        End Get
        Set(ByVal value As String)
            var_uom = value
        End Set
    End Property
    Public Property itm_desc As String
        Get
            Return var_itm_desc
        End Get
        Set(ByVal value As String)
            var_itm_desc = value
        End Set
    End Property
    Public Property status As Char
        Get
            Return var_status
        End Get
        Set(ByVal value As Char)
            var_status = value
        End Set
    End Property
    Public Property inv_typ As String
        Get
            Return var_inv_typ
        End Get
        Set(ByVal value As String)
            var_inv_typ = value
        End Set
    End Property
    Public Property miv_dt As String
        Get
            Return var_miv_dt
        End Get
        Set(ByVal value As String)
            var_miv_dt = value
        End Set
    End Property

    Public Property auth_dt As String
        Get
            Return var_auth_dt
        End Get
        Set(ByVal value As String)
            var_auth_dt = value
        End Set
    End Property

    Public Property auth_id As String
        Get
            Return var_auth_id
        End Get
        Set(ByVal value As String)
            var_auth_id = value
        End Set
    End Property

    Public Property bom As String
        Get
            Return var_bom
        End Get
        Set(ByVal value As String)
            var_bom = value
        End Set
    End Property

    Public Property cc_cd As Long
        Get
            Return var_cc_cd
        End Get
        Set(ByVal value As Long)
            var_cc_cd = value
        End Set
    End Property

    Public Property comp_cd As Integer
        Get
            Return var_comp_cd
        End Get
        Set(ByVal value As Integer)
            var_comp_cd = value
        End Set
    End Property

    Public Property cons_cd As Integer
        Get
            Return var_cons_cd
        End Get
        Set(ByVal value As Integer)
            var_cons_cd = value
        End Set
    End Property

    Public Property iss_qty As Decimal
        Get
            Return var_iss_qty
        End Get
        Set(ByVal value As Decimal)
            var_iss_qty = value
        End Set
    End Property

    Public Property iss_rt As Decimal
        Get
            Return var_iss_rt
        End Get
        Set(ByVal value As Decimal)
            var_iss_rt = value
        End Set
    End Property

    Public Property iss_val As Decimal
        Get
            Return var_iss_val
        End Get
        Set(ByVal value As Decimal)
            var_iss_val = value
        End Set
    End Property

    Public Property iss_yard As String
        Get
            Return var_iss_yard
        End Get
        Set(ByVal value As String)
            var_iss_yard = value
        End Set
    End Property

    Public Property itm_cd As String
        Get
            Return var_itm_cd
        End Get
        Set(ByVal value As String)
            var_itm_cd = value
        End Set
    End Property

    Public Property itm_sno As Integer
        Get
            Return var_itm_sno
        End Get
        Set(ByVal value As Integer)
            var_itm_sno = value
        End Set
    End Property

    Public Property locn_cd As Integer
        Get
            Return var_locn_cd
        End Get
        Set(ByVal value As Integer)
            var_locn_cd = value
        End Set
    End Property

    Public Property lupd_dt As String
        Get
            Return var_lupd_dt
        End Get
        Set(ByVal value As String)
            var_lupd_dt = value
        End Set
    End Property

    Public Property luser_id As String
        Get
            Return var_luser_id
        End Get
        Set(ByVal value As String)
            var_luser_id = value
        End Set
    End Property

    Public Property miv_dt1 As String
        Get
            Return var_miv_dt1
        End Get
        Set(ByVal value As String)
            var_miv_dt1 = value
        End Set
    End Property

    Public Property miv_no As Long
        Get
            Return var_miv_no
        End Get
        Set(ByVal value As Long)
            var_miv_no = value
        End Set
    End Property

    Public Property miv_yr As Integer
        Get
            Return var_miv_yr
        End Get
        Set(ByVal value As Integer)
            var_miv_yr = value
        End Set
    End Property

    Public Property pre_stk_qty As Decimal
        Get
            Return var_pre_stk_qty
        End Get
        Set(ByVal value As Decimal)
            var_pre_stk_qty = value
        End Set
    End Property

    Public Property req_qty As Decimal
        Get
            Return var_req_qty
        End Get
        Set(ByVal value As Decimal)
            var_req_qty = value
        End Set
    End Property

    Public Property rtn_qty As Decimal
        Get
            Return var_rtn_qty
        End Get
        Set(ByVal value As Decimal)
            var_rtn_qty = value
        End Set
    End Property

    Public Property sale_no As Long
        Get
            Return var_sale_no
        End Get
        Set(ByVal value As Long)
            var_sale_no = value
        End Set
    End Property

    Public Property sale_yr As Integer
        Get
            Return var_sale_yr
        End Get
        Set(ByVal value As Integer)
            var_sale_yr = value
        End Set
    End Property

    Public Property sbu_cd As Long
        Get
            Return var_sbu_cd
        End Get
        Set(ByVal value As Long)
            var_sbu_cd = value
        End Set
    End Property

    Public Property str_cd As String
        Get
            Return var_str_cd
        End Get
        Set(ByVal value As String)
            var_str_cd = value
        End Set
    End Property

    Public Property SUB_STR_CD As String
        Get
            Return var_SUB_STR_CD
        End Get
        Set(ByVal value As String)
            var_SUB_STR_CD = value
        End Set
    End Property

    Public Property unit_cd As Integer
        Get
            Return var_unit_cd
        End Get
        Set(ByVal value As Integer)
            var_unit_cd = value
        End Set
    End Property


    Private var_stk As Decimal
    Public Property stk() As Decimal
        Get
            Return var_stk
        End Get
        Set(ByVal value As Decimal)
            var_stk = value
        End Set
    End Property


    Private var_MinList As List(Of PRP_MinList)
    Public Property MinList() As List(Of PRP_MinList)
        Get
            Return var_MinList
        End Get
        Set(ByVal value As List(Of PRP_MinList))
            var_MinList = value
        End Set
    End Property

End Class
Public Class PRP_MinList
    Private var_min_desc As String
    Public Property min_desc() As String
        Get
            Return var_min_desc
        End Get
        Set(ByVal value As String)
            var_min_desc = value
        End Set
    End Property


    Private var_min_no As String
    Public Property min_no() As String
        Get
            Return var_min_no
        End Get
        Set(ByVal value As String)
            var_min_no = value
        End Set
    End Property

End Class
Public Class PRP_plgdtl
    Private var_comp_cd As Int32
    Private var_locn_cd As Int32
    Private var_inv_typ As Char
    Private var_sr_no As Int64
    Private var_itm_cd As String
    Private var_str_cd As String
    Private var_crt_dt As String
    Private var_mm As Int32
    Private var_yr As Int32
    Private var_doc_typ As String
    Private var_doc_no As Int64
    Private var_doc_dt As String
    Private var_rcpt_qty As Decimal
    Private var_rcpt_val As Decimal
    Private var_iss_qty As Decimal
    Private var_iss_val As Decimal
    Private var_luser_id As String
    Private var_lupd_dt As DateTime
    Private var_auth_id As String
    Private var_auth_dt As DateTime
    Private var_SUB_STR_CD As String
    Public Property auth_dt As DateTime
        Get
            Return var_auth_dt
        End Get
        Set(ByVal value As DateTime)
            var_auth_dt = value
        End Set
    End Property

    Public Property auth_id As String
        Get
            Return var_auth_id
        End Get
        Set(ByVal value As String)
            var_auth_id = value
        End Set
    End Property

    Public Property comp_cd As Integer
        Get
            Return var_comp_cd
        End Get
        Set(ByVal value As Integer)
            var_comp_cd = value
        End Set
    End Property

    Public Property crt_dt As String
        Get
            Return var_crt_dt
        End Get
        Set(ByVal value As String)
            var_crt_dt = value
        End Set
    End Property

    Public Property doc_dt As String
        Get
            Return var_doc_dt
        End Get
        Set(ByVal value As String)
            var_doc_dt = value
        End Set
    End Property

    Public Property doc_no As Long
        Get
            Return var_doc_no
        End Get
        Set(ByVal value As Long)
            var_doc_no = value
        End Set
    End Property

    Public Property doc_typ As String
        Get
            Return var_doc_typ
        End Get
        Set(ByVal value As String)
            var_doc_typ = value
        End Set
    End Property

    Public Property inv_typ As Char
        Get
            Return var_inv_typ
        End Get
        Set(ByVal value As Char)
            var_inv_typ = value
        End Set
    End Property

    Public Property iss_qty As Decimal
        Get
            Return var_iss_qty
        End Get
        Set(ByVal value As Decimal)
            var_iss_qty = value
        End Set
    End Property

    Public Property iss_val As Decimal
        Get
            Return var_iss_val
        End Get
        Set(ByVal value As Decimal)
            var_iss_val = value
        End Set
    End Property

    Public Property itm_cd As String
        Get
            Return var_itm_cd
        End Get
        Set(ByVal value As String)
            var_itm_cd = value
        End Set
    End Property

    Public Property locn_cd As Integer
        Get
            Return var_locn_cd
        End Get
        Set(ByVal value As Integer)
            var_locn_cd = value
        End Set
    End Property

    Public Property lupd_dt As Date
        Get
            Return var_lupd_dt
        End Get
        Set(ByVal value As Date)
            var_lupd_dt = value
        End Set
    End Property

    Public Property luser_id As String
        Get
            Return var_luser_id
        End Get
        Set(ByVal value As String)
            var_luser_id = value
        End Set
    End Property

    Public Property mm As Integer
        Get
            Return var_mm
        End Get
        Set(ByVal value As Integer)
            var_mm = value
        End Set
    End Property

    Public Property rcpt_qty As Decimal
        Get
            Return var_rcpt_qty
        End Get
        Set(ByVal value As Decimal)
            var_rcpt_qty = value
        End Set
    End Property

    Public Property rcpt_val As Decimal
        Get
            Return var_rcpt_val
        End Get
        Set(ByVal value As Decimal)
            var_rcpt_val = value
        End Set
    End Property

    Public Property sr_no As Long
        Get
            Return var_sr_no
        End Get
        Set(ByVal value As Long)
            var_sr_no = value
        End Set
    End Property

    Public Property str_cd As String
        Get
            Return var_str_cd
        End Get
        Set(ByVal value As String)
            var_str_cd = value
        End Set
    End Property

    Public Property SUB_STR_CD As String
        Get
            Return var_SUB_STR_CD
        End Get
        Set(ByVal value As String)
            var_SUB_STR_CD = value
        End Set
    End Property

    Public Property yr As Integer
        Get
            Return var_yr
        End Get
        Set(ByVal value As Integer)
            var_yr = value
        End Set
    End Property
End Class
Public Class PRP_hry
    Private var_emp_cd As String
    Private var_emp_nm As String
    Private var_Apr_id As String
    Private var_Apr_emp_nm As String
    Private var_Aut_id As String
    Private var_aut_emp_nm As String
    Private var_eid As String
    Private var_reid As String
    Private var_tag As String
    Private var_tpi As String
    Private var_tpiid As String
    Private var_dept_nm As String
    Private var_desig_nm As String
    Private var_dept_cd As Int32
    Private var_rpt As String
    Private var_srno As Int32

    Public Property srno As Int32
        Get
            Return var_srno
        End Get
        Set(ByVal value As Int32)
            var_srno = value
        End Set
    End Property
    Public Property rpt As String
        Get
            Return var_rpt
        End Get
        Set(ByVal value As String)
            var_rpt = value
        End Set
    End Property
    Public Property dept_cd As Int32
        Get
            Return var_dept_cd
        End Get
        Set(ByVal value As Int32)
            var_dept_cd = value
        End Set
    End Property
    Public Property desig_nm As String
        Get
            Return var_desig_nm
        End Get
        Set(ByVal value As String)
            var_desig_nm = value
        End Set
    End Property
    Public Property dept_nm As String
        Get
            Return var_dept_nm
        End Get
        Set(ByVal value As String)
            var_dept_nm = value
        End Set
    End Property

    Public Property emp_nm As String
        Get
            Return var_emp_nm
        End Get
        Set(ByVal value As String)
            var_emp_nm = value
        End Set
    End Property
    Public Property aut_id As String
        Get
            Return var_Aut_id
        End Get
        Set(ByVal value As String)
            var_Aut_id = value
        End Set
    End Property
    Public Property aut_emp_nm As String
        Get
            Return var_aut_emp_nm
        End Get
        Set(ByVal value As String)
            var_aut_emp_nm = value
        End Set
    End Property
    Public Property apr_emp_nm As String
        Get
            Return var_Apr_emp_nm
        End Get
        Set(ByVal value As String)
            var_Apr_emp_nm = value
        End Set
    End Property

    Public Property eid As String
        Get
            Return var_eid
        End Get
        Set(ByVal value As String)
            var_eid = value
        End Set
    End Property

    Public Property emp_cd As String
        Get
            Return var_emp_cd
        End Get
        Set(ByVal value As String)
            var_emp_cd = value
        End Set
    End Property

    Public Property reid As String
        Get
            Return var_reid
        End Get
        Set(ByVal value As String)
            var_reid = value
        End Set
    End Property

    Public Property apr_id As String
        Get
            Return var_Apr_id
        End Get
        Set(ByVal value As String)
            var_Apr_id = value
        End Set
    End Property

    Public Property tag As String
        Get
            Return var_tag
        End Get
        Set(ByVal value As String)
            var_tag = value
        End Set
    End Property

    Public Property tpi As String
        Get
            Return var_tpi
        End Get
        Set(ByVal value As String)
            var_tpi = value
        End Set
    End Property

    Public Property tpiid As String
        Get
            Return var_tpiid
        End Get
        Set(ByVal value As String)
            var_tpiid = value
        End Set
    End Property
End Class
Public Class PRP_lv_emp_sec
    Private var_emp_cd As String
    Private var_sec_cd As String
    Public Property emp_cd As String
        Get
            Return var_emp_cd
        End Get
        Set(ByVal value As String)
            var_emp_cd = value
        End Set
    End Property

    Public Property sec_cd As String
        Get
            Return var_sec_cd
        End Get
        Set(ByVal value As String)
            var_sec_cd = value
        End Set
    End Property
End Class
Public Class PRP_Login
    Private var_UserID As String
    Private var_pwd As String
    Private var_indt_entry As Char
    Private var_indt_app As Char
    Private var_auth_ID As String
    Private var_Auth_ID_2 As String
    Private var_Auth_ID_3 As String
    Private var_dept_Cd As Int32
    Private var_Email As String
    Private var_Store_status As Char
    Private var_UserNm As String
    Private var_dept_nm As String
    Private var_desig_nm As String
    Public Property dept_nm As String
        Get
            Return var_dept_nm
        End Get
        Set(ByVal value As String)
            var_dept_nm = value
        End Set
    End Property
    Public Property desig_nm As String
        Get
            Return var_desig_nm
        End Get
        Set(ByVal value As String)
            var_desig_nm = value
        End Set
    End Property
    Public Property auth_ID As String
        Get
            Return var_auth_ID
        End Get
        Set(ByVal value As String)
            var_auth_ID = value
        End Set
    End Property

    Public Property Auth_ID_2 As String
        Get
            Return var_Auth_ID_2
        End Get
        Set(ByVal value As String)
            var_Auth_ID_2 = value
        End Set
    End Property

    Public Property Auth_ID_3 As String
        Get
            Return var_Auth_ID_3
        End Get
        Set(ByVal value As String)
            var_Auth_ID_3 = value
        End Set
    End Property

    Public Property dept_Cd As Integer
        Get
            Return var_dept_Cd
        End Get
        Set(ByVal value As Integer)
            var_dept_Cd = value
        End Set
    End Property

    Public Property Email As String
        Get
            Return var_Email
        End Get
        Set(ByVal value As String)
            var_Email = value
        End Set
    End Property

    Public Property indt_app As Char
        Get
            Return var_indt_app
        End Get
        Set(ByVal value As Char)
            var_indt_app = value
        End Set
    End Property

    Public Property indt_entry As Char
        Get
            Return var_indt_entry
        End Get
        Set(ByVal value As Char)
            var_indt_entry = value
        End Set
    End Property

    Public Property pwd As String
        Get
            Return var_pwd
        End Get
        Set(ByVal value As String)
            var_pwd = value
        End Set
    End Property

    Public Property Store_status As Char
        Get
            Return var_Store_status
        End Get
        Set(ByVal value As Char)
            var_Store_status = value
        End Set
    End Property

    Public Property UserID As String
        Get
            Return var_UserID
        End Get
        Set(ByVal value As String)
            var_UserID = value
        End Set
    End Property

    Public Property UserNm As String
        Get
            Return var_UserNm
        End Get
        Set(ByVal value As String)
            var_UserNm = value
        End Set
    End Property
End Class
Public Class PRP_Indent_Log
    Private var_edatetime As DateTime
    Private var_emp_cd As String
    Private var_ipaddress As String
    Private var_hostname As String

    Public Property hostname As String
        Get
            Return var_hostname
        End Get
        Set(ByVal value As String)
            var_hostname = value
        End Set
    End Property
    Public Property ipaddress As String
        Get
            Return var_ipaddress
        End Get
        Set(ByVal value As String)
            var_ipaddress = value
        End Set
    End Property
    Public Property edatetime As Date
        Get
            Return var_edatetime
        End Get
        Set(ByVal value As Date)
            var_edatetime = value
        End Set
    End Property

    Public Property emp_cd As String
        Get
            Return var_emp_cd
        End Get
        Set(ByVal value As String)
            var_emp_cd = value
        End Set
    End Property
End Class
Public Class PRP_ConsumptionCentre
    Private var_cons_cd As Int32
    Private var_cons_desc As String
    Public Property cons_cd As Integer
        Get
            Return var_cons_cd
        End Get
        Set(ByVal value As Integer)
            var_cons_cd = value
        End Set
    End Property

    Public Property cons_desc As String
        Get
            Return var_cons_desc
        End Get
        Set(ByVal value As String)
            var_cons_desc = value
        End Set
    End Property
End Class
Public Class PRP_Hit_Counter
    Private var_hit_cou As Int64
    Public Property hit_cou As Long
        Get
            Return var_hit_cou
        End Get
        Set(ByVal value As Long)
            var_hit_cou = value
        End Set
    End Property
End Class
Public Class PRP_CostCentre
    Private var_cc_cd As Int64
    Private var_cc_desc As String
    Public Property cc_cd As Long
        Get
            Return var_cc_cd
        End Get
        Set(ByVal value As Long)
            var_cc_cd = value
        End Set
    End Property

    Public Property cc_desc As String
        Get
            Return var_cc_desc
        End Get
        Set(ByVal value As String)
            var_cc_desc = value
        End Set
    End Property
End Class
Public Class PRP_User_Master
    Private var_emp As String
    Private var_u_id As Int64
    Private var_emp_cd As String
    Private var_emp_nm As String
    Private var_loc_cod As Int32
    Private var_pre_exp_yrs As Int32
    Private var_pre_exp_mon As Int32
    Private var_dt_join As DateTime
    Private var_desig_cd As Int32
    Private var_dept_cd As Int32
    Private var_std_qual_cd As Int32
    Private var_sta As Int16
    Private var_rev_num As Int16
    Private var_las_usr_cod As String
    Private var_las_usr_pas As String
    Private var_las_usr_dat As DateTime

    Private var_dept_nm As String
    Private var_desig_nm As String
    Private var_catg_nm As String
    Private var_std_qual_desc As String

    Public Property emp_cd As String
        Get
            Return var_emp_cd
        End Get
        Set(ByVal value As String)
            var_emp_cd = value
        End Set
    End Property

    Public Property dept_nm As String
        Get
            Return var_dept_nm
        End Get
        Set(ByVal value As String)
            var_dept_nm = value
        End Set
    End Property

    Public Property desig_nm As String
        Get
            Return var_desig_nm
        End Get
        Set(ByVal value As String)
            var_desig_nm = value
        End Set
    End Property

    Public Property catg_nm As String
        Get
            Return var_catg_nm
        End Get
        Set(ByVal value As String)
            var_catg_nm = value
        End Set
    End Property

    Public Property std_qual_desc As String
        Get
            Return var_std_qual_desc
        End Get
        Set(ByVal value As String)
            var_std_qual_desc = value
        End Set
    End Property

    Public Property emp_nm As String
        Get
            Return var_emp_nm
        End Get
        Set(ByVal value As String)
            var_emp_nm = value
        End Set
    End Property

    Public Property emp As String
        Get
            Return var_emp
        End Get
        Set(ByVal value As String)
            var_emp = value
        End Set
    End Property

    Public Property las_usr_cod As String
        Get
            Return var_las_usr_cod
        End Get
        Set(ByVal value As String)
            var_las_usr_cod = value
        End Set
    End Property

    Public Property las_usr_dat As Date
        Get
            Return var_las_usr_dat
        End Get
        Set(ByVal value As Date)
            var_las_usr_dat = value
        End Set
    End Property

    Public Property sta As Short
        Get
            Return var_sta
        End Get
        Set(ByVal value As Short)
            var_sta = value
        End Set
    End Property

    Public Property u_id As Long
        Get
            Return var_u_id
        End Get
        Set(ByVal value As Long)
            var_u_id = value
        End Set
    End Property

    Public Property dept_cd As Integer
        Get
            Return var_dept_cd
        End Get
        Set(ByVal value As Integer)
            var_dept_cd = value
        End Set
    End Property

    Public Property desig_cd As Integer
        Get
            Return var_desig_cd
        End Get
        Set(ByVal value As Integer)
            var_desig_cd = value
        End Set
    End Property

    Public Property dt_join As Date
        Get
            Return var_dt_join
        End Get
        Set(ByVal value As Date)
            var_dt_join = value
        End Set
    End Property

    Public Property loc_cod As Integer
        Get
            Return var_loc_cod
        End Get
        Set(ByVal value As Integer)
            var_loc_cod = value
        End Set
    End Property

    Public Property pre_exp_mon As Integer
        Get
            Return var_pre_exp_mon
        End Get
        Set(ByVal value As Integer)
            var_pre_exp_mon = value
        End Set
    End Property

    Public Property pre_exp_yrs As Integer
        Get
            Return var_pre_exp_yrs
        End Get
        Set(ByVal value As Integer)
            var_pre_exp_yrs = value
        End Set
    End Property

    Public Property rev_num As Short
        Get
            Return var_rev_num
        End Get
        Set(ByVal value As Short)
            var_rev_num = value
        End Set
    End Property

    Public Property std_qual_cd As Integer
        Get
            Return var_std_qual_cd
        End Get
        Set(ByVal value As Integer)
            var_std_qual_cd = value
        End Set
    End Property

    Public Property las_usr_pas As String
        Get
            Return var_las_usr_pas
        End Get
        Set(ByVal value As String)
            var_las_usr_pas = value
        End Set
    End Property
End Class
Public Class PRP_Department
    Private var_dept_cd As Integer
    Private var_dept_nm As String
    Public Property dept_cd As Integer
        Get
            Return var_dept_cd
        End Get
        Set(ByVal value As Integer)
            var_dept_cd = value
        End Set
    End Property

    Public Property dept_nm As String
        Get
            Return var_dept_nm
        End Get
        Set(ByVal value As String)
            var_dept_nm = value
        End Set
    End Property
End Class
Public Class PRP_EmployeeDetail
    Private var_emp_nm As String
    Private var_emp_nm1 As String
    Private var_emp_cd As String
    Private var_desig_nm As String
    Private var_dept_nm As String
    Private var_firautcod As String
    Private var_finautcod As String
    Private var_firautnam As String
    Private var_finautnam As String
    Private var_secautcod As String
    Private var_secautnam As String
    Private var_dept_cd As Int32
    Private var_srno As Int32
    Public Property srno As Int32
        Get
            Return var_srno
        End Get
        Set(ByVal value As Int32)
            var_srno = value
        End Set
    End Property
    Public Property secautcod As String
        Get
            Return var_secautcod
        End Get
        Set(ByVal value As String)
            var_secautcod = value
        End Set
    End Property
    Public Property secautnam As String
        Get
            Return var_secautnam
        End Get
        Set(ByVal value As String)
            var_secautnam = value
        End Set
    End Property
    Public Property dept_cd As Int32
        Get
            Return var_dept_cd
        End Get
        Set(ByVal value As Int32)
            var_dept_cd = value
        End Set
    End Property
    Public Property dept_nm As String
        Get
            Return var_dept_nm
        End Get
        Set(ByVal value As String)
            var_dept_nm = value
        End Set
    End Property

    Public Property desig_nm As String
        Get
            Return var_desig_nm
        End Get
        Set(ByVal value As String)
            var_desig_nm = value
        End Set
    End Property

    Public Property emp_cd As String
        Get
            Return var_emp_cd
        End Get
        Set(ByVal value As String)
            var_emp_cd = value
        End Set
    End Property
    Public Property emp_nm1 As String
        Get
            Return var_emp_nm1
        End Get
        Set(ByVal value As String)
            var_emp_nm1 = value
        End Set
    End Property
    Public Property emp_nm As String
        Get
            Return var_emp_nm
        End Get
        Set(ByVal value As String)
            var_emp_nm = value
        End Set
    End Property

    Public Property finautcod As String
        Get
            Return var_finautcod
        End Get
        Set(ByVal value As String)
            var_finautcod = value
        End Set
    End Property

    Public Property finautnam As String
        Get
            Return var_finautnam
        End Get
        Set(ByVal value As String)
            var_finautnam = value
        End Set
    End Property

    Public Property firautcod As String
        Get
            Return var_firautcod
        End Get
        Set(ByVal value As String)
            var_firautcod = value
        End Set
    End Property

    Public Property firautnam As String
        Get
            Return var_firautnam
        End Get
        Set(ByVal value As String)
            var_firautnam = value
        End Set
    End Property
End Class
Public Class QueryResponse(Of T)

    Private var_respnse As Int64

    Public Property response() As Int64

        Get
            Return var_respnse
        End Get
        Set(ByVal value As Int64
)
            var_respnse = value
        End Set
    End Property

    Private var_responseMsg As String
    Public Property responseMsg() As String
        Get
            Return var_responseMsg
        End Get
        Set(ByVal value As String)
            var_responseMsg = value
        End Set
    End Property

    Private var_responseSet As System.Data.DataSet

    Public Property responseSet() As System.Data.DataSet

        Get
            Return var_responseSet
        End Get
        Set(ByVal value As System.Data.DataSet
)
            var_responseSet = value
        End Set
    End Property

    Private var_responseTableList As List(Of System.Data.DataTable)
    Public Property responseTableList() As List(Of System.Data.DataTable)
        Get
            Return var_responseTableList
        End Get
        Set(ByVal value As List(Of System.Data.DataTable))
            var_responseTableList = value
        End Set
    End Property


    Private var_responseObjectList As List(Of T)
    Public Property responseObjectList() As List(Of T)
        Get
            Return var_responseObjectList
        End Get
        Set(ByVal value As List(Of T))
            var_responseObjectList = value
        End Set
    End Property


    Private var_responseObject As T
    Public Property responseObject() As T
        Get
            Return var_responseObject
        End Get
        Set(ByVal value As T)
            var_responseObject = value
        End Set
    End Property


    Private var_CheckID As Int32
    Public Property CheckID() As Int32
        Get
            Return var_CheckID
        End Get
        Set(ByVal value As Int32)
            var_CheckID = value
        End Set
    End Property


    Private var_slipNo As Int32
    Public Property slipNo() As Int32
        Get
            Return var_slipNo
        End Get
        Set(ByVal value As Int32)
            var_slipNo = value
        End Set
    End Property


    Private var_preStock As Double
    Public Property preStock() As Double
        Get
            Return var_preStock
        End Get
        Set(ByVal value As Double)
            var_preStock = value
        End Set
    End Property


    Private var_currentMivNo As Int64
    Public Property currentMivNo() As Int64
        Get
            Return var_currentMivNo
        End Get
        Set(ByVal value As Int64)
            var_currentMivNo = value
        End Set
    End Property


End Class
Public Class PRP_users

    Private var_empcd As String
    Public Property empcd() As String
        Get
            Return var_empcd
        End Get
        Set(ByVal value As String)
            var_empcd = value
        End Set
    End Property


    Private var_empnm As String
    Public Property empnm() As String
        Get
            Return var_empnm
        End Get
        Set(ByVal value As String)
            var_empnm = value
        End Set
    End Property


    Private var_outres As Integer
    Public Property outres() As Integer
        Get
            Return var_outres
        End Get
        Set(ByVal value As Integer)
            var_outres = value
        End Set
    End Property



End Class
#Region "Indent"
Public Class PRP_Pindhdr
    Private var_indt_no As Int64
    Private var_indt_dt As String
    Private var_dept_cd As Int32
    Private var_indt_status As Char
    Private var_indt_idle As Char
    Private var_tot_itms As Int32
    Private var_noof_op_itms As Int32
    Private var_noof_cl_itms As Int32
    Private var_remarks As String
    Private var_prodn_ind As Char
    Private var_amend As Char
    Private var_amend_dt As DateTime
    Private var_doc_ref_no As String
    Private var_doc_ref_dt As DateTime
    Private var_indt_typ As Char
    Private var_loss_val As Decimal
    Private var_tot_indt_val As Decimal
    Private var_print_ind As Char
    Private var_luser_id As String
    Private var_lupd_dt As DateTime
    Private var_auth_id As String
    Private var_auth_dt As DateTime
    Private var_min_status As Char
    Private var_auth_ind As Char
    Private var_mark_to As String
    Private var_Cur_indt_no As Int64

    Private var_spl_desc As String
    Private var_nature_goods As String
    Private var_area_use As String
    Private var_first_Authority As String
    Private var_final_Authority As String
    Private var_indentor As String
    Private var_itm_cd As String
    Private var_itm_desc As String
    Private var_uom As String
    Private var_desc1 As String
    Private var_desc2 As String
    Private var_payback As String

    Private var_schdat As Date

    Private var_itm_sno As Int32
    Private var_qty As Decimal
    Private var_binbal As Decimal
    Private var_rate As Decimal
    Private var_totval As Decimal
    Private var_indt_dt1 As Date

    Private var_srno As Int32
    Private var_rat As Decimal
    Private var_itmcd As String
    Private var_itmdesc As String
    Private var_dsc1 As String
    Private var_dsc2 As String
    Private var_paybacper As String

    Private var_indt_entry As String
    Private var_indt_app As String
    Private var_autche As Int32

    Private var_Indt_date As String
    Private var_sch_date As String
    Private var_VP As Int32
    Private var_role As Char
    Private var_email As String

    Private var_ordno As Int64
    Private var_orddt As String
    Private var_ordqty As Decimal
    Private var_ordrt As Decimal
    Private var_ordval As Decimal
    Private var_SUPPCD As String
    Private var_SUPPNM As String
    Private var_MINNO As Int64
    Private var_REcqty As Decimal
    Private var_acpqty As Decimal
    Private var_ishdt As String
    Private var_mindt As String
    Private var_r_orddt As Date
    Private var_r_mindt As Date
    Private var_priority As String
    Private var_PriSta As Int32

    Private var_emp_cd As String
    Private var_emp_nm As String
    Private var_dept_nm As String
    Private var_indent_status As String

    Private var_Second_Authority As String
    Private var_Ind_type As String
    Private var_Cons_Centre As String
    Private var_authind As Char
    Private var_indval As Decimal
    Private var_TotIndVal As Decimal

    Private var_PendQty As Decimal
    Private var_ItemStatus As String

    Public Property ItemStatus As String
        Get
            Return var_ItemStatus
        End Get
        Set(ByVal value As String)
            var_ItemStatus = value
        End Set
    End Property
    Public Property PendQty As Decimal
        Get
            Return var_PendQty
        End Get
        Set(ByVal value As Decimal)
            var_PendQty = value
        End Set
    End Property
    Public Property TotIndVal As Decimal
        Get
            Return var_TotIndVal
        End Get
        Set(ByVal value As Decimal)
            var_TotIndVal = value
        End Set
    End Property
    Public Property indval As Decimal
        Get
            Return var_indval
        End Get
        Set(ByVal value As Decimal)
            var_indval = value
        End Set
    End Property

    Public Property authind As Char
        Get
            Return var_authind
        End Get
        Set(ByVal value As Char)
            var_authind = value
        End Set
    End Property

    Public Property cons_Centere As String
        Get
            Return var_Cons_Centre
        End Get
        Set(ByVal value As String)
            var_Cons_Centre = value
        End Set
    End Property
    Public Property indt_type As String
        Get
            Return var_Ind_type
        End Get
        Set(ByVal value As String)
            var_Ind_type = value
        End Set
    End Property
    Public Property Second_Authority As String
        Get
            Return var_Second_Authority
        End Get
        Set(ByVal value As String)
            var_Second_Authority = value
        End Set
    End Property

    Public Property indent_status As String
        Get
            Return var_indent_status
        End Get
        Set(ByVal value As String)
            var_indent_status = value
        End Set
    End Property
    Public Property dept_nm As String
        Get
            Return var_dept_nm
        End Get
        Set(ByVal value As String)
            var_dept_nm = value
        End Set
    End Property
    Public Property emp_nm As String
        Get
            Return var_emp_nm
        End Get
        Set(ByVal value As String)
            var_emp_nm = value
        End Set
    End Property
    Public Property emp_cd As String
        Get
            Return var_emp_cd
        End Get
        Set(ByVal value As String)
            var_emp_cd = value
        End Set
    End Property

    Public Property priority As String
        Get
            Return var_priority
        End Get
        Set(ByVal value As String)
            var_priority = value
        End Set
    End Property

    Public Property prista As Int32
        Get
            Return var_PriSta
        End Get
        Set(ByVal value As Int32)
            var_PriSta = value
        End Set
    End Property
    Public Property r_orddt As Date
        Get
            Return var_r_orddt
        End Get
        Set(ByVal value As Date)
            var_r_orddt = value
        End Set
    End Property
    Public Property r_mindt As Date
        Get
            Return var_r_mindt
        End Get
        Set(ByVal value As Date)
            var_r_mindt = value
        End Set
    End Property
    Public Property mindt As String
        Get
            Return var_mindt
        End Get
        Set(ByVal value As String)
            var_mindt = value
        End Set
    End Property
    Public Property ordno As Int64
        Get
            Return var_ordno
        End Get
        Set(ByVal value As Int64)
            var_ordno = value
        End Set
    End Property
    Public Property orddt As String
        Get
            Return var_orddt
        End Get
        Set(ByVal value As String)
            var_orddt = value
        End Set
    End Property
    Public Property ordqty As Decimal
        Get
            Return var_ordqty
        End Get
        Set(ByVal value As Decimal)
            var_ordqty = value
        End Set
    End Property
    Public Property ordrt As Decimal
        Get
            Return var_ordrt
        End Get
        Set(ByVal value As Decimal)
            var_ordrt = value
        End Set
    End Property
    Public Property ordval As Decimal
        Get
            Return var_ordval
        End Get
        Set(ByVal value As Decimal)
            var_ordval = value
        End Set
    End Property

    Public Property suppcd As String
        Get
            Return var_SUPPCD
        End Get
        Set(ByVal value As String)
            var_SUPPCD = value
        End Set
    End Property
    Public Property suppnm As String
        Get
            Return var_SUPPNM
        End Get
        Set(ByVal value As String)
            var_SUPPNM = value
        End Set
    End Property
    Public Property minno As Int64
        Get
            Return var_MINNO
        End Get
        Set(ByVal value As Int64)
            var_MINNO = value
        End Set
    End Property
    Public Property recqty As Decimal
        Get
            Return var_REcqty
        End Get
        Set(ByVal value As Decimal)
            var_REcqty = value
        End Set
    End Property
    Public Property acptqty As Decimal
        Get
            Return var_acpqty
        End Get
        Set(ByVal value As Decimal)
            var_acpqty = value
        End Set
    End Property
    Public Property ishdt As String
        Get
            Return var_ishdt
        End Get
        Set(ByVal value As String)
            var_ishdt = value
        End Set
    End Property
    Public Property email As String
        Get
            Return var_email
        End Get
        Set(ByVal value As String)
            var_email = value
        End Set
    End Property
    Public Property role As Char
        Get
            Return var_role
        End Get
        Set(ByVal value As Char)
            var_role = value
        End Set
    End Property
    Public Property vp As Int32
        Get
            Return var_VP
        End Get
        Set(ByVal value As Int32)
            var_VP = value
        End Set
    End Property

    Public Property sch_date As String
        Get
            Return var_sch_date
        End Get
        Set(ByVal value As String)
            var_sch_date = value
        End Set
    End Property
    Public Property indt_date As String
        Get
            Return var_Indt_date
        End Get
        Set(ByVal value As String)
            var_Indt_date = value
        End Set
    End Property
    Public Property autche As Int32
        Get
            Return var_autche
        End Get
        Set(ByVal value As Int32)
            var_autche = value
        End Set
    End Property

    Public Property indt_entry As String
        Get
            Return var_indt_entry
        End Get
        Set(ByVal value As String)
            var_indt_entry = value
        End Set
    End Property
    Public Property indt_app As String
        Get
            Return var_indt_app
        End Get
        Set(ByVal value As String)
            var_indt_app = value
        End Set
    End Property
    Public Property dsc2 As String
        Get
            Return var_dsc2
        End Get
        Set(ByVal value As String)
            var_dsc2 = value
        End Set
    End Property
    Public Property dsc1 As String
        Get
            Return var_dsc1
        End Get
        Set(ByVal value As String)
            var_dsc1 = value
        End Set
    End Property
    Public Property itmcd As String
        Get
            Return var_itmcd
        End Get
        Set(ByVal value As String)
            var_itmcd = value
        End Set
    End Property
    Public Property itmdesc As String
        Get
            Return var_itmdesc
        End Get
        Set(ByVal value As String)
            var_itmdesc = value
        End Set
    End Property
    Public Property paybacper As String
        Get
            Return var_paybacper
        End Get
        Set(ByVal value As String)
            var_paybacper = value
        End Set
    End Property
    Public Property srno As Int32
        Get
            Return var_srno
        End Get
        Set(ByVal value As Int32)
            var_srno = value
        End Set
    End Property
    Public Property rat As Decimal
        Get
            Return Math.Round(var_rat, 2)
        End Get
        Set(ByVal value As Decimal)
            var_rat = Math.Round(value, 2)
        End Set
    End Property
    Public Property indt_dt1 As Date
        Get
            Return var_indt_dt1
        End Get
        Set(ByVal value As Date)
            var_indt_dt1 = value
        End Set
    End Property
    Public Property totval As Decimal
        Get
            Return Math.Round(var_totval, 2)
        End Get
        Set(ByVal value As Decimal)
            var_totval = value
        End Set
    End Property
    Public Property rate As Decimal
        Get
            Return Math.Round(var_rate, 2)
        End Get
        Set(ByVal value As Decimal)
            var_rate = value
        End Set
    End Property
    Public Property binbal As Decimal
        Get
            Return Math.Round(var_binbal, 2)
        End Get
        Set(ByVal value As Decimal)
            var_binbal = value
        End Set
    End Property
    Public Property qty As Decimal
        Get
            Return Math.Round(var_qty, 2)
        End Get
        Set(ByVal value As Decimal)
            var_qty = value
        End Set
    End Property

    Public Property itm_sno As Int32
        Get
            Return var_itm_sno
        End Get
        Set(ByVal value As Int32)
            var_itm_sno = value
        End Set
    End Property
    Public Property schdat As Date
        Get
            Return var_schdat
        End Get
        Set(ByVal value As Date)
            var_schdat = value
        End Set
    End Property
    Public Property payback As String
        Get
            Return var_payback
        End Get
        Set(ByVal value As String)
            var_payback = value
        End Set
    End Property
    Public Property desc2 As String
        Get
            Return var_desc2
        End Get
        Set(ByVal value As String)
            var_desc2 = value
        End Set
    End Property
    Public Property desc1 As String
        Get
            Return var_desc1
        End Get
        Set(ByVal value As String)
            var_desc1 = value
        End Set
    End Property
    Public Property uom As String
        Get
            Return var_uom
        End Get
        Set(ByVal value As String)
            var_uom = value
        End Set
    End Property
    Public Property itm_desc As String
        Get
            Return var_itm_desc
        End Get
        Set(ByVal value As String)
            var_itm_desc = value
        End Set
    End Property
    Public Property itm_cd As String
        Get
            Return var_itm_cd
        End Get
        Set(ByVal value As String)
            var_itm_cd = value
        End Set
    End Property
    Public Property indentor As String
        Get
            Return var_indentor
        End Get
        Set(ByVal value As String)
            var_indentor = value
        End Set
    End Property
    Public Property final_authority As String
        Get
            Return var_final_Authority
        End Get
        Set(ByVal value As String)
            var_final_Authority = value
        End Set
    End Property
    Public Property first_authority As String
        Get
            Return var_first_Authority
        End Get
        Set(ByVal value As String)
            var_first_Authority = value
        End Set
    End Property
    Public Property area_use As String
        Get
            Return var_area_use
        End Get
        Set(ByVal value As String)
            var_area_use = value
        End Set
    End Property
    Public Property nature_goods As String
        Get
            Return var_nature_goods
        End Get
        Set(ByVal value As String)
            var_nature_goods = value
        End Set
    End Property
    Public Property spl_desc As String
        Get
            Return var_spl_desc
        End Get
        Set(ByVal value As String)
            var_spl_desc = value
        End Set
    End Property
    Public Property cur_indt_no As Int64
        Get
            Return var_Cur_indt_no
        End Get
        Set(ByVal value As Int64)
            var_Cur_indt_no = value
        End Set
    End Property
    Public Property amend As Char
        Get
            Return var_amend
        End Get
        Set(ByVal value As Char)
            var_amend = value
        End Set
    End Property

    Public Property amend_dt As Date
        Get
            Return var_amend_dt
        End Get
        Set(ByVal value As Date)
            var_amend_dt = value
        End Set
    End Property

    Public Property auth_dt As Date
        Get
            Return var_auth_dt
        End Get
        Set(ByVal value As Date)
            var_auth_dt = value
        End Set
    End Property

    Public Property auth_id As String
        Get
            Return var_auth_id
        End Get
        Set(ByVal value As String)
            var_auth_id = value
        End Set
    End Property

    Public Property auth_ind As Char
        Get
            Return var_auth_ind
        End Get
        Set(ByVal value As Char)
            var_auth_ind = value
        End Set
    End Property

    Public Property dept_cd As Integer
        Get
            Return var_dept_cd
        End Get
        Set(ByVal value As Integer)
            var_dept_cd = value
        End Set
    End Property

    Public Property doc_ref_dt As Date
        Get
            Return var_doc_ref_dt
        End Get
        Set(ByVal value As Date)
            var_doc_ref_dt = value
        End Set
    End Property

    Public Property doc_ref_no As String
        Get
            Return var_doc_ref_no
        End Get
        Set(ByVal value As String)
            var_doc_ref_no = value
        End Set
    End Property

    Public Property indt_dt As String
        Get
            Return var_indt_dt
        End Get
        Set(ByVal value As String)
            var_indt_dt = value
        End Set
    End Property

    Public Property indt_idle As Char
        Get
            Return var_indt_idle
        End Get
        Set(ByVal value As Char)
            var_indt_idle = value
        End Set
    End Property

    Public Property indt_no As Long
        Get
            Return var_indt_no
        End Get
        Set(ByVal value As Long)
            var_indt_no = value
        End Set
    End Property

    Public Property indt_status As Char
        Get
            Return var_indt_status
        End Get
        Set(ByVal value As Char)
            var_indt_status = value
        End Set
    End Property

    Public Property indt_typ As Char
        Get
            Return var_indt_typ
        End Get
        Set(ByVal value As Char)
            var_indt_typ = value
        End Set
    End Property

    Public Property loss_val As Decimal
        Get
            Return Math.Round(var_loss_val, 2)
        End Get
        Set(ByVal value As Decimal)
            var_loss_val = value
        End Set
    End Property

    Public Property lupd_dt As Date
        Get
            Return var_lupd_dt
        End Get
        Set(ByVal value As Date)
            var_lupd_dt = value
        End Set
    End Property

    Public Property luser_id As String
        Get
            Return var_luser_id
        End Get
        Set(ByVal value As String)
            var_luser_id = value
        End Set
    End Property

    Public Property mark_to As String
        Get
            Return var_mark_to
        End Get
        Set(ByVal value As String)
            var_mark_to = value
        End Set
    End Property

    Public Property min_status As Char
        Get
            Return var_min_status
        End Get
        Set(ByVal value As Char)
            var_min_status = value
        End Set
    End Property

    Public Property noof_cl_itms As Integer
        Get
            Return var_noof_cl_itms
        End Get
        Set(ByVal value As Integer)
            var_noof_cl_itms = value
        End Set
    End Property

    Public Property noof_op_itms As Integer
        Get
            Return var_noof_op_itms
        End Get
        Set(ByVal value As Integer)
            var_noof_op_itms = value
        End Set
    End Property

    Public Property print_ind As Char
        Get
            Return var_print_ind
        End Get
        Set(ByVal value As Char)
            var_print_ind = value
        End Set
    End Property

    Public Property prodn_ind As Char
        Get
            Return var_prodn_ind
        End Get
        Set(ByVal value As Char)
            var_prodn_ind = value
        End Set
    End Property

    Public Property remarks As String
        Get
            Return var_remarks
        End Get
        Set(ByVal value As String)
            var_remarks = value
        End Set
    End Property

    Public Property tot_indt_val As Decimal
        Get
            Return Math.Round(var_tot_indt_val, 2)
        End Get
        Set(ByVal value As Decimal)
            var_tot_indt_val = value
        End Set
    End Property

    Public Property tot_itms As Integer
        Get
            Return var_tot_itms
        End Get
        Set(ByVal value As Integer)
            var_tot_itms = value
        End Set
    End Property
End Class
Public Class PRP_Pinddtl
    Private var_indt_no As Int64
    Private var_itm_sno As Int32
    Private var_itm_cd As String
    Private var_indt_qty As Double
    Private var_ord_qty As Double
    Private var_iss_qty As Double
    Private var_rtn_qty As Double
    Private var_area_use As String
    Private var_indt_status As Char
    Private var_stk_qty As Double
    Private var_acc_hd As Int64
    Private var_rcvd_qty As Double
    Private var_min_qty As Double
    Private var_max_qty As Double
    Private var_re_ord_qty As Double
    Private var_indt_dt As String
    Private var_cp_min_no As Int64
    Private var_cp_min_dt As DateTime
    Private var_tot_bud_amt As Double
    Private var_indt_bud_amt As Double
    Private var_pend_bud_amt As Double
    Private var_pend_qty As Double
    Private var_bud_cd As Int32
    Private var_itm_rt As Double
    Private var_itm_val As Double
    Private var_indtd_qty As Double
    Private var_ui_qty As Double
    Private var_reord_lvl As Double
    Private var_auth_id As String
    Private var_auth_dt As DateTime
    Private var_lupd_dt As DateTime
    Private var_luser_id As String
    Private var_spl_desc As String
    Private var_min_status As Char
    Private var_en_flg As Char
    Private var_MARK_TO As String
    Private var_SBU_CD As Long
    Private var_sale_no As Int64
    Private var_sale_yr As Int32
    Private var_bom As String
    Private var_nature_goods As String
    Private var_vp As Int32
    Public Property vp As Int32
        Get
            Return var_vp
        End Get
        Set(ByVal value As Int32)
            var_vp = value
        End Set
    End Property
    Public Property acc_hd As Long
        Get
            Return var_acc_hd
        End Get
        Set(ByVal value As Long)
            var_acc_hd = value
        End Set
    End Property

    Public Property area_use As String
        Get
            Return var_area_use
        End Get
        Set(ByVal value As String)
            var_area_use = value
        End Set
    End Property

    Public Property auth_dt As DateTime
        Get
            Return var_auth_dt
        End Get
        Set(ByVal value As DateTime)
            var_auth_dt = value
        End Set
    End Property

    Public Property auth_id As String
        Get
            Return var_auth_id
        End Get
        Set(ByVal value As String)
            var_auth_id = value
        End Set
    End Property

    Public Property bom As String
        Get
            Return var_bom
        End Get
        Set(ByVal value As String)
            var_bom = value
        End Set
    End Property

    Public Property bud_cd As Integer
        Get
            Return var_bud_cd
        End Get
        Set(ByVal value As Integer)
            var_bud_cd = value
        End Set
    End Property

    Public Property cp_min_dt As Date
        Get
            Return var_cp_min_dt
        End Get
        Set(ByVal value As Date)
            var_cp_min_dt = value
        End Set
    End Property

    Public Property cp_min_no As Long
        Get
            Return var_cp_min_no
        End Get
        Set(ByVal value As Long)
            var_cp_min_no = value
        End Set
    End Property

    Public Property en_flg As Char
        Get
            Return var_en_flg
        End Get
        Set(ByVal value As Char)
            var_en_flg = value
        End Set
    End Property

    Public Property indt_bud_amt As Double
        Get
            Return var_indt_bud_amt
        End Get
        Set(ByVal value As Double)
            var_indt_bud_amt = value
        End Set
    End Property

    Public Property indt_dt As String
        Get
            Return var_indt_dt
        End Get
        Set(ByVal value As String)
            var_indt_dt = value
        End Set
    End Property

    Public Property indt_no As Long
        Get
            Return var_indt_no
        End Get
        Set(ByVal value As Long)
            var_indt_no = value
        End Set
    End Property

    Public Property indt_qty As Double
        Get
            Return var_indt_qty
        End Get
        Set(ByVal value As Double)
            var_indt_qty = value
        End Set
    End Property

    Public Property indt_status As Char
        Get
            Return var_indt_status
        End Get
        Set(ByVal value As Char)
            var_indt_status = value
        End Set
    End Property

    Public Property indtd_qty As Double
        Get
            Return var_indt_qty
        End Get
        Set(ByVal value As Double)
            var_indt_qty = value
        End Set
    End Property

    Public Property iss_qty As Double
        Get
            Return var_iss_qty
        End Get
        Set(ByVal value As Double)
            var_iss_qty = value
        End Set
    End Property

    Public Property itm_cd As String
        Get
            Return var_itm_cd
        End Get
        Set(ByVal value As String)
            var_itm_cd = value
        End Set
    End Property

    Public Property itm_rt As Double
        Get
            Return var_itm_rt
        End Get
        Set(ByVal value As Double)
            var_itm_rt = value
        End Set
    End Property

    Public Property itm_sno As Integer
        Get
            Return var_itm_sno
        End Get
        Set(ByVal value As Integer)
            var_itm_sno = value
        End Set
    End Property

    Public Property itm_val As Double
        Get
            Return var_itm_val
        End Get
        Set(ByVal value As Double)
            var_itm_val = value
        End Set
    End Property

    Public Property lupd_dt As Date
        Get
            Return var_lupd_dt
        End Get
        Set(ByVal value As Date)
            var_lupd_dt = value
        End Set
    End Property

    Public Property luser_id As String
        Get
            Return var_luser_id
        End Get
        Set(ByVal value As String)
            var_luser_id = value
        End Set
    End Property

    Public Property MARK_TO As String
        Get
            Return var_MARK_TO
        End Get
        Set(ByVal value As String)
            var_MARK_TO = value
        End Set
    End Property

    Public Property max_qty As Double
        Get
            Return var_max_qty
        End Get
        Set(ByVal value As Double)
            var_max_qty = value
        End Set
    End Property

    Public Property min_qty As Double
        Get
            Return var_min_qty
        End Get
        Set(ByVal value As Double)
            var_min_qty = value
        End Set
    End Property

    Public Property min_status As Char
        Get
            Return var_min_status
        End Get
        Set(ByVal value As Char)
            var_min_status = value
        End Set
    End Property

    Public Property nature_goods As String
        Get
            Return var_nature_goods
        End Get
        Set(ByVal value As String)
            var_nature_goods = value
        End Set
    End Property

    Public Property ord_qty As Double
        Get
            Return var_ord_qty
        End Get
        Set(ByVal value As Double)
            var_ord_qty = value
        End Set
    End Property

    Public Property pend_bud_amt As Double
        Get
            Return var_pend_bud_amt
        End Get
        Set(ByVal value As Double)
            var_pend_bud_amt = value
        End Set
    End Property

    Public Property pend_qty As Double
        Get
            Return var_pend_qty
        End Get
        Set(ByVal value As Double)
            var_pend_qty = value
        End Set
    End Property

    Public Property rcvd_qty As Double
        Get
            Return var_rcvd_qty
        End Get
        Set(ByVal value As Double)
            var_rcvd_qty = value
        End Set
    End Property

    Public Property re_ord_qty As Double
        Get
            Return var_re_ord_qty
        End Get
        Set(ByVal value As Double)
            var_re_ord_qty = value
        End Set
    End Property

    Public Property reord_lvl As Double
        Get
            Return var_reord_lvl
        End Get
        Set(ByVal value As Double)
            var_reord_lvl = value
        End Set
    End Property

    Public Property rtn_qty As Double
        Get
            Return var_rtn_qty
        End Get
        Set(ByVal value As Double)
            var_rtn_qty = value
        End Set
    End Property

    Public Property sale_no As Long
        Get
            Return var_sale_no
        End Get
        Set(ByVal value As Long)
            var_sale_no = value
        End Set
    End Property

    Public Property sale_yr As Integer
        Get
            Return var_sale_yr
        End Get
        Set(ByVal value As Integer)
            var_sale_yr = value
        End Set
    End Property

    Public Property SBU_CD As Long
        Get
            Return var_SBU_CD
        End Get
        Set(ByVal value As Long)
            var_SBU_CD = value
        End Set
    End Property

    Public Property spl_desc As String
        Get
            Return var_spl_desc
        End Get
        Set(ByVal value As String)
            var_spl_desc = value
        End Set
    End Property

    Public Property stk_qty As Double
        Get
            Return var_stk_qty
        End Get
        Set(ByVal value As Double)
            var_stk_qty = value
        End Set
    End Property

    Public Property tot_bud_amt As Double
        Get
            Return var_tot_bud_amt
        End Get
        Set(ByVal value As Double)
            var_tot_bud_amt = value
        End Set
    End Property

    Public Property ui_qty As Double
        Get
            Return var_ui_qty
        End Get
        Set(ByVal value As Double)
            var_ui_qty = value
        End Set
    End Property
End Class
Public Class PRP_pinddtl_asset
    Private var_Indt_no As Int64
    Private var_indt_dt As String
    Private var_itm_CD As String
    Private var_qty As Decimal
    Private var_payback As String
    Private var_asset_cd As String
    Private var_dept_cd As Int64
    Private var_indt_typ As Char
    Private var_rate As Double
    Private var_binbal As Double
    Private var_sch_dt As DateTime
    Private var_UserID As String
    Private var_Userdt As DateTime
    Private var_AuthID_1 As String
    Private var_AuthDt_1 As DateTime
    Private var_AuthID_2 As String
    Private var_AuthDt_2 As DateTime
    Private var_activity As String
    Private var_remm As String
    Private var_VP As Int32
    Private var_priority As Int32

    Public Property priority As Int32
        Get
            Return var_priority
        End Get
        Set(ByVal value As Int32)
            var_priority = value
        End Set
    End Property
    Public Property vp As Int32
        Get
            Return var_VP
        End Get
        Set(ByVal value As Int32)
            var_VP = value
        End Set
    End Property
    Public Property activity As String
        Get
            Return var_activity
        End Get
        Set(ByVal value As String)
            var_activity = value
        End Set
    End Property

    Public Property asset_cd As String
        Get
            Return var_asset_cd
        End Get
        Set(ByVal value As String)
            var_asset_cd = value
        End Set
    End Property

    Public Property AuthDt_1 As Date
        Get
            Return var_AuthDt_1
        End Get
        Set(ByVal value As Date)
            var_AuthDt_1 = value
        End Set
    End Property

    Public Property AuthDt_2 As Date
        Get
            Return var_AuthDt_2
        End Get
        Set(ByVal value As Date)
            var_AuthDt_2 = value
        End Set
    End Property

    Public Property AuthID_1 As String
        Get
            Return var_AuthID_1
        End Get
        Set(ByVal value As String)
            var_AuthID_1 = value
        End Set
    End Property

    Public Property AuthID_2 As String
        Get
            Return var_AuthID_2
        End Get
        Set(ByVal value As String)
            var_AuthID_2 = value
        End Set
    End Property

    Public Property binbal As Double
        Get
            Return var_binbal
        End Get
        Set(ByVal value As Double)
            var_binbal = value
        End Set
    End Property

    Public Property dept_cd As Long
        Get
            Return var_dept_cd
        End Get
        Set(ByVal value As Long)
            var_dept_cd = value
        End Set
    End Property

    Public Property indt_dt As String
        Get
            Return var_indt_dt
        End Get
        Set(ByVal value As String)
            var_indt_dt = value
        End Set
    End Property

    Public Property Indt_no As Long
        Get
            Return var_Indt_no
        End Get
        Set(ByVal value As Long)
            var_Indt_no = value
        End Set
    End Property

    Public Property indt_typ As Char
        Get
            Return var_indt_typ
        End Get
        Set(ByVal value As Char)
            var_indt_typ = value
        End Set
    End Property

    Public Property itm_CD As String
        Get
            Return var_itm_CD
        End Get
        Set(ByVal value As String)
            var_itm_CD = value
        End Set
    End Property

    Public Property payback As String
        Get
            Return var_payback
        End Get
        Set(ByVal value As String)
            var_payback = value
        End Set
    End Property

    Public Property qty As Decimal
        Get
            Return var_qty
        End Get
        Set(ByVal value As Decimal)
            var_qty = value
        End Set
    End Property

    Public Property rate As Double
        Get
            Return var_rate
        End Get
        Set(ByVal value As Double)
            var_rate = value
        End Set
    End Property

    Public Property remm As String
        Get
            Return var_remm
        End Get
        Set(ByVal value As String)
            var_remm = value
        End Set
    End Property

    Public Property sch_dt As Date
        Get
            Return var_sch_dt
        End Get
        Set(ByVal value As Date)
            var_sch_dt = value
        End Set
    End Property

    Public Property Userdt As Date
        Get
            Return var_Userdt
        End Get
        Set(ByVal value As Date)
            var_Userdt = value
        End Set
    End Property

    Public Property UserID As String
        Get
            Return var_UserID
        End Get
        Set(ByVal value As String)
            var_UserID = value
        End Set
    End Property
End Class
Public Class PRP_Pindesc
    Private var_indt_no As Int64
    Private var_indt_dt As String
    Private var_item_cd As String
    Private var_desc_1 As String
    Private var_desc_2 As String
    Private var_desc_3 As String
    Private var_desc_4 As String
    Private var_DESC5 As String
    Private var_DESC6 As String
    Public Property desc_1 As String
        Get
            Return var_desc_1
        End Get
        Set(ByVal value As String)
            var_desc_1 = value
        End Set
    End Property

    Public Property desc_2 As String
        Get
            Return var_desc_2
        End Get
        Set(ByVal value As String)
            var_desc_2 = value
        End Set
    End Property

    Public Property desc_3 As String
        Get
            Return var_desc_3
        End Get
        Set(ByVal value As String)
            var_desc_3 = value
        End Set
    End Property

    Public Property desc_4 As String
        Get
            Return var_desc_4
        End Get
        Set(ByVal value As String)
            var_desc_4 = value
        End Set
    End Property

    Public Property DESC5 As String
        Get
            Return var_DESC5
        End Get
        Set(ByVal value As String)
            var_DESC5 = value
        End Set
    End Property

    Public Property DESC6 As String
        Get
            Return var_DESC6
        End Get
        Set(ByVal value As String)
            var_DESC6 = value
        End Set
    End Property

    Public Property indt_dt As String
        Get
            Return var_indt_dt
        End Get
        Set(ByVal value As String)
            var_indt_dt = value
        End Set
    End Property

    Public Property indt_no As Long
        Get
            Return var_indt_no
        End Get
        Set(ByVal value As Long)
            var_indt_no = value
        End Set
    End Property

    Public Property item_cd As String
        Get
            Return var_item_cd
        End Get
        Set(ByVal value As String)
            var_item_cd = value
        End Set
    End Property
End Class
Public Class PRP_Pindsch
    Private var_indt_no As Int64
    Private var_indt_dt As String
    Private var_itm_cd As String
    Private var_sch_dt As String
    Private var_sch_qty As Decimal
    Private var_auth_dt As DateTime
    Private var_lupd_dt As DateTime
    Private var_luser_id As String
    Private var_auth_id As String
    Public Property auth_dt As Date
        Get
            Return var_auth_dt
        End Get
        Set(ByVal value As Date)
            var_auth_dt = value
        End Set
    End Property

    Public Property auth_id As String
        Get
            Return var_auth_id
        End Get
        Set(ByVal value As String)
            var_auth_id = value
        End Set
    End Property

    Public Property indt_dt As String
        Get
            Return var_indt_dt
        End Get
        Set(ByVal value As String)
            var_indt_dt = value
        End Set
    End Property

    Public Property indt_no As Long
        Get
            Return var_indt_no
        End Get
        Set(ByVal value As Long)
            var_indt_no = value
        End Set
    End Property

    Public Property itm_cd As String
        Get
            Return var_itm_cd
        End Get
        Set(ByVal value As String)
            var_itm_cd = value
        End Set
    End Property

    Public Property lupd_dt As Date
        Get
            Return var_lupd_dt
        End Get
        Set(ByVal value As Date)
            var_lupd_dt = value
        End Set
    End Property

    Public Property luser_id As String
        Get
            Return var_luser_id
        End Get
        Set(ByVal value As String)
            var_luser_id = value
        End Set
    End Property

    Public Property sch_dt As String
        Get
            Return var_sch_dt
        End Get
        Set(ByVal value As String)
            var_sch_dt = value
        End Set
    End Property

    Public Property sch_qty As Decimal
        Get
            Return var_sch_qty
        End Get
        Set(ByVal value As Decimal)
            var_sch_qty = value
        End Set
    End Property
End Class
Public Class PRP_Pitmaster
    Private var_itm_cd As String
    Private var_itm_desc As String
    Private var_uom As String
    Private var_stk_qty As Decimal
    Private var_rate As Decimal

    Private var_last_iss_no As Int32
    Private var_last_iss_dt As DateTime
    Private var_str_cd As String
    Private var_str_typ As String


    Public Property str_typ As String
        Get
            Return var_str_typ
        End Get
        Set(ByVal value As String)
            var_str_typ = value
        End Set
    End Property
    Public Property str_cd As String
        Get
            Return var_str_cd
        End Get
        Set(ByVal value As String)
            var_str_cd = value
        End Set
    End Property
    Public Property last_iss_no As Int32
        Get
            Return var_last_iss_no
        End Get
        Set(ByVal value As Int32)
            var_last_iss_no = value
        End Set
    End Property

    Public Property last_iss_dt As DateTime
        Get
            Return var_last_iss_dt
        End Get
        Set(ByVal value As DateTime)
            var_last_iss_dt = value
        End Set
    End Property

    Public Property rate As Decimal
        Get
            Return var_rate
        End Get
        Set(ByVal value As Decimal)
            var_rate = value
        End Set
    End Property
    Public Property uom As String
        Get
            Return var_uom
        End Get
        Set(ByVal value As String)
            var_uom = value
        End Set
    End Property
    Public Property stk_qty As Decimal
        Get
            Return var_stk_qty
        End Get
        Set(ByVal value As Decimal)
            var_stk_qty = value
        End Set
    End Property
    Public Property itm_cd As String
        Get
            Return var_itm_cd
        End Get
        Set(ByVal value As String)
            var_itm_cd = value
        End Set
    End Property

    Public Property itm_desc As String
        Get
            Return var_itm_desc
        End Get
        Set(ByVal value As String)
            var_itm_desc = value
        End Set
    End Property
End Class
#End Region

Public Class Prp_Breadcrumb
    Dim mp As MasterPage
    'Public obj As UserControl = DirectCast(mp.FindControl("


    Private var_menuHeader As String
    Public Property menuHeader() As String
        Get
            Return var_menuHeader
        End Get
        Set(ByVal value As String)
            var_menuHeader = value
        End Set
    End Property


    Private var_mainMenuLabel As String
    Public Property mainMenuLabel() As String
        Get
            Return var_mainMenuLabel
        End Get
        Set(ByVal value As String)
            var_mainMenuLabel = value
        End Set
    End Property


    Private var_menuLabel As String
    Public Property menuLabel() As String
        Get
            Return var_menuLabel
        End Get
        Set(ByVal value As String)
            var_menuLabel = value
        End Set
    End Property



End Class

#End Region



