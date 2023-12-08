var table;
Timer();

$(document).ready(function () {
    ChangeBreadCrumb("Report", "Report Consumption/Cost Centre viz", "Report");
     $("#issueBody").addClass("sidebar-collapse");
    changeDate();
    userDetail();
});


 $(".datepicker").datepicker({
    dateFormat: "dd-M-yy",     // SET THE FORMAT.
    changeMonth: true,
    changeYear: true,
    yearRange: '1950:2100',
    inline: true,
    showAnim: 'fadeIn',
    showButtonPanel: true,
    closeText: 'Clear',
    beforeShow: function (input) 
	{
        setTimeout(function () 
		{
            var clearButton = $(input)
            .datepicker("widget")
            .find(".ui-datepicker-close");
            clearButton.unbind("click").bind("click", function () { $.datepicker._clearDate(input); });
        }, 1);
    },
    onClose: function (e) 
	{
		var ev = window.event;
		if (ev.srcElement.innerHTML == 'Clear')
		{
			this.value = "";
		}
    },
    closeText: 'Clear',
});


async  function userDetail()
{
    var ErrMsg=null;
    try {
        $(".loader").fadeIn();
//	    var usercd= await  getSessionVariables();
        var usercd= $("#hdfUserName").val();
	    if (usercd.length ==0)
	    {
		    $("[id*=lblMessage]").text("Session Expired").css('color', '#ff0000'); // Red color
		    toastr.error("Session Expired", {timeOut: 200});
		    setTimeout(window.location.href = "/Login/Login", 10000);
		    return;
	    }
        if (usercd.length >0) 
        {
            $("#hdfempcd").val(usercd.toString().trim());
            var res =  await getEmployeeDetail(usercd.toString().trim());
            if (res.response ==-1) {
                ErrMsg =(res.responseMsg);
                throw ErrMsg;
            }
            var objempprp= res.responseObject;
             $("#hdfempcd").val($("#hdfempcd").val().toString().trim());
             $("#hdfempnam").val(objempprp.emp_nm.toString().trim());
             $("#hdfdept").val(objempprp.dept_nm.toString().trim());
             $("#hdfdesig").val(objempprp.desig_nm.toString().trim());

            //-----------Populate Consumption Centre DropdownList--------------
            res=null;
            res = await getConsumptionCentre();
            if (res.response == -1) 
            {
                ErrMsg =(res.responseMsg);
                throw ErrMsg;
            }
            var concenList =res.responseObjectList;
            var allconcen =null; allconcen ='<option value="L">--ALL--</option>';
            $.each(concenList,function(){
                allconcen += '<option value="'+this["cons_cd"]+'">'+this["cons_desc"]+' </option>';
            });
            $("[id*=drpConCen]").empty();
            $("[id*=drpConCen]").append(allconcen); 
            //--------------------end---------------------------

            //-----------Populate Cost Centre DropdownList--------------
            res=null;
            res = await getCostCentre();
            if (res.response == -1) 
            {
                ErrMsg =(res.responseMsg);
                throw ErrMsg;
            }
            var coscenList =res.responseObjectList;
            var allcoscen =null; allcoscen ='<option value="L">--ALL--</option>';
            $.each(coscenList,function(){
                allcoscen += '<option value="'+this["cc_cd"]+'">'+this["cc_desc"]+' </option>';
            });
            $("[id*=drpCosCen]").empty();
            $("[id*=drpCosCen]").append(allcoscen); 
            //------------------------end-------------------
        }
        else
        {
            setTimeout(window.location.href = "/Login/Login", 10000);
        }
    } 
    catch (err) 
    {
      $("[id*=lblMessage]").text(err).css('color', '#ff0000'); // Red color
    }
    finally
    {
     $(".loader").fadeOut();
    }

 }


function getConCosReport(varpar,varmivdatfro,varmivdatTo,varconscd,varcccd,varvari ) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Report/getConCosReport",
            data: "{'varpar' : '" +  varpar + "', 'varmivdatfro' : '" +  varmivdatfro + "', 'varmivdatTo' : '" +  varmivdatTo + "', 'varconscd' : '" +  varconscd + "', 'varcccd' : '" +  varcccd + "', 'varvari' : '" +  varvari + "'}",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                resolve(mData);
            },
            error: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            },
            failure: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            }
        });
    });
}

