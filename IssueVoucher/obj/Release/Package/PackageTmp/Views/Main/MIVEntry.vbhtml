@imports System.Web.Optimization
@Code
    ViewData("Title") = "MIVEntry"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@*<h2>MIVEntry</h2>*@
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
 .loader {  
        position: fixed;  
        left: 0px;  
        opacity:0.9;
        top: 0px;  
        width: 100%;  
        height: 100%;  
        z-index: 9999;  
        background: rgb(201, 201, 201) url('../AdminLte/dist/img/waiting.gif') no-repeat 50% 50%;  
    } 
    th, td {
        white-space: nowrap;
    }    

    table.dataTable thead tr {
        background-color: #007bff;
        padding-top:0;
        font-size:12px;
        color:#fff;
        font-family: "Calibri";
    }   

    table.dataTable tfoot tr 
    {
        background-color: #007bff;
        color:#fff;
        font-family: "Calibri";
        font-size:12px;
    }
    
    table.dataTable 
    {
        margin: 0 !important;
        font-family: "Calibri"; 
        font-size:12px;
    }

    .wrapContent
    {
        white-space:normal !important;
    }
     
    .controlSize
    {
        padding-left: 3px !important;
        padding-right: 3px !important;
    }  
    

    table.dataTable td input[type="text"]
    {
        padding-top:0;  
        font-size:12px;
        vertical-align: top; 
        font-family: "Calibri";  
        text-align:right;
    }
    
    table.dataTable select, table.dataTable input[type="text"]
    {
         font-size:12px;
         padding-top:0;
         font-family: "Calibri";
    }
    
    .dropDowntext
    {
        padding-top:0;
    }
    
    .tabcolor
    {
        border-color:#C80000;
    }
    
    .tdPadding
    {
        padding-top: -0.625rem;
        margin-bottom: 0;     
        font-size:12px;
        font-family: "Calibri";
        margin-top: -5px !important;
        height: calc(2.25rem + 2px);
        }       
     
 </style>
End Section


