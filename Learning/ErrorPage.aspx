<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="Learning.ErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Error Page</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.min.js" integrity="sha384-0pUGZvbkm6XF6gxjEnlmuGrJXVbNuzT9qBBavbLwCsOGabYfZo0T0to5eqruptLy" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>

    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>

      <link rel="icon" type="image/x-icon" href="Images/error.png"/>
        
    <style>
        .main{
            overflow:hidden;
        }
        .errordiv{
            width:50%;
            text-align:center;
        }   #cafeImg{
       width:500px;
   }
      @media screen and (max-width: 480px) {
          #cafeImg{
              margin-top:20px;
              width:300px;
          }
         
          .errordiv{
              width:100%;
              font-size:.8rem;
             
          }
        }
    </style>

    <script>
        function goback() {
            window.history.back();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid main vh-100 d-flex justify-content-center align-items-center flex-column">
            <div class="text d-flex justify-content-center align-items-center flex-column">
                     <h1>Oops :(</h1>
                <div class="errordiv m-lg-3 m-3">
                    
                        <asp:Label ID="errormsg" runat="server" style="letter-spacing:1px" CssClass="text-center " Text=""></asp:Label>
                        <%--<asp:Label ID="title" runat="server" style="letter-spacing:1px" CssClass="text-center " Text="We're sorry. The servers are currently not reachable. Please try again later.</br>or"></asp:Label>--%>
                </div>

                       <asp:Button ID="goBack" runat="server" Text="Go To Back" CssClass="btn btn-rounded btn-dark btn-sm px-5 my-2" OnClientClick="goback()"/>
              
            </div>
           
            <div>
                <asp:Image ID="cafeImg" runat="server" ImageUrl="~/Images/error.gif" />
              
            </div>
        </div>
    </form>
</body>
</html>