function ShowEmptyTable()
{
$('#MIVDetailTable').DataTable().clear().draw();
    $('#MIVDetailTable').removeAttr("width").DataTable({
        "JQueryUI" : false,
        "paging": false,
        "processing": true,
        "deferRender" : true,
        "destroy": true,  
	    "language": 
        {
		    "emptyTable": "No Data Found"
	    }
    });
    $(".dataTables_length").hide();       //  -----Hide Show Number of Entry 
    $(".dataTables_filter").hide();   //--HIde Search label and textbox     
}



function createDataTable(myData)
{
  return new Promise(function (resolve, reject) 
  {
           var table = $('#MIVDetailTable').removeAttr("width").DataTable({
                "JQueryUI" : false,
                "paging": false,
                "processing": true,
                "deferRender" : true,
                "destroy": true,  
                "language": 
                {
                    "emptyTable":  "My Record Found"
                },
                data: myData,
                columns:
                [
                    { 'data': 'miv_no' },
                    { 'data': 'miv_dt'},
                    { 'data': 'emp_cdG'},
                    { 'data': 'emp_nmG'},
                    { "data": "inv_typG"},
                    {"data" : "dept_nmG"},
                    { "data": "itm_cd"},
                    { "data": "itm_desc"},
                    { "data": "cons_desc"},
                    { "data": "cc_desc"},
                    { "data": "iss_qty"},
                    { "data": "iss_rt"},
                    { "data": "Tot_valG"}
                ],
                "language": {
                    "emptyTable": "No Data Found"
                },
                "fixedColumns": {
                    "leftColumns": "2"
                },
                "scrollY": "400",
                "scrollX": "true",
                'columnDefs': [{
                    "targets": 0,
                    "orderable": false
                }]
            });
            $(".dataTables_length").hide();       //  -----Hide Show Number of Entry 
            $(".dataTables_filter").hide();   //--HIde Search label and textbox     
            setTimeout(function(){$.fn.dataTable.tables( { visible: false, api: true } ).columns.adjust().fixedColumns().relayout();}, 500);
            resolve("OK");
  });

}


function getExportTable(myData)
{
     return new Promise(function (resolve, reject) {
        var newRows = "";
        var tot=0;
     //   var tableHeading='<table id="MIVExportTable"  border="0" cellpadding="0" cellspacing="0"  class ="table table-striped" style="width:100%;"><thead><tr><th class="empcd">EmpCd</th><th class="empnm">Emp Name</th><th class="deptnm">Department</th><th class="mivno">MIV No.</th><th class="mivdt">MIV Date</th><th class="type">Type</th><th class="status">Status</th><th class="totval">Tot. Value</th></tr></thead><tbody>';
        var tableHeading ='<table id="MIVExportTable"  border="0" cellpadding="0" cellspacing="0"  class ="table table-striped" style="width:100%;"><thead><tr><th>MIV No.</th><th>MIV Date</th><th>Emp.CD</th><th>Emp. Name</th><th>Department</th><th>Type</th><th>Itm. CD</th><th>Itm Name</th><th>Cons. Centre</th><th>Cost Centre</th><th>Iss. Qty</th><th>Iss. Rate</th><th>Tot. Value</th></tr></thead><tbody>';
        newRows += tableHeading;
        for (var i = 0; i < myData.length; i++) 
        {
        newRows +=  '<tr><td>' + myData[i].miv_no + 
                    '</td><td>' + myData[i].miv_dt + 
                    '</td><td>' + myData[i].emp_cdG + 
                    '</td><td>' + myData[i].emp_nmG + 
                    '</td><td>' + myData[i].inv_typG + 
                    '</td><td>' + myData[i].dept_nmG + 
                    '</td><td>' + myData[i].itm_cd + 
                    '</td><td>' + myData[i].itm_desc + 
                    '</td><td>' + myData[i].cons_desc + 
                    '</td><td>' + myData[i].cc_desc + 
                    '</td><td>' + myData[i].iss_qty + 
                    '</td><td>' + myData[i].iss_rt + 
                    '</td><td>' + myData[i].Tot_valG + 
                     '</td></tr>';
        }
        newRows +='</tbody>';
        newRows +='</table>';
        document.getElementById("DivExport").innerHTML = newRows;
        resolve("OK");
    });
}

function getIEVersion()
// Returns the version of Windows Internet Explorer or a -1
// (indicating the use of another browser).
{
    var rv = -1; // Return value assumes failure.
    if (navigator.appName == 'Microsoft Internet Explorer') {
        var ua = navigator.userAgent;
        var re = new RegExp("MSIE ([0-9]{1,}[\.0-9]{0,})");
        if (re.exec(ua) != null)
            rv = parseFloat(RegExp.$1);
    }
    return rv;
}

