
var varitmnos=0
var PRP_CostCentre_List;
var PRP_ConsumptionCentre_List;
var ConsumptionCentre;
var CostCentre;
var PRP_Items;
var prpMIVList;
var scrollPos=0;
var negChec=0;
var dtable = []; //Table object for Preserve row
var table;
var pmivhdr=[];

$(document).ready(function()
{
    ChangeBreadCrumb("Action", "MIVEntry", "Action");    
    MivEntry_Load();  
    SetTabs();  
    $("#issueBody").addClass("sidebar-collapse");
});

function SetTabs()
{
    $("[id*=txtRetRes]").attr('tabindex', -1);
    $("[id*=btnSearch]").attr('tabindex', -1);
    $("[id*=drpMivTyp]").attr('tabindex', 1);
    $("[id*=txtitmCd]").attr('tabindex', 2);
    $("[id*=DropDownList2]").attr('tabindex', 3);
    $("[id*=txtReqireQty]").attr('tabindex', 4);
    $("[id*=drpConCen]").attr('tabindex', 5);
    $("[id*=drpCosCen]").attr('tabindex', 6);
    $("[id*=btnadd]").attr('tabindex', 7);
}


$(".myTab").change(function(){
    $("[id*=lblMessage]").text(""); 
    $(this).removeClass('tabcolor');
	var sta =(getQueryVariable("sta")==false) ? 0 : parseInt(getQueryVariable("sta").toString());  
	if ($("[id*=hdfUserID]").val().toUpperCase() == "J16338" &&  sta <=0 ) 
    {
        $("[id*=lblMessage]").text("You Are Not Authorized For Voucher Creation.");
    }
});


async function MivEntry_Load() 
{
    var ErrMsg=null;
    var gridresult=null;
    try 
    {
         $(".loader").fadeIn();
//         var usercd= await  getSessionVariables();
         var usercd= $("#hdfUserName").val();
        if (usercd.length ==0)
        {
            $("[id*=lblMessage]").text("Session Expired").css('color', '#ff0000'); // Red color
            toastr.error("Session Expired", {timeOut: 200});
            setTimeout(window.location.href = "/Login/Login", 10000);
            return;
        }
        if(usercd.length > 0)
        {
            $("[id*=hdfUserID]").val(usercd.toString());
            $(".issueqty").attr("style","display:none;");
            $("[id*=txtReqireQty]").val(0);
            $("[id*=txtItmRat]").val(0);
            $("[id*=txtPreStk]").val(0);
            $("[id*=txtIssueQty]").val(0);
            $("[id*=txtissval]").val(0);
            $("[id*=lblMessage2]").hide();
            var itmData=null; var myData=null;
            var obj = await getAllList();
            if (obj.response ==-1) {
                ErrMsg=  obj.responseMsg;
			    throw ErrMsg;
            }
            var myObj = obj.responseObject;
            PRP_ConsumptionCentre_List = myObj.ConsumptionCentre;
            PRP_CostCentre_List = myObj.CostCentre;
            OurObject = myObj.UserRole;
            itmData =myObj.ItemList;

            CostCentre=null; CostCentre ='<option value="0">--Select--</option>';
            $.each(PRP_CostCentre_List,function(){
                CostCentre += '<option value="'+this["cc_cd"]+'">'+this["cc_desc"]+' </option>';
            });
            $("[id*=drpCosCen]").empty();
            $("[id*=drpCosCen]").append(CostCentre);

            ConsumptionCentre=null; ConsumptionCentre ='<option value="0">--Select--</option>';
            $.each(PRP_ConsumptionCentre_List,function(){
                ConsumptionCentre += '<option value="'+this["cons_cd"]+'">'+this["cons_desc"]+' </option>';
            });
            $("[id*=drpConCen]").empty();
            $("[id*=drpConCen]").append(ConsumptionCentre);

            var usercd = $("[id*=hdfUserID]").val();

            var sta =(getQueryVariable("sta")==false) ? 0 : parseInt(getQueryVariable("sta").toString());  
            var mytag = (getQueryVariable("mytag")==false) ? 0 : parseInt(getQueryVariable("mytag").toString());   //   parseInt(getQueryVariable("mytag").toString());

            subItem=null;subItem='<option value="0">--Select--</option>'
            for (var e=0; e < itmData.length; e++)
            {
                var st =  itmData[e];
                subItem += '<option value="'+st["itm_cd"]+'">'+st["itm_desc"]+' </option>';
            }
             $("[id*=DropDownList2]").empty();
              $("[id*=DropDownList2]").append(subItem);


            $("[id*=hdfTag]").val(OurObject["tag"].toString());
            if ($("[id*=hdfUserID]").val().toUpperCase() == "J16338" &&  sta <=0 ) 
            {
                ErrMsg= "You Are Not Authorized For Voucher Creation.";
                $("[id*=btnCheck]").attr("disabled", "disabled");  //disable button
                $("[id*=btnaction]").attr("disabled", "disabled");
                $("[id*=btnSave]").attr("disabled", "disabled");
                $("[id*=btnadd]").attr("disabled", "disabled");
                $("[id*=btnCheck]").hide();
                $("[id*=Panelsp]").hide();  // Control Visible False
                throw ErrMsg;
            }

             var tag =  $("[id*=hdfTag]").val();

            if (tag != "S" && sta <= 0) 
            {
                 ErrMsg= "You Are Approver Authority, So You Can't Generate Issue Voucher.";
                $("[id*=btnCheck]").attr("disabled", "disabled");  //disable button
                $("[id*=btnaction]").attr("disabled", "disabled");
                $("[id*=btnSave]").attr("disabled", "disabled");
                $("[id*=btnadd]").attr("disabled", "disabled");
                $("[id*=Panelsp]").hide();  // Control Visible False   
                throw ErrMsg;   
            }
    
            $("[id*=nature]").hide();
            var currdate=new Date();
            $("[id*=txtMivDate]").val(ChangeDateFormat1(currdate));
            var userDetail= await GetUserDetail($("[id*=hdfUserID]").val());
            if (userDetail.response == -1) 
            {
               ErrMsg= userDetail.responseMsg.toString();
                throw ErrMsg;
            }

            var detailOject =userDetail.responseObject;
            $("[id*=hdfempcd]").val(detailOject["emp_cd"]);
            $("[id*=txtempnam]").val(detailOject["emp_nm"]);
            $("[id*=hdfAppCod]").val(detailOject["apr_id"]);
            $("[id*=txtAppNam]").val(detailOject["apr_emp_nm"]);
            $("[id*=txtDept]").val(detailOject["dept_nm"]);
            $("[id*=hdfdesig]").val(detailOject["desig_nm"]);
            $("[id*=hdfAutCod]").val(detailOject["aut_id"]);
            $("[id*=txtAutNam]").val(detailOject["aut_emp_nm"]);
            $("[id*=hdfdeptcd]").val(detailOject["dept_cd"]);

            if (mytag == 20) 
            {
                var mindt= new Date(getQueryVariable("mivdt").toString());
                var objPmivtype = new Object();
                objPmivtype.miv_no = parseInt(getQueryVariable("mivno").toString());       
                objPmivtype.miv_yr = Math.abs(mindt.getFullYear());
                var returndetail= await GetReturnNo(objPmivtype);
                var returnOject =  returndetail.responseObject;
                $("input[type='hidden'][id*=hdfRetNo]").val(returnOject["Ret_No"]);

                var userDetail1= await GetUserDetail(getQueryVariable("empcd").toString());
                if (userDetail1.response == -1) 
                {
                    ErrMsg = userDetail1.responseMsg.toString();
                    throw ErrMsg;
                }

                var detailOject1 =userDetail1.responseObject;
                $("[id*=hdfempcd]").val(detailOject1["emp_cd"]);
                $("[id*=txtempnam]").val(detailOject1["emp_nm"]);
                $("[id*=hdfAppCod]").val(detailOject1["apr_id"]);
                $("[id*=txtAppNam]").val(detailOject1["apr_emp_nm"]);
                $("[id*=txtDept]").val(detailOject1["dept_nm"]);
                $("[id*=hdfdesig]").val(detailOject1["desig_nm"]);
                $("[id*=hdfAutCod]").val(detailOject1["aut_id"]);
                $("[id*=txtAutNam]").val(detailOject1["aut_emp_nm"]);
                $("[id*=hdfdeptcd]").val(detailOject1["dept_cd"]);

                $("[id*=txtMivNo]").val(parseInt(getQueryVariable("mivno").toString()));
                $("[id*=txtMivDate]").val(ChangeDateFormat1(new Date(getQueryVariable("mivdt").toString())));
        
                $("[id*=drpMivTyp] option:selected").removeAttr("selected");
                if (getQueryVariable("invtyp").toString() == "Consumable") 
                {
                    $("[id*=drpMivTyp] option[value='C']").attr('selected', 'selected');
                }
                else 
                {
                    $("[id*=drpMivTyp] option[value='P']").attr('selected', 'selected');
                }

                var bind1= await BindGrid(parseInt(getQueryVariable("mivno").toString()),  Math.abs((new Date(getQueryVariable("mivdt").toString())).getFullYear()),usercd.toString().trim().toUpperCase());
                if (bind1) {
                        var prpMIVList=null;gridresult=null;
                        if (usercd.toString().trim().toUpperCase() == "J16338") 
                        {
                             prpMIVList= bind1;
                            populateGrid(prpMIVList).catch(function(reason) {ErrMsg = "Error while populate Grid" ;  throw ErrMsg;});
                        }
                        else if (usercd.toString().trim().toUpperCase() != "J16338") 
                        {
                            prpMIVList= bind1;
                            populateGrid_OtherUsers(prpMIVList).catch(function(reason) {ErrMsg = "Error while populate Grid" ;  throw ErrMsg;});
                        }
                }

                hideShowColumn("remark",false );

                if ($("[id*=hdfMivStg]").val() == "Entry Mode") 
                {
                    $("[id*=btnSave]").text("Update");  //.attr('value', 'Update');
                    hideShowColumn("issqty",false );
                    if (sta == 0) 
                    {
                        $("[id*=btnaction]").text("Forward");  //   .attr('value', 'Forward');
                        $("[id*=btnaction]").show()
                        $("[id*=btnaction]").attr("disabled", "disabled");
                        if (getQueryVariable("invtyp").toString() == "Consumable" ) 
                        {
                            $("[id*=nature]").hide();   //Hide Select Nature Column
                                $("[id*=reason_activity_Name]").hide();   //Hide Reason/Activity Name Column
                        }
                        else
                        {
                            $("[id*=nature]").show();   //Show Select Nature Column
                            $("[id*=reason_activity_Name]").show();   //Show Reason/Activity Name Column
                        }
                    }
                    if ($("[id*=btnaction]").text() == "Forward") 
                    {
                        $("[id*=btnCheck]").removeAttr("disabled");  //Enabale button
                        $("[id*=btnSave]").removeAttr("disabled");  //Enabale button
                        $("[id*=btnCheck]").hide();
                        $("[id*=btnSave]").hide();
                    }
                }

                if ($("[id*=hdfMivStg]").val() == "Entry Mode") 
                {
                    $("[id*=btnSave]").text("Update");  //.attr('value', 'Update');
                    if (sta == 0) 
                    {
                        $("[id*=btnaction]").text("Forward");  //.attr('value', 'Forward');
                        $("[id*=btnaction]").removeAttr("disabled");  //Enabale button
                        $("[id*=btnaction]").show()  //Show button
                        hideShowColumn("issqty",false );
                    }
                    else if(sta == 1) 
                    {
                        $("[id*=hdfMivStg]").val("Approval Mode");
                        $("[id*=txtMivDate]").attr("disabled", "disabled");
                        $("[id*=drpMivTyp]").attr("disabled", "disabled");
                        $("[id*=btncancel]").show();
                        $("[id*=btncancel]").removeAttr("disabled");  //Enabale button
                        hideShowColumn("issqty",false );
                    }
                    else if(sta == 2) 
                    {
                        $("[id*=hdfMivStg]").val("Autorization Mode");
                        $("[id*=txtMivDate]").attr("disabled", "disabled");
                        $("[id*=drpMivTyp]").attr("disabled", "disabled");
                        hideShowColumn("issqty",true );
                        hideShowColumn("minno",true );
                        hideShowColumn("mindt",true );
                        hideShowColumn("minqty",true );
                        hideShowColumn("remqty",true );
                        $("[id*=cancel_reason]").show();
                    }
                }

                if ($("[id*=hdfUserID]").val().toUpperCase() == "J16338" ) 
                {
                    hideShowColumn("del",false );
                }

                if (sta == 1) 
                {
                    hideShowColumn("del",false );
                }
                $("[id*=drpMivTyp]").attr("disabled", "disabled");
            }

            if (sta == 1 && mytag == 20 ) 
            {
                $("[id*=Panelsp]").hide();  // Control Visible False    
                $("[id*=btnCheck]").removeAttr("disabled")  //Enable button
                $("[id*=btnSave]").attr("disabled", "disabled");
                $("[id*=btnaction]").show();
                $("[id*=btnaction]").removeAttr("disabled")  //Enable button
                $("[id*=MIVTable]").attr("disabled","disabled");
                $("[id*=btnaction]").text("Approve");  //.attr('value', 'Approve');
            }
            else if (sta == 2 && mytag == 20 ) 
            {
                $("[id*=Panelsp]").hide();  // Control Visible False    
                $("[id*=btnCheck]").removeAttr("disabled")  //Enable button  
                $("[id*=btnSave]").attr("disabled", "disabled");
                $("[id*=btnaction]").show();
                $("[id*=btnaction]").removeAttr("disabled")  //Enable button
                $("[id*=MIVTable]").attr("disabled","disabled");
                $("[id*=btnaction]").text("Authorize");  //  .attr('value', 'Authorize');
                i = 0; var t = document.getElementById('MIVTable');
                $("#MIVTable > tbody > tr").each(function(index, tr) 
                {
                    $(tr).find("input[id*=txtReqQty]").prop("disabled",true);
                    $(tr).find("input[id*=txtIssQty]").prop("disabled",false);
                    var currentRow = $(this);
                    i++;
                });


                if (getQueryVariable("invtyp").toString() == "Consumable") 
                {
                    hideShowColumn("nature",false );
                    hideShowColumn("rsn",false );
                }
                else 
                {
                    hideShowColumn("nature",true );
                    hideShowColumn("rsn",true );
                }
            }

            if (mytag == 30) 
            {
                var userDetail2= await GetUserDetail(getQueryVariable("empcd").toString());  
                if (userDetail2.response == -1) 
                {
                    ErrMsg = userDetail2.responseMsg.toString();
                    throw ErrMsg;
                }

                var detailOject2 =userDetail2.responseObject;
                $("[id*=hdfempcd]").val(detailOject2["emp_cd"]);
                $("[id*=txtempnam]").val(detailOject2["emp_nm"]);
                $("[id*=hdfAppCod]").val(detailOject2["apr_id"]);
                $("[id*=txtAppNam]").val(detailOject2["apr_emp_nm"]);
                $("[id*=txtDept]").val(detailOject2["dept_nm"]);
                $("[id*=hdfdesig]").val(detailOject2["desig_nm"]);
                $("[id*=hdfAutCod]").val(detailOject2["aut_id"]);
                $("[id*=txtAutNam]").val(detailOject2["aut_emp_nm"]);
                $("[id*=hdfdeptcd]").val(detailOject2["dept_cd"]);
                $("[id*=txtMivNo]").val(parseInt(getQueryVariable("mivno").toString()));
                $("[id*=txtMivDate]").val(ChangeDateFormat1(new Date(getQueryVariable("mivdt").toString())));
                $("[id*=drpMivTyp] option:selected").removeAttr("selected");
                if (getQueryVariable("invtyp").toString() == "Consumable") 
                {
                    $("[id*=drpMivTyp] option[value='C']").attr('selected', 'selected');
                }
                else 
                {
                    $("[id*=drpMivTyp] option[value='P']").attr('selected', 'selected');
                }
                // Populate Grid
                var bind2= await BindGrid(parseInt(getQueryVariable("mivno").toString()),  Math.abs((new Date(getQueryVariable("mivdt").toString())).getFullYear()),usercd.toString().trim().toUpperCase());
                if (bind2) 
                {
                    var prpMIVList=null; gridresult=null;
                    if (usercd.toString().trim().toUpperCase() == "J16338") 
                    {
                        prpMIVList= bind2;
                        populateGrid(prpMIVList).catch(function(reason) {ErrMsg = "Error while populate Grid" ;  throw ErrMsg;});
                    }
                    else if (usercd.toString().trim().toUpperCase() != "J16338") 
                    {
                        prpMIVList= bind2;
                        populateGrid_OtherUsers(prpMIVList).catch(function(reason) {ErrMsg = "Error while populate Grid" ;  throw ErrMsg;});
                    }
                }
                hideShowColumn("remark",false );
                $("[id*=Panelsp]").hide();  // Control Visible False 
                $("[id*=txtMivDate]").attr("disabled", "disabled");
                $("[id*=drpMivTyp]").attr("disabled", "disabled");
                $("[id*=hdfMivStg]").val("View Mode");
                $("[id*=MIVTable]").find("input,button,textarea,select").attr("disabled", "disabled");
                $("[id*=btnCheck]").hide();
                $("[id*=btnSave]").hide();

                if (sta == 3) 
                {
                    $("[id*=txtMivStatus]").val("Authorized");
                }
                else if (sta == 4) {
                     $("[id*=txtMivStatus]").val("Canceled");
                }
                else 
                {
                    $("[id*=txtMivStatus]").val("Open");
                }

                if (parseInt(getQueryVariable("mytag1").toString()) == 7) 
                {
                    $("[id*=txtMivStatus]").val(getQueryVariable("a_status").toString());
                }
                  hideShowColumn("del",false );
                 var mivInboxDetail= await GetmivInboxD(parseInt(getQueryVariable("mivno").toString()),  Math.abs((new Date(getQueryVariable("mivdt").toString())).getFullYear()));
                if (mivInboxDetail.response == -1) 
                {
                    ErrMsg= mivInboxDetail.responseMsg.toString();
                    throw ErrMsg;
                }
                $("[id*=cancel_reason]").show();
                $("[id*=txtCancelReason]").val(detailOject2["remark"]);
                $("[id*=txtCancelReason]").attr("disabled", "disabled");
            }

            if( $("[id*=txtMivStatus]").val() == "Approval Mode" ||  $("[id*=txtMivStatus]").val() == "Autorization Mode")
            {
                    $("[id*=Panelsp]").hide();
            }  
            if($("[id*=btnSave]").text() =="Save"  ||  $("[id*=btnaction]").text() =="Forward" ||  $("[id*=btnaction]").text() =="Approve"  )
            {
                hideShowColumn("minno",false );
                hideShowColumn("mindt",false );
                hideShowColumn("minqty",false );
                hideShowColumn("remqty",false );
            } 
            if ($("[id*=btnaction]").text() =="Authorize") 
            {
                $("#MIVTable > tbody > tr").each(function(index, tr) 
                {
                    $(tr).find("input[id*=txtReqQty]").prop("disabled",true);
                    $(tr).find("input[id*=txtReqQty]").removeClass("form-control");
                    $(tr).find("input[id*=txtReqQty]").addClass("form-control-plaintext");
                    $(tr).find("input[id*=txtIssQty]").prop("disabled",false);
                });
                hideShowColumn("nature",false );
                hideShowColumn("rsn",false );
            }
            if(!$("[id*=btnSave]").is(":visible") && !$("[id*=btnaction]").is(":visible") && usercd.toString().trim().toUpperCase() == "J16338" )
            {
                hideShowColumn("nature",false );
                hideShowColumn("rsn",false );
                hideShowColumn("minno",true );  
                hideShowColumn("mindt",true ); 
                hideShowColumn("minqty",true );
                hideShowColumn("remqty",true ); 
                $("#MIVTable > tbody > tr").each(function(index, tr) 
                {
                    $(tr).find("input[id*=txtReqQty]").prop("disabled",true);
                    $(tr).find("input[id*=txtReqQty]").removeClass("form-control");
                    $(tr).find("input[id*=txtReqQty]").addClass("form-control-plaintext");
                });                 
            }	

                  
             MakeDataTable(); 
            if (usercd.toString().trim().toUpperCase() != "J16338") 
            {
                $(".dataTables_scrollHeadInner").css({"width":"100%"});
                $(".dataTables_scrollFootInner").css({"width":"100%"});
                $(".table ").css({"width":"100%"});
            }
            if (sta == 3) 
            {
                $("[id*=MIVTable]").find("input,button,textarea,select").attr("disabled", "disabled");
                $("[id*=pnlctrl]").find("input,button,textarea,select").attr("disabled", "disabled");
                $("[id*=Panelsp]").find("input,button,textarea,select").attr("disabled", "disabled");
            }
        }

        if (ErrMsg == null ) 
        {
            $("[id*=lblMessage]").text("");
            $("[id*=lblMessage2]").text("");
        }    
    } 
    catch (err) 
    {
        $("[id*=lblMessage]").text(err).css('color', '#ff0000'); // Red color
        toastr.error(err, {timeOut: 200});;
        $(".loader").fadeOut();
    } 
    finally
    {
        $(".loader").fadeOut();
    }
}


