var datatable;
var $ = jQuery.noConflict();

$(function () {
    ChangeBreadCrumb("Action", "Inbox", "Action");
      $("#issueBody").addClass("sidebar-collapse");
    BindGrid();
});


function populateGrid(myData)
{
    return new Promise(function(resolve,reject){
    $(document).ready(function() {
        var table = $('#InboxTable').DataTable(
        {
            "JQueryUI" : false,
            "paging": false,
            "processing": true,
            "deferRender" : true,
            "destroy": true,  
		    "language": 
            {
			    "emptyTable": "No Data Found"
		    },
            "data": myData,
            "columns":
            [
                { 'data': 'Miv_No'},
                { 'data': 'Miv_dt', 'render': function (newDt) {return (ChangeDateFormat(newDt));} },
                { 'data': 'inv_typ' },
                { 'data': 'Emp_Cd' },
                { "data": "emp_nm" },
                { "data": "dept_nm" },
                { "data": "apr_sta" },
                { "data": "aut_sta" },
                {
                    "data": null,
                    "defaultContent": '<input type="button" id="btnSelect" class="btn btn-primary gridButton" value="Select" />'
                }
            ],
            "fixedColumns": {
                "leftColumns": "2"
            },
           // "scrollY": "400",
            "scrollX": "true",
            'order':[],
            'columnDefs': [{
                "targets": 0,
                "orderable": false
            }]
        });

        $(".dataTables_length").hide();   
        $(".dataTables_filter").hide();  
        $(".pagination").hide();
         setTimeout(function(){$.fn.dataTable.tables( { visible: false, api: true } ).columns.adjust().fixedColumns().relayout();}, 500);


        $('#InboxTable').on('click', 'tbody tr #btnSelect', function () {
            var mytag = 20;
            var arr = $('#InboxTable').dataTable().fnGetData($(this).parents('tr'));
            var lblmivno = arr["Miv_No"];
            var lblmivdt = arr["Miv_dt"];
            var lblsta = arr["Sta"].toString();
            var lblempcd = arr["Emp_Cd"].toString();
            var lblinvtyp = arr["inv_typ"].toString();
            var strUrl = String.format('/Main/MIVEntry?mivno={0}&mivdt={1}&sta={2}&mytag={3}&empcd={4}&invtyp={5}', lblmivno, ChangeDateFormat(lblmivdt.toString()), lblsta, mytag, lblempcd, lblinvtyp);
            setTimeout(window.location.href = strUrl, 10000);
        });  
        resolve("OK");
    });
    });
}

function getInboxData(usercd) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Action/getInboxData",
            data: "{'par' : 4,'emp_cd' :  '" + usercd + "'}",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 500,
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




async function BindGrid() {
    var ErrMsg=null;
    $("#loader").fadeIn();
    var lblMessage = $("[id*=lblMessage]");
    try 
    {
        var usercd= $("#hdfUserName").val();
        if (usercd.length ==0)
        {
            $("[id*=lblMessage]");("Session Expired").css('color', '#ff0000'); // Red color
            toastr.error("Session Expired", {timeOut: 200});
            setTimeout(window.location.href = "/Login/Login", 10000);
            return;
        }
        if(usercd.length > 0)
        {
            var res= await getInboxData(usercd.toString().trim());
            if (res.response ==-1) 
            {
                ShowEmptyTable();
                ErrMsg= res.responseMsg;
                throw ErrMsg;
            }
            var myData = res.responseObjectList;
            populateGrid(myData).catch(function(reason) {ErrMsg="An Error found during populate the Grid";  throw ErrMsg;});
        }
        $("#loader").fadeOut();
        if(ErrMsg ==null)
        {
            lblMessage.text("");
        }
    
    } 
    catch (err) 
    {
        lblMessage.text(err).css('color', '#ff0000'); // Red color
        // Hide image container
        $("#loader").fadeOut();
    }
    finally
    {
//          Hide image container
        $("#loader").fadeOut();   
    }
}



function ShowEmptyTable()
{
    $('#InboxTable').removeAttr("width").DataTable({
	    "processing": true,
	    "language": 
        {
		    "emptyTable": "No Data Found"
	    },
    });
	$(".dataTables_length").hide();       //  -----Hide Show Number of Entry 
	$(".dataTables_filter").hide();   //--HIde Search label and textbox         });
}



