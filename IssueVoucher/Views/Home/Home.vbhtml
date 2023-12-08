@imports System.Web.Optimization
@Code
    ViewData("Title") = "Home"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code


@section styles
<style type="text/css" >
    .cardHeight
    {
        min-height: 320px;
		max-height: 420px;
    }
</style>
End Section



 
 <div class="row">
    <div class ="col-md-12">
        <div class="card card-primary">
            <div class="card-header">
                <h3 class="card-title">Company Profile</h3>
                <input type="hidden" id ="hdfUserName" value="@System.Web.HttpContext.Current.Session("usrnam")" />
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-12">
                    <p style="text-align: justify;color: #0000ff;">OL Chemicals and Pharmaceuticals Limited (IOLCP) is a leading organic chemicals manufacturer and supplier. We are Indian manufacturer of industrial chemicals & bulk drugs for over two decades. By pursuing & implementing the highest standards of excellence in our operations, we have nurtured our capabilities. By delivering consistent results have earned the admiration of customers and stakeholders alike.</p>
                    </div>
                </div> 
                <div class="row">
                    <div class="col-12">
                        <ul style="color: #0000ff;text-align: left; text-decoration: none; font-size: medium; font-weight: 500;">
                            <li>Innovative Strengths &amp; Strong Growth have made us the market leaders.</li>
                            <li>We have built up our expertise responding to diverse customer requirements.</li>
                            <li>Our products cater to the key industrial sectors of Textiles, Pharmaceutical &amp; Packaging.</li>
                            <li>Efficient teamwork &amp; strong associations have guided us to success.</li>
                            <li>Accolades for our environmental policies have come from the highest levels of power.</li>
                        </ul>
                    </div>
                </div> 
                <div class ="row">
                    <div class ="col-12">
                        <p style="color: #0000ff; text-decoration: none; font-size: medium; font-weight: 500; text-align:justify;">Through an unwavering focus on Quality, Commitment &amp; Delivery, we have charted our way to success in our operations and have won the admiration of our customers. Our success is built on the strong pillars of innovation, quality, &amp; dedicated customer service. By incorporating these &amp; other business strengths, we have boosted our capabilities to maintain the leading edge in the industry &amp; earn the loyalty of our customers.</p>
                    </div>
                </div>
            </div> 
        </div>
      </div> 
</div>
<div class="row">
    <div class="col-md-3">
        <div class="card card-primary">
            <div class="card-header">
                <h3 class="card-title">Our Vision</h3>
            </div>
            <div class="card-body cardHeight">
                <div class="row">
                    <div class="col-12">
                    <p style="color: #0000ff; text-align:justify; text-decoration: none; font-size: medium; font-weight: 500; ">To be the most admired and valuable company in bulk chemicals, intermediate specialty chemicals and APIs globally.</p>
                    </div>
                </div> 
            </div> 
        </div>   
    </div>
    <div class="col-md-3">
        <div class="card card-primary">
            <div class="card-header">
                <h3 class="card-title">Our Mission</h3>
            </div>
            <div class="card-body cardHeight">
                <div class="row">
                    <div class="col-12">
                    <p style="color: #0000ff; text-align:justify; text-decoration: none; font-size: medium; font-weight: 500;">To provide qualitative products in bulk chemicals, intermediate specialty chemicals and APIs by constant innovation and breaking technological barriers with due regard to safety and environment.</p>
                    </div>
                </div> 
            </div> 
        </div>   
    </div>
    <div class="col-md-3">
        <div class="card card-primary">
            <div class="card-header">
                <h3 class="card-title">Our Core Values</h3>
            </div>
            <div class="card-body cardHeight">
                <div class="row">
                    <div class="col-12">
                    <p style="color: #0000ff; text-align:justify; text-decoration: none; font-size: medium; font-weight: 500; ">To provide qualitative products in bulk chemicals, intermediate specialty chemicals and APIs by constant innovation and breaking technological barriers with due regard to safety and environment.</p>
                    </div>
                </div> 
            </div> 
        </div>   
    </div>
    <div class="col-md-3">
        <div class="card card-primary">
            <div class="card-header">
                <h3 class="card-title">Quality Policy</h3>
            </div>
            <div class="card-body cardHeight">
                <div class="row">
                    <div class="col-12">
                    <p style="color: #0000ff; text-align:justify; text-decoration: none; font-size: medium; font-weight: 500; " class="style1">We at IOL Chemicals and Pharmaceuticals Ltd., are committed to supply good quality products, excelling laid down standards to delight our customers by continually upgrading our skill, technology, processes and complying to Good Manufacturing Practices and Quality Management Systems. </p>
                    </div>
                </div> 
            </div> 
        </div>   
    </div>
</div>

@Scripts.Render("~/script/home")




