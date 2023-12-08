Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Optimization

Public Class BundleConfig
    Public Shared Sub RegisterBundle(ByVal bundles As BundleCollection)
        'bundles.Add(New StyleBundle("~/content/cssqueryUI").Include("~/Content/themes/base/jquery-ui.css"))
        'bundles.Add(New StyleBundle("~/content/css").Include("~/AdminLte/plugins/fontawesome-free/css/all.min.css", "~/Styles/googlefont.css", "~/Content/ionicons.min.css", "~/AdminLte/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css", "~/AdminLte/plugins/icheck-bootstrap/icheck-bootstrap.min.css", "~/AdminLte/plugins/jqvmap/jqvmap.min.css", "~/AdminLte/plugins/overlayScrollbars/css/OverlayScrollbars.min.css", "~/AdminLte/plugins/summernote/summernote-bs4.min.css", "~/AdminLte/plugins/datatables-fixedcolumns/css/fixedColumns.bootstrap4.min.css", "~/AdminLte/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css", "~/AdminLte/dist/css/adminlte.min.css", "~/Content/themes/base/jquery.ui.datepicker.css", "~/AdminLte/plugins/toastr/toastr.min.css"))
        'bundles.Add(New StyleBundle("~/content/login").Include("~/Content/nwlogn.css"))
        'bundles.Add(New ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js", "~/AdminLte/plugins/jquery/jquery.min.js", "~/AdminLte/plugins/jquery-ui/jquery-ui.min.js", "~/Scripts/JQuery/jquery.min.js", "~/Scripts/JQuery/jquery-ui.min.js"))
        'bundles.Add(New ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"))
        'bundles.Add(New ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr.*"))
        'bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include("~/AdminLte/plugins/bootstrap/js/bootstrap.bundle.min.js"))
        'bundles.Add(New ScriptBundle("~/bundles/jqueryui").Include("~/Scripts/jquery-ui.min.js"))
        ''bundles.Add(New ScriptBundle("~/scripts/ajax").Include("~/Scripts/jquery.unobtrusive-ajax.min.js"))
        'bundles.Add(New ScriptBundle("~/adminlte/js").Include("~/AdminLte/plugins/sparklines/sparkline.js", "~/AdminLte/plugins/jqvmap/jquery.vmap.min.js", "~/AdminLte/plugins/jquery-knob/jquery.knob.min.js", "~/AdminLte/plugins/moment/moment.min.js", "~/AdminLte/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js", "~/AdminLte/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js", "~/AdminLte/plugins/summernote/summernote-bs4.min.js", "~/AdminLte/plugins/datatables-fixedcolumns/js/dataTables.fixedColumns.min.js", "~/AdminLte/plugins/datatables-bs4/js/dataTables.bootstrap4.min.js", "~/AdminLte/plugins/datatables/jquery.dataTables.min.js", "~/AdminLte/dist/js/adminlte.min.js", "~/AdminLte/build/js/PushMenu.js", "~/AdminLte/build/js/Treeview.js", "~/AdminLte/build/js/Layout.js", "~/AdminLte/plugins/toastr/toastr.min.js"))

        '' bundles.Add(New ScriptBundle("~/script/extraQuery").Include("~/Scripts/JQuery/jquery.min.js", "~/Scripts/JQuery/jquery-ui.min.js"))


        bundles.Add(New StyleBundle("~/content/cssqueryUI").Include("~/Content/themes/base/jquery-ui.css"))
        bundles.Add(New StyleBundle("~/content/css").Include("~/AdminLte/plugins/fontawesome-free/css/all.min.css", "~/Styles/googlefont.css", "~/Content/ionicons.min.css", "~/AdminLte/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css", "~/AdminLte/plugins/icheck-bootstrap/icheck-bootstrap.min.css", "~/AdminLte/plugins/jqvmap/jqvmap.min.css", "~/AdminLte/plugins/overlayScrollbars/css/OverlayScrollbars.min.css", "~/AdminLte/plugins/summernote/summernote-bs4.min.css", "~/AdminLte/plugins/datatables-fixedcolumns/css/fixedColumns.bootstrap4.min.css", "~/AdminLte/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css", "~/AdminLte/dist/css/adminlte.min.css", "~/Content/themes/base/jquery.ui.datepicker.css", "~/AdminLte/plugins/toastr/toastr.min.css"))
        bundles.Add(New StyleBundle("~/content/nwlogin").Include("~/Content/nwlogn.css"))
        bundles.Add(New ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"))
        bundles.Add(New ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"))
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr.*"))

        bundles.Add(New ScriptBundle("~/script/adminLte").Include("~/AdminLte/plugins/jquery/jquery.min.js", "~/AdminLte/plugins/jquery-ui/jquery-ui.min.js", "~/AdminLte/plugins/bootstrap/js/bootstrap.bundle.min.js",
            "~/AdminLte/plugins/chart.js/Chart.min.js",
            "~/AdminLte/plugins/sparklines/sparkline.js",
            "~/AdminLte/plugins/jqvmap/jquery.vmap.min.js",
            "~/AdminLte/plugins/jqvmap/maps/jquery.vmap.usa.js",
            "~/AdminLte/plugins/jquery-knob/jquery.knob.min.js",
            "~/AdminLte/plugins/daterangepicker/daterangepicker.js",
            "~/AdminLte/plugins/summernote/summernote-bs4.min.js",
            "~/AdminLte/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js",
            "~/AdminLte/plugins/datatables/jquery.dataTables.min.js",
            "~/AdminLte/plugins/datatables-bs4/js/dataTables.bootstrap4.min.js",
            "~/AdminLte/plugins/datatables-responsive/js/dataTables.responsive.min.js",
            "~/AdminLte/plugins/datatables-responsive/js/responsive.bootstrap4.min.js",
            "~/AdminLte/plugins/datatables-buttons/js/dataTables.buttons.min.js",
            "~/AdminLte/plugins/datatables-buttons/js/buttons.bootstrap4.min.js",
            "~/AdminLte/plugins/jszip/jszip.min.js",
            "~/AdminLte/plugins/pdfmake/pdfmake.min.js",
            "~/AdminLte/plugins/pdfmake/vfs_fonts.js",
            "~/AdminLte/plugins/datatables-buttons/js/buttons.html5.min.js",
            "~/AdminLte/plugins/datatables-buttons/js/buttons.print.min.js",
            "~/AdminLte/plugins/datatables-buttons/js/buttons.colVis.min.js",
            "~/AdminLte/plugins/datatables-fixedcolumns/js/dataTables.fixedColumns.min.js",
            "~/AdminLte/plugins/toastr/toastr.min.js",
            "~/AdminLte/dist/js/adminlte.js",
            "~/AdminLte/dist/js/demo.js",
            "~/AdminLte/build/js/PushMenu.js",
            "~/AdminLte/build/js/Treeview.js",
            "~/AdminLte/build/js/Layout.js"
        ))
        bundles.Add(New ScriptBundle("~/script/extraJQueryUI").Include("~/Scripts/JQuery/jquery-ui.min.js"))
        bundles.Add(New ScriptBundle("~/script/table2excel").Include("~/Scripts/jquery.table2excel.js"))
        bundles.Add(New ScriptBundle("~/script/common").Include("~/Scripts/commonfuntions.js"))
        bundles.Add(New ScriptBundle("~/script/Login").Include("~/Scripts/Login.js"))
        bundles.Add(New ScriptBundle("~/script/home").Include("~/Scripts/Home.js"))
        bundles.Add(New ScriptBundle("~/script/inbox").Include("~/Scripts/Inbox.js"))
        bundles.Add(New ScriptBundle("~/script/outbox").Include("~/Scripts/Outbox.js"))
        bundles.Add(New ScriptBundle("~/script/pendingdetails").Include("~/Scripts/PendingDetail.js"))
        bundles.Add(New ScriptBundle("~/script/ReportConsCos").Include("~/Scripts/ReportConsCos.js"))
        bundles.Add(New ScriptBundle("~/script/ReportMIVDetail").Include("~/Scripts/ReportMIVDetail.js"))
        bundles.Add(New ScriptBundle("~/script/MIVEntry").Include("~/Scripts/MIVEntry.js"))
        bundles.Add(New ScriptBundle("~/script/CHECKMIV").Include("~/Scripts/CHECKMIV.js"))
        bundles.Add(New ScriptBundle("~/script/Password").Include("~/Scripts/Password.js"))
        bundles.Add(New ScriptBundle("~/script/UserDetail").Include("~/Scripts/UserDetail.js"))
        bundles.Add(New ScriptBundle("~/script/NewIssueId").Include("~/Scripts/NewIssueId.js"))
    End Sub

End Class