<div class="row" id="mivEntryDetail">
    <div class ="col-md-12">
        <div class="card card-primary" style="margin-bottom: 5px;">
            <div class="card-header">
                <h3 class="card-title">Employee Detail</h3>
                 <input type="hidden" id ="hdfUserName" value="@System.Web.HttpContext.Current.Session("usrnam")" />  
            </div>
            <div class="card-body" style="padding:0;">
                <div class="row">
                    <div class="col-sm-12 col-md-6">
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Employee Name</label>
                                <div class="col-sm-6">
                                    <input type="text" readonly  class="form-control-plaintext TextAlign" id="txtempnam" placeholder="Employee Name"  disabled/>
                                    <input type ="hidden" id="hdfempcd" />
                                </div>
                            </div>
                    </div>
                    <div class="col-sm-12 col-md-6">
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Department</label>
                                <div class="col-sm-6">
                                    <input type="text"  class="form-control-plaintext TextAlign" id="txtDept" placeholder="Department" required  disabled/>
                                    <input type ="hidden" id="hdfdeptcd" />
                                </div>
                            </div>
                    </div>
                    <div class="col-sm-12 col-md-6">
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Approver Name</label>
                                <div class="col-sm-6">
                                    <input type="text" readonly  class="form-control-plaintext TextAlign" id="txtAppNam" placeholder="Employee Name"  disabled/>
                                    <input type ="hidden" id=="hdfAppCod" />
                                </div>
                            </div>
                    </div>
                    <div class="col-sm-12 col-md-6">
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Authorizer  Name</label>
                                <div class="col-sm-6">
                                    <input type="text" readonly   class="form-control-plaintext TextAlign" id="txtAutNam" placeholder="Authorizer  Name" required />
                                    <input type ="hidden" id=="hdfAutCod" />
                                     <input type ="hidden" id=="hdfdesig" />
                                    <input type ="hidden" id=="hdfTotItm" />
                                     <input type ="hidden" id=="hdfMivStg" Value="Entry Mode" />
                                     <input type ="hidden" id=="hdfUser_Role_Empcd" />
                                     <input type ="hidden" id=="hdfTag" />
                                </div>
                            </div>
                    </div>
                </div> 
            </div> 
        </div>    
        <div class="card card-primary" style="margin-bottom: 5px;">
                <div class="card-header">
                    <h3 class="card-title">MIV Detail</h3>
                </div>
                <div class="card-body" style="padding:0;">
                    <div class="row" id="pnlctrl">
                        <div class="col-sm-12 col-md-6">
                                <div class="form-group row">
                                    <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">MIV No</label>
                                    <div class="col-sm-6">
                                        <input type="text" readonly  class="form-control-plaintext TextAlign" id="txtMivNo" maxlength="6" placeholder="MIV No"  disabled/>
                                        <input type ="hidden" id=="hdfRetNo" />
                                        <input type ="hidden" id=="hdfMivNo" />
                                    </div>
                                </div>
                        </div>
                        <div class="col-sm-12 col-md-6">
                                <div class="form-group row">
                                    <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">MIV Date</label>
                                    <div class="col-sm-6">
                                        <input type="text"  class="form-control-plaintext TextAlign" id="txtMivDate" placeholder="MIV Date"  disabled required/>
                                    </div>
                                </div>
                        </div>
                        <div class="col-sm-12 col-md-6">
                                <div class="form-group row">
                                    <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Select Type</label>
                                    <div class="col-sm-6">
                                        <select  id="drpMivTyp" class="form-control select2 myTab"   tabindex="-1"  onchange="drpMivTyp_IndexChange();" >
                                            <option value="0">--Select--</option>
                                            <option value="P">Captial</option>
                                            <option value="C">Consumable</option>
                                        </select>
                                    </div>
                                </div>
                        </div>
                        <div class="col-sm-12 col-md-6">
                                <div class="form-group row">
                                    <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Status</label>
                                    <div class="col-sm-6">
                                        <input type="text"  class="form-control-plaintext TextAlign myTab" id="txtMivStatus" placeholder="Status"  disabled required value="OPEN"/>
                                    </div>
                                </div>
                        </div>
                        <div class="col-sm-12 col-md-6"  id= "cancel_reason" style="display:none;">
                                <div class="form-group row">
                                    <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Reason For Cancel</label>
                                    <div class="col-sm-6">
                                        <input type="text"  class="form-control TextAlign myTab" id="txtReason" placeholder="Reason for Cancel"  />
                                    </div>
                                </div>
                        </div>
                    </div> 
                    <div class="row" id="Panelsp">
                        <div class="col-sm-12 col-md-6" id="nature" style="display:none;">
                                <div class="form-group row">
                                    <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Select Nature</label>
                                    <div class="col-sm-6">
                                        <select  id="drpRetTyp" class="form-control select2 myTab"  tabindex="-1" >
                                            <option value="0">--Select--</option>
                                            <option value="R">Replacement</option>
                                            <option value="A">New Addition</option>
                                            <option value="P">Project</option>
                                        </select>
                                    </div>
                                </div>
                        </div>  
                        <div class="col-sm-12 col-md-6" id="reason_activity_Name"  style="display:none;">
                                <div class="form-group row">
                                    <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign myTab">Reason/Activity Name</label>
                                    <div class="col-sm-6">                                    
                                        <input type="text"   class="form-control TextAlign myTab" id="txtRetRes" placeholder="Reason/Activity Name" />
                                    </div>
                                </div>
                        </div>   
                        <div class="col-sm-12 col-md-6">
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Item Code</label>
                                <div class="col-sm-4">                                    
                                    <input type="text"  class="form-control TextAlign myTab" id="txtitmCd" placeholder="Item Code" maxlength="7" value="0" onchange ="txtitmCd_TextChanged();"/>
                                </div>
                                <div class="col-sm-2">                                    
                                    <button type="button" id="btnSearch"  class="btn btn-primary" onclick="showitemsLookup();">Lookup</button>
                                </div>
                            </div>
                        </div> 
                        <div class="col-sm-12 col-md-6"> 
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Item Name</label>
                                <div class="col-sm-6">
								    <select  id="DropDownList2" class="form-control select2 myTab"  tabindex="-1"  onchange= "DropDownList2_IndexChange();">
									    <option value="0">--Select--</option>
								    </select>
                                </div>
                            </div>
                        </div> 
                        <div class="col-sm-12 col-md-6">
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Unit of Measurement</label>
                                <div class="col-sm-6">                                    
                                    <input type="text" readonly  class="form-control-plaintext TextAlign myTab" id="txtUOM" maxlength="3"   disabled/>
                                </div>
                            </div>
                        </div> 
                        <div class="col-sm-12 col-md-6">
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Pre Stock Qty</label>
                                <div class="col-sm-6">                                    
                                    <input type="text" readonly  class="form-control-plaintext TextAlign" id="txtPreStk" placeholder="Pre Stock Qty"  disabled/>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-6">
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Required Qty</label>
                                <div class="col-sm-6">                                    
                                    <input type="text"  class="form-control TextAlign myTab" id="txtReqireQty" maxlength="10" ondrop="return false;" onpaste="return false;" onkeydown="return (event.keyCode!=13);" onkeypress="return isNumberfloatKey(event,this,3);"  onkeyup="txtReqireQty_TextChanged();"/>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-6">
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Item Rate</label>
                                <div class="col-sm-6">                                    
                                    <input type="text" readonly  class="form-control-plaintext TextAlign" id="txtItmRat" placeholder="Item Rate"  disabled/>
                                </div>
                            </div>
                        </div>                                                                   
                        <div class="col-sm-12 col-md-6">
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Select Consumption Centre</label>
                                <div class="col-sm-6"> 
                                    <select  id="drpConCen" class="form-control select2 myTab"  tabindex="-1">
                                        <option value="0">--Select--</option>
                                    </select>   
                                </div>
                            </div>
                        </div> 
                        <div class="col-sm-12 col-md-6">
                                <div class="form-group row">
                                    <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Item Value</label>
                                    <div class="col-sm-6">                                    
                                        <input type="text" readonly  class="form-control-plaintext TextAlign" id="txtissval" placeholder="Item Value"  disabled/>
                                    </div>
                                </div>
                        </div> 
                        <div class="col-sm-12 col-md-6">
                                <div class="form-group row">
                                    <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Select Cost Centre</label>
                                    <div class="col-sm-6">  
                                        <select  id="drpCosCen" name="drpCosCen" class="form-control select2 myTab"  tabindex="-1" >
                                            <option value="0">--Select--</option>
                                        </select>                                    
                                    </div>
                                </div>
                        </div> 
                        <div class="col-sm-12 col-md-6" id="remark"  style="display:none;">
                                <div class="form-group row">
                                    <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Remark</label>
                                    <div class="col-sm-6">                                    
                                        <input type="text" readonly  class="form-control TextAlign myTab" id="txtRemark" placeholder="Remark"  disabled/>
                                    </div>
                                </div>
                        </div> 
                        <div class="col-sm-12 col-md-6" id="issue_qty" >
                                <div class="form-group row">
                                    <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign issueqty">Issue Qty.</label>
                                    <div class="col-sm-3">                                    
                                        <input type="text" readonly  class="form-control-plaintext TextAlign issueqty myTab" id="txtIssueQty" placeholder="Issue Qty"  disabled  onchange="txtIssQty_TextChanged();"  />
                                    </div>
                                    <div class="col-sm-3">                                    
                                        <button type="button" id="btnadd"   class="btn btn-primary" onclick="btnadd_Click();">Add Item</button>
                                    </div>
                                </div>
                        </div>                                                                                                                
                    </div>              

                    <div class="row">
                        <div class="col-12">
                                <div class ="table table-bordered table-striped" id="mivDIV" >
                                <!--style="overflow:scroll;"-->

                                </div>
                        </div>
                    </div>
                    <div class ="row" style ="margin-top:10px;">
                        <div class ="col-12">
                            <div style ="float:right;">
                                    <button type ="button"  class="btn btn-primary" id="btnCheck" onclick="btnCheck_Click();" >Validate</button>
                                    <button  type ="button"  class="btn btn-primary" id="btnSave" style="display:none;" disabled onclick="btnSave_Click();">Save</button>
                                    <button  type ="button"  class="btn btn-primary" id="btnaction" style="display:none;" disabled onclick="btnaction_Click();">Forward</button>
                                    <button  type ="button"  class="btn btn-primary" id="btncancel" style="display:none;" disabled onclick="btncancel_Click();">Reject</button>
                                    <button  type ="button"  class="btn btn-primary" id="Btnexit" onclick="btnexit_click();">Exit</button>
                                    <input type="text" id="TextBox1"  style="display:none;"/>
                            </div>
                        </div>
                    </div>

                </div> 
                <div class="card-footer">

                </div>
                <div class="loader"></div> 
           </div>
    </div> 
