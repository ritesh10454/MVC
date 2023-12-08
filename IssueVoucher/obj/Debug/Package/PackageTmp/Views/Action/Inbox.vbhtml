@imports System.Web.Optimization 
@Code
    ViewData("Title") = "Inbox"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@*<h2>Inbox</h2>*@
@section scripts
<style type="text/css">

     .ButtonRightAlign
    {
        float:right;
    }
    
   
    table.dataTable thead tr 
    {
        background-color: #007bff;
        color:#fff;
        font-size:12px;
    } 
    .dataTables_scroll
    {
        overflow:auto;
    }   
    
    table.dataTable {
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
                <h3 class="card-title">Inbox</h3>  
                <input type="hidden" id ="hdfUserName" value="@System.Web.HttpContext.Current.Session("usrnam")" />              
            </div>
            <div class="card-body" style="padding:0;">
                <div class="row">
                    <div class="col-sm-12">
                          <div class="form-group row">
                              <div class ="table table-bordered table-striped" id="mivOutboxDIV">
                                    <table id="InboxTable"  border="0" cellpadding="0" cellspacing="0"  class ="table table-bordered table-striped" style="width:100%;">
                                        <thead>
                                            <tr>
                                                <th>MIV No</th>
                                                <th>MIV Date</th>
                                                <th>Type</th>
                                                <th>Emp. Cd</th>
                                                <th>Employee Name</th>
                                                <th>Department</th>
                                                <th>Apporver's Status</th>
                                                <th>Authorizer's Status</th>
                                                <th>Select</th>
                                            </tr>
                                        </thead>                                
                                    </table> 
                                </div> 
                                <label id ="lblMessage" style="text-align:center; color:Red; font-weight:bold;" ></label>
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
    <!-- Loader -->
    <div id="loader"></div> 
</div> 
@Scripts.Render("~/script/inbox")