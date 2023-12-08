@imports System.Web.Optimization 
@Code
    ViewData("Title") = "ReportMIVDetail"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@section styles
<style type="text/css" >
    .LabelAlign
    {
        text-align:right;
    }
     
    .TextAlign
    {
        text-align:left;
    }


    
    table.dataTable thead tr {
        background-color: #007bff;
        color:#fff;
    }   

    table.dataTable tfoot tr 
    {
        background-color: #007bff;
        color:#fff;
    }
    
    th, td 
    {
        white-space: nowrap;
        font-size:12px;
    }
        
    table.dataTable select, table.dataTable input[type="text"]
    {
         font-size:12px;
         font-family: "Calibri";
    }
    
    .buttonF
    {
        font-size:12px;
        font-family: "Calibri";       
    }    
    

    table.dataTable td input[type="text"]
    {
       display: ruby-base-container;          
    }
    .hideAll  
    {
    visibility:hidden;
    }    

    
   .loader 
    {  
        position: fixed;  
        opacity:0.9;
        left: 0px;  
        top: 0px;  
        width: 100%;  
        height: 100%;  
        z-index: 9999;  
        background: rgb(201, 201, 201) url('../AdminLte/dist/img/waiting.gif') no-repeat 50% 50%;
    }  
    
 </style>
End Section

<div class="row">
    <div class ="col-md-12">
        <div class="card card-primary" style="margin-bottom: 5px;">
            <div class="card-header">
                <h3 class="card-title">MIV DETAIL REPORT</h3>
                <input type="hidden" id ="hdfUserName" value="@System.Web.HttpContext.Current.Session("usrnam")" />  
            </div>
            <div class="card-body" style="padding:0;">
                <div class="row">
                    <div class="col-sm-12 col-md-8">
                     <input type="hidden" id  ="hdfempcd" />
                     <input type="hidden" id  ="hdfempnam" />
                     <input type="hidden" id  ="hdfdept" />
                     <input type="hidden" id  ="hdfdesig" />
                    </div>
                    <div class="col-sm-12 col-md-2">
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Date</label>
                                <div class="col-sm-6">
                                    <input type="text" class="form-control-plaintext TextAlign" id="txtDate" readonly/>
                                </div>
                            </div>
                    </div>
                    <div class="col-sm-12 col-md-2">
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Time</label>
                                <div class="col-sm-6">
                                    <input type="text"  class="form-control-plaintext TextAlign" id="txtTime"  readonly/>
                                </div>
                            </div>
                    </div>                
                </div>
            </div> 
        </div>    
        <div class="card card-primary" style="margin-bottom: 5px;">
                <div class="card-header">
                    <h3 class="card-title">Filter Criteria</h3>
                </div>
                <div class="card-body" style="padding:0;">
                    <div class="row">
                        <div class="col-sm-12 col-md-6">
                                <div class="form-group row">
                                    <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">From Date</label>
                                    <div class="col-sm-6">
                                        <input type="text" class="form-control TextAlign datepicker" id="txtFroDat" placeholder="From Date"  readonly  />
                                         <input type="hidden" id ="hdfRetNo" />
                                    </div>
                                </div>
                        </div>
                        <div class="col-sm-12 col-md-6">
                                <div class="form-group row">
                                    <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">To Date</label>
                                    <div class="col-sm-6">
                                        <input type="text"  class="form-control TextAlign datepicker" id="txtToDat" placeholder="To Date" readonly  />
                                    </div>
                                </div>
                        </div>
                        <div class="col-sm-12 col-md-6">
                                <div class="form-group row">
                                    <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Select MIV Type</label>
                                    <div class="col-sm-6">
                                    <select id="drpMIVTyp" class ="form-control select2" tabindex ="-1">
                                        <option value ="L">--ALL--</option> 
                                        <option value ="P">Captial</option> 
                                        <option value ="P">Consumable</option> 
                                    </select>
                                    </div>
                                </div>
                        </div>
                        <div class="col-sm-12 col-md-6">
                                <div class="form-group row">
                                    <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Select MIV Owner</label>
                                    <div class="col-sm-6">
                                        <select id="drpEmp" class ="form-control select2" tabindex ="-1">
                                        </select>
                                    </div>
                                </div>
                        </div>
                        <div class="col-sm-12 col-md-6"  id= "cancel_reason" >
                                <div class="form-group row">
                                    <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Select Department</label>
                                    <div class="col-sm-6">
                                        <select id="drpdep" class ="form-control select2" tabindex ="-1">
                                        </select>
                                    </div>
                                </div>
                        </div>
                    </div>     
                     <div class ="row">
                        <div class ="col-12">
                            <div style ="float:right;">
                                <button type ="button"  class="btn btn-primary" id="btnShow" onclick="btnShow_Click();" >Show</button>
                                <button type ="button" class="btn btn-primary" id="btnExport"  onclick="btnExport_click();">Export</button>
                                <button type ="button" class="btn btn-primary" id="btnExit"  onclick="btnexit_click();">Exit</button>
                            </div>
                        </div>
                     </div> 
                     <div class="row">
                        <div class="col-12">
                            <div class ="table table-bordered table-striped  dt-responsive" id="mivDetailDIV" style="width:100%;"></div> 
                            <div class ="table table-bordered table-striped  dt-responsive" id="DivExport" style="width:100%;display:none;">
                            </div> 
                        </div>
                    </div>                           
                </div> 
                <div class="card-footer">
                </div>            
            </div>
    </div> 
    <!-- Loader -->
