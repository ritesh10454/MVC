@Code
    Layout = Nothing
End Code

@imports System.Web.Optimization


<!DOCTYPE html>

<html>
<head runat="server">
    <title>Login</title>
    @Styles.Render("~/content/cssqueryUI")
    @Styles.Render("~/content/css")
    @Scripts.Render("~/bundles/modernizr")
    @Styles.Render("~/content/nwlogin")
</head>
<body>
    <div class="row">
        <div class ="col-12">
            <h2 align="center" style="color: #FFFFFF;text-decoration: underline;padding-bottom: 10px;font-weight: 900;letter-spacing: 0.162em;line-height: 1;font-size: 2.5rem;">ONLINE MATERIAL ISSUE VOUCHER</h2>
        </div>

    </div>
    <div class ="row">
        <div class ="col-12">
            <span style="font-family: Verdana; font-size: x-large; text-align: left; height: 3%; color: #fff; font-weight: 700; border-bottom-style: solid; border-bottom-color: #fff;border-bottom-width: 1px;"></span>
        </div>
    </div>
    <div class ="row">
        <div class ="col-12">
        <asp:Label ID="lblSts" runat="server" Width="200px" Style="font-family: 'Century Gothic';font-size: small; font-weight: 700"></asp:Label>
        </div>
    </div>

    <div class ="row">
        <div class="col-8">
            <div class ="form-group">
                <p>
                    Issue Voucher System takes the fuss and time-consuming paperwork out of applying for, and
                    authorising, any type of Issue Voucher. It gives everyone in your company access to a fast,
                    efficient, online system, which they can use no matter where they are, so booking
                    and approving time off couldn’t be easier.</p>
                <p style="font-family: calibri; font-size: x-large; margin-left: 3%;">
                    <img src="../../Images/people.png" alt="IOLCP" style="height:55px;margin-right: 10px;" />Simple and Easy to use for Employees
                </p>   
            </div>
            <div class ="form-group">
                    <ul>
                        <li>Request for required Material in lieu quickly and easily online.</li>
                        <li>Find out who’s already booked time off for your Issuing Item.</li>
                        <li>Obtain confirmation of approved Voucher via email.</li>
                        <li>View the current status of your request and easily update or cancel issue 
                            vouchers.</li>
                        <li>Carry untaken days over to the following year (if part of your company policy.)</li>
                    </ul>        
            </div>
            <div class ="form-group">
                    <p style="font-family: calibri; font-size: x-large; margin-left: 3%;">
                        <img src="../../Images/people.png" alt="IOLCP"  style="height:55px;margin-right: 10px;" />Powerful Monitoring Tool for Managers.
                    </p>
                    <ul>
                        <li>Record and monitor all types of Vouchers,<span style="font-size:12.0pt;line-height:115%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;mso-ansi-language:EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">Whether </span>capital or consumable?</li>
                        <li>Keep accurate, up-to-date records of Voucher. Which is approved or cancelled?</li>
                        <li>Approve or reject Voucher requests at the click of a button.</li>
                        <li>Cut down on wasted time, effort and paperwork and eliminate admin errors.</li>
                        <li>Set a maximum number of days that can be carried Voucher in a Year , according
                            to your company policy.</li>
                        <li>Establish a single, consistent system for applying for Issue Voucher across your
                            company. </li>
                        <li>Instant update of Issue Voucher status Instant update of Issue Voucher&nbsp; application status to applicant
                            via e-mail or alternatively view from system.</li>
                    </ul>
                    <p style="font-family: calibri; font-size: x-large; margin-left: 3%;">
                        <img src="../../Images/people.png" alt="IOLCP" style="height:55px;margin-right: 10px;" >See for Yourself
                        <ul>
                            <li>Why not experience MaterialVoucher Master for yourself and see how effortless it makes the
                                process of managing and monitoring employee .</li>
                            <li>Instant update of Material Issue Voucher&nbsp; status</li>
                            <li>Instant update of Material Issue Voucher&nbsp; application status to applicant via e-mail or alternatively
                                view from system. </li>
                        </ul>
                        </p>                 
            </div>

        </div>
        <div class ="col-4">
            <div class="container">
                <div class="card card-container" style="padding-bottom: 16px;">            
                    <!-- <img class="profile-img-card" src="//lh3.googleusercontent.com/-6V8xOA6M7BA/AAAAAAAAAAI/AAAAAAAAAAA/rzlHcD0KYwo/photo.jpg?sz=120" alt="" /> -->
                    <img id="profile-img" alt ="" class="profile-img-card" src="../../Images/avatar_2x.png" />
                    <p id="profile-name" class="profile-name-card"></p>
                    <form class="form-signin" runat="server">
                        <span id="reauth-email" class="reauth-email"></span>
                        <input type="text" id="txtusrnam" class="form-control" placeholder="User Name" required autofocus tabindex ="0" />
                        <input type="password" id="txtusrpwd" class="form-control" placeholder="Password" required tabindex="1" />
                       <button type="button" id="btnSignIn" class="btn btn-lg btn-primary btn-block btn-signin" tabindex ="2" onclick="btnsignin_click();">Sign In</button>
                       <label id="lblMessage" style="color:Red;font-weight:bold;"></label>
                    </form><!-- /form -->
                </div><!-- /card-container -->
            </div><!-- /container -->    
         </div>

    </div>
    <div class ="row">
        <div class="col-12">
            <div class="form-group">
    <center style="font-family: calibri;  color: #fff;">
                            <strong>This site has visited
                                <asp:Label runat="server" ID="lblhitcou" Style="font-style: italic"></asp:Label>
                               times.</strong></center>
                        <marquee behavior="Alternate" scrolldelay="5" direction="right" scrollamount="2" onmouseover="this.stop();" onmouseout="this.start();" >
     <p style="font-weight: 400; font-family: verdana; ">  
        For More Details, please Contact IT Department at 1807,1808,1809.
    </p></marquee>                          
            </div>
        </div>
    </div>
    <div class ="row">
        <div class ="col-12">
    <div id="footer">
            <center style="padding: 0px; margin: 0px; color: #ffff; font-family: verdana; font-size: small;
                font-weight: bold;">
                <br />
                Copyright (C) Commercial 2012 IOLCP DHAULA, BARNALA. All rights reserved.
            </center>
        </div>
        </div>
    </div>
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/jqueryval")
    @Scripts.Render("~/script/adminLte")   
    @Scripts.Render("~/script/Login") 
</body>
</html>

