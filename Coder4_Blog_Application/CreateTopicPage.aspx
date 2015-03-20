<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateTopicPage.aspx.cs" Inherits="Coder4_Blog_Application.ViewPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    
    
       <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet"/>
    <link href='http://fonts.googleapis.com/css?family=Arvo|Lobster|Gloria+Hallelujah|Open+Sans|Raleway|Pacifico|Architects+Daughter|Courgette|Jura' rel='stylesheet' type='text/css'>
    <link href="Content/pageStyle1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class=" container">
    <!--Header + Navber-->
    <div class="row">
        <!--header-->
        <div class="col-xs-12 part4">
            <div class="row">
                <div class="col-xs-10">
                    CODER<b class="bfont">4</b> BLOG
                </div>
                <div class="col-xs-2">
                    <b class="bheader">POWER BY CODER4</b>
                </div>
            </div>
        </div>
        <!--Navber-->
        <div class="col-xs-12 nav1">

            <nav class="navbar navbar-inverse navChange2">
                <div class="container-fluid">
                    <!-- Brand and toggle get grouped for better mobile display -->
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="#">Filter articles by:</a>
                    </div>

                    <!-- Collect the nav links, forms, and other content for toggling -->
                    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1 ">
                        <ul class="nav navbar-nav">
                            <li><a href="ShowPage.aspx" class="hov123">Newest <span class="sr-only">(current)</span></a></li>
                            <li><a href="#" class="hov123">Popular</a></li>
                            <li><a href="CreateTopicPage.aspx" class="hov123">Compose</a></li>
                            <%--<li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Dropdown<span class="caret"></span></a>
                                <ul class="dropdown-menu" role="menu">
                                    <li><a href="#">Action</a></li>
                                    <li><a href="#">Another action</a></li>
                                    <li><a href="#">Something else here</a></li>
                                    <li class="divider"></li>
                                    <li><a href="#">Separated link</a></li>
                                    <li class="divider"></li>
                                    <li><a href="#">One more separated link</a></li>
                                </ul>
                            </li>--%>
                        </ul>
                        <%-- <form class="navbar-form navbar-right" role="search">
                            <div class="form-group">
                                <input type="text" class="form-control" placeholder="Search">
                            </div>
                            <button type="submit" class="btn btn-default">Submit</button>
                        </form>--%>

                    </div><!-- /.navbar-collapse -->
                </div><!-- /.container-fluid -->
            </nav>
        </div>


    </div>
    <!--body                 <textarea>Easy! You should check out MoxieManager!</textarea>                         -->
    <div class="row">
        <div class="col-xs-8 postTopic1">
            
               <p class="center-block"><b class="bfont3">Topic:</b>
               <asp:TextBox ID="TextBox1" runat="server" CssClass="butto"></asp:TextBox></p>
            
               
               <p><textarea id="TextArea1" cols="20" name="TextAreaName" rows="15" runat="server"></textarea></p> 
            
            
            <p> <asp:Button ID="Button3" runat="server" Text="Save post" CssClass="butto1 center-block" OnClick="Button3_Click" /></p>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
               </p>
           
        </div>
        <div class="col-xs-4 div2cus">
            <div class="list-group">
                <a href="#" class="list-group-item active ">
                    <b>Populer Post</b>
                </a>
                <a href="#" class="list-group-item">Dapibus ac facilisis in</a>
                <a href="#" class="list-group-item">Morbi leo risus</a>
                <a href="#" class="list-group-item">Porta ac consectetur ac</a>
                <a href="#" class="list-group-item">Vestibulum at eros</a>
                <a href="#" class="list-group-item">Vestibulum at eros</a>
            </div>
            <div class="list-group">
                <a href="#" class="list-group-item active">
                    <b>Recent Post</b>
                </a>
                <a href="#" class="list-group-item">Dapibus ac facilisis in</a>
                <a href="#" class="list-group-item">Morbi leo risus</a>
                <a href="#" class="list-group-item">Porta ac consectetur ac</a>
                <a href="#" class="list-group-item">Vestibulum at eros</a>
                <a href="#" class="list-group-item">Vestibulum at eros</a>
            </div>

        </div>
    </div>
    <!--FOOTER-->
    <div class="row">
        <div class="col-xs-12 col-lg-12 part3Footer">
            Follow Us In FaceBook 
        </div>
    </div>

</div>
    </form>
    
    



 <script src="Scripts/jquery-2.1.3.js"></script>
<script src="Scripts/bootstrap.js"></script>
   <script src="//tinymce.cachefly.net/4.1/tinymce.min.js"></script>
    
   <script>tinymce.init({ selector: 'textarea' });</script>

</body>
</html>