function tableToExcel(table, sheetName, fileName) {
    

    var ua = window.navigator.userAgent;
    var msie = ua.indexOf("MSIE ");
    if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))      // If Internet Explorer
    {
        return fnExcelReport(table, fileName);
    }

    var uri = 'data:application/vnd.ms-excel;base64,',
        templateData = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--><meta http-equiv="content-type" content="text/plain; charset=UTF-8"/></head><body><table>{table}</table></body></html>',
        base64Conversion = function (s) { return window.btoa(unescape(encodeURIComponent(s))) },
        formatExcelData = function (s, c) { return s.replace(/{(\w+)}/g, function (m, p) { return c[p]; }) }

    $("tbody > tr[data-level='0']").show();

    if (!table.nodeType)
        table = document.getElementById(table)

    var ctx = { worksheet: sheetName || 'Worksheet', table: table.innerHTML }

    var element = document.createElement('a');
    element.setAttribute('href', 'data:application/vnd.ms-excel;base64,' + base64Conversion(formatExcelData(templateData, ctx)));
    element.setAttribute('download', fileName);
    element.style.display = 'none';
    document.body.appendChild(element);
    element.click();
    document.body.removeChild(element);

    $("tbody > tr[data-level='0']").hide();
}

function fnExcelReport(table, fileName) {
    
    var tab_text = "<table border='2px'>";
    var textRange;

    if (!table.nodeType)
        table = document.getElementById(table)

    $("tbody > tr[data-level='0']").show();
    tab_text =  tab_text + table.innerHTML;

    tab_text = tab_text + "</table>";
    tab_text = tab_text.replace(/<A[^>]*>|<\/A>/g, "");//remove if u want links in your table
    tab_text = tab_text.replace(/<img[^>]*>/gi, ""); // remove if u want images in your table
    tab_text = tab_text.replace(/<input[^>]*>|<\/input>/gi, ""); // reomves input params

    txtArea1.document.open("txt/html", "replace");
    txtArea1.document.write(tab_text);
    txtArea1.document.close();
    txtArea1.focus();
    sa = txtArea1.document.execCommand("SaveAs", false, fileName + ".xls");
    $("tbody > tr[data-level='0']").hide();
    return (sa);
}




////////Button Click Events Start/////////////
function btnexit_click()
{
    var strUrl = '/Home/Home';
    setTimeout(window.location.href = strUrl, 10000);
}

