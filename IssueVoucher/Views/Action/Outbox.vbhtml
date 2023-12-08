﻿@imports System.Web.Optimization 
@Code
    ViewData("Title") = "Outbox"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@section scripts
  <style type ="text/css">   
     .ButtonRightAlign
    {
        float:right;
    }
     
    .TextAlign
    {
        text-align:left;
    }         
        
    table.dataTable thead tr 
    {
        background-color: #007bff;
        font-size:12px;
        color:#fff;
    }   
    
     table.dataTable 
     {
        margin: 0 !important;
        font-family: "Calibri"; 
        font-size:12px;
    }    
    .gridButton
    {
        font-family: "Calibri"; 
        font-size:12px;
    }   
     

    #loader 
    {  
        position: fixed;  
        left: 0px;  
        top: 0px;  
        opacity:0.9;
        width: 100%;  
        height: 100%;  
        z-index: 9999;  
        background: rgb(201, 201, 201) url('../AdminLte/dist/img/waiting.gif') no-repeat 50% 50%;
    }
    th, td {
        white-space: nowrap;
        font-size:12px;
    }
        
  
    </style>
End Section

<div class="row">
    <div class ="col-md-12">
        <div class="card card-primary" style="margin-bottom: 5px;">
            <div class="card-header">
                <h3 class="card-title">Outbox</h3>
                <input type="hidden" id ="hdfUserName" value="@System.Web.HttpContext.Current.Session("usrnam")" />  
            </div>
            <div class="card-body" style="padding:0;">
                <div class="row" id="batchtype"  style="display:none;" >
                    <div class="col-sm-12 col-md-6">
                        <div class="form-group row">
                            <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Select Bacth Type</label>
                            <div class="col-sm-6">
                                <select id ="drpLabReqTyp" class ="form-control select2" tabindex ="1">
                                    <option value ="0">--Select--</option> 
                                    <option value ="P">Captial</option> 
                                    <option value ="C">Consumable</option> 
                                </select>
                                <input type="hidden" id="hdfinf" />
                            </div>
                        </div>
                    </div>
                </div> 
                 <div class="row">
                    <div class="col-sm-12">
                        <div class="form-group row">
                            <div class ="table table-bordered table-striped  dt-responsive" id="mivOutboxDIV">
                                <table id="OutboxTable"  border="0" cellpadding="0" cellspacing="0"  class ="table table-striped" style="width:100%;">
                                    <thead>
                                        <tr>
                                            <th>MIV No.</th>
                                            <th>MIV Date</th>
                                            <th>Type</th>
                                            <th>Emp. Cd</th>
                                            <th>Employee Name</th>
                                            <th>Department</th>
                                            <th>Apporver's Status</th>
                                            <th>Authorizer's Status</th>
                                            <th>Select</th>
                                            <th>Print</th>
                                        </tr>
                                    </thead>                                
                                </table> 
                            </div> 
                            <label id ="lblMessage" style="text-align:center; color:Red; font-weight:bold;" ></label>
                            <input type="hidden" id="hdfempcd" />
                        </div>  
                    </div> 
                 </div> 
                 <div class="row">
                    <div class="col-sm-12">
                        <a href="/Home/Home" id="btnExit" class="btn btn-primary ButtonRightAlign">Exit</a>
                    </div>
                 </div>
            </div> 
            <div class="card-footer">                
            </div>        
        </div>  
    </div> 

<!--Print Modal -->
<div class="modal fade" id="ShowModalPrint" tabindex="-1" role="dialog" aria-labelledby="ModalTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog  modal-xl" role="document">
        <div class="modal-content">
            <div class="modal-header bg-primary">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true" style="display:none">
            &times;</button>
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
                                    <div class ="table table-striped  dt-responsive" id="mivDetailDIV">
                                    </div>
                                </td>
                            </tr>

                        </table>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" id="btnPrint" class="btn btn-primary" onclick="printData();">Print</button>
                <button type="button" id="btnClose" class="btn btn-primary" data-dismiss="modal" aria-hidden="true" >Close</button>
            </div>
        </div>
    </div>
</div>

<!-- Loader -->
<div id="loader"></div> 
</div>
@Scripts.Render("~/script/outbox")