</div>

<div class ="row">
    <div class ="col">
    <input type ="hidden" id=="hdfUserID" />
         <label id="lblMessage" style="color:#ff0000; font-weight:bold;"/>
        <label id="lblMessage2" style="color:#ff0000; font-weight:bold;"/>
    </div>
</div>

<!--Search Modal -->
<div class="modal fade" id="ShowItemsModal" tabindex="-1" role="dialog" aria-labelledby="ModalTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog modal-lg" role="document">
        <div class="modal-content">
            <div class="modal-header bg-primary">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true" style="display:none"></button>
            <h4 class="modal-title" id="ModalTitle">Search</h4>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="col-sm-12 col-md-12" id="Div1" >
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-3 col-form-label LabelAlign">Enter Text</label>
                                <div class="col-sm-6">                                    
                                    <input type="text"  class="form-control" id="txtItemCode" placeholder="Enter Item Code" />
                                </div>
                                <div class ="col-sm-3">
                                    <button type="button" id="btnItemSearch" class="btn btn-primary"  onclick="btnItemSearch_Click();" >Search</button>
                                </div>
                            </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12 col-md-12" id="Div2" >
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-3 col-form-label LabelAlign">Select Item</label>
                                <div class="col-sm-6">   
								    <select  id="ddSubItem" class="form-control select2 myTab"  tabindex="-1"  onchange="ddSubItem_IndexChanged();">
									    <option value="0">--Select--</option>
								    </select>                                
                                </div>
                            </div>
                    </div>
                </div>

            </div>
            <div class="modal-footer">
                <button type="button" id="btnClose" class="btn btn-primary" data-dismiss="modal" aria-hidden="true" >Close</button>
            </div>
        </div>
    </div>
<!-- Loader -->
    <div class="loader"></div> 
</div>
<!-- Lo -->
<div class="loader"></div> 
@Scripts.Render("~/script/MIVEntry")