async function getData()
{
   var par=null; var ErrMsg=null; var st=""; var tval=0;  
    try 
    {
        var txtFroDat =  $("input[id*=txtFroDat]");
        var txtToDat = $("input[id*=txtToDat]");
        var drpConCen = $("select[id*=drpConCen] option:Selected");
        var drpCosCen = $("select[id*=drpCosCen] option:Selected");
        var fromDate =  ChangeDateFormat2(DateInYYYYMMDD(txtFroDat.val()));
        var ToDate = ChangeDateFormat2(DateInYYYYMMDD(txtToDat.val()));
        var currdt= new Date();
        var objPrpUsrLogDtl= [];
        var row={};
        var mth = (currdt.getMonth()+1);
        var dy = currdt.getDate();
        var yr =Math.abs(currdt.getFullYear());
        if (mth < 10) {   mth = '0' + mth; }
        if (dy < 10) {   dy = '0' + dy; }
        var currdt =mth + '/' + dy + '/' + yr;
        var varvari =null;
        if (drpConCen.val() == "L" &&  txtFroDat.val() != "0" &&  txtToDat.val() != "0" && drpCosCen.val() == "L" ) 
        {
            par =35;
            row["emp_cd"] =$("[id*=hdfempcd]").val();
            row["login_dt"] = ChangeDateFormat2(currdt);
            row["PACK_NAME"] = "OnLine Issue Voucher";
            row["rpt_name"] = "Report Consumption/Cost Centre viz";
            row["para_1"] = String.format("Cons/cost Centre viz Report From Date : {0} To Date : {1} Cons. Centre and Cost Centre viz.",fromDate,ToDate);
            row["para_2"] = "Cons/cost Centre viz Report View - All Consumption, All Cost Centre wiz";
            objPrpUsrLogDtl.push(row); 
            varvar ="";   
        }
        else if (drpConCen.val() != "L" &&  txtFroDat.val() != "0" &&  txtToDat.val() != "0" && drpCosCen.val() != "L" ) 
        {
            par =38;
            row["emp_cd"] =$("[id*=hdfempcd]").val();
            row["login_dt"] = ChangeDateFormat2(currdt);
            row["PACK_NAME"] = "OnLine Issue Voucher";
            row["rpt_name"] = "Report Consumption/Cost Centre viz";
            row["para_1"] = String.format("Cons/cost Centre viz Report From Date : {0} To Date : {1} Cons. Centre and Cost Centre viz.",fromDate,ToDate);
            row["para_2"] = String.format("Cons/cost Centre viz Report View - For Consumption Centre : {0} For Cost Centre : {1}",drpConCen.val(), drpCosCen.val());            
            objPrpUsrLogDtl.push(row);
            varvar ="";
        }
        else if (drpConCen.val() != "L" &&  txtFroDat.val() != "0" &&  txtToDat.val() != "0" && drpCosCen.val() == "L" ) 
        {
            par =36;
            row["emp_cd"] =$("[id*=hdfempcd]").val();
            row["login_dt"] = ChangeDateFormat2(currdt);
            row["PACK_NAME"] = "OnLine Issue Voucher";
            row["rpt_name"] = "Report Consumption/Cost Centre viz";
            row["para_1"] = String.format("Cons/cost Centre viz Report From Date : {0} To Date : {1} Cons. Centre and Cost Centre viz.",fromDate,ToDate);
            row["para_2"] = String.format("Cons/cost Centre viz Report View - For Consumption Centre : {0} and all Cost Centre",drpConCen.val());        
            objPrpUsrLogDtl.push(row);
            varvar ="R";
        }
        else if (drpConCen.val() == "L" &&  txtFroDat.val() != "0" &&  txtToDat.val() != "0" && drpCosCen.val() != "L" ) 
        {
            par =37;
            row["emp_cd"] =$("[id*=hdfempcd]").val();
            row["login_dt"] = ChangeDateFormat2(currdt);
            row["PACK_NAME"] = "OnLine Issue Voucher";
            row["rpt_name"] = "Report Consumption/Cost Centre viz";
            row["para_1"] = String.format("Cons/cost Centre viz Report From Date : {0} To Date : {1} Cons. Centre and Cost Centre viz.",fromDate,ToDate);
            row["para_2"] = String.format("Cons/cost Centre viz Report View - For Cost Centre : {0} and all Consumption Centre",drpCosCen.val());               
            objPrpUsrLogDtl.push(row);
            varvar ="";
        }
        var res= await getConCosReport(par,fromDate,ToDate, drpConCen.val(),drpCosCen.val(),varvar);
        if (res.response == -1) 
		{
            ErrMsg= res.responseMsg;
           ShowEmptyTable();
            throw ErrMsg;
        }
        var myData = res.responseObjectList;
        res=null;
        res = await createDataTable(myData);
        if (res != "OK") 
        {
            ErrMsg = "Error found during Populate Grid";
            throw ErrMsg;
        } 
        var data =objPrpUsrLogDtl[0];
        var res = await Save_UsrLogDtl(data);
        if (res.response == -1) 
        {
            ErrMsg = res.responseMsg;
            throw ErrMsg;
        }
        if(ErrMsg==null)
        {
            $("[id*=lblMessage]").text("");
        }
    } 
    catch (err) 
    {
        $("[id*=lblMessage]").text(err).css('color', '#ff0000'); // Red color

    }
}

function btnShow_click()
{
    $(".loader").fadeIn();
    getData();
    $(".loader").fadeOut();
}


