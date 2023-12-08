 <!-- Navbar -->
  <nav class="main-header navbar navbar-expand navbar-white navbar-light">
    <!-- Left navbar links -->
    <ul class="navbar-nav">
        <li class="nav-item">
            <a class="nav-link" data-widget="pushmenu" href="#" role="button"><i class="fas fa-bars"></i></a>
        </li>
        <li class="nav-item d-none d-sm-inline-block">
            <a href="#" class="nav-link" style ="font-size: x-large;text-transform: uppercase;color: rgba(87, 21, 132, 0.87);font-weight: 800;">Online Material Issue Voucher</a>
        </li>
    </ul>
    <ul class="navbar-nav ml-auto">
        <li class="nav-item dropdown">            
            <a class="nav-link" data-toggle="dropdown" href="#">
                <span id="userName_Link"></span>          
            </a>
            <div class="dropdown-menu dropdown-menu-lg dropdown-menu-right">
              <a href="#" class ="dropdown-item">
                <!-- Message Start -->
               <div class="media">
                    <h3 class="drpdown-item-title"><a href="#" class="btn btn-primary" onclick ="ClickLogout();">Logout</a></h3>
                </div>
                <!-- Message End -->
              </a>
            </div>
        </li> 
    </ul> 
  </nav>
  <!-- /.navbar -->
  @Html.Partial("_Sidebar") 