<div class="loader"></div> 
</div>

<!--Print Modal -->
<div class="modal fade" id="ShowModalPrint" tabindex="-1" role="dialog" aria-labelledby="ModalTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog  modal-xl" role="document">
        <div class="modal-content">
            <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true" style="display:none">&times;</button>
            <h4 class="modal-title" id="ModalTitle">Material Issue Voucher</h4>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="col-12">
                        <div  id="OutputPrint">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td colspan="4"  style="text-align:center;"><span><img  src="../Images/logo.JPG" style="height:57px;" alt=""/>IOL CHEMICALS AND PHARMACEUTICALES LIMITED</span></td>
                            </tr>
                            <tr>
                                <td colspan="4"  style="text-align:center;text-align:center;">MANSA ROAD, DHAULA, BARNALA (PUNJAB)</td>
                            </tr>
                            <tr>
                                <td colspan="4" style="text-align:center;font-weight:bold;">MATERIAL ISSUE VOUCHER</td> 
                            </tr>
                            <tr>
                                <td>Miv Type</td>
                                <td style="text-decoration: underline;" id="td_mivtype"></td>
                                <td>Miv No.</td>
                                <td style="text-decoration: underline;" id="td_Mivno"></td>
                            </tr>
                            <tr>
                                <td>Generate By</td>
                                <td style="text-decoration: underline;" id="td_generateby"></td>
                                <td>Miv Date</td>
                                <td style="text-decoration: underline;" id="td_mivdt"></td>
                            </tr>
                            <tr>
                                <td>Department</td>
                                <td style="text-decoration: underline;" id="td_dept_nm"></td>
                                <td>Approving Authority</td>
                                <td style="text-decoration: underline;" id="td_appauth"></td>
                            </tr>
                            <tr>
                                <td colspan="4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <div class ="table table-striped  dt-responsive" id="DIV1">
                                    </div>
                                </td>
                            </tr>

                        </table>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" id="btnPrint" class="btn btn-default" onclick="printData();">Print</button>
                <button type="button" id="btnClose" class="btn btn-default" data-dismiss="modal" aria-hidden="true" >Close</button>
            </div>
        </div>
    </div>
</div>


<div class ="row">
    <div class ="col">
        <input type="hidden" id ="hdfUserID" />
        <label id ="lblMessage" style="color:#ff0000; font-weight:bold;"/>
        <label id ="lblMessage2" style="color:#ff0000; font-weight:bold;"/>
    </div>
</div>
<!-- Loader -->
<div class="loader"></div> 
@Scripts.Render("~/script/extraJQueryUI")
@Scripts.Render("~/script/ReportMIVDetail")