async function btnExport_click()
{
   var par=null; var ErrMsg=null; var st=""; var tval=0;  
    try 
    {
         $(".loader").fadeIn();
        var txtFroDat =  $("input[id*=txtFroDat]");
        var txtToDat = $("input[id*=txtToDat]");
        var drpConCen = $("select[id*=drpConCen] option:Selected");
        var drpCosCen = $("select[id*=drpCosCen] option:Selected");
        var fromDate =  ChangeDateFormat2(DateInYYYYMMDD(txtFroDat.val()));
        var ToDate = ChangeDateFormat2(DateInYYYYMMDD(txtToDat.val()));
        var objPrpUsrLogDtl= [];
        var row={};
        var currdt= new Date();
        var mth = (currdt.getMonth()+1);
        var dy = currdt.getDate();
        var yr =Math.abs(currdt.getFullYear());
        if (mth < 10) {   mth = '0' + mth; }
        if (dy < 10) {   dy = '0' + dy; }
        var currdt =mth + '/' + dy + '/' + yr;
        var varvari =null;
        if (drpConCen.val() == "L" &&  txtFroDat.val() != "0" &&  txtToDat.val() != "0" && drpCosCen.val() == "L" ) 
        {
            par =35;
            row["emp_cd"] =$("[id*=hdfempcd]").val();
            row["login_dt"] = ChangeDateFormat2(currdt);
            row["PACK_NAME"] = "OnLine Issue Voucher";
            row["rpt_name"] = "Report Consumption/Cost Centre viz";
            row["para_1"] = String.format("Cons/cost Centre viz Report From Date : {0} To Date : {1} Cons. Centre and Cost Centre viz.",fromDate,ToDate);
            row["para_2"] = "Cons/cost Centre viz Report View - All Consumption, All Cost Centre wiz";
            objPrpUsrLogDtl.push(row); 
            varvar ="";   
        }
        else if (drpConCen.val() != "L" &&  txtFroDat.val() != "0" &&  txtToDat.val() != "0" && drpCosCen.val() != "L" ) 
        {
            par =38;
            row["emp_cd"] =$("[id*=hdfempcd]").val();
            row["login_dt"] = ChangeDateFormat2(currdt);
            row["PACK_NAME"] = "OnLine Issue Voucher";
            row["rpt_name"] = "Report Consumption/Cost Centre viz";
            row["para_1"] = String.format("Cons/cost Centre viz Report From Date : {0} To Date : {1} Cons. Centre and Cost Centre viz.",fromDate,ToDate);
            row["para_2"] = String.format("Cons/cost Centre viz Report View - For Consumption Centre : {0} For Cost Centre : {1}",drpConCen.val(), drpCosCen.val());            
            objPrpUsrLogDtl.push(row);
            varvar ="";
        }
        else if (drpConCen.val() != "L" &&  txtFroDat.val() != "0" &&  txtToDat.val() != "0" && drpCosCen.val() == "L" ) 
        {
            par =36;
            row["emp_cd"] =$("[id*=hdfempcd]").val();
            row["login_dt"] = ChangeDateFormat2(currdt);
            row["PACK_NAME"] = "OnLine Issue Voucher";
            row["rpt_name"] = "Report Consumption/Cost Centre viz";
            row["para_1"] = String.format("Cons/cost Centre viz Report From Date : {0} To Date : {1} Cons. Centre and Cost Centre viz.",fromDate,ToDate);
            row["para_2"] = String.format("Cons/cost Centre viz Report View - For Consumption Centre : {0} and all Cost Centre",drpConCen.val());        
            objPrpUsrLogDtl.push(row);
            varvar ="R";
        }
        else if (drpConCen.val() == "L" &&  txtFroDat.val() != "0" &&  txtToDat.val() != "0" && drpCosCen.val() != "L" ) 
        {
            par =37;
            row["emp_cd"] =$("[id*=hdfempcd]").val();
            row["login_dt"] = ChangeDateFormat2(currdt);
            row["PACK_NAME"] = "OnLine Issue Voucher";
            row["rpt_name"] = "Report Consumption/Cost Centre viz";
            row["para_1"] = String.format("Cons/cost Centre viz Report From Date : {0} To Date : {1} Cons. Centre and Cost Centre viz.",fromDate,ToDate);
            row["para_2"] = String.format("Cons/cost Centre viz Report View - For Cost Centre : {0} and all Consumption Centre",drpCosCen.val());               
            objPrpUsrLogDtl.push(row);
            varvar ="";
        }
        res= await getConCosReport(par,fromDate,ToDate, drpConCen.val(),drpCosCen.val(),varvar);
        if (res.response == -1) 
		{
            ErrMsg= res.responseMsg;
            throw ErrMsg;
        }
        var myData = res.responseObjectList;
        var res = await getExportTable(myData);
        if(res !="OK")
        {
            ErrMsg=("Error during Export the Table");
            throw ErrMsg;
        }


          tableToExcel('MIVExportTable','test','TestExport1');
    } 
    catch (err) 
    {
        $("[id*=lblMessage]").text(err);
        $(".loader").fadeOut();
    }
    finally
    {
      $(".loader").fadeOut();
    }
}


///////////Button Click Events End/////////////


