var table;
Timer();

$(document).ready(function () {
    ChangeBreadCrumb("Report", "MIV Detail", "Report");
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

            res=null;
            res = await getAllUsers();
            if (res.response == -1) 
            {
                ErrMsg =(res.responseMsg);
                throw ErrMsg;
            }
            var userList =res.responseObjectList;
            var allUsers =null; allUsers ='<option value="L">--ALL--</option>';
            $.each(userList,function(){
                allUsers += '<option value="'+this["emp_cd"]+'">'+this["emp_nm"]+' </option>';
            });
            $("[id*=drpEmp]").empty();
            $("[id*=drpEmp]").append(allUsers);

            res=null;
            res = await getDepartment();
            if (res.response == -1) 
            {
                ErrMsg =(res.responseMsg);
                throw ErrMsg;
            }
            var deptList =res.responseObjectList;
            var alldepts =null; alldepts ='<option value="L">--ALL--</option>';
            $.each(deptList,function(){
                alldepts += '<option value="'+this["dept_cd"]+'">'+this["dept_nm"]+' </option>';
            });
            $("[id*=drpdep]").empty();
            $("[id*=drpdep]").append(alldepts);
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
 


////////Button Click Events/////////////
function btnSelect_Click(ctl)
{
    var ErrMsg=null;
    try 
    {
      $(".loader").fadeIn();
        var mytag = 30; var mytag1 = 7;
        var row=$(ctl).closest("tr");  //.find('td')[1].textContent
        var rowIndex= row[0].sectionRowIndex;  //  rowIndex;
        var cols= row.find('td');
        var lblmivno = $(cols[3]).text();
        var lblmivdt =ChangeDateFormat2($(cols[4]).text());
        var lblMivTyp = $(cols[5]).text();
        var lblempcd = $(cols[0]).text();
        var lblstatus = $(cols[6]).text();
        var strUrl = String.format("/Main/MIVEntry?mivno={0}&mivdt={1}&empcd={2}&mytag={3}&mytag1={4}&a_status={5}&invtyp={6}",lblmivno,lblmivdt,lblempcd,mytag,mytag1,lblstatus,lblMivTyp);
        setTimeout(window.location.href = strUrl, 10000);    

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

async function btnPrint_Click(ctl)
{
    var ErrMsg=null;
    try 
    {
      $(".loader").fadeIn();
        var mytag = 30; var mytag1 = 7;
        var row=$(ctl).closest("tr");  //.find('td')[1].textContent
        var rowIndex= row[0].sectionRowIndex;  //  rowIndex;
        var cols= row.find('td');
        var lblmivno = $(cols[3]).text();
        var lblmivdt =ChangeDateFormat2($(cols[4]).text());
        var lblMivTyp = $(cols[5]).text();
        var lblempcd = $(cols[0]).text();
        var lblstatus = $(cols[6]).text();
        var mivyr= Math.abs(new Date(lblmivdt).getFullYear());
        var newRows = "";
        var tot=0;
		var tableHeading='<table id="MIVPrintTable"  border="0" cellpadding="0" cellspacing="0"  class ="table table-striped" style="width:100%;"><thead><tr><th class="no">No.</th><th class="itmcd">Item Code</th><th class="itmnm">Item Name</th><th class="uom">UOM</th><th class="stock" style="text-align: right;">Stock</th><th class="issqty" style="text-align: right;">Iss. Qty</th><th class="rate" style="text-align: right;">Rate</th><th class="totval" style="text-align: right;">Issue Val</th><th class="consumpcent">Consumption Centre</th><th class="costcent">Cost Centre</th></tr></thead><tbody>';
        newRows += tableHeading;
        var myData = await getPmivReport(lblmivno,mivyr);
        if (myData.response == -1) {
            alert(myData.responseMsg);
        }
            var reportData= myData.responseObjectList;
            for (var i = 0; i < reportData.length; i++) {
                if(i==0){
                    $("#td_mivtype").text(reportData[i].inv_typ);
                        $("#td_Mivno").text(reportData[i].miv_no);
                        $("#td_generateby").text(reportData[i].emp_nm);
                        $("#td_mivdt").text(reportData[i].miv_dt);
                        $("#td_dept_nm").text(reportData[i].dept_nm);
                        $("#td_appauth").text(reportData[i].app_nm);
                    break;
                }             
            }

            for (var i = 0; i < reportData.length; i++) 
            {
                tot += parseFloat(reportData[i].iss_val);
			    newRows +=  '<tr><td class="no" style="white-space: initial;width: 60px !important;">' + reportData[i].itm_sno + 
						    '</td><td class="itmcd" style="white-space: initial;width: 80px !important;">' + reportData[i].itm_cd + 
						    '</td><td class="itmnm" style="white-space: initial;width: 135px !important;">' + reportData[i].itm_desc + 
						    '</td><td class="uom" style="white-space: initial;width: 40px !important;">' + reportData[i].stk_uom + 
						    '</td><td class="stock" style="white-space: initial;width: 80px !important;text-align: right;">' + reportData[i].pre_stk_qty + 
						    '</td><td class="issqty" style="white-space: initial;width: 100px !important;text-align: right;">' + reportData[i].iss_qty + 
						    '</td><td class="rate" style="white-space: initial;text-align: right;width: 80px !important;">' + reportData[i].iss_rt + 
						    '</td><td class="totval" style="white-space: initial;text-align: right;width: 120px !important;">' + reportData[i].iss_val + 
						    '</td><td class="consumpcent">' + reportData[i].cons_desc + 
						    '</td><td class="costcent">' + reportData[i].cc_desc +  '</td></tr>';
            }
            newRows +='</tbody>';
            newRows += '<tfoot><tr><th class="no"></th><th class="itmcd"></th><th class="itmnm">Grand Total</th><th class="uom"></th><th class="stock"></th></th><th class="issqty"></th><th class="rate"></th><th class="totval" style="text-align: right;">Tot Val</th><th class="consumpcent"></th><th class="costcent"></th></tr></tfoot>';
            newRows +='</table>';
            document.getElementById("DIV1").innerHTML = newRows;
            $('#MIVPrintTable tfoot th:eq(7)').text(tot.toFixed(2));
            $('#MIVPrintTable td').css('white-space','initial');
            $("#ShowModalPrint").modal("toggle");
    } catch (err) {
       $("[id*=lblMessage]").text(err).css('color', '#ff0000'); // Red color
    }
    finally
    {
      $(".loader").fadeOut();
    }
}

async function getData()
{
    var par=null; var ErrMsg=null; var st=""; var tval=0;
    try 
    {
        var txtFroDat =  $("input[id*=txtFroDat]");
        var txtToDat = $("input[id*=txtToDat]");
        var drpEmp = $("select[id*=drpEmp] option:Selected");
        var drpMIVTyp = $("select[id*=drpMIVTyp] option:Selected");
        var drpdep = $("select[id*=drpdep] option:Selected");
        var fromDate =  ChangeDateFormat2(DateInYYYYMMDD(txtFroDat.val()));
        var ToDate = ChangeDateFormat2(DateInYYYYMMDD(txtToDat.val()));
        var currdt= new Date();
        var objPrpUsrLogDtl= [];
        var row={};
        currdt = (currdt.getMonth()+1) + '/' + currdt.getDate() + '/' + Math.abs(currdt.getFullYear());
        
        if (drpMIVTyp.val() == "L" &&  txtFroDat.val() != "0" &&  txtToDat.val() != "0" && drpEmp.val() == "L"  && drpdep.val() == "L" ) 
        {
            par =15;
            row["emp_cd"] =$("[id*=hdfempcd]").val();
           row["login_dt"] = ChangeDateFormat2(currdt);
            row["PACK_NAME"] = "OnLine Issue Voucher";
            row["rpt_name"] = "Report MIV Detail";
            row["para_1"] = String.format("MIV Detail Report From Date : {0} To Date : {1} Employee and MIV Type wiz",fromDate,ToDate);
            row["para_2"] = "MIV Detail Report View - All Employee, All Department and MIV Type wiz";
            objPrpUsrLogDtl.push(row);
        }
        else if (drpMIVTyp.val() != "L" &&  txtFroDat.val() != "0" &&  txtToDat.val() != "0" && drpEmp.val() == "L"  && drpdep.val() == "L" ) 
        {
            par =16;
            row["emp_cd"] =$("[id*=hdfempcd]").val();
            row["login_dt"] = ChangeDateFormat2(currdt);
            row["PACK_NAME"] = "OnLine Issue Voucher";
            row["rpt_name"] = "Report MIV Detail";
            row["para_1"] =  String.format("MIV Detail Report From Date : {0} To Date : {1} Employee and MIV Type wiz",fromDate,ToDate);
            row["para_2"] = String.format("MIV Detail Report View - All Employee , All Department and {0} viz.", drpMIVTyp.text().trim()); 
            objPrpUsrLogDtl.push(row);
        } 
        else if (drpMIVTyp.val() == "L" &&  txtFroDat.val() != "0" &&  txtToDat.val() != "0" && drpEmp.val() != "L"  && drpdep.val() == "L" ) 
        {
            par =28;
            row["emp_cd"] =$("[id*=hdfempcd]").val();
            row["login_dt"] = ChangeDateFormat2(currdt);
            row["PACK_NAME"] = "OnLine Issue Voucher";
            row["rpt_name"] = "Report MIV Detail";
            row["para_1"] =  String.format("MIV Detail Report From Date : {0} To Date : {1} Employee and MIV Type wiz",fromDate,ToDate);
            row["para_2"] = String.format("MIV Detail Report View - All Department and MIV Type wiz and MIV Owner:{0}",drpEmp.text());
            objPrpUsrLogDtl.push(row);
        }  
        else if (drpMIVTyp.val() != "L" &&  txtFroDat.val() != "0" &&  txtToDat.val() != "0" && drpEmp.val() != "L"  && drpdep.val() == "L" ) 
        {
            par =29;
            row["emp_cd"] =$("[id*=hdfempcd]").val();
            row["login_dt"] = ChangeDateFormat2(currdt);
            row["PACK_NAME"] = "OnLine Issue Voucher";
            row["rpt_name"] = "Report MIV Detail";
            row["para_1"] =  String.format("MIV Detail Report From Date : {0} To Date : {1} Employee and MIV Type wiz",fromDate,ToDate);
            row["para_2"] = String.format("MIV Detail Report View - all department, MIV owner : {0}, MIV type : {1} ",drpEmp.text(), drpMIVTyp.text());
            objPrpUsrLogDtl.push(row);
        }  
        else if (drpMIVTyp.val() == "L" &&  txtFroDat.val() != "0" &&  txtToDat.val() != "0" && drpEmp.val() == "L"  && drpdep.val() != "L" ) 
        {
            par =33;
            row["emp_cd"] =$("[id*=hdfempcd]").val();
            row["login_dt"] = ChangeDateFormat2(currdt);
            row["PACK_NAME"] = "OnLine Issue Voucher";
            row["rpt_name"] = "Report MIV Detail";
            row["para_1"] =  String.format("MIV Detail Report From Date : {0} To Date : {1} Employee and MIV Type wiz.  and For Dept : {2}",fromDate,ToDate,drpdep.text());
            row["para_2"] = String.format("MIV Detail Report View - all department, MIV owner : {0}, MIV type : {1}",drpEmp.text(), drpMIVTyp.text());
            objPrpUsrLogDtl.push(row);
        }   
        else if (drpMIVTyp.val() != "L" &&  txtFroDat.val() != "0" &&  txtToDat.val() != "0" && drpEmp.val() == "L"  && drpdep.val() != "L" ) 
        {
            par =34;
            row["emp_cd"] =$("[id*=hdfempcd]").val();
            row["login_dt"] = ChangeDateFormat2(currdt);
            row["PACK_NAME"] = "OnLine Issue Voucher";
            row["rpt_name"] = "Report MIV Detail";
            row["para_1"] =  String.format("MIV Detail Report From Date : {0} To Date : {1} Employee and MIV Type wiz.  and For Dept : {2}",fromDate,ToDate,drpdep.text());
            row["para_2"] = String.format("MIV Detail Report View - all department, MIV owner : {0}, MIV type : {1}",drpEmp.text(), drpMIVTyp.text());
            objPrpUsrLogDtl.push(row);
        }  
        res= await getMIVReport(par,fromDate,ToDate, drpMIVTyp.val(),drpEmp.val(),drpdep.val());
        if (res.response == -1) 
		{
            ErrMsg= res.responseMsg;
            throw ErrMsg;
        }
        var myData = res.responseObjectList;
        var res = await createDataTable(myData);
        if (res != "OK") 
        {
            ErrMsg = "Error found during Populate Grid";
            $(".loader").fadeOut();
            throw ErrMsg;
        }    
         MakeDataTable();
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

function btnShow_Click()
{
    $(".loader").fadeIn();
    getData();
    $(".loader").fadeOut();
}

function btnexit_click()
{
    var strUrl = '/Home/Home';
    setTimeout(window.location.href = strUrl, 10000);
}


async function btnExport_click()
{
    var ErrMsg=null;
    try 
    {
        $(".loader").fadeIn();
        var txtFroDat =  $("input[id*=txtFroDat]");
        var txtToDat = $("input[id*=txtToDat]");
        var drpEmp = $("select[id*=drpEmp] option:Selected");
        var drpMIVTyp = $("select[id*=drpMIVTyp] option:Selected");
        var drpdep = $("select[id*=drpdep] option:Selected");
        var fromDate =  ChangeDateFormat2(DateInYYYYMMDD(txtFroDat.val()));
        var ToDate = ChangeDateFormat2(DateInYYYYMMDD(txtToDat.val()));
        var currdt= new Date();
       var objPrpUsrLogDtl= [];
       var row={};
       currdt = (currdt.getMonth()+1) + '/' + currdt.getDate() + '/' + Math.abs(currdt.getFullYear());
        //currdt = currdt.getDate() + '/' + currdt.getMonth() + '/' + Math.abs(currdt.getFullYear());
        
        if (drpMIVTyp.val() == "L" &&  txtFroDat.val() != "0" &&  txtToDat.val() != "0" && drpEmp.val() == "L"  && drpdep.val() == "L" ) 
        {
            par =15;
            row["emp_cd"] =$("[id*=hdfempcd]").val();
           row["login_dt"] = ChangeDateFormat2(currdt);
            row["PACK_NAME"] = "OnLine Issue Voucher";
            row["rpt_name"] = "Report MIV Detail";
            row["para_1"] = String.format("MIV Detail Report From Date : {0} To Date : {1} Employee and MIV Type wiz",fromDate,ToDate);
            row["para_2"] = "MIV Detail Report View - All Employee, All Department and MIV Type wiz";
            objPrpUsrLogDtl.push(row);
        }
        else if (drpMIVTyp.val() != "L" &&  txtFroDat.val() != "0" &&  txtToDat.val() != "0" && drpEmp.val() == "L"  && drpdep.val() == "L" ) 
        {
            par =16;
            row["emp_cd"] =$("[id*=hdfempcd]").val();
            row["login_dt"] = ChangeDateFormat2(currdt);
            row["PACK_NAME"] = "OnLine Issue Voucher";
            row["rpt_name"] = "Report MIV Detail";
            row["para_1"] =  String.format("MIV Detail Report From Date : {0} To Date : {1} Employee and MIV Type wiz",fromDate,ToDate);
            row["para_2"] = String.format("MIV Detail Report View - All Employee , All Department and {0} viz.", drpMIVTyp.text().trim()); 
            objPrpUsrLogDtl.push(row);
        } 
        else if (drpMIVTyp.val() == "L" &&  txtFroDat.val() != "0" &&  txtToDat.val() != "0" && drpEmp.val() != "L"  && drpdep.val() == "L" ) 
        {
            par =28;
            row["emp_cd"] =$("[id*=hdfempcd]").val();
            row["login_dt"] = ChangeDateFormat2(currdt);
            row["PACK_NAME"] = "OnLine Issue Voucher";
            row["rpt_name"] = "Report MIV Detail";
            row["para_1"] =  String.format("MIV Detail Report From Date : {0} To Date : {1} Employee and MIV Type wiz",fromDate,ToDate);
            row["para_2"] = String.format("MIV Detail Report View - All Department and MIV Type wiz and MIV Owner:{0}",drpEmp.text());
            objPrpUsrLogDtl.push(row);
        }  
        else if (drpMIVTyp.val() != "L" &&  txtFroDat.val() != "0" &&  txtToDat.val() != "0" && drpEmp.val() != "L"  && drpdep.val() == "L" ) 
        {
            par =29;
            row["emp_cd"] =$("[id*=hdfempcd]").val();
            row["login_dt"] = ChangeDateFormat2(currdt);
            row["PACK_NAME"] = "OnLine Issue Voucher";
            row["rpt_name"] = "Report MIV Detail";
            row["para_1"] =  String.format("MIV Detail Report From Date : {0} To Date : {1} Employee and MIV Type wiz",fromDate,ToDate);
            row["para_2"] = String.format("MIV Detail Report View - all department, MIV owner : {0}, MIV type : {1} ",drpEmp.text(), drpMIVTyp.text());
            objPrpUsrLogDtl.push(row);
        }  
        else if (drpMIVTyp.val() == "L" &&  txtFroDat.val() != "0" &&  txtToDat.val() != "0" && drpEmp.val() == "L"  && drpdep.val() != "L" ) 
        {
            par =33;
            row["emp_cd"] =$("[id*=hdfempcd]").val();
            row["login_dt"] = ChangeDateFormat2(currdt);
            row["PACK_NAME"] = "OnLine Issue Voucher";
            row["rpt_name"] = "Report MIV Detail";
            row["para_1"] =  String.format("MIV Detail Report From Date : {0} To Date : {1} Employee and MIV Type wiz.  and For Dept : {2}",fromDate,ToDate,drpdep.text());
            row["para_2"] = String.format("MIV Detail Report View - all department, MIV owner : {0}, MIV type : {1}",drpEmp.text(), drpMIVTyp.text());
            objPrpUsrLogDtl.push(row);
        }   
        else if (drpMIVTyp.val() != "L" &&  txtFroDat.val() != "0" &&  txtToDat.val() != "0" && drpEmp.val() == "L"  && drpdep.val() != "L" ) 
        {
            par =34;
            row["emp_cd"] =$("[id*=hdfempcd]").val();
            row["login_dt"] = ChangeDateFormat2(currdt);
            row["PACK_NAME"] = "OnLine Issue Voucher";
            row["rpt_name"] = "Report MIV Detail";
            row["para_1"] =  String.format("MIV Detail Report From Date : {0} To Date : {1} Employee and MIV Type wiz.  and For Dept : {2}",fromDate,ToDate,drpdep.text());
            row["para_2"] = String.format("MIV Detail Report View - all department, MIV owner : {0}, MIV type : {1}",drpEmp.text(), drpMIVTyp.text());
            objPrpUsrLogDtl.push(row);
        }  
        var data =objPrpUsrLogDtl[0];
        var res = await Save_UsrLogDtl(data);
        if (res.response == -1) 
        {
            ErrMsg = res.responseMsg;
            throw ErrMsg;
        }

        res=null;
        res= await getMIVReport(par,fromDate,ToDate, drpMIVTyp.val(),drpEmp.val(),drpdep.val());
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

         tableToExcel('MIVExportTable','test','TestExport');

    } 
    catch (err) 
    {
    
    }
    finally
    {
        $(".loader").fadeOut();
    }

}

function getExportTable(myData)
{
     return new Promise(function (resolve, reject) {
        var newRows = "";
        var tot=0;
        var tableHeading ='<table id="MIVExportTable"  border="0" cellpadding="0" cellspacing="0"  class ="table table-striped" style="width:100%;"><thead><tr><th>EmpCd</th><th>Emp Name</th><th>Department</th><th>MIV No.</th><th>MIV Date</th><th>Type</th><th>Status</th><th>Tot. Value</th></tr></thead><tbody>';
        newRows += tableHeading;
        for (var i = 0; i < myData.length; i++) 
        {
             newRows +=     '<tr><td>' + myData[i].emp_cdG + 
                            '</td><td>' + myData[i].emp_nmG + 
                            '</td><td>' + myData[i].dept_nmG +  
                            '</td><td>' + myData[i].miv_no + 
                            '</td><td>' + myData[i].miv_dt + 
                            '</td><td>' + myData[i].inv_typG + 
                            '</td><td>' + myData[i].statusG + 
                            '</td><td>' + myData[i].Tot_valG + '</td></tr>';
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


 

/////////end////////////////////////////
//}

function getPmivReport(varmivno,varmivyr) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Action/getPmivReport",
            data: "{'varmivno' : '" + varmivno + "', 'varmivyr' : '" + varmivyr + "' }",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (myData) {
                resolve(myData);
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


function printData() {
    var contents = $("#OutputPrint").html();
    var frame1 = $('<iframe />');
    frame1[0].name = "frame1";
    frame1.css({ "position": "absolute", "top": "-1000000px" });
    $("body").append(frame1);
    var frameDoc = frame1[0].contentWindow ? frame1[0].contentWindow : frame1[0].contentDocument.document ? frame1[0].contentDocument.document : frame1[0].contentDocument;
    frameDoc.document.open();
    //Create a new HTML document.
    frameDoc.document.write('<html><head><title>Material Issue Voucher</title>');
    frameDoc.document.write('</head><body>');
    ////Append the external CSS file.
    frameDoc.document.write('<link rel="stylesheet" type="text/css" href="Styles/bootstrap.min.css" />');
    frameDoc.document.write('<link rel="stylesheet" type="text/css" href="Styles/headcss.css" />');
    //frameDoc.document.write('<link href="code/theme/css/TableStyle.css" rel="stylesheet" type="text/css" />');
    //Append the DIV contents.
    frameDoc.document.write(contents);
    frameDoc.document.write('</body></html>');
    frameDoc.document.close();
    setTimeout(function () {
    window.frames["frame1"].focus();
    window.frames["frame1"].print();
    frame1.remove();
    }, 500);

}



function getMIVReport(varpar,varmivdatfro,varmivdatTo,varinvtyp,varempcd,vardeptcd ) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Report/getMIVReport",
            data: "{'varpar' : '" +  varpar + "', 'varmivdatfro' : '" +  varmivdatfro + "', 'varmivdatTo' : '" +  varmivdatTo + "', 'varinvtyp' : '" +  varinvtyp + "', 'varempcd' : '" +  varempcd + "', 'vardeptcd' : '" +  vardeptcd + "'}",
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




function createDataTable(myData)
{
  return new Promise(function (resolve, reject) 
  {
        var newRows = "";
        var tot=0;
        var tableHeading='<table id="MivDetailTable"  border="0" cellpadding="0" cellspacing="0"  class ="table table-striped" style="width:100%;"><thead><tr><th class="empcd">EmpCd</th><th class="empnm">Emp Name</th><th class="deptnm">Department</th><th class="mivno">MIV No.</th><th class="mivdt">MIV Date</th><th class="type">Type</th><th class="status">Status</th><th class="totval">Tot. Value</th><th class="select">Select</th><th class="print">Print</th></tr></thead><tbody>';
        newRows += tableHeading;
        for (var i = 0; i < myData.length; i++) 
        {
            if (myData[i].statusG.toString().trim() == "Canceled") {
                tot += parseFloat(myData[i].Tot_valG);
            }

            
             newRows +=     '<tr><td class="empcd">' + myData[i].emp_cdG + 
                            '</td><td class="empnm">' + myData[i].emp_nmG + 
                            '</td><td class="deptnm">' + myData[i].dept_nmG +  
                            '</td><td class="mivno">' + myData[i].miv_no + 
                            '</td><td class="mivdt">' + myData[i].miv_dt + 
                            '</td><td class="type">' + myData[i].inv_typG + 
                            '</td><td class="status">' + myData[i].statusG + 
                            '</td><td class="totval">' + myData[i].Tot_valG + 
                            '</td><td class="select"><input type="button" id="btnSelect" class="btn btn-primary buttonF" value="Select"  onclick ="btnSelect_Click(this);"/>' + 
                            '</td><td class="print"><input type="button" id="btnPrint" class="btn btn-primary buttonF" value="Print"  onclick ="btnPrint_Click(this);" /></td></tr>';
        }
        newRows +='</tbody>';
       // newRows += '<tfoot><tr><th></th><th colspan="6">Grand Total</th><th>Tot. Value</th><th colspan="2"></th></tr></tfoot>';
       newRows += '<tfoot><tr><th></th><th></th><th>Grand Total</th><th></th><th></th><th></th><th></th><th>Tot. Value</th><th></th><th></th></tr></tfoot>';
        newRows +='</table>';
        document.getElementById("mivDetailDIV").innerHTML = newRows;
        if (tot > 0) {
            $('#MivDetailTable tfoot th:eq(8)').text(tot.toFixed(2));
        }
        else 
        {
            $('#MivDetailTable tfoot').hide();
        }
        $("[id*=lblMessage]").text("");
            resolve("OK");
    });
}

function MakeDataTable()
{
//  $("[id*=MIVTable]").removeAttr("width").DataTable({
 table=  $("#MivDetailTable").removeAttr("width").DataTable({
        "JQueryUI" : false,
        "paging": false,
        "processing": true,
        "deferRender" : true,
        "destroy": true,  
        "language": {
            "emptyTable": "No Data Found"
        },
        "fixedColumns": {
            "leftColumns": "3"
        },
        "scrollY": "400",
        "scrollX": "true",
        'order':[],
        'columnDefs': [{
            "targets": 0,
            "orderable": false
        }]
    });

    $(".dataTables_length").hide();       //  -----Hide Show Number of Entry 
    $(".dataTables_filter").hide();   //--HIde Search label and textbox         });
    table.order( [ 4, 'desc' ] ).draw();
    setTimeout(function(){$.fn.dataTable.tables( { visible: false, api: true } ).columns.adjust().fixedColumns().relayout();}, 100);
//    $(".dataTables_scrollHeadInner").css({"width":"100%"});
//    $(".dataTables_scrollFootInner").css({"width":"100%"});
//    $(".table ").css({"width":"100%"});
}