function isNumberfloatKey(evt, element,afterDot) {
  var afterDot = afterDot+1;
  var charCode = (evt.which) ? evt.which : event.keyCode
  if (charCode > 31 && (charCode < 48 || charCode > 57) && !(charCode == 46 || charCode == 8))
    return false;
  else 
  {
    var len = $(element).val().length;
    var index = $(element).val().indexOf('.');
    if (index > 0 && charCode == 46) 
    {
      return false;
    }
    if (index > 0) 
    {
      var CharAfterdot = (len + 1) - index;
      if (CharAfterdot > afterDot) 
      {
        return false;
      }
    }
  }
  return true;
}


function hideShowColumn(classnm,do_show)
 {
    var stl;
    if (do_show) stl = 'block'
    else         stl = 'none';
    var elems = document.getElementsByClassName(classnm);
    for(var i = 0; i<elems.length; i++) {
       elems[i].style.display = do_show ? '' : 'none';
    }
}


Array.prototype.remove = function (v) {
    if (this.indexOf(v) != -1) {
        this.splice(this.indexOf(v), 1);
        return true;
    }
    return false;
}


function GetUserDetail(usercd) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Home/GetUserDetail",
           data: "{'usercd' : '" + usercd + "'}",
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


function GetUserRole() {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Home/GetUserRole",
            data: "{}",
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


function GetReturnNo(com) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Main/GetReturnNo",
            data: JSON.stringify({p: com}),
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


function getAllList() {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Main/getAllList",
            data: "{}",
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




function GetmivInboxD(mivno,mivyr) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Main/GetmivInboxD",
            data: "{'miv_no' : '" + mivno + "', 'miv_yr' : '" + mivyr + "' }",
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



// App variable to show the confirm response
function getQueryVariable(variable) {
    var query = window.location.search.substring(1);
    var vars = query.split("&");
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split("=");
        if (pair[0] == variable) { return pair[1]; }
    }
    return (false);
}



function BindGrid(mivno,mivyr,loginID) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Main/BindGrid",
            data: "{'miv_no' : '" + mivno + "', 'miv_yr' : '" + mivyr + "', 'loginID' : '" + loginID + "' }",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (response) {
               //------Bind Table-----------
                var myData= response.responseObject.Pmivdtl_List;
               //------------end------------
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

//$('#MIVTable').on('shown.bs.collapse', function () {
//   $($.fn.dataTable.tables(true)).DataTable()
//      .columns.adjust();
//});


function populateGrid_OtherUsers(myData)
{   
    return new Promise(function (resolve, reject) {
        var newRows = "";
        var tableHeading='<table id="MIVTable"  border="0" cellpadding="0" cellspacing="0"  class ="table table-bordered table-striped nowrap" style="width:100%;"><thead><tr><th class="no">No.</th><th class="itmcd">Item Code</th><th class="itmnm">Item Name</th><th class="uom">UOM</th><th class="stock">Stock</th><th class="reqqty">Req. Qty</th><th class="issqty">Iss. Qty</th><th class="rate">Rate</th><th class="totval">Tot Val</th><th class="consumpcent">Consumption Centre</th><th class="costcent">Cost Centre</th><th class="nature">Nature</th><th class="rsn">Rsn/Atvty</th><th class="remark">Remark</th><th class="minno">MIN No/Date</th><th class="mindt">MIN Date</th><th class="minqty">MIN Qty</th><th class="remqty">Rem Qty</th><th class="ordno">OrdNo</th><th class="del">Del</th></tr></thead><tbody>';
        newRows += tableHeading;

        var tot=0;
        for (var i = 0; i < myData.length; i++) 
        {                
			tot += parseFloat(myData[i].iss_val);
			newRows +=  '<tr><td class="no">' + myData[i].itm_sno + 
						'</td><td class="itmcd tdPadding">' + myData[i].itm_cd + 
						'</td><td class="itmnm tdPadding">' + myData[i].itm_desc + 
						'</td><td class="uom tdPadding">' + myData[i].uom + 
						'</td><td class="stock tdPadding">' + myData[i].pre_stk_qty + 
						'</td><td class="reqqty tdPadding">' + myData[i].req_qty + 
						'</td><td class="issqty tdPadding">' + myData[i].iss_qty + 
						'</td><td class="rate tdPadding">' + myData[i].iss_rt + 
						'</td><td class="totval tdPadding">' + myData[i].iss_val + 
                        '</td><td class="consumpcent tdPadding"><input type="text" id="txtcons_cd" class="myTab"  value=' + myData[i].cons_cd + ' style="display:none;"/><span id="txtcons_nm" class="myTab">' + myData[i].cons_nm + '</span>' +
                        '</td><td class="costcent tdPadding"><input type="text" id="txtcc_cd" class="myTab"  value=' + myData[i].cc_cd + ' style="display:none;"/><span id="txtcc_nm" class="myTab" >' + myData[i].cc_nm + '</span>' +
//                        '</td><td class="consumpcent tabcolor"><input type="text" id="txtcons_cd" class="form-control myTab"  value=' + myData[i].cons_cd + ' style="display:none;"/><input type="text" id="txtcons_nm" class="form-control-plaintext myTab" disabled value="' + myData[i].cons_nm + '" />' +
//                        '</td><td class="costcent tabcolor"><input type="text" id="txtcc_cd" class="form-control myTab"  value=' + myData[i].cc_cd + ' style="display:none;"/><input type="text" id="txtcc_nm" class="form-control-plaintext myTab" disabled value="'  + myData[i].cc_nm + '" />' +
						'</td><td class="nature tdPadding">' + myData[i].RetTyp + 
						'</td><td class="rsn tdPadding">' + myData[i].Reason + 
						'</td><td class="remark tdPadding">' + myData[i].Remark + 
						 '</td><td class="minno tdPadding">' + myData[i].min_no + 
						'</td><td class="mindt tdPadding">' + myData[i].min_dt + 
						'</td><td class="minqty tdPadding">' + myData[i].min_qty + 
						'</td><td class="remqty tdPadding">' + myData[i].rem_qty + 
						'</td><td class="ordno tdPadding">' + myData[i].OrdNo + 
						'</td><td class="del tdPadding"><input type="button" id="btnDelete"  class="btn btn-primary" value="Delete" onclick="rowDelete(this)"  /></td></tr>';
        }
        newRows +='</tbody>';
        newRows += '<tfoot><tr><th class="no"></th><th class="itmcd"></th><th class="itmnm">Grand Total</th><th class="uom"></th><th class="stock"></th><th class="reqqty"></th><th class="issqty"></th><th class="rate"></th><th class="totval">Tot Val</th><th class="consumpcent"></th><th class="costcent"></th><th class="nature"></th><th class="rsn"></th><th class="remark"></th><th class="minno"></th><th class="mindt"></th><th class="minqty"></th><th class="remqty"></th><th class="ordno"></th><th class="del"></th></tr></tfoot>';
        newRows +='</table>';

        document.getElementById("mivDIV").innerHTML = newRows;
        $('tfoot th:eq(8)').text(tot.toFixed(2));
        resolve("OK");
    });
}



 function populateGrid(myData)
{   
    return new Promise(function (resolve, reject) {
        var newRows = "";
        var tableHeading='<table id="MIVTable"  border="0" cellpadding="0" cellspacing="0"  class ="table table-bordered table-striped nowrap" style="width:100%;"><thead><tr><th class="no">No</th><th class="itmcd">Itm CD</th><th class="itmnm">Item Name</th><th class="uom">UOM</th><th class="stock">Stock</th><th class="reqqty">R.Qty</th><th class="issqty">Iss.Qty</th><th class="rate">Rate</th><th class="totval">Tot Val</th><th class="consumpcent">Consumption Centre</th><th class="costcent">Cost Centre</th><th class="nature">Nature</th><th class="rsn">Rsn/Atvty</th><th class="remark">Remark</th><th class="minno">MIN No/Date</th><th class="mindt">MIN Date</th><th class="minqty">MIN Qty</th><th class="remqty">Rem Qty</th><th class="ordno">OrdNo</th><th class="del">Del</th></tr></thead><tbody>';
        newRows += tableHeading;

        var tot=0;
        for (var i = 0; i < myData.length; i++) 
        {
            var drpMin='<option value="0">--Select--</option>';
            if (myData[i].MinList != null) 
			{
                for (var e=0; e < myData[i].MinList.length; e++)
                {
                    var adt =  myData[i].MinList[e];
                    drpMin += '<option value="'+adt["min_no"]+'">'+adt["min_desc"]+' </option>';
                }    
            }
            else 
			{
                drpMin='<option value="0">--Select--</option>';
            }
                    
            tot += parseFloat(myData[i].iss_val);
            newRows +=  '<tr><td class="no">' + myData[i].itm_sno + 
                        '</td><td class="itmcd tdPadding">' + myData[i].itm_cd + 
                        '</td><td class="itmnm tdPadding wrapContent">' + myData[i].itm_desc + 
                        '</td><td class="uom tdPadding">' + myData[i].uom + 
                        '</td><td class="stock tdPadding" style="text-align: right;">' + myData[i].pre_stk_qty + 
                        '</td><td class ="reqqty tdPadding wrapContent controlSize"><input type="text" class="form-control reqqty tdPadding myTab" id="txtReqQty"  value=' + myData[i].req_qty + ' onchange ="txtReqQty_IndexChanged(this);"  maxlength="10" ondrop="return false;" onpaste="return false;" onkeydown="return (event.keyCode!=13);" onkeypress="return isNumberfloatKey(event,this,3);"/>' +
                        //'</td><td class="reqqty">' + myData[i].req_qty + 
                        '</td><td class="issqty tdPadding wrapContent controlSize"><input type="text" class="form-control issqty tdPadding myTab" id="txtIssQty"  value=' + myData[i].iss_qty + ' onchange ="txtIssQty_IndexChanged(this);"  maxlength="10" ondrop="return false;" onpaste="return false;" onkeydown="return (event.keyCode!=13);" onkeypress="return isNumberfloatKey(event,this,3);" />' + 
                        //'</td><td class="issqty">' + myData[i].iss_qty + 
                        '</td><td class="rate tdPadding" style="text-align: right;">' + myData[i].iss_rt + 
                        '</td><td class="totval tdPadding" style="text-align: right;">' + myData[i].iss_val + 
                        '</td><td class="consumpcent tdPadding controlSize"><select id="drpConCen" class="form-control select2 dropDowntext tdPadding myTab" onchange="drpConCenE_IndexChange(this);" style="width:200px;">' + ConsumptionCentre + '</select>' +
                        '</td><td class="costcent tdPadding controlSize"><select id="drpCosCen" class="form-control select2 dropDowntext tdPadding myTab" onchange="drpCosCenE_IndexChange(this);" style="width:200px;">' + CostCentre + '</select>' +
                        '</td><td class="nature tdPadding">' + myData[i].RetTyp + 
                        '</td><td class="rsn tdPadding">' + myData[i].Reason + 
                        '</td><td class="remark tdPadding">' + myData[i].Remark + 
                        '</td><td class="minno tdPadding controlSize"> <select id="drpMIN" class="form-control select2 dropDowntext tdPadding myTab" onchange="DisplayMINDetail(this)">' + drpMin + '</select>' +
                        '</td><td class="mindt tdPadding">' + myData[i].min_dt + 
                        '</td><td class="minqty tdPadding">' + myData[i].min_qty + 
                        '</td><td class="remqty tdPadding">' + myData[i].rem_qty + 
                        '</td><td class="ordno tdPadding">' + myData[i].OrdNo + 
                        '</td><td class="del tdPadding"><input type="button" id="btnDelete"  class="btn btn-primary tdPadding" value="Delete" onclick="rowDelete(this)"  /></td></tr>';
        }
        newRows +='</tbody>';
        newRows += '<tfoot><tr><th class="no"></th><th class="itmcd"></th><th class="itmnm">Grand Total</th><th class="uom"></th><th class="stock"></th><th class="reqqty"></th><th class="issqty"></th><th class="rate"></th><th class="totval">Tot Val</th><th class="consumpcent"></th><th class="costcent"></th><th class="nature"></th><th class="rsn"></th><th class="remark"></th><th class="minno"></th><th class="mindt"></th><th class="minqty"></th><th class="remqty"></th><th class="ordno"></th><th class="del"></th></tr></tfoot>';
        newRows +='</table>';

        document.getElementById("mivDIV").innerHTML = newRows;
        $('tfoot th:eq(8)').text(tot.toFixed(2));

        $("#MIVTable > tbody > tr").each(function(index, tr) 
        {
            $(tr).find("[id*=drpConCen]").val(myData[index].cons_cd.toString().trim());
            $(tr).find("[id*=drpCosCen]").val(myData[index].cc_cd.toString().trim());
            $(tr).find("[id*=drpMIN]").val(myData[index].min_no.toString().trim());

        });
        resolve("OK");
    });
}


function getMINList(com) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Main/getMINList",
            data: JSON.stringify({p: com}),
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



function getItemList() {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url:  "/Main/getItemList",
            data: "{}",
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


function getPending_Slip(varPar,varEmpCod) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Main/getPending_Slip",
              data: "{'varPar' : '" + varPar + "', 'varEmpCod' : '" + varEmpCod + "' }",
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


function get_Current_MIV_No() {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Main/get_Current_MIV_No",
              data: "{}",
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


function get_Current_Ret_No() {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Main/get_Current_Ret_No",
              data: "{}",
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



function SaveMivEntry(com) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Main/SaveMivEntry",
            data:  JSON.stringify({'p': com}),
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


function SaveMivAuthorize(com) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Main/SaveMivAuthorize",
            data:  JSON.stringify({'p': com}),
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



function MakeDataTable()
{
 table=  $("#MIVTable").removeAttr("width").DataTable({
        "JQueryUI" : false,
        "paging": false,
        "processing": true,
        "deferRender" : true,
        "destroy": true,  
        "autoWidth": false,
        "pageLength": 500,
        "scrollCollapse": true,
        "language": {
            "emptyTable": "No Data Found"
        },
        "autoWidth": "true",
        "fixedColumns": {
            "leftColumns": "2"
        },
        "scrollY": "400",
        "scrollX": "true"
    });
    table.order([ 0, "asc" ]).draw();
    $(".dataTables_length").hide();    
    $(".dataTables_filter").hide(); 
    $(".dataTables_info").hide();
    $(".dataTables_paginate").hide();
    setTimeout(function(){$.fn.dataTable.tables( { visible: false, api: true } ).columns.adjust().fixedColumns().relayout();}, 100);
    $(".table ").css({"width":"100%"});
}


async function rowDelete(ctl)
{
    var ErrMsg=null;
    try 
    {
//         var usercd= await  getSessionVariables();
        var usercd= $("#hdfUserName").val();
        if (usercd.length ==0)
        {
            $("[id*=lblMessage]").text("Session Expired").css('color', '#ff0000'); // Red color
            toastr.error("Session Expired", {timeOut: 200});
            setTimeout(window.location.href = "/Login/Login", 10000);
            return;
        }
        else if (usercd.length >0) 
        {
            if (usercd.toString().trim().toUpperCase() == "J16338")
            {
                PreserveRows();
            }
            else 
            {
                PreserveRows_otherUsers();
            }
            var row=$(ctl).closest("tr"); 
            var objIdx=0;
            var rowIndex = $(ctl).closest("tr")[0].sectionRowIndex;
            if ($('#MIVTable > tbody > tr').length > 1) 
            {
                dtable.findIndex(function (entry, i) 
                {
                    if (i == rowIndex) {
                        objIdx = i;
                        return true;
                    }
                });

                for (var n = 0 ; n < dtable.length ; n++) 
                {
                    if (rowIndex == n) {
                      var removedObject = dtable.splice(n,1);
                      removedObject = null;
                      break;
                    }
                }        
            }
            else 
            {
                ErrMsg="One row must required";
                throw ErrMsg;   
            }
            var prpMIVList=null; gridresult=null;
            if (usercd.toString().trim().toUpperCase() == "J16338") 
            {
                prpMIVList= await getMINList(dtable);
                populateGrid(prpMIVList).catch(function(reason) {ErrMsg = "Error while populate Grid" ;  throw ErrMsg;});
            }
            else if (usercd.toString().trim().toUpperCase() != "J16338") 
            {
                prpMIVList= dtable;
                populateGrid_OtherUsers(prpMIVList).catch(function(reason) {ErrMsg = "Error while populate Grid" ;  throw ErrMsg;}); 
            }

            SetttingsAfterMINSelection();
            $("[id*=btnCheck]").removeAttr("disabled");  // Enable True    
            $("[id*=btnSave]").attr("disabled", "disabled");   //Enable False
            $("[id*=btnaction]").attr("disabled", "disabled");  // Enable True  
            $("[id*=btncancel]").attr("disabled", "disabled");  // Enable True  
            $("[id*=btnadd]").removeAttr("disabled");  // Enable True
            $("[id*=btnCheck]").show();  // Visible True
            $("[id*=btnCheck]").removeAttr("disabled");  // Enable True
            $("[id*=btnaction]").hide();  // Visible True  
            if ($("[id*=btnSave]").text() == "Save") 
            { 
                hideShowColumn("remark",false );
                hideShowColumn("minno",false );
                hideShowColumn("mindt",false );
                hideShowColumn("minqty",false );
                hideShowColumn("remqty",false );   
            }


            MakeDataTable();
            if (ErrMsg==null) {
                $("[id*=lblMessage]").text("");
            }    
        }       
    } 
    catch (err)
    {
        $("[id*=lblMessage]").text(err).css('color', '#ff0000'); // Red color
        toastr.error(err, {timeOut: 200});
    }
}



function CreateRow_otherUsers()
{
//    dtable=[];
    var dr={};
    var tot=0;
     dr["itm_sno"] = $("#MIVTable > tbody > tr").length +1;
    dr["itm_cd"] =  $("input[id*=txtitmCd]").val(); 
    dr["itm_desc"] =   $("select[id*=DropDownList2] option:Selected").text().trim();
    dr["uom"] =     $("input[id*=txtUOM]").val();
    dr["pre_stk_qty"] =     parseFloat($("input[id*=txtPreStk]").val());   // CType(prow.FindControl("lblprestk"), Label).Text.Trim
    dr["req_qty"] =   parseFloat($("input[id*=txtReqireQty]").val());   //  CType(prow.FindControl("txtreqqty"), TextBox).Text.Trim
    dr["iss_qty"] =      parseFloat($("input[id*=txtIssueQty]").val());   // CType(prow.FindControl("txtissqty"), TextBox).Text.Trim
    dr["iss_rt"] = parseFloat($("input[id*=txtItmRat]").val());
    tot =parseFloat($("input[id*=txtIssueQty]").val()) * parseFloat($("input[id*=txtItmRat]").val())
    dr["iss_val"] = tot.toFixed(2) ;
    dr["cons_cd"] =    parseInt($("select[id*=drpConCen] option:Selected").val());   // CType(prow.FindControl("drpconcen"), DropDownList).SelectedValue
    dr["cc_cd"] =  parseFloat($("select[id*=drpCosCen] option:Selected").val());   // CType(prow.FindControl("drpcoscen"), DropDownList).SelectedValue
    if ($("select[id*=drpRetTyp] option:Selected").val() == "R") 
    {
        dr["RetTyp"]="Project";
    }
    else 
    {
         dr["RetTyp"]="";
    }   

    dr["Reason"] = $("input[id*=txtRetRes]").val().trim();
    dr["Remark"] =  $("input[id*=txtRemark]").val().trim();
    dr["min_no"] = 0;
    dr["min_dt"] = "";
    dr["min_qty"] = 0;
    dr["rem_qty"] =0;
    dr["OrdNo"] =  0;
    dr["cons_nm"] =  $("select[id*=drpConCen] option:Selected").text().trim();  
    dr["cc_nm"] = $("select[id*=drpCosCen] option:Selected").text().trim();  
    var tot = parseFloat($('tfoot th:eq(8)').text());
    tot += parseFloat(dr["iss_val"]);
    $('tfoot th:eq(8)').text(tot.toFixed(2));
    dtable.push(dr);
}



function CreateRow()
{
//    dtable=[];
    var dr={};
    var tot=0;
     dr["itm_sno"] = $("#MIVTable > tbody > tr").length +1;
    dr["itm_cd"] =  $("input[id*=txtitmCd]").val(); 
    dr["itm_desc"] =   $("select[id*=DropDownList2] option:Selected").text().trim();
    dr["uom"] =     $("input[id*=txtUOM]").val();
    dr["pre_stk_qty"] =     parseFloat($("input[id*=txtPreStk]").val());   // CType(prow.FindControl("lblprestk"), Label).Text.Trim
    dr["req_qty"] =   parseFloat($("input[id*=txtReqireQty]").val());   //  CType(prow.FindControl("txtreqqty"), TextBox).Text.Trim
    dr["iss_qty"] =      parseFloat($("input[id*=txtIssueQty]").val());   // CType(prow.FindControl("txtissqty"), TextBox).Text.Trim
    dr["iss_rt"] = parseFloat($("input[id*=txtItmRat]").val());
    tot =parseFloat($("input[id*=txtIssueQty]").val()) * parseFloat($("input[id*=txtItmRat]").val())
    dr["iss_val"] = tot.toFixed(2) ;
    dr["cons_cd"] =    parseInt($("select[id*=drpConCen] option:Selected").val());   // CType(prow.FindControl("drpconcen"), DropDownList).SelectedValue
    dr["cc_cd"] =  parseFloat($("select[id*=drpCosCen] option:Selected").val());   // CType(prow.FindControl("drpcoscen"), DropDownList).SelectedValue
    if ($("select[id*=drpRetTyp] option:Selected").val() == "R") 
    {
        dr["RetTyp"]="Project";
    }
    else 
    {
         dr["RetTyp"]="";
    }   

    dr["Reason"] = $("input[id*=txtRetRes]").val();
    dr["Remark"] =  $("input[id*=txtRemark]").val()
    dr["min_no"] = 0;
    dr["min_dt"] = "";
    dr["min_qty"] = 0;
    dr["rem_qty"] =0;
    dr["OrdNo"] =  0;
    var tot = parseFloat($('tfoot th:eq(8)').text());
    tot += parseFloat(dr["iss_val"]);
    $('tfoot th:eq(8)').text(tot.toFixed(2));
    dtable.push(dr);
}


function PreserveRows_otherUsers()
{
    var rowindex=0;
    var dr={};
    dtable=[];
    var tot=0;
    var k=0;var i=0;
    var mytag = (getQueryVariable("mytag")==false) ? 0 : parseInt(getQueryVariable("mytag").toString());

    $("#MIVTable > tbody > tr").each(function(index, tr) 
    {
        k++;
        dr = {};
        if (mytag == 20) {
            dr["itm_sno"] = k
        }
        else {
            dr["itm_sno"] = k
        }
        dr["itm_cd"] =  $(tr.cells[1]).text().trim();   
        dr["itm_desc"] =    $(tr.cells[2]).text().trim();  
        dr["uom"] =   $(tr.cells[3]).text().trim();  
        dr["pre_stk_qty"] =  parseFloat($(tr.cells[4]).text()); 
        dr["req_qty"] =     parseFloat($(tr.cells[5]).text());   
        dr["iss_qty"] =    parseFloat($(tr.cells[6]).text());  
        dr["iss_rt"] = parseFloat($(tr.cells[7]).text());   
        dr["iss_val"] = parseFloat($(tr.cells[8]).text()).toFixed(2);  
        dr["cons_cd"] = parseInt($(tr).find("[id*=txtcons_cd]").val());   
        dr["cc_cd"] =  parseFloat($(tr).find("[id*=txtcc_cd]").val());   
        dr["RetTyp"] = $(tr.cells[11]).text().trim();   
        dr["Reason"] =  $(tr.cells[12]).text().trim();  
        dr["Remark"] =  $(tr.cells[13]).text().trim();  
        dr["min_no"] = parseInt($(tr.cells[14]).text());  
        dr["min_dt"] = $(tr.cells[15]).text();  
        dr["min_qty"] = parseFloat( $(tr.cells[16]).text());   
        dr["rem_qty"] = parseFloat( $(tr.cells[17]).text());  
        dr["OrdNo"] =  parseFloat($(tr.cells[18]).text());   
        dr["cons_nm"] =  $(tr).find("[id*=txtcons_nm]").text().trim();  
        dr["cc_nm"] = $(tr).find("[id*=txtcc_nm]").text().trim(); 
        tot += parseFloat(dr["iss_val"]);
        dtable.push(dr);
        i++;
    });
}




function PreserveRows()
{
    var rowindex=0;
    var dr={};
    dtable=[];
    var tot=0;
    var k=0;var i=0;
    var mytag = (getQueryVariable("mytag")==false) ? 0 : parseInt(getQueryVariable("mytag").toString());

    $("#MIVTable > tbody > tr").each(function(index, tr) 
    {
        k++;
        dr = {};
        if (mytag == 20) {
            dr["itm_sno"] = k
        }
        else {
            dr["itm_sno"] = k
        }
        dr["itm_cd"] =  $(tr.cells[1]).text().trim();   //   CType(prow.FindControl("lblitmcd"), Label).Text.Trim
        dr["itm_desc"] =    $(tr.cells[2]).text().trim();   //   CType(prow.FindControl("lblitmdesc"), Label).Text.Trim
        dr["uom"] =     $(tr.cells[3]).text().trim();   //  CType(prow.FindControl("lbluom"), Label).Text.Trim
        dr["pre_stk_qty"] =     parseFloat($(tr.cells[4]).text());   // CType(prow.FindControl("lblprestk"), Label).Text.Trim
        dr["req_qty"] =     parseFloat($(tr).find("input[id*=txtReqQty]").val());   //  CType(prow.FindControl("txtreqqty"), TextBox).Text.Trim
        dr["iss_qty"] =     parseFloat($(tr).find("input[id*=txtIssQty]").val());   // CType(prow.FindControl("txtissqty"), TextBox).Text.Trim
        dr["iss_rt"] = parseFloat($(tr.cells[7]).text());   // CType(prow.FindControl("txtitmrat"), TextBox).Text.Trim
        dr["iss_val"] = parseFloat($(tr.cells[8]).text()).toFixed(2);   //  CType(prow.FindControl("txtissval"), TextBox).Text.Trim
        dr["cons_cd"] = parseInt($(tr).find("[id*=drpConCen] option:Selected").val());   // CType(prow.FindControl("drpconcen"), DropDownList).SelectedValue
        dr["cc_cd"] =  parseFloat($(tr).find("[id*=drpCosCen] option:Selected").val());   // CType(prow.FindControl("drpcoscen"), DropDownList).SelectedValue
        dr["RetTyp"] = $(tr.cells[11]).text().trim();   //  CType(prow.FindControl("lblRetTyp"), Label).Text.Trim
        dr["Reason"] =  $(tr.cells[12]).text().trim();   // CType(prow.FindControl("lblrea"), Label).Text.Trim
        dr["Remark"] =  $(tr.cells[13]).text().trim();   // CType(prow.FindControl("lblRem"), Label).Text.Trim
        dr["min_no"] = parseInt( $(tr).find("[id*=drpMIN] option:Selected").val());   // CType(prow.FindControl("lblMinNo"), Label).Text.Trim
        dr["min_dt"] = $(tr.cells[15]).text();   // CType(prow.FindControl("lblMinDat"), Label).Text.Trim
        dr["min_qty"] = parseFloat( $(tr.cells[16]).text());   // CType(prow.FindControl("lblMinQty"), Label).Text.Trim
        dr["rem_qty"] = parseFloat( $(tr.cells[17]).text());   // CType(prow.FindControl("lblRemQty"), Label).Text.Trim
        dr["OrdNo"] =  parseFloat($(tr.cells[18]).text());   // CType(prow.FindControl("lblOrdNo"), Label).Text.Trim
        tot += parseFloat(dr["iss_val"]);
        dtable.push(dr);
        i++;
    });
}


function ControlBlank()
{
    $("input[id*=txtitmCd]").val("");
    document.getElementById("DropDownList2").value="0";
    $("input[id*=txtUOM]").val("");
    $("input[id*=txtReqireQty]").val("0");
    $("input[id*=txtIssueQty]").val("0"); 
    $("input[id*=txtissval]").val("0");
    $("input[id*=txtItmRat]").val("0");
    $("input[id*=txtPreStk]").val("0");
    document.getElementById("drpConCen").value="0";
    document.getElementById("drpCosCen").value="0";
    document.getElementById("drpRetTyp").value="0";
    $("input[id*=txtRetRes]").val("");
    $("input[id*=txtRemark]").val("");
    $("input[id*=remark]").hide();
}

async function showitemsLookup()
{
//    var usercd= await  getSessionVariables();
    var usercd= $("#hdfUserName").val();
	if (usercd.length ==0)
	{
		$("[id*=lblMessage]").text("Session Expired").css('color', '#ff0000'); // Red color
		toastr.error("Session Expired", {timeOut: 200});
		setTimeout(window.location.href = "/Login/Login", 10000);
		return;
	}
    if(usercd.length > 0)
	{
		$("#ShowItemsModal").modal("toggle");
	}  
}



async function drpMivTyp_IndexChange()
{
//    var usercd= await  getSessionVariables();
    var usercd= $("#hdfUserName").val();
    if (usercd.length ==0)
    {
        $("[id*=lblMessage]").text("Session Expired").css('color', '#ff0000'); // Red color
        toastr.error("Session Expired", {timeOut: 200});
        setTimeout(window.location.href = "/Login/Login", 10000);
        return;
    }
    if(usercd.length > 0)
	{
        if ($("[id*=drpMivTyp] option:Selected").val() == "P") 
        {
            $("[id*=nature]").show();
            $("[id*=reason_activity_Name]").show();
        }
        else 
        {
            $("[id*=nature]").hide();
            $("[id*=reason_activity_Name]").hide();   
        }
	}  
}

function collect_Pmivdtl()
{
    return new Promise(function(resolve,reject)
    {
        var objPrpPmivdtl=new Object();
        var btnSave =$("[id*=btnSave]");
        var btnCheck =$("[id*=btnCheck]");
        var lblempcd= $("input[id*=hdfempcd]");
        var txtMivNo=$("input[id*=txtMivNo]");
        var  txtMivDate =$("[id*=txtMivDate]");
        var hdfRetNo=$("input[id*=hdfRetNo]");
        var drpMivTyp= $("[id*=drpMivTyp] option:Selected");
        var hdfdeptcd =$("[id*=hdfdeptcd]");
        var hdfAutCod = $("input[id*=hdfAutCod]");
        ////////current date////////////
        var currdt= new Date();
        currdt = (currdt.getMonth()+1) + '/' + currdt.getDate() + '/' + Math.abs(currdt.getFullYear());
        ///////////end/////////////////
        var mivdt = new Date($("[id*=txtMivDate]").val());
        mivdt = (mivdt.getMonth()+1) + '/' + mivdt.getDate() + '/' + Math.abs(mivdt.getFullYear());
        var PRP_pmivdtl_List=[]; var dr={};
	    $("#MIVTable > tbody > tr").each(function(index, tr) 
	    {
            var lblsrno =$(tr.cells[0]);
            var lblItmCd=$(tr.cells[1]);
            var lblItmdesc=$(tr.cells[2]);
            var lblUOM=$(tr.cells[3]);
            var lblPreStk =$(tr.cells[4]);
            var txtReqQty= $(tr).find("input[id*=txtReqQty]");
            var txtIssQty = $(tr).find("input[id*=txtIssQty]");
            var txtItmRat =$(tr.cells[7]);
            var txtIssval =$(tr.cells[8]);
            var drpConCen =$(tr).find("select[id*=drpConCen] option:Selected");
            var drpCosCen =$(tr).find("select[id*=drpCosCen] option:Selected");
            var lblRetTyp=$(tr.cells[11]);
            var lblRea=$(tr.cells[12]);
            var lblRem=$(tr.cells[13]);
            var drpMinNo= $(tr).find("[id*=drpMIN] option:Selected");
            var lblMinDt =$(tr.cells[15]);
            var lblMinQty = $(tr.cells[16]);
            var lblRemQty = $(tr.cells[17]);
            var lblOrdNo= $(tr.cells[18]);

            dr={};
            dr["itm_sno"] = parseInt(lblsrno.text());
            dr["itm_cd"] = lblItmCd.text().trim();
            dr["itm_desc"] = lblItmdesc.text().trim();
            dr["uom"] =    lblUOM.text().trim();  
            dr["pre_stk_qty"] =   parseFloat(lblPreStk.text()); 
            dr["req_qty"] =     parseFloat(txtReqQty.val());  
            dr["iss_qty"] =     parseFloat(txtIssQty.val());  
            dr["iss_rt"] = parseFloat(txtItmRat.text());  
            dr["iss_val"] = parseFloat(txtIssval.text());  
            dr["cons_cd"] = parseFloat(drpConCen.val());   
            dr["cc_cd"] =  parseFloat(drpCosCen.val());  
            dr["RetTyp"] = lblRetTyp.text();
            dr["Reason"] = lblRea.text();
            dr["Remark"] =  lblRem.text();
            dr["min_no"] = parseInt(drpMinNo.val()); 
            dr["min_dt"] = lblMinDt.text();
            dr["min_qty"] = parseFloat(lblMinQty.text()); 
            dr["rem_qty"] = parseFloat(lblRemQty.text()); 
            dr["OrdNo"] =  parseFloat(lblOrdNo.text()); 
            dr["sbu_cd"] = 414200;
            dr["iss_yard"] = "01";
            dr["luser_id"] = lblempcd.val();  
            dr["auth_id"] =  hdfAutCod.val();  
            dr["lupd_dt"] = ChangeDateFormat1(currdt);   
            dr["auth_dt"] =  ChangeDateFormat1(currdt);   
            dr["miv_no"] =  txtMivNo.val();   
            dr["miv_dt"] =  ChangeDateFormat1(mivdt);        
            dr["miv_yr"] = Math.abs(new Date(txtMivDate.val()).getFullYear());
            dr["Ret_no"] = hdfRetNo.val();
            PRP_pmivdtl_List.push(dr);
        });
        resolve(PRP_pmivdtl_List); 
    });
}


function collect_Pmivdtl_OtherUsers()
{
    return new Promise(function(resolve,reject)
    {
        var objPrpPmivdtl=new Object();
        var btnSave =$("[id*=btnSave]");
        var btnCheck =$("[id*=btnCheck]");
        var lblempcd= $("input[id*=hdfempcd]");
      //  var txtMivNo=$("input[id*=txtMivNo]");
        var hdfMivNo=$("input[id*=hdfMivNo]");
        var  txtMivDate =$("[id*=txtMivDate]");
        var hdfRetNo=$("input[id*=hdfRetNo]");
        var drpMivTyp= $("[id*=drpMivTyp] option:Selected");
        var hdfdeptcd =$("[id*=hdfdeptcd]");
        var hdfAutCod = $("input[id*=hdfAutCod]");
        ////////current date////////////
        var currdt= new Date();
        currdt = (currdt.getMonth()+1) + '/' + currdt.getDate() + '/' + Math.abs(currdt.getFullYear());
        ///////////end/////////////////
        var mivdt = new Date($("[id*=txtMivDate]").val());
        mivdt = (mivdt.getMonth()+1) + '/' + mivdt.getDate() + '/' + Math.abs(mivdt.getFullYear());
        var PRP_pmivdtl_List=[]; var dr={};
	    $("#MIVTable > tbody > tr").each(function(index, tr) 
	    {
            var lblsrno =$(tr.cells[0]);
            var lblItmCd=$(tr.cells[1]);
            var lblItmdesc=$(tr.cells[2]);
            var lblUOM=$(tr.cells[3]);
            var lblPreStk =$(tr.cells[4]);
            var txtReqQty= $(tr.cells[5]);
            var txtIssQty = $(tr.cells[6]);
            var txtItmRat =$(tr.cells[7]);
            var txtIssval =$(tr.cells[8]);
            var drpConCen =$(tr).find("[id*=txtcons_cd]");
            var drpCosCen =$(tr).find("[id*=txtcc_cd]");
            var lblRetTyp=$(tr.cells[11]);
            var lblRea=$(tr.cells[12]);
            var lblRem=$(tr.cells[13]);
            var drpMinNo= $(tr.cells[14]);
            var lblMinDt =$(tr.cells[15]);
            var lblMinQty = $(tr.cells[16]);
            var lblRemQty = $(tr.cells[17]);
            var lblOrdNo= $(tr.cells[18]);

            dr={};
            dr["itm_sno"] = parseInt(lblsrno.text());
            dr["itm_cd"] = lblItmCd.text().trim();
            dr["itm_desc"] = lblItmdesc.text().trim();
            dr["uom"] =    lblUOM.text().trim();  
            dr["pre_stk_qty"] =   parseFloat(lblPreStk.text()); 
            dr["req_qty"] =     parseFloat(txtReqQty.text());  
            dr["iss_qty"] =     parseFloat(txtIssQty.text());  
            dr["iss_rt"] = parseFloat(txtItmRat.text());  
            dr["iss_val"] = parseFloat(txtIssval.text());  
            dr["cons_cd"] = parseFloat(drpConCen.val());   
            dr["cc_cd"] =  parseFloat(drpCosCen.val());  
            dr["RetTyp"] = lblRetTyp.text();
            dr["Reason"] = lblRea.text();
            dr["Remark"] =  lblRem.text();
            dr["min_qty"] = parseFloat(lblMinQty.text()); 
            dr["rem_qty"] = parseFloat(lblRemQty.text()); 
            dr["OrdNo"] =  parseFloat(lblOrdNo.text()); 
            dr["sbu_cd"] = 414200;
            dr["iss_yard"] = "01";
            dr["luser_id"] = lblempcd.val();  
            dr["auth_id"] =  hdfAutCod.val();  
            dr["lupd_dt"] = ChangeDateFormat1(currdt);   
            dr["auth_dt"] =  ChangeDateFormat1(currdt);   
            dr["miv_no"] =  hdfMivNo.val();  //  txtMivNo.val();   
            dr["miv_dt"] =  ChangeDateFormat1(mivdt);        
            dr["miv_yr"] = Math.abs(new Date(txtMivDate.val()).getFullYear());
            dr["Ret_no"] =  hdfRetNo.val();
            PRP_pmivdtl_List.push(dr);
        });
        resolve(PRP_pmivdtl_List); 
    });
}




async function btnSave_Click()
{
    var btnSave =$("[id*=btnSave]");
    var btnCheck =$("[id*=btnCheck]");
    var btnaction =$("[id*=btnaction]");
    var btncancel =$("[id*=btncancel]");
    var lblempcd =$("[id*=hdfempcd]");
    var txtMivNo=$("input[id*=txtMivNo]");
    var hdfMivNo=$("input[id*=hdfMivNo]");
    var hdfRetNo=$("input[id*=hdfRetNo]");
    var drpMivTyp= $("[id*=drpMivTyp] option:Selected");
    var hdfdeptcd =$("[id*=hdfdeptcd]");
    var  txtMivDate =$("[id*=txtMivDate]");
    var Panelsp =$("[id*=Panelsp]");  
  
    
    ////////current date////////////
    var currdt= new Date();
    currdt = (currdt.getMonth()+1) + '/' + currdt.getDate() + '/' + Math.abs(currdt.getFullYear());
    ///////////end/////////////////
    var mivdt = new Date(txtMivDate.val());
    mivdt = (mivdt.getMonth()+1) + '/' + mivdt.getDate() + '/' + Math.abs(mivdt.getFullYear());
    var res =null;
    var ErrMsg=null;
    var objPrpPmivhdr = new Object();
    try {
//	    var usercd= await  getSessionVariables();
        var usercd= $("#hdfUserName").val();
	    if (usercd.length ==0)
	    {
		    $("[id*=lblMessage]").text("Session Expired").css('color', '#ff0000'); // Red color
		    toastr.error("Session Expired", {timeOut: 200});
		    setTimeout(window.location.href = "/Login/Login", 10000);
		    return;
	    }
//        lblempcd.val(usercd.toString().trim().toUpperCase());

        if (btnSave.text() == "Save") 
        {
            //////////////////Save Button/////////////////////////
			if($("#MIVTable > tbody > tr").length >0)
			{
				$(".loader").fadeIn();
				hdfMivNo.val(0);
				hdfRetNo.val(0);
				objPrpPmivhdr = new Object();
				objPrpPmivhdr.miv_no =  parseFloat(hdfMivNo.val());  //   parseFloat(txtMivNo.val());  
				objPrpPmivhdr.miv_yr =  Math.abs(new Date(txtMivDate.val()).getFullYear());  
				objPrpPmivhdr.miv_dt = ChangeDateFormat1(mivdt);  
				objPrpPmivhdr.inv_typ = drpMivTyp.val();  
				objPrpPmivhdr.dept_cd = hdfdeptcd.val();   
				objPrpPmivhdr.cc_cd = 1;
				objPrpPmivhdr.status = "O";
				objPrpPmivhdr.luser_id =usercd.toString().trim().toUpperCase();  
				objPrpPmivhdr.lupd_dt = ChangeDateFormat1(currdt);
				objPrpPmivhdr.auth_dt = ChangeDateFormat1(currdt); 
				objPrpPmivhdr.btnsaveText=btnSave.text();
				res=null;
				if (usercd.toString().trim().toUpperCase() != "J16338")
				{
					res = await collect_Pmivdtl_OtherUsers();
				}
				else
				{
					res = await collect_Pmivdtl();
				}

				if (!res) 
				{
					 ErrMsg=("An Error while Saving grid Record");
					 throw ErrMsg;
				}
				objPrpPmivhdr.pmivdtl_List = res
				var res1=null; 
				res1 = await SaveMivEntry(objPrpPmivhdr);
				if (res1.response == -1) {
					ErrMsg =res1.responseMsg;
					throw ErrMsg;
				}
				txtMivNo.val(res1.responseObject.miv_no );
				hdfMivNo.val(res1.responseObject.miv_no );
				$("[id*=lblMessage]").text(res1.responseMsg).css('color', '#008000'); // Green color
				toastr.success(res1.responseMsg, {timeOut: 200});
				btnCheck.attr("disabled","disabled");
				btnSave.attr("disabled","disabled");
				Panelsp.hide();
				$("#MIVTable").attr("disabled","disabled");
				drpMivTyp.attr("disabled","disabled");
				txtMivNo.val(hdfMivNo.val());
				txtMivDate.attr("disabled","disabled");   
				$(".loader").fadeOut();
			}
            ///////////////////end/////////////////////////
        }
        else if (btnSave.text() == "Update") 
        {
			if($("#MIVTable > tbody > tr").length >0)
			{
				$(".loader").fadeIn();
				objPrpPmivhdr = new Object();
				if (usercd.toString().trim().toUpperCase() != "J16338")
				{
					hdfMivNo.val(txtMivNo.val());
					objPrpPmivhdr.miv_no = parseFloat(hdfMivNo.val());  
				}
				else
				{
					objPrpPmivhdr.miv_no = parseFloat(txtMivNo.val());  
				}
				
				objPrpPmivhdr.miv_yr =  Math.abs(new Date(txtMivDate.val()).getFullYear());  
				objPrpPmivhdr.miv_dt = ChangeDateFormat1(mivdt);  
				objPrpPmivhdr.inv_typ = drpMivTyp.val();  
				objPrpPmivhdr.dept_cd = hdfdeptcd.val();   
				objPrpPmivhdr.cc_cd = 1;
	//            objPrpPmivhdr.status = "O";
				objPrpPmivhdr.luser_id =usercd.toString().trim().toUpperCase();  
				objPrpPmivhdr.lupd_dt = ChangeDateFormat1(currdt);
				objPrpPmivhdr.auth_dt = ChangeDateFormat1(currdt); 
				objPrpPmivhdr.btnsaveText=btnSave.text();
				res=null;
				if (usercd.toString().trim().toUpperCase() != "J16338")
				{
					 res = await collect_Pmivdtl_OtherUsers();
				}
				else
				{
					res = await collect_Pmivdtl();
				}
				if (!res) 
				{
					 ErrMsg=("An Error while updating grid Record");
					 throw ErrMsg;
				}
				objPrpPmivhdr.pmivdtl_List = res
				var res1=null; 
				res1 = await SaveMivEntry(objPrpPmivhdr);
				if (res1.response == -1) {
					ErrMsg =res1.responseMsg;
					throw ErrMsg;
				}
				$("[id*=lblMessage]").text(res1.responseMsg).css('color', '#008000'); // Green color
				toastr.success(res1.responseMsg, {timeOut: 200});

				btnCheck.attr("disabled","disabled"); //Enable False
				btnSave.attr("disabled","disabled"); //Enable False
				btnCheck.hide();
				btnSave.hide();
				btnaction.show();
				btnaction.removeAttr("disabled");  //Enable True 
				if (btnaction.text() == "Approve" && btnaction.is(':visible')) {
					btncancel.show();
				}
				else
				{
					btncancel.hide();
				}
				$(".loader").fadeOut();
			}
        }
    } 
    catch (err) 
    {
          $("[id*=lblMessage]").text(err).css('color', '#ff0000'); // Red color
          toastr.error(err, {timeOut: 200});
           $(".loader").fadeOut();
    }
    finally
    {
     $(".loader").fadeOut();
    }
}


async function btncancel_Click()
{
   var ErrMsg=null;
    try 
    {
        $(".loader").fadeIn(); 
         var mivdt= new Date($("[id*=txtMivDt]").val());    //new Date(getQueryVariable("mivdt").toString());
         var mivno =  $("[id*=txtMivNo]").val();   // parseInt(getQueryVariable("mivno").toString());
        var currdate=new Date();
        var objPrpPmivhdr = new Object();
        objPrpPmivhdr.auth_id = $("[id*=hdfUserID]");  
        objPrpPmivhdr.auth_id = ChangeDateFormat1(currdate)  ;  
        objPrpPmivhdr.miv_no = parseInt(mivno);       
        objPrpPmivhdr.miv_yr = Math.abs(mindt.getFullYear());  

        var mindt1 = new Date($("[id*=txtMivDate]").val());
        var res1=  await CancelMIV(objPrpPmivhdr);
        if (res1.response == -1) {
             ErrMsg = (res1.responseMsg);
             throw ErrMsg;
        }
        $("[id*=lblMessage]").text("MIV is Canceled.").css('color', '#008000'); // Green color;
         toastr.success("MIV is Canceled.", {timeOut: 200});   
        $("[id*=btnaction]").attr("disabled","disabled");
        $("[id*=btncancel]").attr("disabled","disabled");
        var strUrl ="Inbox.aspx";
        setTimeout(window.location.href = strUrl, 10000);
        if (ErrMsg == null) 
        {
            $("[id*=lblMessage]").text("");
        } 

    } 
    catch (err) 
    {
        $("[id*=lblMessage]").text(err).css('color', '#ff0000'); // Red color
        toastr.error(err, {timeOut: 200});   
    }
    finally
    {
      $(".loader").fadeOut(); 
    }
}

function CancelMIV(com) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Main/CancelMIV",
            data: JSON.stringify({p: com}),
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

function CancelMailFunction(varmivno,varmivyr) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Main/CancelMailFunction",
            data: "{'varmivno' : '" + varmivno + "', 'varmivyr' : '" + varmivyr + "' }",
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

function MailFunction(varmivno,varmivyr) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Main/MailFunction",
            data: "{'varmivno' : '" + varmivno + "', 'varmivyr' : '" + varmivyr + "' }",
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



function drpCosCen_IndexChanged()
{
    if ($("[id*=drpCosCen] option:Selected").val() == "12048") 
    {
        $("[id*=remark]").show()  // Visible true
    }
    else 
    {
        $("[id*=remark]").hide()  // Visible false
    }
}

function btnexit_click()
{
    var strUrl = '/Home/Home';
    setTimeout(window.location.href = strUrl, 10000);
}


async function btnaction_Click()
{
    var btnSave =$("[id*=btnSave]");
    var btnCheck =$("[id*=btnCheck]");
    var btnaction =$("[id*=btnaction]");
    var btncancel =$("[id*=btncancel]");
    var lblempcd =$("[id*=hdfempcd]");
    var txtMivNo=$("input[id*=txtMivNo]");
    var hdfRetNo=$("input[id*=hdfRetNo]");
    var drpMivTyp = $("[id*=drpMivTyp] option:Selected");
    var hdfdeptcd =$("[id*=hdfdeptcd]");
    var  txtMivDate =$("[id*=txtMivDate]");
    var Panelsp =$("[id*=Panelsp]");  
    var hdfAppCod=  $("[id*=hdfAppCod]"); 
    var hdfAutCod =$("[id*=hdfAutCod]"); 
    var txtReason  =$("[id*=txtReason]"); 
    ////////current date////////////
    var currdt= new Date();
    currdt = (currdt.getMonth()+1) + '/' + currdt.getDate() + '/' + Math.abs(currdt.getFullYear());
    ///////////end/////////////////
    var mivdt = new Date(txtMivDate.val());
    mivdt = (mivdt.getMonth()+1) + '/' + mivdt.getDate() + '/' + Math.abs(mivdt.getFullYear());
    var res =null;
    var ErrMsg=null;
    var varretno=0;
    var objPrpPmivinbox = new Object();
    var objPrpPmivhdr = new Object();
    try 
    {
        $(".loader").fadeIn(); 
       // var ucd = await getSessionVariables();
        var usercd= $("#hdfUserName").val();
        if (ucd.length == 0)
        {
//            ErrMsg="Session is Expired , Please Login Again";
//            throw ErrMsg; 
              $("[id*=lblMessage]").text("Session is Expired , Please Login Again").css('color', '#ff0000'); // Red color 
              toastr.success( "Session is Expired , Please Login Again", {timeOut: 1000});
              setTimeout(window.location.href = "/Login/Login", 10000);
        }
        $("[id*=hdfUserID]").val(ucd.toString().trim());
        if ($("[id*=btnaction]").text() == "Forward") 
        {   
            ///////////////////Forward Code//////////////////////
            objPrpPmivinbox = new Object();
            objPrpPmivinbox.par = 1;
            objPrpPmivinbox.Sta = 1;
            objPrpPmivinbox.Auth_Cd1 = hdfAppCod.val();
            objPrpPmivinbox.Tra = "F";
            objPrpPmivinbox.Miv_No = parseInt(txtMivNo.val()); 
            objPrpPmivinbox.Miv_dt =  ChangeDateFormat1(mivdt);
//            res= await MailFunction(mivno,Math.abs(new Date(txtMivDate.val()).getFullYear()));
//            if (res.response == -1) {
//                ErrMsg= res.responseMsg;
//                throw ErrMsg;
//            }
            res=null;
            res=  await Update_Pmivinbox(objPrpPmivinbox);
            if (res.response == -1) {
                    ErrMsg =res.responseMsg;
                    throw ErrMsg;
            }
            $("[id*=lblMessage]").text("MIV is forwarded to Approver authority Successfully.").css('color', '#008000'); // Green color
//            $("[id*=lblMessage]").css('backgroundColor', '#008000'); // Green color
            toastr.success( "MIV is forwarded to Approver authority Successfully.", {timeOut: 200});
            btnaction.attr("disabled","disabled");    //    .Enabled = False
            btnCheck.attr("disabled","disabled");    //     Enabled = False 
            setTimeout(window.location.href = "Inbox.aspx", 5000);   
            ////////////////////////End//////////////////////////
        }
        else if ($("[id*=btnaction]").text() == "Approve") 
        {
            ////////////////////Approve Code/////////////////////
            var objPrpPmivinbox = new Object();
            objPrpPmivinbox.par = 2;
            objPrpPmivinbox.Sta = 1;
            objPrpPmivinbox.Auth_Cd1 = hdfAutCod.val();
            objPrpPmivinbox.Miv_No = parseInt(txtMivNo.val()); 
            objPrpPmivinbox.Miv_dt =  ChangeDateFormat1(mivdt);   
//            res=null;
//            res= await MailFunction(mivno, Math.abs(new Date(txtMivDate.val()).getFullYear()));
//            if (res.response == -1) {
//                ErrMsg =res.responseMsg;
//                throw ErrMsg;
//            }
            res=null;
            res =  await Update_Pmivinbox(objPrpPmivinbox);
            if (res.response == -1) {
                    ErrMsg =res.responseMsg;
                    throw ErrMsg;
            }
            $("[id*=lblMessage]").text("MIV is Approved  Successfully.").css('color', '#008000'); // Green color
            toastr.success( "MIV is Approved  Successfully.", {timeOut: 200});
            btnaction.attr("disabled","disabled");    //    .Enabled = False
            btncancel.hide();   //visible=false
            btnCheck.attr("disabled","disabled");    //     Enabled = False 
             setTimeout(window.location.href = "Inbox.aspx", 5000);   
            ///////////////////End///////////////////////////
        }
        else if ($("[id*=btnaction]").text() == "Authorize") 
        {
			////////////////////Authorize Code/////////////////////
            var rcnt=0;
            var k=0;
            var negChec=0;
            var tot =0;
            var min_notSelected =0;
	        rcnt= $("#MIVTable > tbody > tr").length;    //GrdMivDet.Rows.Count
	        $("#MIVTable > tbody > tr").each(function(index, tr) 
	        {
                var totval=0;
                var itemcode=null;
                itemcode=$(tr.cells[1]).text().trim();
                totval= parseFloat($(tr.cells[8]).text());
		        if($(tr).find("input[id*=txtIssQty]").val() <= 0)
		        {
			        k++;
		        }
//                tot += parseFloat($(tr.cells[8]).text());
//                if ($(tr).find("[id*=drpMIN] option:Selected").val() == "0") 
//                {
//                    min_notSelected += 1;
//                }
                if (totval >= 10000 && drpMivTyp.val() =="P" && ucd.toString().trim().toUpperCase() =="J16338" && $(tr).find("[id*=drpMIN] option:Selected").val() == "0") 
                {
                    min_notSelected=1;
                    $(tr.cells[1]).removeClass("sorting_desc");  //    .css('background-color', 'Red');
                     $(tr.cells[1]).addClass("sorting_asc");
                     $(tr).addClass("tabcolor");
                    ErrMsg= String.format("Please select MIN for Item Code : {0}",itemcode);
                    return false;
                }
                $(tr).removeClass('tabcolor');
	        });
            
	        if (k == rcnt) {
		        if ($("[id*=txtReason]").val() == "")
		        {
                    ErrMsg="Give Reason To Cancel MIV.";
                    throw ErrMsg;
		        }
	        }
            //------If the Total Amount is greater then or equal to 10000 and User_cd ='J16338' as well as If min is not selected.----
//            if (tot >= 10000 && drpMivTyp.val() =="P" && $("[id*=hdfUserID]").val() =="J16338" && min_notSelected >0) 
//            {
//                ErrMsg="Please select Min No.";
//                throw ErrMsg;    
//            }
            if(min_notSelected ==1)
            {
                throw ErrMsg;
            }


            objPrpPmivhdr = new Object();
            objPrpPmivhdr.miv_no = parseFloat(txtMivNo.val());  
            objPrpPmivhdr.miv_yr =  Math.abs(new Date(txtMivDate.val()).getFullYear());  
            objPrpPmivhdr.miv_dt = ChangeDateFormat1(mivdt);  
            objPrpPmivhdr.inv_typ = drpMivTyp.val();  
            objPrpPmivhdr.dept_cd = hdfdeptcd.val();   
            objPrpPmivhdr.cc_cd = 1;
            objPrpPmivhdr.status = "A";
            objPrpPmivhdr.Auth_Cd2=ucd.toString().trim().toUpperCase();  //   $("[id*=hdfUserID]").val().trim(); 
            objPrpPmivhdr.auth_id = ucd.toString().trim().toUpperCase();  //   $("[id*=hdfUserID]").val().trim(); 
            objPrpPmivhdr.lupd_dt = ChangeDateFormat1(currdt);
            objPrpPmivhdr.auth_dt = ChangeDateFormat1(currdt); 
            objPrpPmivhdr.btnsaveText=btnSave.text();
            res=null;
            if ($("[id*=hdfUserID]").val().trim().toUpperCase() != "J16338")
            {
                res = await collect_Pmivdtl_OtherUsers();
            }
            else
            {
                res = await  collect_Pmivdtl();
            }
            
            if (!res) 
            {
		         ErrMsg="An Error while updating grid Record";
		         throw ErrMsg;
            }
            objPrpPmivhdr.pmivdtl_List = res
            var res1=null; 
            res1 = await SaveMivAuthorize(objPrpPmivhdr);
            if (res1.response == -1) {
                ErrMsg =res1.responseMsg;
                throw ErrMsg;
            }
            $("[id*=lblMessage]").text("MIV is Authorized  Successfully.").css('color', '#008000'); // Green color
            toastr.success( "MIV is Authorized  Successfully.", {timeOut: 200});
            btnaction.attr("disabled","disabled");    //    .Enabled = False
            btnCheck.attr("disabled","disabled");    //     Enabled = False 
            setTimeout(window.location.href = "Inbox.aspx", 5000);   
     
            /////////////////////////End///////////////////////////
        }
    } 
    catch (err) 
    {
        $("[id*=lblMessage]").text(err).css('color', '#ff0000'); // Red color
        toastr.error(err, {timeOut: 200});        
    }
    finally
    {
      $(".loader").fadeOut(); 
    }
}


function getPreStock1(itmcd) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Main/getPreStock1",
            data: "{'varitmcd' : '" + itmcd + "' }",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                var myData = mData.d;
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



function Update_Pmivinbox(com) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Main/Update_Pmivinbox",
            data: JSON.stringify({p: com}),
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                var myData = mData.d;
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



async function btnItemSearch_Click()
{
  var ErrMsg=null;
    try 
    {
        $(".loader").fadeIn(); 
        var txtItemCode= $("[id*=txtItemCode]");
        var res= await getItems(txtItemCode.val());
        if (res.response == -1) {
            ErrMsg =(String.format("{0}, check sp : NSM_Display_Detail", res.responseMsg));
            return;
        }
        var myData= res.responseObjectList;
        var ddSubItem='<option value="0">--Select--</option>'
        for (var e=0; e < myData.length; e++)
        {
            var st =  myData[e];
            ddSubItem += '<option value="'+st["itm_cd"]+'">'+st["itm_desc"]+' </option>';
        }
         $("[id*=ddSubItem]").empty();
          $("[id*=ddSubItem]").append(ddSubItem);



//        var ddSubItem = $("[id*=ddSubItem]");
//        ddSubItem.empty().append('<option selected="selected" value="0">--Select--</option>');
//        $.each(myData, function () 
//        {
//            ddSubItem.append($("<option></option>").val(this['itm_cd']).html(this['itm_desc']));
//        }); 
        if (ErrMsg != null) {
            throw ErrMsg;
        }   
    } 
    catch (err) 
    {
        $("[id*=lblMessage]").text(err).css('color', '#ff0000'); // Red color
         toastr.error(err, {timeOut: 200});    
    }
    finally{
        $(".loader").fadeOut(); 
    }

}



function getItems(itmcd) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Main/getItems",
            data: "{'varitmcd' : '" + itmcd + "' }",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                var myData = mData.d;
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

async function ddSubItem_IndexChanged()
{
   var ErrMsg=null;
   $(".loader").fadeIn();
    try 
    {
         var rt=0
        var ddlSubItem = $("[id*=ddSubItem] option:Selected");
        var res = await getItemDetail(ddlSubItem.val());
        if (res.response == -1) {
            ErrMsg =(res.responseMsg);
            throw ErrMsg;
        }
        var objpitmasterprp= res.responseObject;

        var res1 = await getPreStock(ddlSubItem.val());
        if (res1.response == -1) {
            ErrMsg =(res1.responseMsg);
            throw ErrMsg;
        }
        $("[id*=txtUOM]").val(objpitmasterprp.uom);
        document.getElementById("DropDownList2").value =objpitmasterprp.itm_cd;
    //    $("[id*=DropDownList2] option:Selected").val(objpitmasterprp.itm_cd);
        $("[id*=txtItmRat]").val(objpitmasterprp.rate);
        $("[id*=txtPreStk]").val(res1.preStock);
        $("[id*=txtitmCd]").val(objpitmasterprp.itm_cd);
        $("[id*=txtitmCd]").removeClass('tabcolor');
        $("[id*=lblMessage]").text("");
    //    var res2 = await getItemRate(objpitmasterprp.itm_cd); 
    //    if (res1.response == -1) {
    //        ErrMsg =(res1.responseMsg);
    //        return;
    //    }
    //    rt = res2.responseObject.rate;
    //    if (rt > 0 ) {
    //    
    //    }
        $("[id*=txtIssueQty]").val($("[id*=txtReqireQty]").val());
        var tot = parseFloat($("[id*=txtIssueQty]").val() ) * parseFloat($("[id*=txtItmRat]").val() )
        $("[id*=txtissval]").val(tot.toFixed(2));
        $("#ShowItemsModal").modal("hide");  //  .modal("toggle");  
    } 
    catch (err) 
    {
     $("[id*=lblMessage]").text(err).css('color', '#ff0000'); // Red color
      toastr.error(err, {timeOut: 200});
    }
    finally
    {
      $(".loader").fadeOut();
    }
}

function getItemRate(itmcd) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Main/getItemRate",
            data: "{'varitmcd' : '" + itmcd + "' }",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                var myData = mData.d;
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


function getPreStock(itmcd) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Main/getPreStock",
            data: "{'varitmcd' : '" + itmcd + "' }",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                var myData = mData.d;
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


function getItemDetail(itmcd) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Main/getItemDetail",
            data: "{'varitmcd' : '" + itmcd + "' }",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                var myData = mData.d;
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

function getItemDetail1(itmcd) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Main/getItemDetail1",
            data: "{'varitmcd' : '" + itmcd + "' }",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                var myData = mData.d;
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





function getMINDetail(par,itmcd) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Main/getMINDetail",
            data: "{'varpar' : '" + par + "', 'varItmCod' : '" + itmcd + "' }",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                var myData = mData.d;
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

function SetttingsAfterMINSelection()
{
    var i = 0;
    var usercd = $("[id*=hdfUserID]").val();
    var sta =(getQueryVariable("sta")==false) ? 0 : parseInt(getQueryVariable("sta").toString());
    var mytag =  (getQueryVariable("mytag")==false) ? 0 : parseInt(getQueryVariable("mytag").toString());    
	if (mytag == 20) 
    {
		hideShowColumn("remark",false );
		if ($("[id*=hdfMivStg]").val() == "Entry Mode") 
		{
            $("[id*=btnSave]").text("Update");  //.attr('value', 'Update');
            hideShowColumn("issqty",false );
		}
        if ($("[id*=hdfMivStg]").val() == "Entry Mode") 
		{
            $("[id*=btnSave]").text("Update");  //.attr('value', 'Update');
            if (sta == 0) 
            {
                hideShowColumn("issqty",false );
	
			}
            else if(sta == 1) 
            {
                hideShowColumn("issqty",false );
	
			}
            else if(sta == 2) 
            {
                hideShowColumn("issqty",true );
                hideShowColumn("minno",true );
                hideShowColumn("mindt",true );
                hideShowColumn("minqty",true );
                hideShowColumn("remqty",true );
	
			}			
		}
        if ($("[id*=hdfMivStg]").val() == "Entry Mode") 
        {
            if (sta == 0) 
            {
                hideShowColumn("issqty",false );
            }
            else if(sta == 1) 
            {
                hideShowColumn("issqty",false );
            }
            else if(sta == 2) 
            {
                hideShowColumn("issqty",true );
                hideShowColumn("minno",true );
                hideShowColumn("mindt",true );
                hideShowColumn("minqty",true );
                hideShowColumn("remqty",true );
            }			
		}	
        if ($("[id*=hdfUserID]").val().toUpperCase() == "J16338" ) 
        {
            hideShowColumn("del",false );
        }
        if (sta == 1) 
        {
            hideShowColumn("del",false );
        }	
	}
    if (sta == 1 && mytag == 20 ) 
    {
        $("[id*=MIVTable]").attr("disabled","disabled");
    }
    else if (sta == 2 && mytag == 20 ) 
    {
        $("[id*=MIVTable]").attr("disabled","disabled");
//        enableDisableColumn("reqqty",false);
//        enableDisableColumn("issqty",true);
        $("#MIVTable > tbody > tr").each(function(index, tr) 
        {
            if ($("[id*=hdfUserID]").val().toUpperCase() == "J16338") 
            {
                $(tr).find("input[id*=txtReqQty]").prop("disabled",true);
                $(tr).find("input[id*=txtIssQty]").prop("disabled",false);
            }
        });


        if (getQueryVariable("invtyp").toString() == "Consumable") 
        {
            hideShowColumn("nature",false );
            hideShowColumn("rsn",false );
        }
        else 
        {
            hideShowColumn("nature",true );
            hideShowColumn("rsn",true );
        }
    }
    if (mytag == 30) 
    {
        hideShowColumn("remark",false );
//        ' calculatestock()
        //GrdMivDet.Columns(18).Visible = False
          hideShowColumn("del",false );
	}
    //use for testing
//    hideShowColumn("del",true );	
}


function validateFloatKeyPress(el, evt) 
{
    var charCode = (evt.which) ? evt.which : event.keyCode;
    var number = el.value.split('.');
    if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) 
    {
        return false;
    }
    //just one dot
    if (number.length > 1 && charCode == 46) 
    {
        return false;
    }
    //get the carat position
    var caratPos = getSelectionStart(el);
    var dotPos = el.value.indexOf(".");
    if (caratPos > dotPos && dotPos > -1 && (number[1].length > 1)) 
    {
        return false;
    }
    return true;
}

function getSelectionStart(o) {
    if (o.createTextRange) 
    {
        var r = document.selection.createRange().duplicate()
        r.moveEnd('character', o.value.length)
        if (r.text == '') return o.value.length
        return o.value.lastIndexOf(r.text)
    } 
    else return o.selectionStart
}


function check_validation_OtherUsers() 
{
    return new Promise(async function(resolve, reject) 
    {
       var j=0;
       var sta =(getQueryVariable("sta")==false) ? 0 : parseInt(getQueryVariable("sta").toString())
	
	   $("[id*=lblMessage]").text("");

        if ($("[id*=txtMivDate]").val() == "" ) 
        {
            $("[id*=txtMivDate]").addClass('tabcolor');
            reject("Select MIV Date"); 
        }
        if ($("[id*=txtMivDate]").val() !="" ) 
        {
            var mvdt=null;var curdt=null;
            var mivdt = new Date($("[id*=txtMivDate]").val());
            mvdt = (mivdt.getMonth()+1) + '/' + mivdt.getDate() + '/' + Math.abs(mivdt.getFullYear());
            var currdt= new Date();
            curdt = (currdt.getMonth()+1) + '/' + currdt.getDate() + '/' + Math.abs(currdt.getFullYear());
            if (new Date(mvdt) > new Date(curdt)) 
            {
                $("[id*=txtMivDate]").addClass('tabcolor');
                reject("Miv Date Can't be greater than Current Date");
            }
        }
        if ($("[id*=drpMivTyp] option:selected").val() =="0") 
        {
            $("[id*=drpMivTyp]").addClass('tabcolor');
            reject("Select MIV Type");
        }
        else 
        {
            if($("#MIVTable > tbody > tr").length >0)
            {
                $("#MIVTable > tbody > tr").each(function(index, tr)  
                {
                    if (parseFloat($(tr.cells[6]).text()) > parseFloat($(tr.cells[5]).text()))
                    {
                       $(tr.cells[6]).addClass('tabcolor');
                        reject("Iss. Qty can not be greater than Stock Qty."); 
                    }
                    else if ($(tr.cells[1]).text().length ==0 ) 
                    {
                       $(tr.cells[5]).addClass('tabcolor');
                        reject("Some of Item Code is Blank");                          
                    }
                    else if ($(tr.cells[1]).text().length  != 7 ) 
                    {
                        $(tr.cells[1]).addClass('tabcolor');
                        reject("Item Code must be in 7 Character.");
                    }
                    else if ($(tr.cells[4]).text().length  <= 0 ) 
                    {
                        $(tr.cells[4]).addClass('tabcolor');   
                        reject("PreStock Qty must greater than zero");                           
                    }
                    else if(parseFloat($(tr.cells[5]).text())  <= 0 ) 
                    {
                        if(sta < 1) 
                        {
                          $(tr.cells[5]).addClass('tabcolor');   
                            reject("Req Qty must greater than zero");   
                        }
				    }
                    else if (parseFloat($(tr.cells[5]).text()) > parseFloat($(tr.cells[4]).text())) 
                    {
                       $(tr.cells[5]).addClass('tabcolor');
                       reject("Req Qty can not be greater thatn Stock Qty.");     
                    }
                    else if (parseFloat($(tr.cells[6]).text()) <= 0) 
                    {
                        if ($("[id*=hdfUserID]").val().toUpperCase() != "J16338") 
                        {
                            $(tr.cells[6]).addClass('tabcolor');
                            reject("Iss Qty must greater than zero");    
                        }
                    }
                    else if (parseFloat($(tr.cells[6]).text()) > parseFloat($(tr.cells[5]).text())) 
                    {
                        $(tr.cells[6]).addClass('tabcolor');
                        reject("Iss Qty can not be greater thatn Req Qty");     
                    }
                    else if (parseFloat($(tr.cells[7]).text()) < 0) 
                    {
                        $(tr.cells[7]).addClass('tabcolor');
                        reject("Item Rate can't be negative");         
                    }
                    else if (parseFloat($(tr.cells[8]).text()) < 0) 
                    {
                       $(tr.cells[8]).addClass('tabcolor');
                        reject("Issue Value can't be negative");         
                    }				
                    else if ($(tr).find("[id*=txtcons_cd]").val() == 0) 
                    {
                       $(tr).find("[id*=txtcons_nm]").addClass('tabcolor');
                        reject("Select Consumption Centre");     
                    }
                    else if ($(tr).find("[id*=txtcc_cd]").val() == 0) 
                    {
                       $(tr).find("[id*=txtcc_nm]").addClass('tabcolor');
                        reject("This cost centre can't be selected.");        
                    }
                    else if ($(tr).find("[id*=txtcc_cd]").val() == "11220" || $(tr).find("[id*=txtcc_cd]").val() == "11930" || $(tr).find("[id*=txtcc_cd]").val() == "11937" || $(tr).find("[id*=txtcc_cd]").val() == "11940" || $(tr).find("[id*=txtcc_cd]").val() == "11941" || $(tr).find("[id*=txtcc_cd]").val() == "11942")                 
                    {
                        $(tr).find("[id*=txtcc_nm]").addClass('tabcolor');
                        reject("This cost centre can't be selected.");       
                    }
                    else 
                    {
                        $(tr.cells[1]).removeClass('tabcolor');  
                       $(tr.cells[5]).removeClass('tabcolor');  
                       $(tr.cells[6]).removeClass('tabcolor');
                        $(tr.cells[7]).removeClass('tabcolor');
                        $(tr.cells[8]).removeClass('tabcolor');
                        $(tr).find("[id*=txtcc_nm]").removeClass('tabcolor');
                        $(tr).find("[id*=txtcons_nm]").removeClass('tabcolor');

                        var fg=0;
                        $("#MIVTable > tbody > tr").each(function(index1, tr1) 
                        {
                            if (($(tr.cells[1]).text() == $(tr1.cells[1]).text())  && ($(tr).find("[id*=txtcons_cd]").val() == $(tr1).find("[id*=drpConCen] option:Selected").val())  && ($(tr).find("[id*=txtcons_cd]").val() == $(tr1).find("[id*=drpConCen] option:Selected").val())) 
                            {
                                fg++;
                            }
                            if (fg > 1 &&  sta != 2) 
                            {
                               // $(tr.cells[1]).css('color', '#ff0000'); // Red color
                               // $(tr).find("[id*=txtcons_nm]").css('backgroundColor', '#ff0000'); // Red color
                               $(tr.cells[1]).addClass('tabcolor');
                               $(tr).find("[id*=txtcons_nm]").addClass('tabcolor');
                                reject("Same Item Can't be Selected For Same Cost/Consumption Centre Again.");  
                            }
                            else  
                            {
//                                $(tr.cells[1]).css('color', '#000000'); // Black color
//                                $(tr).find("[id*=txtcons_nm]").css('backgroundColor', '#fff'); // white color
                                $(tr.cells[1]).removeClass('tabcolor');
                                $(tr).find("[id*=txtcons_nm]").removeClass('tabcolor');
                            }                     
                        }); 

					    var io=0;
					    j=0
					    if ($(tr.cells[6]).text().length != 0 && $(tr.cells[7]).text().length !=0 ) 
					    {
						    if ($(tr.cells[6]).text().length > 0  && $(tr.cells[7]).text().length > 0  ) 
						    {
							    $(tr.cells[8]).text(parseFloat($(tr.cells[6]).text()) * parseFloat($(tr.cells[7]).text()));
							    j += parseFloat($(tr.cells[8]).text());
						    }
					    }
//					    resolve("Record is Validated.");
                        resolve("VALID");
					    $('tfoot th:eq(8)').text(j);
                        MakeDataTable();
                    }
			    });
            }
//            else
//            {
//                reject("detail is empty");
//            }
            if ($('#MIVTable tr').length < 0)
            {
                reject("No Item Detail in Voucher"); 
            } 
        }
	});
}






function check_validation() 
{
    return new Promise(async function (resolve, reject) 
    {
       var j=0;
       var sta =(getQueryVariable("sta")==false) ? 0 : parseInt(getQueryVariable("sta").toString())
	
	   $("[id*=lblMessage]").text("");

        if ($("[id*=txtMivDate]").val() == "" ) 
        {
            $("[id*=txtMivDate]").addClass('tabcolor');
            reject("Select MIV Date"); 
        }
        if ($("[id*=txtMivDate]").val() !="" ) 
        {
            var mvdt=null;var curdt=null;
            var mivdt = new Date($("[id*=txtMivDate]").val());
            mvdt = (mivdt.getMonth()+1) + '/' + mivdt.getDate() + '/' + Math.abs(mivdt.getFullYear());
            var currdt= new Date();
            curdt = (currdt.getMonth()+1) + '/' + currdt.getDate() + '/' + Math.abs(currdt.getFullYear());
            if (new Date(mvdt) > new Date(curdt)) 
            {
                $("[id*=txtMivDate]").addClass('tabcolor');
                reject("Miv Date Can't be greater than Current Date");
            }
        }
        if ($("[id*=drpMivTyp] option:selected").val() =="0") 
        {
            $("[id*=drpMivTyp]").addClass('tabcolor');
            reject("Select MIV Type");
        }
        else 
        {
            if($("#MIVTable > tbody > tr").length >0)
            {
                $("#MIVTable > tbody > tr").each(function(index, tr)  
                {
                    if (parseFloat($(tr).find("input[id*=txtIssQty]").val()) > parseFloat($(tr).find("input[id*=txtReqQty]").val()))
                    {
                        $(tr).find("input[id*=txtIssQty]").addClass('tabcolor');
//                        $(tr).find("input[id*=txtIssQty]").css('backgroundColor', '#FFB6C1');   //Light Pink
                        reject("Iss. Qty can not be greater than Stock Qty."); 
                    }
                    else if ($(tr.cells[1]).text().length ==0 ) 
                    {
//                        $(tr).find("input[id*=txtReqQty]").css('backgroundColor', '#FFB6C1');   //Light Pink
                        $(tr).find("input[id*=txtReqQty]").addClass('tabcolor');
                        reject("Some of Item Code is Blank");                          
                    }
                    else if ($(tr.cells[1]).text().length  != 7 ) 
                    {
                      //  $(tr.cells[1]).css('backgroundColor', '#FFB6C1');   //Light Pink
                        $(tr.cells[1]).addClass('tabcolor');
                        reject("Item Code must be in 7 Character.");
                    }
                    else if ($(tr.cells[4]).text().length  <= 0 ) 
                    {
                        $(tr.cells[4]).addClass('tabcolor');   
                        reject("PreStock Qty must greater than zero");                           
                    }
                    else if(parseFloat($(tr).find("input[id*=txtReqQty]").val())  <= 0 ) 
                    {
                        if(sta < 1) 
                        {
                           //$(tr).find("input[id*=txtReqQty]").css('backgroundColor', '#FFB6C1');   //Light Pink
                           $(tr).find("input[id*=txtReqQty]").addClass('tabcolor');   
                            reject("Req Qty must greater than zero");   
                        }
				    }
                    else if (parseFloat($(tr).find("input[id*=txtReqQty]").val()) > parseFloat($(tr.cells[4]).text())) 
                    {
                        //$(tr).find("input[id*=txtReqQty]").css('backgroundColor', '#FFB6C1');   //Light Pink
                        $(tr).find("input[id*=txtReqQty]").addClass('tabcolor');
                        reject("Req Qty can not be greater thatn Stock Qty.");     
                    }
                    else if (parseFloat($(tr).find("input[id*=txtIssQty]").val()) > parseFloat($(tr).find("input[id*=txtReqQty]").val())) 
                    {
                        //$(tr).find("input[id*=txtIssQty]").css('backgroundColor', '#FFB6C1');   //Light Pink
                        $(tr).find("input[id*=txtIssQty]").addClass('tabcolor');
                        reject("Iss Qty can not be greater thatn Req Qty");     
                    }
                    else if (parseFloat($(tr.cells[7]).text()) < 0) 
                    {
                       // $(tr.cells[7]).css('backgroundColor', '#FFB6C1');   //Light Pink
                       $(tr.cells[7]).addClass('tabcolor');
                        reject("Item Rate can't be negative");         
                    }
                    else if (parseFloat($(tr.cells[8]).text()) < 0) 
                    {
                       // $(tr.cells[8]).css('backgroundColor', '#FFB6C1');   //Light Pink
                       $(tr.cells[8]).addClass('tabcolor');
                        reject("Issue Value can't be negative");         
                    }				
                    else if ($(tr).find("[id*=drpConCen] option:Selected").val() == 0) 
                    {
                       // $(tr).find("[id*=drpConCen]").css('backgroundColor', '#FFB6C1');   //Light Pink
                       $(tr).find("[id*=drpConCen]").addClass('tabcolor');
                        reject("Select Consumption Centre");     
                    }
                    else if ($(tr).find("[id*=drpCosCen] option:Selected").val() == 0) 
                    {
                       // $(tr).find("[id*=drpCosCen]").css('backgroundColor', '#FFB6C1');   //Light Pink
                       $(tr).find("[id*=drpCosCen]").addClass('tabcolor');
                        reject("This cost centre can't be selected.");        
                    }
                    else if ($(tr).find("[id*=drpCosCen] option:Selected").val() == "11220" || $(tr).find("[id*=drpCosCen] option:Selected").val() == "11930" || $(tr).find("[id*=drpCosCen] option:Selected").val() == "11937" || $(tr).find("[id*=drpCosCen] option:Selected").val() == "11940" || $(tr).find("[id*=drpCosCen] option:Selected").val() == "11941" || $(tr).find("[id*=drpCosCen] option:Selected").val() == "11942")                 
                    {
                        //$(tr).find("[id*=drpCosCen]").css('backgroundColor', '#FFB6C1');   //Light Pink
                        $(tr).find("[id*=drpCosCen]").addClass('tabcolor');
                        reject("This cost centre can't be selected.");       
                    }
                    else 
                    {
//                        $(tr.cells[1]).css('backgroundColor', '#fff');   
//                        $(tr).find("input[id*=txtReqQty]").css('backgroundColor', '#fff');   
//                        $(tr).find("input[id*=txtIssQty]").css('backgroundColor', '#fff');   
//                        $(tr.cells[7]).css('backgroundColor', '#fff'); 
//                        $(tr.cells[8]).css('backgroundColor', '#fff');   
//                        $(tr).find("[id*=drpCosCen]").css('backgroundColor', '#fff');   
//                        $(tr).find("[id*=drpConCen]").css('backgroundColor', '#fff');  
                        $(tr.cells[1]).removeClass('tabcolor');  
                        $(tr).find("input[id*=txtReqQty]").removeClass('tabcolor');  
                        $(tr).find("input[id*=txtIssQty]").removeClass('tabcolor');
                        $(tr.cells[7]).removeClass('tabcolor');
                        $(tr.cells[8]).removeClass('tabcolor');
                        $(tr).find("[id*=drpCosCen]").removeClass('tabcolor');
                        $(tr).find("[id*=drpConCen]").removeClass('tabcolor');

                        var fg=0;
                        $("#MIVTable > tbody > tr").each(function(index1, tr1) 
                        {
                            if (($(tr.cells[1]).text() == $(tr1.cells[1]).text())  && ($(tr).find("[id*=drpConCen] option:Selected").val() == $(tr1).find("[id*=drpConCen] option:Selected").val())  && ($(tr).find("[id*=drpConCen] option:Selected").val() == $(tr1).find("[id*=drpConCen] option:Selected").val())) 
                            {
                                fg++;
                            }
                            if (fg > 1 &&  sta != 2) 
                            {
                               // $(tr.cells[1]).css('color', '#ff0000'); // Red color
                               // $(tr).find("[id*=drpConCen]").css('backgroundColor', '#ff0000'); // Red color
                               $(tr.cells[1]).addClass('tabcolor');
                               $(tr).find("[id*=drpConCen]").addClass('tabcolor');
                                reject("Same Item Can't be Selected For Same Cost/Consumption Centre Again.");  
                            }
                            else  
                            {
//                                $(tr.cells[1]).css('color', '#000000'); // Black color
//                                $(tr).find("[id*=drpConCen]").css('backgroundColor', '#fff'); // white color
                                $(tr.cells[1]).removeClass('tabcolor');
                                $(tr).find("[id*=drpConCen]").removeClass('tabcolor');
                            }                     
                        }); 

					    var io=0;
					    j=0
					    if ($(tr).find("input[id*=txtIssQty]").val().length != 0 && $(tr.cells[7]).text().length !=0 ) 
					    {
						    if ($(tr).find("input[id*=txtIssQty]").val().length > 0  && $(tr.cells[7]).text().length > 0  ) 
						    {
							    $(tr.cells[8]).text(parseFloat($(tr).find("input[id*=txtIssQty]").val()) * parseFloat($(tr.cells[7]).text()));
							    j += parseFloat($(tr.cells[8]).text());
						    }
					    }
//					    resolve("Record is Validated.");
                        resolve("VALID");
					    $('tfoot th:eq(8)').text(j);
                        MakeDataTable();
                    }
			    });
            }
//            else
//            {
//                reject("detail is empty");
//            }
            if ($('#MIVTable tr').length < 0)
            {
                reject("No Item Detail in Voucher"); 
            } 
        }
	});
}



////////////////////STart Control Events //////////////////////////////

async function btnCheck_Click()
{
    var ErrMsg=null;
    try 
    {
        $(".loader").fadeIn();
        var sta =(getQueryVariable("sta")==false) ? 0 : parseInt(getQueryVariable("sta").toString());
        var btncheck =$("[id*=btncheck]");
       // var usercd= await  getSessionVariables();
        var usercd= $("#hdfUserName").val();
        if (usercd.length ==0)
        {
            $("[id*=lblMessage]").text("Session Expired");
            toastr.error("Session Expired", {timeOut: 200});
            setTimeout(window.location.href = "/Login/Login", 10000);
            return;
        }
        else if(usercd.length != 0)
        {
//            $("[id*=hdfempcd]").val(usercd.toString().trim());
            var res=null;
			if($("#MIVTable > tbody > tr").length >0)
			{
				if (usercd.toString().trim().toUpperCase() == "J16338")
				{
					res = await check_validation();            
				}
				else
				{
					res= await check_validation_OtherUsers();
				}

				if (res != "VALID") 
				{
					ErrMsg= res;
					throw ErrMsg; 
				}
				else
				{
					$("[id*=mivEntryDetail]").find("input,button,textarea,select").removeClass('tabcolor');
					var result="Record is Validated.";
					$("[id*=lblMessage]").text(result).css('color', '#008000'); // Green color
					toastr.success( result, {timeOut: 200});

					$("[id*=btnSave]").show();
					$("[id*=btnSave]").removeAttr("disabled");
					$("[id*=btnaction]").hide();
					if (sta == 1  && $("[id*=btnSave]").text() == "Update" && $("[id*=btnaction]").text() == "Approve") 
					{
						$("[id*=btncancel]").show();
					}
					else 
					{
						$("[id*=btncancel]").hide();
					}         
				}
			}
			else if($("#MIVTable > tbody > tr").length==0)
			{
				toastr.error( "There are no row available for Validation", {timeOut: 200});
			}
        }

        if (ErrMsg ==null) 
        {
            $("[id*=lblMessage]").text("");
        }
        $(".loader").fadeOut();    
    } 
    catch (err) 
    {
        if (err != null && err !== undefined) 
        {
//            $("[id*=lblMessage]").text(err).css('color', '#ff0000'); // Red color 
//            toastr.error( err, {timeOut: 200});
//            $(".loader").fadeOut(); 
        }
    }
}



function validationInAdd()
{
    return new Promise(function(resolve,reject){
         $("[id*=txtIssueQty]").val($("[id*=txtReqireQty]").val());
        if($("[id*=drpMivTyp] option:Selected").val()=="0")
        {
           $("[id*=drpMivTyp]").addClass('tabcolor');
            reject("Select Type");
        }
        else if ($("[id*=drpMivTyp] option:Selected").val() == "P" && $("[id*=drpRetTyp] option:Selected").val() == "0") 
        {
            $("[id*=drpRetTyp]").addClass('tabcolor');
             reject("Select Nature.");     
        } 
        else if($("[id*=drpMivTyp] option:Selected").val() == "P" && $("[id*=txtRetRes]").val().length ==0)
        {
            $("[id*=txtRetRes]").addClass('tabcolor');
            reject("Reason/Activity Name is required");
        }
        else if ($("input[id*=txtitmCd]").val().length == 0 || $("input[id*=txtitmCd]").val()=="0" ) 
        { 
            $("input[id*=txtitmCd]").addClass('tabcolor');
           reject("Item Code Can't be Blank.");
        }
        else if ($("[id*=txtReqireQty]").val() == 0) 
        {
           $("[id*=txtReqireQty]").addClass('tabcolor');
           reject("Requested Qty Can't be Blank.");     
        }
        else if ($("[id*=txtReqireQty]").val() <= 0) 
        {
           $("[id*=txtReqireQty]").addClass('tabcolor');
           reject("Requested Qty should be greated that zero.");     
        }  
        else if (parseFloat($("[id*=txtReqireQty]").val()) > parseFloat($("[id*=txtPreStk]").val())) 
        {
            $("[id*=txtReqireQty]").addClass('tabcolor');
            reject("Requested Qty Can't be greater than Stock Qty.");     
        }   
        else if ($("[id*=txtIssueQty]").val().length == 0) 
        {
            $("[id*=txtIssueQty]").addClass('tabcolor');
            reject("Issue Qty Can't be Blank.");       
        }         
        else if ($("[id*=txtIssueQty]").val().length <= 0) 
        {
             $("[id*=txtIssueQty]").addClass('tabcolor');
            reject("Issue Qty should be greated than zero.");      
        }   
        else if ($("[id*=txtIssueQty]").val() > $("[id*=txtReqireQty]").val()) 
        {
             $("[id*=txtIssueQty]").addClass('tabcolor');
            reject("Issue Qty Can't be greater than Req. Qty.");     
        }  
        else if ($("[id*=drpConCen] option:Selected").val() == "0") 
        {
             $("[id*=drpConCen]").addClass('tabcolor'); 
            reject("Select Consumption Centre.");      
        }   
        else if ($("[id*=drpCosCen] option:Selected").val() == "0") 
        {
            $("[id*=drpCosCen]").addClass('tabcolor'); 
            reject("Select cost Centre.");      
        }    
        else if ($("[id*=drpCosCen] option:Selected").val() == "11220" || $("[id*=drpCosCen] option:Selected").val() == "11929" || $("[id*=drpCosCen] option:Selected").val() == "11930" || $("[id*=drpCosCen] option:Selected").val() == "11937" || $("[id*=drpCosCen] option:Selected").val() == "11940" || $("[id*=drpCosCen] option:Selected").val() == "11941" || $("[id*=drpCosCen] option:Selected").val() == "11942")                 
        {
            $("[id*=drpCosCen]").addClass('tabcolor'); 
            reject("This cost centre can't be selected.");  
        }   
        else 
        {
            if ($("[id*=drpCosCen] option:Selected").val() == "12048" && $("[id*=txtRemark]").val().length ==0 ) 
            {
                $("[id*=drpCosCen]").addClass('tabcolor'); 
                reject("Please give remark in case Rejected Material Return");    
            }
         }           
        resolve("Validate");
    });
}


async function btnadd_Click()
{
	//var usercd= await  getSessionVariables();
    var usercd= $("#hdfUserName").val();
	if (usercd.length ==0)
	{
        $("[id*=mivEntryDetail]").find("input,button,textarea,select").removeClass('tabcolor');
		$("[id*=lblMessage]").text("Session Expired").css('color', '#ff0000'); // Red color
		toastr.error("Session Expired", {timeOut: 200});
		setTimeout(window.location.href = "/Login/Login", 10000);
		return;
	}

    $(".loader").fadeIn();
    $("[id*=lblMessage]").text(""); 
	validationInAdd().then(async function(result)
	{
		$("[id*=mivEntryDetail]").find("input,button,textarea,select").removeClass('tabcolor');
		$("[id*=lblMessage]").text(""); 


		var prpMIVList=null;
		gridresult=null;
		if (usercd.toString().trim().toUpperCase() == "J16338") 
		{
			PreserveRows();
			CreateRow();  // ' To Add New Row In Grid 
			prpMIVList= await getMINList(dtable);
			 populateGrid(prpMIVList).catch(function(reason) {ErrMsg = "Error while populate Grid" ;  throw ErrMsg;});
//            gridresult = await populateGrid(prpMIVList);
//            if (gridresult != "OK") {
//                    ErrMsg = "Error while populate Grid";
//                throw ErrMsg;
//            }
		}
		else if (usercd.toString().trim().toUpperCase() != "J16338") 
		{
			PreserveRows_otherUsers();
			CreateRow_otherUsers();
			prpMIVList=dtable;
			populateGrid_OtherUsers(prpMIVList).catch(function(reason) {ErrMsg = "Error while populate Grid" ;  throw ErrMsg;});
//            populateGrid_OtherUsers(prpMIVList)
//            gridresult = await populateGrid_OtherUsers(prpMIVList);
//            if (gridresult != "OK") {
//                    ErrMsg = "Error while populate Grid";
//                throw ErrMsg;
//            }    
		}

		 $(".loader").fadeOut(); 
		SetttingsAfterMINSelection();

		hideShowColumn("issqty",false);        
		hideShowColumn("remark",false);
		hideShowColumn("minno",false);
		hideShowColumn("mindt",false);
		hideShowColumn("minqty",false);
		hideShowColumn("remqty",false);
		$("#MIVTable > tbody > tr").each(function(index, tr) 
		{
			 if (usercd.toString().trim().toUpperCase() == "J16338") 
			 {
				$(tr).find("input[id*=txtReqQty]").prop("disabled",true);
				$(tr).find("input[id*=txtReqQty]").removeClass("form-control");
				$(tr).find("input[id*=txtReqQty]").addClass("form-control-plaintext");
			}
		});
		 MakeDataTable();
		$("[id*=lblMessage]").text("One New Row is Added").css('color', '#008000');
		toastr.success( "One New Row is Added", {timeOut: 200});
		ControlBlank();
		if ($("[id*=btnaction]").text() == "Forward") 
		{
			$("[id*=btnCheck]").show();
			$("[id*=btnCheck]").removeAttr("disabled");  //Enable True
			$("[id*=btnaction]").hide();
		}
		$("[id*=drpMivTyp]").attr("disabled", "disabled");

		
	}).catch(function(error)
	{

		$("[id*=lblMessage]").text(error).css('color', '#ff0000'); // Red color
		toastr.error( error, {timeOut: 200});
		$(".loader").fadeOut();  
	});
}


async function txtReqireQty_TextChanged()
{
	//var usercd= await  getSessionVariables();
    var usercd= $("#hdfUserName").val();
	if (usercd.length ==0)
	{
		$("[id*=lblMessage]").text("Session Expired").css('color', '#ff0000'); // Red color
		toastr.error("Session Expired", {timeOut: 200});
		setTimeout(window.location.href = "/Login/Login", 10000);
		return;
	}
	if(usercd.length > 0)
	{
        if (parseFloat($("[id*=txtReqireQty]").val()) > parseFloat($("[id*=txtPreStk]").val())) 
        {
            $("[id*=lblMessage]").text("Req. Qty can't be greater than Stock Qty.").css('color', '#ff0000'); // Red color
            toastr.error( "Req. Qty can't be greater than Stock Qty.", {timeOut: 200});;
            return;
        }
        else 
        {
            $("[id*=lblMessage]").text("");
            $("[id*=lblMessage2]").text("");    
        }
        $("[id*=txtIssueQty]").val($("[id*=txtReqireQty]").val());
        var tot=parseFloat($("[id*=txtIssueQty]").val()) * parseFloat($("[id*=txtItmRat]").val());
        $("[id*=txtissval]").val(tot.toFixed(2));	
	}
}

function txtIssQty_TextChanged()
{
    $("[id*=txtissval]").val(parseFloat($("[id*=txtIssueQty]").val()) * parseFloat($("[id*=txtItmRat]").val()));
}

async function txtitmCd_TextChanged()
{
	//var usercd= await  getSessionVariables();
    var usercd= $("#hdfUserName").val();
	if (usercd.length ==0)
	{
		$("[id*=lblMessage]").text("Session Expired").css('color', '#ff0000'); // Red color
		toastr.error("Session Expired", {timeOut: 200});
		setTimeout(window.location.href = "/Login/Login", 10000);
		return;
	}
	if(usercd.length > 0)
	{
        var ErrMsg=null; var rt=0;
        $(".loader").fadeIn();  
        var txtitmCd= $("input[id*=txtitmCd]");
        var txtUOM = $("input[id*=txtUOM]");
        var DropDownList2 = $("select[id*=DropDownList2]");
        var txtItmRat =$("input[id*=txtItmRat]");
        var txtPreStk = $("input[id*=txtPreStk]");
        var txtIssueQty = $("input[id*=txtIssueQty]");
        var txtItmRat =  $("input[id*=txtItmRat]");
        var txtissval = $("input[id*=txtissval]");
        var txtReqireQty =  $("input[id*=txtReqireQty]");
        try 
        {
            var res = await getItemDetail(txtitmCd.val().trim());
            if (res.response == -1) 
            {
                txtUOM.val("");
                DropDownList2.val("0");
                txtItmRat.val("0");
                txtPreStk.val("0");
                txtIssueQty.val("0");
                txtissval.val("0");
                ErrMsg =(res.responseMsg);
                throw ErrMsg;
            }
            var objpitmasterprp= res.responseObject;
            txtitmCd.val(objpitmasterprp.itm_cd);
            DropDownList2.val(objpitmasterprp.itm_cd);
            txtUOM.val(objpitmasterprp.uom);
            txtItmRat.val(objpitmasterprp.rate);
            txtPreStk.val(objpitmasterprp.stk_qty);
            txtIssueQty.val(0); //  txtIssQty.Text.Trim
            var tot = parseFloat(txtIssueQty.val()) * parseFloat(txtItmRat.val());
            txtissval.val(tot.toFixed(2));   
            $("[id*=mivEntryDetail]").find("input,button,textarea,select").removeClass('tabcolor');
        } 
        catch (err) 
        {
            $("[id*=lblMessage]").text(err).css('color', '#ff0000'); // Red color
            $(".loader").fadeOut();  
        }
        finally
        {
            $(".loader").fadeOut();  
        }
	}
}

async function DropDownList2_IndexChange()
{
    var rt=0;
    var ErrMsg=null;
    $(".loader").fadeIn();  
    var txtitmCd= $("input[id*=txtitmCd]");
    var txtUOM = $("input[id*=txtUOM]");
    var DropDownList2 = $("select[id*=DropDownList2]");
    var txtItmRat =$("input[id*=txtItmRat]");
    var txtPreStk = $("input[id*=txtPreStk]");
    var txtIssueQty = $("input[id*=txtIssueQty]");
    var txtItmRat =  $("input[id*=txtItmRat]");
    var txtissval = $("input[id*=txtissval]");
    try 
    {
        var res = await getItemDetail(DropDownList2.val().trim());
        if (res.response == -1) {
            txtUOM.val("");
            DropDownList2.val("0");
            txtItmRat.val("0");
            txtPreStk.val("0");
            txtIssueQty.val("0");
            txtissval.val("0");
            ErrMsg =(res.responseMsg);
            throw ErrMsg;
        }
        var objpitmasterprp= res.responseObject;
        txtitmCd.val(objpitmasterprp.itm_cd);
        DropDownList2.val(objpitmasterprp.itm_cd);
        txtUOM.val(objpitmasterprp.uom);
        txtItmRat.val(objpitmasterprp.rate);
        txtPreStk.val(objpitmasterprp.stk_qty);
        txtIssueQty.val(0); //  txtIssQty.Text.Trim
        var tot = parseFloat(txtIssueQty.val()) * parseFloat(txtItmRat.val());
        txtissval.val(tot.toFixed(2));   
        $("[id*=mivEntryDetail]").find("input,button,textarea,select").removeClass('tabcolor');
    } 
    catch (err)
    {
        $("[id*=lblMessage]").text(err).css('color', '#ff0000'); // Red color
        toastr.error(err, {timeOut: 200});
         $(".loader").fadeOut();  
    }
    finally
    {
          $(".loader").fadeOut();  
    }
}



////////////////////End Control Events/////////////////////////////////


///////////Grid Column Click Events///////////
async function txtReqQty_IndexChanged(ctl)
{
	//var usercd= await  getSessionVariables();
    var usercd= $("#hdfUserName").val();
	if (usercd.length ==0)
	{
		$("[id*=lblMessage]").text("Session Expired").css('color', '#ff0000'); // Red color
		toastr.error("Session Expired", {timeOut: 200});
		setTimeout(window.location.href = "/Login/Login", 10000);
		return;
	}
	if(usercd.length > 0)
	{
        var ErrMsg=null;
        try 
        {
            var row=$(ctl).closest("tr");
            var cols= row.find('td');
            var rowIndex =row[0].sectionRowIndex; 
            var txtReqQty =$(ctl);
            var txtIssQty=  cols.find("input[type='text'][id$=txtIssQty]");
            var lblPreStk =$(cols[4]);
            var txtIssval = $(cols[8]);
            var txtItmRat = $(cols[7]);
            if (parseFloat(txtReqQty.val()) > parseFloat(lblPreStk.text())) 
            {
                ErrMsg ="Req. Qty can't be greater than Stock Qty";
                lblPreStk.addClass('tabcolor');
                throw ErrMsg;
            } 
            txtIssQty.val(txtReqQty.val());
            var tot =parseFloat(txtIssQty.val()) * parseFloat(txtItmRat.text());
            txtIssval.text(tot.toFixed(2));
        } 
        catch (err) 
        {
            $("[id*=lblMessage]").text(err).css('color', '#ff0000'); // Red color;
            toastr.error(err, {timeOut: 200});
        }	
	}       
}



 async function DisplayMINDetail(ctl)
 {
 	//var usercd= await  getSessionVariables();
    var usercd= $("#hdfUserName").val();
	if (usercd.length ==0)
	{
		$("[id*=lblMessage]").text("Session Expired").css('color', '#ff0000'); // Red color
		toastr.error("Session Expired", {timeOut: 200});
		setTimeout(window.location.href = "/Login/Login", 10000);
		return;
	}
	if(usercd.length > 0)
    {
        var chkval=0; var varIssQty=0;  var varMinQty=0; var varRemQty=0 //  As Decimal
        var  varMinDat ; var varOrdNo=0; var varMinNo=0; var ErrMsg=null;  //  As String
        try 
        {
            $(".loader").fadeIn();
            var row=$(ctl).closest("tr");  
            var P= $(ctl).closest("tr")[0].sectionRowIndex; 
            var rowIndex = P;
            var R = ctl.selectedIndex;
            var cols= row.find('td');
            var itmcd= cols[1].textContent;
            var MinNo= ctl.value;

            var res = await getMINDetail(1, itmcd)
                if (res.response ==-1) {
                    alert(res.responseMsg);
                }
                var objprpdtl= res.responseObjectList;

                varIssQty = 0
                varMinQty = 0
                varRemQty = 0
                varAllQty = 0
                var issqtyctrl =cols.find("input[type='text'][id$=txtIssQty]");
                if (issqtyctrl.val()=="0") {
                    varRemQty= parseFloat(cols[17].textContent);  //Req Qty..
                }
                else {
                    varRemQty=parseFloat(issqtyctrl.val());
                }

                for (var e=0; e < objprpdtl.length; e++)
                {
                    var dtl =  objprpdtl[e];
                    if (dtl["itm_cd"].toString() == itmcd.toString() &&  dtl["min_no"].toString() == ctl.value) 
                    {
                        varMinNo =  parseFloat(dtl["min_no"].toString()); 
                        varMinDat =  ctl.options[ctl.selectedIndex].text.split(":")[2]; 
                        varMinQty = parseFloat(dtl["min_qty"].toString()); 
                        varOrdNo =  parseFloat(dtl["OrdNo"].toString());  
                        break;          
                    }
            
                }

                if (varRemQty > varMinQty) 
                {
                    cols[17].textContent =varRemQty;   // RemQty
                    cols[16].textContent =varMinQty;   //MinQty
        //            cols[14].textContent =varMinNo;   //MinNo
                    cols.find("[id*=drpMIN] option:Selected").val(varMinNo); 
                    cols[15].textContent =varMinDat;   //MINDate
                    cols[18].textContent =varOrdNo;   //OrdNo
                    varRemQty = varRemQty - varMinQty;
                }
                else 
                {
                    chkval= varRemQty;
                    cols[17].textContent =varRemQty;   // RemQty
                    cols[16].textContent =varRemQty;   //MinQty
                    // cols[14].textContent =varMinNo;   //MinNo
                    cols.find("[id*=drpMIN] option:Selected").val(varMinNo);   //MinNo
                    cols[15].textContent =varMinDat;   //MINDate
                    cols[18].textContent =varOrdNo;   //OrdNo
                    varRemQty = varRemQty - chkval;
                }

                var i = 0;
                var t = document.getElementById('MIVTable');

                // Iterate MivTable 
                if($("#MIVTable > tbody > tr").length >0)
                {
                    $("#MIVTable > tbody > tr").each(function(index, tr)  
                    {
                        if ((P != index) &&  (cols[1].textContent == $(tr.cells[1]).text()) && (ctl.options[ctl.selectedIndex].text == $(tr).find("[id*=drpMIN] option:Selected").text()) && (issqtyctrl.val() == $(tr).find("input[id*=txtIssQty]").val()))
                        {
                            ctl.value=0
                            ErrMsg="One MIN No can't be selected again"
                            $(cols[16]).text("");
                            throw ErrMsg;
                        }
                        i++;
                    });
                }


                if (varRemQty >0) 
                {
                    // To save existing row
                    var rIndex =0; var tot=0;var k=0; 
                    var dtable = [];   // table
                    var dr = {};  // table row 
                    var mytag =  (getQueryVariable("mytag")==false) ? 0 : parseInt(getQueryVariable("mytag").toString());
                    i=0;
                            // Iterate MivTable 
                    $("#MIVTable > tbody > tr").each(function(index, tr) 
                    {
                    k++;
                    dr = {}
                    if (mytag == 20) {
                        dr["itm_sno"] = k
                    }
                    else {
                        dr["itm_sno"] = k
                    }
                    dr["itm_cd"] =  $(tr.cells[1]).text().trim(); 
                    dr["itm_desc"] =    $(tr.cells[2]).text().trim(); 
                    dr["UOM"] =     $(tr.cells[3]).text().trim(); 
                    dr["pre_stk_Qty"] =     parseFloat($(tr.cells[4]).text()); 
                    dr["req_qty"] =     parseFloat($(tr).find("input[id*=txtReqQty]").val()); 
                    dr["iss_qty"] =     parseFloat($(tr).find("input[id*=txtIssQty]").val());  
                    dr["iss_rt"] = parseFloat($(tr.cells[7]).text()); 
                    dr["iss_val"] = parseFloat($(tr.cells[8]).text());  
                    dr["cons_cd"] = parseInt($(tr).find("[id*=drpConCen] option:Selected").val());  
                    dr["cc_cd"] =  parseFloat($(tr).find("[id*=drpCosCen] option:Selected").val());  
                    dr["RetTyp"] = $(tr.cells[11]).text().trim();   
                    dr["Reason"] =  $(tr.cells[12]).text().trim(); 
                    dr["Remark"] =  $(tr.cells[13]).text().trim();  
                    dr["min_no"] = parseInt( $(tr).find("[id*=drpMIN] option:Selected").val());  
                    dr["min_dt"] = $(tr.cells[15]).text();  
                    dr["min_qty"] = parseFloat( $(tr.cells[16]).text());  
                    dr["rem_qty"] = parseFloat( $(tr.cells[17]).text());  
                    dr["ordno"] =  parseFloat($(tr.cells[18]).text());  
                    tot += parseFloat(dr["iss_val"]);
                    dtable.push(dr);
                    i++;
                });
                dr = {};
                dr["itm_sno"] = dtable.length+1;
                dr["itm_cd"] = cols[1].textContent.trim();  
                dr["itm_desc"] =cols[2].textContent.trim();  
                dr["UOM"] = cols[3].textContent.trim();  
                dr["pre_stk_qty"] = (isEmpty(cols[4].textContent)) ? 0 : parseFloat(cols[4].textContent);   
                dr["req_qty"] = (isEmpty(cols.find("input[type='text'][id$=txtReqQty]").val())) ? 0 : parseFloat(cols.find("input[type='text'][id$=txtReqQty]").val());
                dr["iss_qty"] = 0;
                dr["iss_rt"] = (isEmpty(cols[7].textContent)) ? 0 : parseFloat(cols[7].textContent);
                dr["iss_val"] = 0;
                dr["cons_cd"] =  parseInt(cols.find("[id*=drpConCen] option:Selected").val());
                dr["Cc_cd"] = parseInt(cols.find("[id*=drpCosCen] option:Selected").val());
                dr["RetTyp"] = cols[7].textContent.trim();
                dr["Reason"] = cols[12].textContent.trim() ;  
                dr["Remark"] =  cols[13].textContent.trim() ;   
                dr["min_no"] = 0;
                dr["min_dt"] = "";
                dr["min_qty"] = 0;
                dr["rem_qty"] = varRemQty;
                dr["OrdNo"] = 0;
                dtable.push(dr);

                var prpMIVList=null;gridresult=null;
                if (usercd.toString().trim().toUpperCase() == "J16338") 
                {
                    prpMIVList= await getMINList(dtable);
                    populateGrid(prpMIVList).catch(function(reason) {ErrMsg = "Error while populate Grid" ;  throw ErrMsg;});
                }
                else if (usercd.toString().trim().toUpperCase() != "J16338") 
                {
                    prpMIVList= dtable;
                    populateGrid_OtherUsers(prpMIVList).catch(function(reason) {ErrMsg = "Error while populate Grid" ;  throw ErrMsg;});  
                }

                SetttingsAfterMINSelection();
                if ($("[id*=btnaction]").text() == "Authorize")
                {
                    hideShowColumn("nature",false );
                    hideShowColumn("rsn",false );
                    hideShowColumn("remark",false );
                    hideShowColumn("del",false );
                    MakeDataTable();
                }
            } 
            if (ErrMsg == null) 
            {
                $("[id*=lblMessage]").text("");
            } 
        } 
        catch (err) 
        {
            $("[id*=lblMessage]").text(err).css('color', '#ff0000'); // Red color
            toastr.error(err, {timeOut: 200});
            $(".loader").fadeOut(); 
        }
        finally
        {
            $(".loader").fadeOut(); 
        }    
    }
}


async function txtIssQty_IndexChanged(ctl)
{
    var ErrMsg=null;
    try 
    {
        var row=$(ctl).closest("tr");
        var cols= row.find('td');
        var rowIndex =row[0].sectionRowIndex; 
        var txtIssQty =$(ctl);
        var txtReqQty = cols.find("input[id*=txtReqQty]");
        var txtIssval = $(cols[8]);
        var txtItmRat = $(cols[7]);
        var tot=0;
        if (txtIssQty.val().trim().length == 0 ) 
        {
            $(ctl).addClass('tabcolor');   
            ErrMsg="Issue. Qty Can't be Blank";
            $(ctl).focus(); 
            throw ErrMsg;
        }
        else
        {
            if (parseFloat(txtIssQty.val()) <= 0) 
            {
 	           // var usercd= await  getSessionVariables();
                var usercd= $("#hdfUserName").val();
	            if (usercd.length ==0)
	            {
		            $("[id*=lblMessage]").text("Session Expired").css('color', '#ff0000'); // Red color
		            toastr.error("Session Expired", {timeOut: 200});
		            setTimeout(window.location.href = "/Login/Login", 10000);
		            return;
	            } 
                if (usercd.toString().trim().toUpperCase() != "J16338") 
                {
                    ErrMsg="Issue. Qty must be greater than zero";
                    $(ctl).addClass('tabcolor');   
                    $(ctl).focus(); 
                    throw ErrMsg;
                } 
                else
                {
                    tot =parseFloat(txtIssQty.val()) * parseFloat(txtItmRat.text());
                    txtIssval.text(tot.toFixed(2));                    
                }             
            }
            else if (parseFloat(txtIssQty.val()) > parseFloat(txtReqQty.val())) 
            {
                ErrMsg="Issue Qty can't be greater than Req. Qty.";
                $(ctl).addClass('tabcolor');   
                $(ctl).focus(); 
                throw ErrMsg;
            }
            else
            {
                tot =parseFloat(txtIssQty.val()) * parseFloat(txtItmRat.text());
                txtIssval.text(tot.toFixed(2));  
            }
        }
        $(ctl).removeClass('tabcolor'); 
        $("[id*=btnCheck]").show();   // visible true 
        $("[id*=btnCheck]").removeAttr("disabled");  //enable button
        $("[id*=btnaction]").hide();   // visible false 
        $("[id*=btncancel]").hide();  // visible false 
        if(ErrMsg ==null)
        {
            $("[id*=lblMessage]").text("");
        }
    } 
    catch (err) 
    {
        $("[id*=lblMessage]").text(err).css('color', '#ff0000'); // Red color
        toastr.error(err, {timeOut: 200});  
    }
}

async function txtReqQty_IndexChanged(ctl)
{
    var ErrMsg=null;
    try 
    {
        var row=$(ctl).closest("tr");
        var cols= row.find('td');
        var rowIndex =row[0].sectionRowIndex; 
        var txtIssQty = cols.find("input[id*=txtIssQty]");
        var txtReqQty = $(ctl); 
        var txtPreStk = $(cols[4]);
        var txtIssval = $(cols[8]);
        var txtItmRat = $(cols[7]);
        var sta =(getQueryVariable("sta")==false) ? 0 : parseInt(getQueryVariable("sta").toString()); 
        var tot=0;
        if (txtReqQty.val().trim().length == 0 ) 
        {
            $(ctl).addClass('tabcolor');   
            ErrMsg="Req. Qty Can't be Blank";
            $(ctl).focus(); 
            throw ErrMsg;
        }
        else
        {
            if (parseFloat(txtReqQty.val()) <= 0) 
            {
                if(parseFloat(txtReqQty.val()) <= 0)
                {
                    if(sta <1)
                    {
                        $(ctl).addClass('tabcolor');   
                        $(ctl).focus(); 
                        ErrMsg="Req. Qty must be greater than zero";
                        throw ErrMsg;
                    }
                    if(sta ==1)
                    {
                        tot =parseFloat(txtIssQty.val()) * parseFloat(txtItmRat.text());
                        txtIssval.text(tot.toFixed(2));                          
                    }
                } 
                else if(parseFloat(txtReqQty.val()) > parseFloat(txtPreStk.val()) )
                {
                    $(ctl).addClass('tabcolor');   
                    $(ctl).focus(); 
                    ErrMsg="Required Qty can't be greater than Pre Stock Qty.";
                    throw ErrMsg;                   
                }
                else
                {
                    tot =parseFloat(txtIssQty.val()) * parseFloat(txtItmRat.text());
                    txtIssval.text(tot.toFixed(2));                   
                }
			}
        }
        $(ctl).removeClass('tabcolor'); 
        $("[id*=btnCheck]").show();   // visible true 
        $("[id*=btnCheck]").removeAttr("disabled");  //enable button
        $("[id*=btnaction]").hide();   // visible false 
        $("[id*=btncancel]").hide();  // visible false 
        if(ErrMsg ==null)
        {
            $("[id*=lblMessage]").text("");
        }
    } 
    catch (err) 
    {
        $("[id*=lblMessage]").text(err).css('color', '#ff0000'); // Red color
        toastr.error(err, {timeOut: 200});  
    }
}


function drpConCenE_IndexChange(ctl)
{
    var ErrMsg=null;
    try 
    {
        var row=$(ctl).closest("tr");
        var cols= row.find('td');
        var rowIndex =row[0].sectionRowIndex; 
        var drpConCen = cols.find("[id*=drpConCen] option:Selected");
        if (drpConCen.val() == "0" ) 
        {
            $(ctl).addClass('tabcolor');  
            $(ctl).focus();  
            ErrMsg="Select Consumption Centre";
            throw ErrMsg;
        }
        $(ctl).removeClass('tabcolor'); 
        $("[id*=btnCheck]").show();   // visible true 
        $("[id*=btnCheck]").removeAttr("disabled");  //enable button
        $("[id*=btnaction]").hide();   // visible false 
        $("[id*=btncancel]").hide();  // visible false 
        if(ErrMsg ==null)
        {
            $("[id*=lblMessage]").text("");
        }
    } 
    catch (err) 
    {
        $("[id*=lblMessage]").text(err).css('color', '#ff0000'); // Red color
        toastr.error(err, {timeOut: 200});  
    }
}


function drpCosCenE_IndexChange(ctl)
{
    var ErrMsg=null;
    try 
    {
        var row=$(ctl).closest("tr");
        var cols= row.find('td');
        var rowIndex =row[0].sectionRowIndex; 
        var drpCosCen = cols.find("[id*=drpCosCen] option:Selected");
        if (drpCosCen.val() == "0" ) 
        {
            $(ctl).addClass('tabcolor');   
            $(ctl).focus(); 
            ErrMsg="Select Cost Centre";
            throw ErrMsg;
        }
        $(ctl).removeClass('tabcolor'); 
        $("[id*=btnCheck]").show();   // visible true 
        $("[id*=btnCheck]").removeAttr("disabled");  //enable button
        $("[id*=btnaction]").hide();   // visible false 
        $("[id*=btncancel]").hide();  // visible false 
        if(ErrMsg ==null)
        {
            $("[id*=lblMessage]").text("");
        }
    } 
    catch (err) 
    {
        $("[id*=lblMessage]").text(err).css('color', '#ff0000'); // Red color
        toastr.error(err, {timeOut: 200});  
    }

}

//////////////////End////////////////////////