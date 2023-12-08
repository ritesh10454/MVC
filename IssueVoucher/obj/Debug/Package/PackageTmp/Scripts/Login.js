var $ = jQuery.noConflict();
    $(document).ready(function () {
    Login_Load();
});

$(document).bind('keypress', function(e) {
    if(e.keyCode==13){
            $('#btnSignIn').trigger('click');
        }
});


async function Login_Load() 
{
    var lblMessage = $("[id*=lblMessage]");
    var txtusrnam = $("input[id*=txtusrnam]");
    var txtusrpwd = $("input[id*=txtusrpwd]");
    var lblhitcou = $("[id*=lblhitcou]");
    var ErrMsg = null;
    try {
//        txtusrnam.focus();
        var res= await getHIT_Counter();
        if (res.response == -1) 
        {
            ErrMsg = res.responseMsg;
            throw ErrMsg;   
        }
        var counter =res.responseObject;
        lblhitcou.text(counter.hit_cou);
        var res1 =await save_LV_Emp_Detail(counter);
        if (res1.response == -1) 
        {
            ErrMsg = res1.responseMsg;
            throw ErrMsg;   
        }
        if(ErrMsg== null)
        {
            lblMessage.text("");
        }
    } 
    catch (err) 
    {
        lblMessage.text(err).css('color', '#ff0000'); // Red color
    }
}


async function btnsignin_click() 
{
//    var lblSts = $("[id*=lblSts]");
    var lblMessage = $("[id*=lblMessage]");
    var txtusrnam = $("input[id*=txtusrnam]");
    var txtusrpwd = $("input[id*=txtusrpwd]");
    var ErrMsg = null;
    try 
    {
        if (txtusrnam.val().length == 0) {
            ErrMsg = "Please Enter User Name";
            txtusrnam.focus();
            throw ErrMsg;
        }
        else if (txtusrpwd.val().length == 0) {
            ErrMsg = "Please Enter Password";
            txtusrpwd.focus();
        }
        var res = await Check_Login(txtusrnam.val().toUpperCase(),txtusrpwd.val())
        if(res.response == -1)
        {
            ErrMsg=res.responseMsg;
            throw ErrMsg;
        }
        if(res.response ==1)
        {
            sessionStorage.setItem("usrnam", txtusrnam.val().trim().toUpperCase());
            setTimeout(window.location.href = "/Home/Home", 10000);
        }
        else if(res.response != -1 && res.response !=1)
        {
            ErrMsg=res.responseMsg;
            throw ErrMsg;            
        }


        if(ErrMsg== null)
        {
            lblMessage.text("");
        }
    }
    catch (err) 
    {
        lblMessage.text(err).css('color', '#ff0000'); // Red color
    }
}



//async function SetMenu() {
//    var adminMenu = $("#mnu_Admin");
//    var mainMenu = $("#mnu_Main");
//    var actionMenu = $("#mnu_Action");
//    var reportMenu = $("#mnu_Report");
//    var usercd= await  getSessionVariables();
//    if (usercd.length ==0)
//    {
//        $("[id*=lblMessage]").text("Session Expired").css('color', '#ff0000'); // Red color
//        toastr.error("Session Expired", {timeOut: 200});
//        setTimeout(window.location.href = "/Login/Login", 10000);
//        return;
//    }
//    if(usercd.length > 0)
//    {
//        if(usercd.toUpperCase() != "H21083") 
//        {
//            adminMenu.hide();
//        }
//    }
//}


function getHIT_Counter() {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Login/getHIT_Counter",
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

function save_LV_Emp_Detail(com) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Login/save_LV_Emp_Detail",
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


function Check_Login(usernm,pwd) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Login/Check_Login",
            data: "{'usernm' : '" + usernm + "', 'pwd' : '" + pwd + "' }",
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

function getSessionVariables() {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Home/getSessionVariables",
            data: "{}",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                var myData = mData;
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




