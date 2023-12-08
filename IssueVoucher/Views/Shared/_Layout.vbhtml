@imports System.Web.Optimization

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>@ViewData("Title")</title>
   
  
    @Styles.Render("~/content/cssqueryUI")
    @Styles.Render("~/content/css")
    @Scripts.Render("~/bundles/modernizr")

</head>

<body class="hold-transition sidebar-mini layout-fixed" id="issueBody">
    <div class="wrapper">
        @Html.Partial("_Other")
        <div class="page">
            <div class="header">
                <div class="main">
                    <!-- Content Wrapper. Contains page content -->
                    <div class="content-wrapper">               
                        @Html.Partial("_Breadcrumb")
                        <!-- Main content -->
                        <section class="content">
                            <div class="container-fluid">
                                @Scripts.Render("~/bundles/jquery")
                                @Scripts.Render("~/bundles/jqueryval")
                                @Scripts.Render("~/script/adminLte")    
                                @Scripts.Render("~/script/common")   
                                @RenderBody()
                            </div><!-- /.container-fluid -->
                        </section>
                        <!-- /.content -->
                      </div>
                </div>
                <div class="clear"></div>           
            </div>
            @Html.Partial("_Footer")
            <div class="footer">

            </div>
        </div>

    </div> 
    @RenderSection("scripts", False)
    @RenderSection("styles", False)
                    
</body>
</html>
